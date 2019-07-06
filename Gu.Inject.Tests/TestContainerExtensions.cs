namespace Gu.Inject.Tests
{
    using Gu.Inject;
    using Gu.Inject.Tests.Types;

    public static class TestContainerExtensions
    {
        public static Container<Disposable> AutoBind(this Container<Disposable> container) => container
            .Bind(_ => new Disposable());

        public static Container<Foo> AutoBind(this Container<Foo> container) => container
            .Bind(x => new Foo(x.Get<Bar>()))
            .Bind(() => new Bar());

        public static Container<WithTwo<DefaultCtor, DefaultCtor>> AutoBind(this Container<WithTwo<DefaultCtor,DefaultCtor>> container) => container
            .Bind(x => new WithTwo<DefaultCtor, DefaultCtor>(x.Get<DefaultCtor>(), x.Get<DefaultCtor>()))
            .Bind(() => new DefaultCtor());

        public static Container<Graph50.Node1> AutoBind(this Container<Graph50.Node1> container) => container
            .Bind(x => new Graph50.Node1(x.Get<Graph50.Node2>(), x.Get<Graph50.Node7>(), x.Get<Graph50.Node10>(), x.Get<Graph50.Node16>(), x.Get<Graph50.Node18>(), x.Get<Graph50.Node24>(), x.Get<Graph50.Node26>(), x.Get<Graph50.Node27>(), x.Get<Graph50.Node29>(), x.Get<Graph50.Node32>()))
            .Bind(x => new Graph50.Node2(x.Get<Graph50.Node4>(), x.Get<Graph50.Node8>(), x.Get<Graph50.Node16>(), x.Get<Graph50.Node48>()))
            .Bind(x => new Graph50.Node4(x.Get<Graph50.Node8>(), x.Get<Graph50.Node32>(), x.Get<Graph50.Node36>()))
            .Bind(() => new Graph50.Node8())
            .Bind(() => new Graph50.Node32())
            .Bind(() => new Graph50.Node36())
            .Bind(() => new Graph50.Node16())
            .Bind(() => new Graph50.Node48())
            .Bind(x => new Graph50.Node7(x.Get<Graph50.Node35>(), x.Get<Graph50.Node49>()))
            .Bind(() => new Graph50.Node35())
            .Bind(() => new Graph50.Node49())
            .Bind(() => new Graph50.Node10())
            .Bind(() => new Graph50.Node18())
            .Bind(x => new Graph50.Node24(x.Get<Graph50.Node48>()))
            .Bind(() => new Graph50.Node26())
            .Bind(() => new Graph50.Node27())
            .Bind(() => new Graph50.Node29());
    }
}