namespace Gu.Inject.Tests
{
    using System;
    using Gu.Inject.Tests.Types;
    using NUnit.Framework;

    public partial class ContainerTests
    {
        public class Throws
        {
            [TestCase(typeof(Circular1.A), "Circular1.A(\r\n  Circular1.B(\r\n    Circular1.A(... Circular dependency detected.\r\n")]
            [TestCase(typeof(Circular2.A), "Circular2.A(\r\n  Circular2.E(\r\n    Circular2.G(\r\n      Circular2.A(... Circular dependency detected.\r\n")]
            public void GetWhenCircular(Type type, string message)
            {
                Assert.Inconclusive("Fix later.");
                //using (var container = new Container<object>())
                //{
                //    var exception = Assert.Throws<ResolveException>(() => container.Get(type));
                //    Assert.AreEqual(message, exception.Message);
                //}
            }

            [TestCase(typeof(IWith))]
            public void GetWhenNoBinding(Type type)
            {
                Assert.Inconclusive("Fix later.");
                //using (var container = new Container<object>())
                //{
                //    var exception = Assert.Throws<AmbiguousGenericBindingException>(() => container.Get(type));
                //    var expected = "Type IWith has binding to a generic type: With<>.\r\n" +
                //                   "Add a binding specifying what type argument to use.";
                //    Assert.AreEqual(expected, exception.Message);
                //}
            }

            [Test]
            public void GetWhenTwoCtors()
            {
                Assert.Inconclusive("Fix later.");
                using (var container = new Container<object>())
                {
                    var exception = Assert.Throws<ResolveException>(() => container.Get<Error.TwoCtors>());
                    var expected = "Type Error.TwoCtors has more than one constructor.\r\n" +
                                   "Add a binding specifying which constructor to use.";
                    Assert.AreEqual(expected, exception.Message);
                }

                Assert.Inconclusive("Provide setting specifying ctors. UsePrivate, UseMostParameters etc.");
            }

            [Test]
            public void GetWhenParamsCtor()
            {
                Assert.Inconclusive("Fix later.");
                using (var container = new Container<object>())
                {
                    var exception = Assert.Throws<ResolveException>(() => container.Get<Error.ParamsCtor>());
                    var expected = "Type Error.ParamsCtor has params argument which is not supported.\r\n" +
                                   "Add a binding specifying which how to create an instance.";
                    Assert.AreEqual(expected, exception.Message);
                }
            }

            [TestCase(typeof(OneToMany.Abstract), "Type OneToMany.Abstract has more than one binding: OneToMany.Concrete1, OneToMany.Concrete2.")]
            [TestCase(typeof(OneToMany.IAbstract), "Type OneToMany.IAbstract has more than one binding: OneToMany.Concrete1, OneToMany.Concrete2.")]
            [TestCase(typeof(OneToMany.IConcrete), "Type OneToMany.IConcrete has more than one binding: OneToMany.Concrete1, OneToMany.Concrete2.")]
            public void GetWhenAmbiguous(Type type, string expected)
            {
                Assert.Inconclusive("Fix later.");
                //using (var container = new Container<object>())
                //{
                //    var exception = Assert.Throws<AmbiguousBindingException>(() => container.Get(type));
                //    Assert.AreEqual(expected, exception.Message);
                //}
            }

            [Test]
            public void GetWhenAmbiguousNonAbstract()
            {
                Assert.Inconclusive("Fix later.");
                using (var container = new Container<object>())
                {
                    var exception = Assert.Throws<AmbiguousBindingException>(() => container.Get<InheritNonAbstract.Foo>());
                    Assert.AreEqual("Type InheritNonAbstract.Foo has more than one binding: InheritNonAbstract.FooDerived.", exception.Message);
                }

                Assert.Inconclusive("Provide setting specifying ctors. RequireExplicit");
            }

            [Test]
            public void BindWhenHasResolved()
            {
                Assert.Inconclusive("Fix later.");
                using (var container = new Container<Foo>().AutoBind())
                {
                    _ = container.Get<Foo>();
                    var exception = Assert.Throws<InvalidOperationException>(() => container.Bind(() => default(Foo)));
                    Assert.AreEqual("Bind not allowed after Get.", exception.Message);
                    exception = Assert.Throws<InvalidOperationException>(() => container.Bind(_ => default(Foo)));
                    Assert.AreEqual("Bind not allowed after Get.", exception.Message);
                }
            }

            [Test]
            public void BindFuncWhenBound()
            {
                Assert.Inconclusive("Fix later.");
                using (var container = new Container<Foo>().AutoBind())
                {
                    container.Bind(() => default(Foo));
                    var expected = "Foo already has a binding to Foo";
                    var exception = Assert.Throws<InvalidOperationException>(() => container.Bind(() => default(Foo)));
                    Assert.AreEqual(expected, exception.Message);
                    exception = Assert.Throws<InvalidOperationException>(() => container.Bind(_ => default(Foo)));
                    Assert.AreEqual(expected, exception.Message);
                }
            }

            [Test]
            public void BindGetterWhenBound()
            {
                Assert.Inconclusive("Fix later.");
                using (var container = new Container<Foo>().AutoBind())
                {
                    container.Bind(_ => default(Foo));
                    var expected = "Foo already has a binding to Foo";
                    var exception = Assert.Throws<InvalidOperationException>(() => container.Bind(() => default(Foo)));
                    Assert.AreEqual(expected, exception.Message);
                    exception = Assert.Throws<InvalidOperationException>(() => container.Bind(_ => default(Foo)));
                    Assert.AreEqual(expected, exception.Message);
                }
            }

            [Test]
            public void BindTypeWhenHasInstanceBinding()
            {
                Assert.Inconclusive("Fix later.");
                //using (var container = new Container<object>())
                //{
                //    var instance = new With<DefaultCtor>(new DefaultCtor());
                //    container.Bind<IWith>(instance);
                //    var exception = Assert.Throws<InvalidOperationException>(() => container.Bind<IWith, With<DefaultCtor>>());
                //    Assert.AreEqual("IWith already has a binding to Gu.Inject.Tests.Types.With`1[Gu.Inject.Tests.Types.DefaultCtor]", exception.Message);
                //}
            }

            [Test]
            public void BindInstanceWhenHasTypeBinding()
            {
                Assert.Inconclusive("Fix later.");
                //using (var container = new Container<object>())
                //{
                //    container.Bind<IWith, With<DefaultCtor>>();
                //    var instance = new With<DefaultCtor>(new DefaultCtor());
                //    var exception = Assert.Throws<InvalidOperationException>(() => container.Bind<IWith>(instance));
                //    Assert.AreEqual("IWith already has a binding to With<DefaultCtor>", exception.Message);
                //}
            }
        }
    }
}