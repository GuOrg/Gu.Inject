namespace Gu.Inject.Tests
{
    using System;
    using Gu.Inject.Tests.Types;
    using NUnit.Framework;

    public partial class KernelTests
    {
        public class Throws
        {
            [TestCase(typeof(Circular1.A), "Circular1.A(\r\n  Circular1.B(\r\n    Circular1.A(... Circular dependency detected.\r\n")]
            [TestCase(typeof(Circular2.A), "Circular2.A(\r\n  Circular2.E(\r\n    Circular2.G(\r\n      Circular2.A(... Circular dependency detected.\r\n")]
            public void GetWhenCircular(Type type, string message)
            {
                using var kernel = new Kernel();
                var exception = Assert.Throws<ResolveException>(() => kernel.Get(type));
                Assert.AreEqual(message, exception.Message);
            }

            [TestCase(typeof(IWith))]
            public void GetWhenNoBinding(Type type)
            {
                using var kernel = new Kernel();
                var exception = Assert.Throws<AmbiguousGenericBindingException>(() => kernel.Get(type));
                var expected = "Type IWith has binding to a generic type: With<>.\r\n" +
                               "Add a binding specifying what type argument to use.";
                Assert.AreEqual(expected, exception.Message);
            }

            [Test]
            public void GetWhenTwoCtors()
            {
                using (var kernel = new Kernel())
                {
                    var exception = Assert.Throws<ResolveException>(() => kernel.Get<Error.TwoCtors>());
                    var expected = "Type Error.TwoCtors has more than one constructor.\r\n" +
                                   "Add a binding specifying which constructor to use.";
                    Assert.AreEqual(expected, exception.Message);
                }

                Assert.Inconclusive("Provide setting specifying ctors. UsePrivate, UseMostParameters etc.");
            }

            [Test]
            public void GetWhenParamsCtor()
            {
                using var kernel = new Kernel();
                var exception = Assert.Throws<ResolveException>(() => kernel.Get<Error.ParamsCtor>());
                var expected = "Type Error.ParamsCtor has params argument which is not supported.\r\n" +
                               "Add a binding specifying which how to create an instance.";
                Assert.AreEqual(expected, exception.Message);
            }

            [TestCase(typeof(OneToMany.Abstract), "Type OneToMany.Abstract has more than one binding: OneToMany.Concrete1, OneToMany.Concrete2.")]
            [TestCase(typeof(OneToMany.IAbstract), "Type OneToMany.IAbstract has more than one binding: OneToMany.Concrete1, OneToMany.Concrete2.")]
            [TestCase(typeof(OneToMany.IConcrete), "Type OneToMany.IConcrete has more than one binding: OneToMany.Concrete1, OneToMany.Concrete2.")]
            public void GetWhenAmbiguous(Type type, string expected)
            {
                using var kernel = new Kernel();
                var exception = Assert.Throws<AmbiguousBindingException>(() => kernel.Get(type));
                Assert.AreEqual(expected, exception.Message);
            }

            [Test]
            public void GetWhenAmbiguousNonAbstract()
            {
                using (var kernel = new Kernel())
                {
                    var exception = Assert.Throws<AmbiguousBindingException>(() => kernel.Get<InheritNonAbstract.Foo>());
                    Assert.AreEqual("Type InheritNonAbstract.Foo has more than one binding: InheritNonAbstract.FooDerived.", exception.Message);
                }

                Assert.Inconclusive("Provide setting specifying ctors. RequireExplicit");
            }

            [Test]
            public void BindWhenHasResolved()
            {
                using var kernel = new Kernel();
                kernel.Get<DefaultCtor>();
                var exception = Assert.Throws<InvalidOperationException>(() => kernel.Bind<IWith, With<DefaultCtor>>());
                Assert.AreEqual("Bind not allowed after Get.", exception.Message);
            }

            [Test]
            public void BindTypeWhenHasBinding()
            {
                using var kernel = new Kernel();
                kernel.Bind<IWith, With<DefaultCtor>>();
                var exception = Assert.Throws<InvalidOperationException>(() => kernel.Bind<IWith, With<DefaultCtor>>());
                Assert.AreEqual("IWith already has a binding to With<DefaultCtor>", exception.Message);
            }

            [Test]
            public void BindTypeWhenHasInstanceBinding()
            {
                using var kernel = new Kernel();
                var instance = new With<DefaultCtor>(new DefaultCtor());
                kernel.Bind<IWith>(instance);
                var exception = Assert.Throws<InvalidOperationException>(() => kernel.Bind<IWith, With<DefaultCtor>>());
                Assert.AreEqual("IWith already has a binding to Gu.Inject.Tests.Types.With`1[Gu.Inject.Tests.Types.DefaultCtor]", exception.Message);
            }

            [Test]
            public void BindInstanceWhenHasTypeBinding()
            {
                using var kernel = new Kernel();
                kernel.Bind<IWith, With<DefaultCtor>>();
                var instance = new With<DefaultCtor>(new DefaultCtor());
                var exception = Assert.Throws<InvalidOperationException>(() => kernel.Bind<IWith>(instance));
                Assert.AreEqual("IWith already has a binding to With<DefaultCtor>", exception.Message);
            }
        }
    }
}