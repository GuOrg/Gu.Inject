namespace Gu.Inject.Tests
{
    using System;
    using Gu.Inject.Tests.Types;
    using NUnit.Framework;

    public class TypeMapTests
    {
        [TestCase(typeof(DefaultCtor), new Type[0])]
        [TestCase(typeof(IDefaultCtor), new[] { typeof(DefaultCtor) })]
        [TestCase(typeof(With<DefaultCtor>), new Type[0])]
        [TestCase(typeof(IWith<DefaultCtor>), new[] { typeof(With<DefaultCtor>) })]
        [TestCase(typeof(IWith), new[] { typeof(With<>) })]
        [TestCase(typeof(InheritNonAbstract.Foo), new[] { typeof(InheritNonAbstract.FooDerived) })]
        [TestCase(typeof(OneToOneGeneric.AbstractGeneric<DefaultCtor>), new[] { typeof(OneToOneGeneric.GenericOfDefaultCtor) })]
        public void GetMapped(Type type, Type[] expected)
        {
            TypeMap.Initialize(typeof(With<>).Assembly, false);
            CollectionAssert.AreEqual(expected, TypeMap.GetMapped(type));
        }
    }
}