namespace Gu.Inject.Analyzers.Tests.GuInj001MissingBindingTests
{
    using Gu.Inject.Analyzers.NodeAnalyzers;
    using Gu.Roslyn.Asserts;
    using Microsoft.CodeAnalysis.Diagnostics;
    using NUnit.Framework;

    public static class ValidCode
    {
        private static readonly DiagnosticAnalyzer Analyzer = new ObjectCreationAnalyzer();

        [Test]
        public static void WhenNotContainer()
        {
            var code = @"
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
            RoslynAssert.Valid(Analyzer, code);
        }

        [Test]
        public static void WhenChainedBind()
        {
            var code = @"
namespace RoslynSandbox
{
    using Gu.Inject;

    public class C
    {
        public C()
        {
            var container = new Container<C>()
                .Bind(() => new C());
        }
    }
}";
            RoslynAssert.Valid(Analyzer, code);
        }

        [Test]
        public static void WhenStatementBind()
        {
            var code = @"
namespace RoslynSandbox
{
    using Gu.Inject;

    public class C
    {
        public C()
        {
            var container = new Container<C>();
            container.Bind(() => new C());
        }
    }
}";
            RoslynAssert.Valid(Analyzer, code);
        }

        [Test]
        public static void WhenExtensionMethod()
        {
            var autoBindCode = @"
namespace RoslynSandbox
{
    using Gu.Inject;

    public static class ContainerExtensions
    {
        public static Container<C> BindC(this Container<C> container)
        { 
            container.Bind(() => new C());
            return container;
        }
    }
}";
            var code = @"
namespace RoslynSandbox
{
    using Gu.Inject;

    public class C
    {
        public C()
        {
            var x = new Container<C>().BindC();
        }
    }
}";
            RoslynAssert.Valid(Analyzer, autoBindCode, code);
        }

        [Test]
        public static void WhenExtensionMethodStaticInvocation()
        {
            var autoBindCode = @"
namespace RoslynSandbox
{
    using Gu.Inject;

    public static class ContainerExtensions
    {
        public static Container<C> BindC(this Container<C> container)
        { 
            container.Bind(() => new C());
            return container;
        }
    }
}";
            var code = @"
namespace RoslynSandbox
{
    using Gu.Inject;

    public class C
    {
        public C()
        {
            var x = ContainerExtensions.BindC(new Container<C>());
        }
    }
}";
            RoslynAssert.Valid(Analyzer, autoBindCode, code);
        }

        [Test]
        public static void WhenExtensionMethodChained()
        {
            var autoBindCode = @"
namespace RoslynSandbox
{
    using Gu.Inject;

    public static class ContainerExtensions
    {
        public static Container<C> BindC(this Container<C> container)
        { 
            return container.Bind(() => new C());
        }
    }
}";
            var code = @"
namespace RoslynSandbox
{
    using Gu.Inject;

    public class C
    {
        public C()
        {
            var x = new Container<C>().BindC();
        }
    }
}";
            RoslynAssert.Valid(Analyzer, autoBindCode, code);
        }

        [Test]
        public static void WhenContainerOfObject()
        {
            var code = @"
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
            RoslynAssert.Valid(Analyzer, code);
        }
    }
}
