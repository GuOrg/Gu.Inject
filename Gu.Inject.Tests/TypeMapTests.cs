namespace Gu.Inject.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Gu.Inject.Tests.Types;
    using NUnit.Framework;

    public class TypeMapTests
    {
        private static TestCase[] TestCases = new[]
        {
            new TestCase(typeof(DefaultCtor)),
            new TestCase(typeof(IDefaultCtor), typeof(DefaultCtor)),
            new TestCase(typeof(With<DefaultCtor>)),
            new TestCase(typeof(IWith<DefaultCtor>), typeof(With<DefaultCtor>)),
            new TestCase(typeof(IWith), typeof(With<>)),
            new TestCase(typeof(InheritNonAbstract.Foo), typeof(InheritNonAbstract.FooDerived)),
            new TestCase(typeof(OneToOneGeneric.AbstractGeneric<DefaultCtor>), typeof(OneToOneGeneric.GenericOfDefaultCtor)),
            new TestCase(typeof(ManyToOne.FooBase), typeof(ManyToOne.Foo)),
            new TestCase(typeof(ManyToOne.FooBaseBase), typeof(ManyToOne.Foo)),
            new TestCase(typeof(ManyToOne.IFoo1), typeof(ManyToOne.Foo)),
            new TestCase(typeof(ManyToOne.IFoo2), typeof(ManyToOne.Foo)),
            new TestCase(typeof(ManyToOne.IFooBase1), typeof(ManyToOne.Foo)),
            new TestCase(typeof(ManyToOne.IFooBase2), typeof(ManyToOne.Foo)),
            new TestCase(typeof(ManyToOne.IGenericFoo1<int>), typeof(ManyToOne.Foo)),
            new TestCase(typeof(ManyToOne.IGenericFoo1<double>), typeof(ManyToOne.Foo)),
            new TestCase(typeof(ManyToOne.IGenericFoo2<int>), typeof(ManyToOne.Foo)),
            new TestCase(typeof(ManyToOne.IFooFoo), typeof(ManyToOne.Foo)),
            new TestCase(typeof(ManyToOne.IFoo), typeof(ManyToOne.Foo)),
        };

        [TestCaseSource(nameof(TestCases))]
        public void GetMapped(TestCase texCase)
        {
            TypeMap.Initialize(typeof(With<>).Assembly, false);
            var actual = TypeMap.GetMapped(texCase.Type);
            Assert.AreEqual(AsString(texCase.Expected), AsString(actual));
        }

        private static string AsString(IReadOnlyList<Type> types)
        {
            return string.Join(", ", types.Select(t => t.PrettyName()));
        }

        public class TestCase
        {
            public TestCase(Type type, params Type[] expected)
            {
                this.Type = type;
                this.Expected = expected ?? new Type[0];
            }

            public Type Type { get; }

            public Type[] Expected { get; }

            public override string ToString()
            {
                return $"{this.Type.PrettyName()} -> {AsString(this.Expected)}";
            }
        }
    }
}