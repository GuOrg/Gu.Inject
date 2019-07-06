namespace Gu.Inject.Benchmarks
{
    using Gu.Inject.Benchmarks.Types;
    using Ninject.Modules;

    public class ModuleGraph50 : NinjectModule
    {
        public override void Load()
        {
            this.Bind<Graph50.Node1>().ToSelf().InSingletonScope();
            this.Bind<Graph50.Node1>().ToSelf().InSingletonScope();
            this.Bind<Graph50.Node2>().ToSelf().InSingletonScope();
            this.Bind<Graph50.Node4>().ToSelf().InSingletonScope();
            this.Bind<Graph50.Node8>().ToSelf().InSingletonScope();
            this.Bind<Graph50.Node32>().ToSelf().InSingletonScope();
            this.Bind<Graph50.Node36>().ToSelf().InSingletonScope();
            this.Bind<Graph50.Node16>().ToSelf().InSingletonScope();
            this.Bind<Graph50.Node48>().ToSelf().InSingletonScope();
            this.Bind<Graph50.Node7>().ToSelf().InSingletonScope();
            this.Bind<Graph50.Node35>().ToSelf().InSingletonScope();
            this.Bind<Graph50.Node49>().ToSelf().InSingletonScope();
            this.Bind<Graph50.Node10>().ToSelf().InSingletonScope();
            this.Bind<Graph50.Node18>().ToSelf().InSingletonScope();
            this.Bind<Graph50.Node24>().ToSelf().InSingletonScope();
            this.Bind<Graph50.Node26>().ToSelf().InSingletonScope();
            this.Bind<Graph50.Node27>().ToSelf().InSingletonScope();
            this.Bind<Graph50.Node29>().ToSelf().InSingletonScope();
        }
    }
}