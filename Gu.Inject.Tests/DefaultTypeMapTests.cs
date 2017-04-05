namespace Gu.Inject.Tests
{
    using System;
    using Gu.Inject.Tests.Types;
    using NUnit.Framework;

    public class DefaultTypeMapTests
    {
        [TestCase(typeof(DefaultCtor), new Type[0])]
        [TestCase(typeof(IDefaultCtor), new[] { typeof(DefaultCtor) })]
        [TestCase(typeof(With<DefaultCtor>), new Type[0])]
        [TestCase(typeof(IWith<DefaultCtor>), new[] { typeof(With<DefaultCtor>) })]
        [TestCase(typeof(IWith), new[] { typeof(With<>) })]
        public void GetMapped(Type type, Type[] expected)
        {
            CollectionAssert.AreEqual(expected, DefaultTypeMap.GetMapped(type));
        }
    }
}