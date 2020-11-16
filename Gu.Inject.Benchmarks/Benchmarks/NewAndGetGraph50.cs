namespace Gu.Inject.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using DryIoc;
    using Ninject;
    using SimpleInjector;
    using static Gu.Inject.Benchmarks.Types.Graph50;

    [MemoryDiagnoser]
    public class NewAndGetGraph50
    {
        [Benchmark]
        public object Ninject()
        {
            using var kernel = new Ninject.StandardKernel(new Module());
            return kernel.Get<Node1>();
        }

        [Benchmark]
        public object SimpleInjector()
        {
            using var container = new SimpleInjector.Container
            {
                Options =
                {
                    ResolveUnregisteredConcreteTypes = true,
                    DefaultLifestyle = Lifestyle.Singleton,
                },
            };
            return container.GetInstance<Node1>();
        }

        [Benchmark]
        public object DryIoc()
        {
            using var container = new DryIoc.Container(x => x.WithConcreteTypeDynamicRegistrations()
                                                             .WithDefaultReuse(Reuse.Singleton));
            return container.Resolve<Node1>();
        }

        [Benchmark(Baseline = true)]
        public object GuInject()
        {
            using var kernel = new Kernel();
            return kernel.Get<Node1>();
        }

        [Benchmark]
        public object GuInjectBound()
        {
            using var kernel = new Kernel()
                               .Bind(c => new Node1(c.Get<Node2>(), c.Get<Node7>(), c.Get<Node10>(), c.Get<Node16>(), c.Get<Node18>(), c.Get<Node24>(), c.Get<Node26>(), c.Get<Node27>(), c.Get<Node29>(), c.Get<Node32>()))
                               .Bind(c => new Node2(c.Get<Node4>(), c.Get<Node8>(), c.Get<Node16>(), c.Get<Node48>()))
                               .Bind(c => new Node3(c.Get<Node33>()))
                               .Bind(c => new Node4(c.Get<Node8>(), c.Get<Node32>(), c.Get<Node36>()))
                               .Bind(c => new Node5(c.Get<Node30>()))
                               .Bind(c => new Node6(c.Get<Node18>(), c.Get<Node30>()))
                               .Bind(c => new Node7(c.Get<Node35>(), c.Get<Node49>()))
                               .Bind(c => new Node8())
                               .Bind(c => new Node9(c.Get<Node18>()))
                               .Bind(c => new Node10())
                               .Bind(c => new Node11(c.Get<Node22>()))
                               .Bind(c => new Node12(c.Get<Node24>(), c.Get<Node48>()))
                               .Bind(c => new Node13(c.Get<Node39>()))
                               .Bind(c => new Node14(c.Get<Node28>()))
                               .Bind(c => new Node15(c.Get<Node30>()))
                               .Bind(c => new Node16())
                               .Bind(c => new Node17())
                               .Bind(c => new Node18())
                               .Bind(c => new Node19())
                               .Bind(c => new Node20())
                               .Bind(c => new Node21())
                               .Bind(c => new Node22())
                               .Bind(c => new Node23())
                               .Bind(c => new Node24(c.Get<Node48>()))
                               .Bind(c => new Node25())
                               .Bind(c => new Node26())
                               .Bind(c => new Node27())
                               .Bind(c => new Node28())
                               .Bind(c => new Node29())
                               .Bind(c => new Node30())
                               .Bind(c => new Node31())
                               .Bind(c => new Node32())
                               .Bind(c => new Node33())
                               .Bind(c => new Node34())
                               .Bind(c => new Node35())
                               .Bind(c => new Node36())
                               .Bind(c => new Node37())
                               .Bind(c => new Node38())
                               .Bind(c => new Node39())
                               .Bind(c => new Node40())
                               .Bind(c => new Node41())
                               .Bind(c => new Node42())
                               .Bind(c => new Node43())
                               .Bind(c => new Node44())
                               .Bind(c => new Node45())
                               .Bind(c => new Node46())
                               .Bind(c => new Node47())
                               .Bind(c => new Node48())
                               .Bind(c => new Node49());
            return kernel.Get<Node1>();
        }

        private class Module : Ninject.Modules.NinjectModule
        {
            public override void Load()
            {
                this.Bind<Node1>().ToSelf().InSingletonScope();
                this.Bind<Node2>().ToSelf().InSingletonScope();
                this.Bind<Node3>().ToSelf().InSingletonScope();
                this.Bind<Node4>().ToSelf().InSingletonScope();
                this.Bind<Node5>().ToSelf().InSingletonScope();
                this.Bind<Node6>().ToSelf().InSingletonScope();
                this.Bind<Node7>().ToSelf().InSingletonScope();
                this.Bind<Node8>().ToSelf().InSingletonScope();
                this.Bind<Node9>().ToSelf().InSingletonScope();
                this.Bind<Node10>().ToSelf().InSingletonScope();
                this.Bind<Node11>().ToSelf().InSingletonScope();
                this.Bind<Node12>().ToSelf().InSingletonScope();
                this.Bind<Node13>().ToSelf().InSingletonScope();
                this.Bind<Node14>().ToSelf().InSingletonScope();
                this.Bind<Node15>().ToSelf().InSingletonScope();
                this.Bind<Node16>().ToSelf().InSingletonScope();
                this.Bind<Node17>().ToSelf().InSingletonScope();
                this.Bind<Node18>().ToSelf().InSingletonScope();
                this.Bind<Node19>().ToSelf().InSingletonScope();
                this.Bind<Node20>().ToSelf().InSingletonScope();
                this.Bind<Node21>().ToSelf().InSingletonScope();
                this.Bind<Node22>().ToSelf().InSingletonScope();
                this.Bind<Node23>().ToSelf().InSingletonScope();
                this.Bind<Node24>().ToSelf().InSingletonScope();
                this.Bind<Node25>().ToSelf().InSingletonScope();
                this.Bind<Node26>().ToSelf().InSingletonScope();
                this.Bind<Node27>().ToSelf().InSingletonScope();
                this.Bind<Node28>().ToSelf().InSingletonScope();
                this.Bind<Node29>().ToSelf().InSingletonScope();
                this.Bind<Node30>().ToSelf().InSingletonScope();
                this.Bind<Node31>().ToSelf().InSingletonScope();
                this.Bind<Node32>().ToSelf().InSingletonScope();
                this.Bind<Node33>().ToSelf().InSingletonScope();
                this.Bind<Node34>().ToSelf().InSingletonScope();
                this.Bind<Node35>().ToSelf().InSingletonScope();
                this.Bind<Node36>().ToSelf().InSingletonScope();
                this.Bind<Node37>().ToSelf().InSingletonScope();
                this.Bind<Node38>().ToSelf().InSingletonScope();
                this.Bind<Node39>().ToSelf().InSingletonScope();
                this.Bind<Node40>().ToSelf().InSingletonScope();
                this.Bind<Node41>().ToSelf().InSingletonScope();
                this.Bind<Node42>().ToSelf().InSingletonScope();
                this.Bind<Node43>().ToSelf().InSingletonScope();
                this.Bind<Node44>().ToSelf().InSingletonScope();
                this.Bind<Node45>().ToSelf().InSingletonScope();
                this.Bind<Node46>().ToSelf().InSingletonScope();
                this.Bind<Node47>().ToSelf().InSingletonScope();
                this.Bind<Node48>().ToSelf().InSingletonScope();
                this.Bind<Node49>().ToSelf().InSingletonScope();
            }
        }
    }
}
