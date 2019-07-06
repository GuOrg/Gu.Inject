namespace Gu.Inject.Benchmarks
{
    using Gu.Inject.Benchmarks.Types;
    using Ninject.Modules;

    public class ModuleFoo : NinjectModule
    {
        public override void Load()
        {
            this.Bind<Foo>().ToSelf().InSingletonScope();
        }
    }
}