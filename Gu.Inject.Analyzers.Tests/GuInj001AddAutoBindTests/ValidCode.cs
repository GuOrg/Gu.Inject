namespace Gu.Inject.Analyzers.Tests.GuInj001AddAutoBindTests
{
    using Gu.Inject.Analyzers.NodeAnalyzers;
    using Gu.Roslyn.Asserts;
    using Microsoft.CodeAnalysis.Diagnostics;
    using NUnit.Framework;

    public static class ValidCode
    {
        private static readonly DiagnosticAnalyzer Analyzer = new ObjectCreationAnalyzer();

        [Test]
        public static void WhenNotKernel()
        {
            var testCode = @"
namespace RoslynSandbox
{
    using System.Text;

    public class C
    {
        public C()
        {
            var x = new StringBuilder();
        }
    }
}";
            AnalyzerAssert.Valid(Analyzer, testCode);
        }

        [Test]
        public static void WhenKernelAndCallingAutoBind()
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
            var x = new Kernel<C>().AutoBind();
        }
    }
}";
            AnalyzerAssert.Valid(Analyzer, autoBindCode, testCode);
        }

        [Test]
        public static void WhenKernelAndCallingBindAndAutoBind()
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
            var x = new Kernel<C>().Bind(() => new C()).AutoBind();
        }
    }
}";
            AnalyzerAssert.Valid(Analyzer, autoBindCode, testCode);
        }

        [Test]
        public static void WhenKernelOfObject()
        {
            var testCode = @"
namespace RoslynSandbox
{
    using Gu.Inject;

    public class C
    {
        public C()
        {
            var x = new Kernel<object>();
        }
    }
}";
            AnalyzerAssert.Valid(Analyzer, testCode);
        }
    }
}
