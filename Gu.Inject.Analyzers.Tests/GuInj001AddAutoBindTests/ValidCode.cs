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
        public static void WhenNotcontainer()
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
        public static void WhencontainerAndCallingAutoBind()
        {
            var autoBindCode = @"
namespace RoslynSandbox
{
    using Gu.Inject;

    public static class ContainerExtensions
    {
        public static Container<C> AutoBind(this Container<C> container)
        { 
            container.Bind(() => new C());
            return container;
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
            var x = new Container<C>().AutoBind();
        }
    }
}";
            AnalyzerAssert.Valid(Analyzer, autoBindCode, testCode);
        }

        [Test]
        public static void WhencontainerAndCallingBindAndAutoBind()
        {
            var autoBindCode = @"
namespace RoslynSandbox
{
    using Gu.Inject;

    public static class ContainerExtensions
    {
        public static Container<C> AutoBind(this Container<C> container)
        { 
            container.Bind(() => new C());
            return container;
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
            var x = new Container<C>().Bind(() => new C()).AutoBind();
        }
    }
}";
            AnalyzerAssert.Valid(Analyzer, autoBindCode, testCode);
        }

        [Test]
        public static void WhencontainerOfObject()
        {
            var testCode = @"
namespace RoslynSandbox
{
    using Gu.Inject;

    public class C
    {
        public C()
        {
            var x = new Container<object>();
        }
    }
}";
            AnalyzerAssert.Valid(Analyzer, testCode);
        }
    }
}
