namespace Gu.Inject.Tests
{
    using System;
    using Gu.Inject.Tests.Types;
    using NUnit.Framework;

    public partial class KernelTests
    {
        public class Throws
        {
            [TestCase(typeof(IWith), "Type IWith has no binding.")]
            [TestCase(typeof(int), "Type int has no binding.")]
            [TestCase(typeof(int?), "Type Nullable<int> has no binding.")]
            [TestCase(typeof(int[]), "Type int[] has no binding.")]
            [TestCase(typeof(IWith<int>), "Type IWith<int> has no binding.")]
            [TestCase(typeof(IWith<int?>), "Type IWith<Nullable<int>> has no binding.")]
            [TestCase(typeof(IWith<IWith<int>>), "Type IWith<IWith<int>> has no binding.")]
            [TestCase(typeof(OneToMany.Abstract), "Type OneToMany.Abstract has no binding.")]
            [TestCase(typeof(OneToMany.IAbstract), "Type OneToMany.IAbstract has no binding.")]
            [TestCase(typeof(OneToMany.IConcrete), "Type OneToMany.IConcrete has no binding.")]
            public void GetWhenNoBinding(Type type, string expected)
            {
                using var kernel = new Kernel();
                var exception = Assert.Throws<NoBindingException>(() => kernel.Get(type));
                Assert.AreEqual(expected, exception.Message);
            }

            [Ignore("TEMP")]
            [TestCase(typeof(Circular1.A), "Circular1.A(\r\n  Circular1.B(\r\n    Circular1.A(... Circular dependency detected.\r\n")]
            [TestCase(typeof(Circular2.A), "Circular2.A(\r\n  Circular2.E(\r\n    Circular2.G(\r\n      Circular2.A(... Circular dependency detected.\r\n")]
            public void GetWhenCircular(Type type, string message)
            {
                using var kernel = new Kernel();
                var exception = Assert.Throws<ResolveException>(() => kernel.Get(type));
                Assert.AreEqual(message, exception.Message);
            }

            [Test]
            public void GetWhenTwoConstructors()
            {
                using var kernel = new Kernel();
                var exception = Assert.Throws<ResolveException>(() => kernel.Get<Error.TwoCtors>());
                var expected = "Type Error.TwoCtors has more than one constructor.\r\n" +
                               "Add a binding specifying which constructor to use.";
                Assert.AreEqual(expected, exception.Message);
            }

            [Test]
            public void GetWhenParamsCtor()
            {
                using var kernel = new Kernel();
                var exception = Assert.Throws<ResolveException>(() => kernel.Get<Error.ParamsCtor>());
                var expected = "Type Error.ParamsCtor has params parameter which is not supported.\r\n" +
                                     "Add a binding specifying how to create an instance.";
                Assert.AreEqual(expected, exception.Message);
            }

            [Test]
            public void BindWhenHasResolved()
            {
                using var kernel = new Kernel();
                _ = kernel.Get<DefaultCtor>();
                var exception = Assert.Throws<InvalidOperationException>(() => kernel.Bind<IWith, With<DefaultCtor>>());
                Assert.AreEqual("Bind not allowed after resolving. This could create hard to track down graph bugs.", exception.Message);
            }

            [Test]
            public void BindBindingToSame()
            {
                using var kernel = new Kernel();
                var exception = Assert.Throws<InvalidOperationException>(() => kernel.Bind<DefaultCtor, DefaultCtor>());
                Assert.AreEqual("Trying to bind to the same type.", exception.Message);
            }

            [Test]
            public void BindTypeWhenHasBinding()
            {
                using var kernel = new Kernel();
                kernel.Bind<IWith, With<DefaultCtor>>();
                var exception = Assert.Throws<InvalidOperationException>(() => kernel.Bind<IWith, With<DefaultCtor>>());
                Assert.AreEqual("IWith already has a binding. It is mapped to the type With<DefaultCtor>", exception.Message);
            }

            [Test]
            public void BindTypeWhenHasInstanceBinding()
            {
                using var kernel = new Kernel();
                var instance = new With<DefaultCtor>(new DefaultCtor());
                kernel.Bind<IWith>(instance);
                var exception = Assert.Throws<InvalidOperationException>(() => kernel.Bind<IWith, With<DefaultCtor>>());
                Assert.AreEqual("IWith already has a binding. It is bound to the instance Gu.Inject.Tests.Types.With`1[Gu.Inject.Tests.Types.DefaultCtor]", exception.Message);
            }

            [Test]
            public void BindInstanceWhenHasTypeBinding()
            {
                using var kernel = new Kernel();
                kernel.Bind<IWith, With<DefaultCtor>>();
                var instance = new With<DefaultCtor>(new DefaultCtor());
                var exception = Assert.Throws<InvalidOperationException>(() => kernel.Bind<IWith>(instance));
                Assert.AreEqual("IWith already has a binding. It is mapped to the type With<DefaultCtor>", exception.Message);
            }
        }
    }
}