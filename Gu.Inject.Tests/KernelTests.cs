namespace Gu.Inject.Tests
{
    using System;
    using Gu.Inject.Tests.Types;
    using NUnit.Framework;

    public partial class KernelTests
    {
        [TestCase(typeof(DefaultCtor), typeof(DefaultCtor))]
        [TestCase(typeof(IDefaultCtor), typeof(DefaultCtor))]
        [TestCase(typeof(With<DefaultCtor>), typeof(With<DefaultCtor>))]
        [TestCase(typeof(IWith<DefaultCtor>), typeof(With<DefaultCtor>))]
        [TestCase(typeof(WithTwo<DefaultCtor, DefaultCtor>), typeof(WithTwo<DefaultCtor, DefaultCtor>))]
        [TestCase(typeof(WithTwo<DefaultCtor, With<DefaultCtor>>), typeof(WithTwo<DefaultCtor, With<DefaultCtor>>))]
        [TestCase(typeof(OneToOne.Concrete), typeof(OneToOne.Concrete))]
        [TestCase(typeof(OneToOne.Abstract), typeof(OneToOne.Concrete))]
        [TestCase(typeof(OneToOne.IAbstract), typeof(OneToOne.Concrete))]
        [TestCase(typeof(OneToOne.IConcrete), typeof(OneToOne.Concrete))]
        [TestCase(typeof(OneToOneGeneric.Generic<DefaultCtor>), typeof(OneToOneGeneric.Generic<DefaultCtor>))]
        [TestCase(typeof(OneToOneGeneric.GenericOfDefaultCtor), typeof(OneToOneGeneric.GenericOfDefaultCtor))]
        public void Get(Type type, Type expected)
        {
            using (var kernel = new Kernel())
            {
                var actual = kernel.Get(type);
                Assert.AreEqual(expected, actual.GetType());
                Assert.AreSame(actual, kernel.Get(expected));
            }
        }

        [Test]
        public void InjectsSingletons()
        {
            using (var kernel = new Kernel())
            {
                var actual = kernel.Get<WithTwo<DefaultCtor, DefaultCtor>>();
                Assert.AreSame(actual.Value1, actual.Value2);
            }
        }

        [TestCase(typeof(Circular1.A), "Circular dependency detected A -> B -> A")]
        [TestCase(typeof(Circular2.A), "Circular dependency detected A -> E -> G -> A")]
        public void Loop(Type type, string message)
        {
            using (var kernel = new Kernel())
            {
                var exception = Assert.Throws<InvalidOperationException>(() => kernel.Get(type));
                Assert.AreEqual(message, exception.Message);
            }
        }

        [TestCase(typeof(IWith))]
        public void ThrowsWhenNoBinding(Type type)
        {
            using (var kernel = new Kernel())
            {
                var exception = Assert.Throws<InvalidOperationException>(() => kernel.Get(type));
                var expected = "Type IWith has binding to a generic type: With<>.\r\n" +
                               "Add a bining specifying what type argument to use.";
                Assert.AreEqual(expected, exception.Message);
            }
        }

        [TestCase(typeof(OneToMany.Abstract), "Type Abstract has more than one binding: Concrete1, Concrete2.")]
        [TestCase(typeof(OneToMany.IAbstract), "Type IAbstract has more than one binding: Concrete1, Concrete2.")]
        [TestCase(typeof(OneToMany.IConcrete), "Type IConcrete has more than one binding: Concrete1, Concrete2.")]
        public void ThrowsWhenAmbiguous(Type type, string expected)
        {
            using (var kernel = new Kernel())
            {
                var exception = Assert.Throws<InvalidOperationException>(() => kernel.Get(type));
                Assert.AreEqual(expected, exception.Message);
            }
        }

        [Test]
        public void DisposesCreated()
        {
            Disposable actual;
            using (var kernel = new Kernel())
            {
                actual = kernel.Get<Disposable>();
                Assert.AreEqual(0, actual.Disposed);
            }

            Assert.AreEqual(1, actual.Disposed);
        }
    }
}
