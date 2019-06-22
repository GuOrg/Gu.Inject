namespace Gu.Inject.Analyzers.Tests.GuInj001AddAutoBindTests
{
    using Gu.Inject.Analyzers.NodeAnalyzers;
    using Gu.Roslyn.Asserts;
    using Microsoft.CodeAnalysis.Diagnostics;
    using NUnit.Framework;

    public static class CodeFix
    {
        private static readonly DiagnosticAnalyzer Analyzer = new ObjectCreationAnalyzer();
        //private static readonly CodeFixProvider Fix = new RenameMemberFix();
        private static readonly ExpectedDiagnostic ExpectedDiagnostic = ExpectedDiagnostic.Create(GuInj001AddAutoBind.Descriptor);

        [Test]
        public static void MessageWhenExtensionExists()
        {
            var autoBindCode = @"
namespace RoslynSandbox
{
    using Gu.Inject;

    public static class KernelExtensions
    {
        public static Kernel<C> AutoBind(this Kernel<C> kernel)
        { 
            kernel.Bind(() => new C());
            return kernel;
        }
    }
}";
            var testCode = @"
namespace RoslynSandbox
{
    using Gu.Inject;

    public class C
    {
        public C()
        {
            var x = ↓new Kernel<C>();
        }
    }
}";

            AnalyzerAssert.Diagnostics(Analyzer, ExpectedDiagnostic.WithMessage("Use AutoBind() to wire up bindings."), autoBindCode, testCode);
        }

        [Test]
        public static void WhenNoExtension()
        {
            var autoBindCode = @"
namespace RoslynSandbox
{
    using Gu.Inject;

    public static class KernelExtensions
    {
    }
}";

            var testCode = @"
namespace RoslynSandbox
{
    using Gu.Inject;

    public class C
    {
        public C()
        {
            var x = ↓new Kernel<C>();
        }
    }
}";

            AnalyzerAssert.Diagnostics(Analyzer, ExpectedDiagnostic, autoBindCode, testCode);
        }

        [Test]
        public static void WhenCallingBind()
        {
            var autoBindCode = @"
namespace RoslynSandbox
{
    using Gu.Inject;

    public static class KernelExtensions
    {
        public static Kernel<C> AutoBind(this Kernel<C> kernel)
        { 
            kernel.Bind(() => new C());
            return kernel;
        }
    }
}";

            var testCode = @"
namespace RoslynSandbox
{
    using Gu.Inject;

    public class C
    {
        public C()
        {
            var x = ↓new Kernel<C>().Bind(() => new C());
        }
    }
}";

            AnalyzerAssert.Diagnostics(Analyzer, ExpectedDiagnostic, autoBindCode, testCode);
        }
    }
}
