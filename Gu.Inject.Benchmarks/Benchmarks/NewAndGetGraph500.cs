namespace Gu.Inject.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using DryIoc;
    using Ninject;
    using Ninject.Modules;
    using SimpleInjector;
    using static Gu.Inject.Benchmarks.Types.Graph500;

    [MemoryDiagnoser]
    public class NewAndGetGraph500
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
                               .Bind(c => new Node1(c.Get<Node7>(), c.Get<Node8>(), c.Get<Node20>(), c.Get<Node26>(),
                                   c.Get<Node29>(), c.Get<Node34>(), c.Get<Node37>(), c.Get<Node49>(), c.Get<Node50>(),
                                   c.Get<Node57>(), c.Get<Node60>(), c.Get<Node63>(), c.Get<Node72>(), c.Get<Node79>(),
                                   c.Get<Node83>(), c.Get<Node93>(), c.Get<Node96>(), c.Get<Node101>(),
                                   c.Get<Node109>(), c.Get<Node113>(), c.Get<Node116>(), c.Get<Node118>(),
                                   c.Get<Node121>(), c.Get<Node124>(), c.Get<Node127>(), c.Get<Node135>(),
                                   c.Get<Node136>(), c.Get<Node144>(), c.Get<Node154>(), c.Get<Node156>(),
                                   c.Get<Node162>(), c.Get<Node167>(), c.Get<Node179>(), c.Get<Node180>(),
                                   c.Get<Node183>(), c.Get<Node188>(), c.Get<Node193>(), c.Get<Node200>(),
                                   c.Get<Node202>(), c.Get<Node207>(), c.Get<Node216>(), c.Get<Node217>(),
                                   c.Get<Node219>(), c.Get<Node221>(), c.Get<Node225>(), c.Get<Node226>(),
                                   c.Get<Node230>(), c.Get<Node233>(), c.Get<Node234>(), c.Get<Node240>(),
                                   c.Get<Node244>(), c.Get<Node245>(), c.Get<Node252>(), c.Get<Node254>(),
                                   c.Get<Node259>(), c.Get<Node261>(), c.Get<Node263>(), c.Get<Node268>(),
                                   c.Get<Node277>(), c.Get<Node282>(), c.Get<Node287>(), c.Get<Node288>(),
                                   c.Get<Node294>(), c.Get<Node295>(), c.Get<Node300>(), c.Get<Node305>(),
                                   c.Get<Node310>(), c.Get<Node318>(), c.Get<Node324>(), c.Get<Node328>(),
                                   c.Get<Node334>(), c.Get<Node338>(), c.Get<Node340>(), c.Get<Node344>(),
                                   c.Get<Node346>(), c.Get<Node348>(), c.Get<Node349>(), c.Get<Node352>(),
                                   c.Get<Node359>(), c.Get<Node363>(), c.Get<Node375>(), c.Get<Node381>(),
                                   c.Get<Node383>(), c.Get<Node395>(), c.Get<Node408>(), c.Get<Node411>(),
                                   c.Get<Node412>(), c.Get<Node415>(), c.Get<Node423>(), c.Get<Node431>(),
                                   c.Get<Node432>(), c.Get<Node437>(), c.Get<Node440>(), c.Get<Node444>(),
                                   c.Get<Node448>(), c.Get<Node461>(), c.Get<Node466>(), c.Get<Node472>(),
                                   c.Get<Node476>(), c.Get<Node485>(), c.Get<Node490>(), c.Get<Node498>()))
                               .Bind(c => new Node2(c.Get<Node18>(), c.Get<Node30>(), c.Get<Node58>(), c.Get<Node64>(),
                                   c.Get<Node82>(), c.Get<Node86>(), c.Get<Node92>(), c.Get<Node96>(), c.Get<Node102>(),
                                   c.Get<Node104>(), c.Get<Node106>(), c.Get<Node114>(), c.Get<Node116>(),
                                   c.Get<Node130>(), c.Get<Node138>(), c.Get<Node140>(), c.Get<Node146>(),
                                   c.Get<Node174>(), c.Get<Node186>(), c.Get<Node188>(), c.Get<Node190>(),
                                   c.Get<Node208>(), c.Get<Node210>(), c.Get<Node234>(), c.Get<Node236>(),
                                   c.Get<Node246>(), c.Get<Node256>(), c.Get<Node274>(), c.Get<Node280>(),
                                   c.Get<Node288>(), c.Get<Node290>(), c.Get<Node298>(), c.Get<Node302>(),
                                   c.Get<Node306>(), c.Get<Node308>(), c.Get<Node336>(), c.Get<Node356>(),
                                   c.Get<Node358>(), c.Get<Node372>(), c.Get<Node386>(), c.Get<Node396>(),
                                   c.Get<Node414>(), c.Get<Node422>(), c.Get<Node430>(), c.Get<Node434>(),
                                   c.Get<Node438>(), c.Get<Node448>(), c.Get<Node456>(), c.Get<Node472>(),
                                   c.Get<Node478>(), c.Get<Node482>(), c.Get<Node494>()))
                               .Bind(c => new Node3(c.Get<Node15>(), c.Get<Node36>(), c.Get<Node72>(), c.Get<Node87>(),
                                   c.Get<Node90>(), c.Get<Node126>(), c.Get<Node138>(), c.Get<Node141>(),
                                   c.Get<Node144>(), c.Get<Node150>(), c.Get<Node156>(), c.Get<Node174>(),
                                   c.Get<Node186>(), c.Get<Node204>(), c.Get<Node210>(), c.Get<Node213>(),
                                   c.Get<Node225>(), c.Get<Node279>(), c.Get<Node282>(), c.Get<Node288>(),
                                   c.Get<Node315>(), c.Get<Node321>(), c.Get<Node336>(), c.Get<Node342>(),
                                   c.Get<Node345>(), c.Get<Node357>(), c.Get<Node363>(), c.Get<Node366>(),
                                   c.Get<Node369>(), c.Get<Node405>(), c.Get<Node414>(), c.Get<Node429>(),
                                   c.Get<Node432>(), c.Get<Node438>(), c.Get<Node441>(), c.Get<Node447>(),
                                   c.Get<Node489>()))
                               .Bind(c => new Node4(c.Get<Node32>(), c.Get<Node36>(), c.Get<Node44>(), c.Get<Node52>(),
                                   c.Get<Node80>(), c.Get<Node108>(), c.Get<Node124>(), c.Get<Node136>(),
                                   c.Get<Node196>(), c.Get<Node232>(), c.Get<Node272>(), c.Get<Node280>(),
                                   c.Get<Node284>(), c.Get<Node292>(), c.Get<Node312>(), c.Get<Node324>(),
                                   c.Get<Node332>(), c.Get<Node352>(), c.Get<Node364>(), c.Get<Node380>(),
                                   c.Get<Node388>(), c.Get<Node396>(), c.Get<Node400>(), c.Get<Node404>(),
                                   c.Get<Node416>(), c.Get<Node424>(), c.Get<Node440>(), c.Get<Node456>(),
                                   c.Get<Node484>()))
                               .Bind(c => new Node5(c.Get<Node10>(), c.Get<Node30>(), c.Get<Node50>(), c.Get<Node60>(),
                                   c.Get<Node70>(), c.Get<Node75>(), c.Get<Node95>(), c.Get<Node100>(),
                                   c.Get<Node120>(), c.Get<Node160>(), c.Get<Node180>(), c.Get<Node190>(),
                                   c.Get<Node200>(), c.Get<Node205>(), c.Get<Node235>(), c.Get<Node255>(),
                                   c.Get<Node270>(), c.Get<Node310>(), c.Get<Node320>(), c.Get<Node335>(),
                                   c.Get<Node350>(), c.Get<Node370>(), c.Get<Node375>(), c.Get<Node405>(),
                                   c.Get<Node430>(), c.Get<Node475>(), c.Get<Node480>(), c.Get<Node495>()))
                               .Bind(c => new Node6(c.Get<Node66>(), c.Get<Node84>(), c.Get<Node90>(), c.Get<Node114>(),
                                   c.Get<Node150>(), c.Get<Node180>(), c.Get<Node192>(), c.Get<Node204>(),
                                   c.Get<Node216>(), c.Get<Node234>(), c.Get<Node240>(), c.Get<Node396>()))
                               .Bind(c => new Node7(c.Get<Node35>(), c.Get<Node63>(), c.Get<Node77>(), c.Get<Node105>(),
                                   c.Get<Node210>(), c.Get<Node217>(), c.Get<Node329>(), c.Get<Node378>(),
                                   c.Get<Node420>(), c.Get<Node441>(), c.Get<Node448>(), c.Get<Node455>()))
                               .Bind(c => new Node8(c.Get<Node40>(), c.Get<Node168>(), c.Get<Node216>(),
                                   c.Get<Node232>(), c.Get<Node248>(), c.Get<Node264>(), c.Get<Node272>(),
                                   c.Get<Node304>(), c.Get<Node312>(), c.Get<Node456>(), c.Get<Node464>()))
                               .Bind(c => new Node9(c.Get<Node45>(), c.Get<Node144>(), c.Get<Node216>(),
                                   c.Get<Node315>(), c.Get<Node324>(), c.Get<Node342>(), c.Get<Node351>(),
                                   c.Get<Node387>(), c.Get<Node405>(), c.Get<Node441>()))
                               .Bind(c => new Node10(c.Get<Node30>(), c.Get<Node130>(), c.Get<Node140>(),
                                   c.Get<Node180>(), c.Get<Node200>(), c.Get<Node300>(), c.Get<Node320>(),
                                   c.Get<Node330>(), c.Get<Node340>(), c.Get<Node370>(), c.Get<Node390>()))
                               .Bind(c => new Node11(c.Get<Node33>(), c.Get<Node99>(), c.Get<Node110>(),
                                   c.Get<Node275>(), c.Get<Node374>(), c.Get<Node385>(), c.Get<Node418>()))
                               .Bind(c => new Node12(c.Get<Node60>(), c.Get<Node96>(), c.Get<Node420>()))
                               .Bind(c => new Node13(c.Get<Node78>(), c.Get<Node221>(), c.Get<Node364>(),
                                   c.Get<Node403>(), c.Get<Node455>()))
                               .Bind(c => new Node14(c.Get<Node28>(), c.Get<Node84>(), c.Get<Node98>(),
                                   c.Get<Node112>(), c.Get<Node154>(), c.Get<Node196>(), c.Get<Node238>(),
                                   c.Get<Node252>(), c.Get<Node280>(), c.Get<Node322>(), c.Get<Node378>(),
                                   c.Get<Node420>()))
                               .Bind(c => new Node15(c.Get<Node330>(), c.Get<Node405>(), c.Get<Node465>()))
                               .Bind(c => new Node16(c.Get<Node176>(), c.Get<Node384>(), c.Get<Node416>(),
                                   c.Get<Node448>()))
                               .Bind(c => new Node17(c.Get<Node85>(), c.Get<Node102>(), c.Get<Node170>(),
                                   c.Get<Node255>(), c.Get<Node289>(), c.Get<Node306>(), c.Get<Node357>(),
                                   c.Get<Node425>(), c.Get<Node459>()))
                               .Bind(c => new Node18(c.Get<Node72>(), c.Get<Node90>(), c.Get<Node198>(),
                                   c.Get<Node270>(), c.Get<Node378>(), c.Get<Node414>()))
                               .Bind(c => new Node19(c.Get<Node209>(), c.Get<Node228>(), c.Get<Node247>(),
                                   c.Get<Node304>(), c.Get<Node342>(), c.Get<Node361>(), c.Get<Node380>(),
                                   c.Get<Node399>(), c.Get<Node494>()))
                               .Bind(c => new Node20(c.Get<Node60>(), c.Get<Node240>(), c.Get<Node260>(),
                                   c.Get<Node380>()))
                               .Bind(c => new Node21(c.Get<Node147>(), c.Get<Node210>(), c.Get<Node483>()))
                               .Bind(c => new Node22(c.Get<Node198>(), c.Get<Node220>(), c.Get<Node264>(),
                                   c.Get<Node308>()))
                               .Bind(c => new Node23(c.Get<Node115>(), c.Get<Node276>(), c.Get<Node299>(), c.Get<Node368>()))
                               .Bind(c => new Node24(c.Get<Node96>(), c.Get<Node240>(), c.Get<Node384>()))
                               .Bind(c => new Node25(c.Get<Node50>(), c.Get<Node100>(), c.Get<Node175>(), c.Get<Node350>()))
                               .Bind(c => new Node26(c.Get<Node104>(), c.Get<Node260>(), c.Get<Node338>(), c.Get<Node364>(), c.Get<Node390>()))
                               .Bind(c => new Node27(c.Get<Node81>(), c.Get<Node378>()))
                               .Bind(c => new Node28(c.Get<Node112>(), c.Get<Node420>()))
                               .Bind(c => new Node29(c.Get<Node261>(), c.Get<Node406>()))
                               .Bind(c => new Node30(c.Get<Node150>(), c.Get<Node210>(), c.Get<Node270>(), c.Get<Node480>()))
                               .Bind(c => new Node31(c.Get<Node62>(), c.Get<Node93>(), c.Get<Node341>(), c.Get<Node372>(), c.Get<Node403>(), c.Get<Node434>()))
                               .Bind(c => new Node32(c.Get<Node256>()))
                               .Bind(c => new Node33(c.Get<Node198>(), c.Get<Node330>()))
                               .Bind(c => new Node34(c.Get<Node68>(), c.Get<Node340>(), c.Get<Node476>()))
                               .Bind(c => new Node35(c.Get<Node175>(), c.Get<Node210>(), c.Get<Node280>(), c.Get<Node350>(), c.Get<Node455>()))
                               .Bind(c => new Node36(c.Get<Node108>(), c.Get<Node180>(), c.Get<Node360>()))
                               .Bind(c => new Node37(c.Get<Node74>(), c.Get<Node370>()))
                               .Bind(c => new Node38(c.Get<Node76>(), c.Get<Node266>(), c.Get<Node380>()))
                               .Bind(c => new Node39())
                               .Bind(c => new Node40(c.Get<Node80>(), c.Get<Node160>(), c.Get<Node200>(), c.Get<Node360>(), c.Get<Node480>()))
                               .Bind(c => new Node41(c.Get<Node123>(), c.Get<Node246>(), c.Get<Node328>()))
                               .Bind(c => new Node42())
                               .Bind(c => new Node43())
                               .Bind(c => new Node44(c.Get<Node352>(), c.Get<Node396>()))
                               .Bind(c => new Node45(c.Get<Node135>()))
                               .Bind(c => new Node46(c.Get<Node92>(), c.Get<Node230>(), c.Get<Node322>()))
                               .Bind(c => new Node47(c.Get<Node329>()))
                               .Bind(c => new Node48(c.Get<Node144>(), c.Get<Node288>(), c.Get<Node336>()))
                               .Bind(c => new Node49(c.Get<Node147>(), c.Get<Node196>(), c.Get<Node441>(), c.Get<Node490>()))
                               .Bind(c => new Node50())
                               .Bind(c => new Node51(c.Get<Node204>()))
                               .Bind(c => new Node52())
                               .Bind(c => new Node53(c.Get<Node371>()))
                               .Bind(c => new Node54(c.Get<Node270>()))
                               .Bind(c => new Node55())
                               .Bind(c => new Node56())
                               .Bind(c => new Node57(c.Get<Node285>()))
                               .Bind(c => new Node58())
                               .Bind(c => new Node59(c.Get<Node177>(), c.Get<Node236>(), c.Get<Node354>(), c.Get<Node472>()))
                               .Bind(c => new Node60(c.Get<Node480>()))
                               .Bind(c => new Node61(c.Get<Node122>()))
                               .Bind(c => new Node62(c.Get<Node248>(), c.Get<Node310>()))
                               .Bind(c => new Node63(c.Get<Node126>()))
                               .Bind(c => new Node64(c.Get<Node192>()))
                               .Bind(c => new Node65(c.Get<Node260>(), c.Get<Node455>()))
                               .Bind(c => new Node66(c.Get<Node462>()))
                               .Bind(c => new Node67(c.Get<Node201>()))
                               .Bind(c => new Node68(c.Get<Node136>(), c.Get<Node476>()))
                               .Bind(c => new Node69(c.Get<Node207>()))
                               .Bind(c => new Node70(c.Get<Node490>()))
                               .Bind(c => new Node71(c.Get<Node142>(), c.Get<Node355>()))
                               .Bind(c => new Node72(c.Get<Node144>(), c.Get<Node288>()))
                               .Bind(c => new Node73())
                               .Bind(c => new Node74(c.Get<Node222>(), c.Get<Node370>()))
                               .Bind(c => new Node75())
                               .Bind(c => new Node76(c.Get<Node304>()))
                               .Bind(c => new Node77(c.Get<Node308>(), c.Get<Node385>(), c.Get<Node462>()))
                               .Bind(c => new Node78(c.Get<Node234>()))
                               .Bind(c => new Node79(c.Get<Node237>()))
                               .Bind(c => new Node80())
                               .Bind(c => new Node81())
                               .Bind(c => new Node82())
                               .Bind(c => new Node83(c.Get<Node249>(), c.Get<Node498>()))
                               .Bind(c => new Node84(c.Get<Node168>(), c.Get<Node420>()))
                               .Bind(c => new Node85(c.Get<Node255>()))
                               .Bind(c => new Node86())
                               .Bind(c => new Node87(c.Get<Node261>()))
                               .Bind(c => new Node88())
                               .Bind(c => new Node89())
                               .Bind(c => new Node90())
                               .Bind(c => new Node91())
                               .Bind(c => new Node92())
                               .Bind(c => new Node93())
                               .Bind(c => new Node94())
                               .Bind(c => new Node95(c.Get<Node285>(), c.Get<Node380>()))
                               .Bind(c => new Node96())
                               .Bind(c => new Node97())
                               .Bind(c => new Node98())
                               .Bind(c => new Node99(c.Get<Node396>(), c.Get<Node495>()))
                               .Bind(c => new Node100(c.Get<Node400>()))
                               .Bind(c => new Node101())
                               .Bind(c => new Node102())
                               .Bind(c => new Node103())
                               .Bind(c => new Node104())
                               .Bind(c => new Node105())
                               .Bind(c => new Node106(c.Get<Node424>()))
                               .Bind(c => new Node107(c.Get<Node214>()))
                               .Bind(c => new Node108(c.Get<Node216>()))
                               .Bind(c => new Node109(c.Get<Node327>(), c.Get<Node436>()))
                               .Bind(c => new Node110())
                               .Bind(c => new Node111())
                               .Bind(c => new Node112())
                               .Bind(c => new Node113(c.Get<Node226>()))
                               .Bind(c => new Node114())
                               .Bind(c => new Node115())
                               .Bind(c => new Node116(c.Get<Node348>()))
                               .Bind(c => new Node117())
                               .Bind(c => new Node118(c.Get<Node236>()))
                               .Bind(c => new Node119(c.Get<Node357>()))
                               .Bind(c => new Node120())
                               .Bind(c => new Node121(c.Get<Node363>()))
                               .Bind(c => new Node122(c.Get<Node244>()))
                               .Bind(c => new Node123())
                               .Bind(c => new Node124(c.Get<Node248>(), c.Get<Node496>()))
                               .Bind(c => new Node125())
                               .Bind(c => new Node126())
                               .Bind(c => new Node127())
                               .Bind(c => new Node128())
                               .Bind(c => new Node129())
                               .Bind(c => new Node130())
                               .Bind(c => new Node131())
                               .Bind(c => new Node132())
                               .Bind(c => new Node133())
                               .Bind(c => new Node134())
                               .Bind(c => new Node135())
                               .Bind(c => new Node136())
                               .Bind(c => new Node137())
                               .Bind(c => new Node138(c.Get<Node414>()))
                               .Bind(c => new Node139(c.Get<Node278>()))
                               .Bind(c => new Node140())
                               .Bind(c => new Node141())
                               .Bind(c => new Node142())
                               .Bind(c => new Node143())
                               .Bind(c => new Node144())
                               .Bind(c => new Node145())
                               .Bind(c => new Node146(c.Get<Node438>()))
                               .Bind(c => new Node147())
                               .Bind(c => new Node148(c.Get<Node296>()))
                               .Bind(c => new Node149())
                               .Bind(c => new Node150())
                               .Bind(c => new Node151())
                               .Bind(c => new Node152(c.Get<Node304>()))
                               .Bind(c => new Node153(c.Get<Node459>()))
                               .Bind(c => new Node154())
                               .Bind(c => new Node155())
                               .Bind(c => new Node156())
                               .Bind(c => new Node157())
                               .Bind(c => new Node158())
                               .Bind(c => new Node159())
                               .Bind(c => new Node160())
                               .Bind(c => new Node161())
                               .Bind(c => new Node162())
                               .Bind(c => new Node163())
                               .Bind(c => new Node164(c.Get<Node328>()))
                               .Bind(c => new Node165(c.Get<Node495>()))
                               .Bind(c => new Node166(c.Get<Node498>()))
                               .Bind(c => new Node167())
                               .Bind(c => new Node168())
                               .Bind(c => new Node169())
                               .Bind(c => new Node170())
                               .Bind(c => new Node171())
                               .Bind(c => new Node172())
                               .Bind(c => new Node173())
                               .Bind(c => new Node174())
                               .Bind(c => new Node175())
                               .Bind(c => new Node176())
                               .Bind(c => new Node177())
                               .Bind(c => new Node178())
                               .Bind(c => new Node179())
                               .Bind(c => new Node180())
                               .Bind(c => new Node181())
                               .Bind(c => new Node182())
                               .Bind(c => new Node183())
                               .Bind(c => new Node184())
                               .Bind(c => new Node185())
                               .Bind(c => new Node186(c.Get<Node372>()))
                               .Bind(c => new Node187(c.Get<Node374>()))
                               .Bind(c => new Node188())
                               .Bind(c => new Node189())
                               .Bind(c => new Node190())
                               .Bind(c => new Node191(c.Get<Node382>()))
                               .Bind(c => new Node192())
                               .Bind(c => new Node193(c.Get<Node386>()))
                               .Bind(c => new Node194())
                               .Bind(c => new Node195(c.Get<Node390>()))
                               .Bind(c => new Node196())
                               .Bind(c => new Node197())
                               .Bind(c => new Node198())
                               .Bind(c => new Node199(c.Get<Node398>()))
                               .Bind(c => new Node200(c.Get<Node400>()))
                               .Bind(c => new Node201(c.Get<Node402>()))
                               .Bind(c => new Node202())
                               .Bind(c => new Node203())
                               .Bind(c => new Node204(c.Get<Node408>()))
                               .Bind(c => new Node205(c.Get<Node410>()))
                               .Bind(c => new Node206())
                               .Bind(c => new Node207(c.Get<Node414>()))
                               .Bind(c => new Node208())
                               .Bind(c => new Node209())
                               .Bind(c => new Node210())
                               .Bind(c => new Node211())
                               .Bind(c => new Node212(c.Get<Node424>()))
                               .Bind(c => new Node213())
                               .Bind(c => new Node214())
                               .Bind(c => new Node215())
                               .Bind(c => new Node216(c.Get<Node432>()))
                               .Bind(c => new Node217())
                               .Bind(c => new Node218())
                               .Bind(c => new Node219())
                               .Bind(c => new Node220())
                               .Bind(c => new Node221(c.Get<Node442>()))
                               .Bind(c => new Node222())
                               .Bind(c => new Node223())
                               .Bind(c => new Node224())
                               .Bind(c => new Node225())
                               .Bind(c => new Node226(c.Get<Node452>()))
                               .Bind(c => new Node227())
                               .Bind(c => new Node228())
                               .Bind(c => new Node229())
                               .Bind(c => new Node230())
                               .Bind(c => new Node231())
                               .Bind(c => new Node232())
                               .Bind(c => new Node233())
                               .Bind(c => new Node234())
                               .Bind(c => new Node235())
                               .Bind(c => new Node236(c.Get<Node472>()))
                               .Bind(c => new Node237())
                               .Bind(c => new Node238(c.Get<Node476>()))
                               .Bind(c => new Node239())
                               .Bind(c => new Node240())
                               .Bind(c => new Node241(c.Get<Node482>()))
                               .Bind(c => new Node242())
                               .Bind(c => new Node243(c.Get<Node486>()))
                               .Bind(c => new Node244())
                               .Bind(c => new Node245(c.Get<Node490>()))
                               .Bind(c => new Node246(c.Get<Node492>()))
                               .Bind(c => new Node247())
                               .Bind(c => new Node248())
                               .Bind(c => new Node249())
                               .Bind(c => new Node250())
                               .Bind(c => new Node251())
                               .Bind(c => new Node252())
                               .Bind(c => new Node253())
                               .Bind(c => new Node254())
                               .Bind(c => new Node255())
                               .Bind(c => new Node256())
                               .Bind(c => new Node257())
                               .Bind(c => new Node258())
                               .Bind(c => new Node259())
                               .Bind(c => new Node260())
                               .Bind(c => new Node261())
                               .Bind(c => new Node262())
                               .Bind(c => new Node263())
                               .Bind(c => new Node264())
                               .Bind(c => new Node265())
                               .Bind(c => new Node266())
                               .Bind(c => new Node267())
                               .Bind(c => new Node268())
                               .Bind(c => new Node269())
                               .Bind(c => new Node270())
                               .Bind(c => new Node271())
                               .Bind(c => new Node272())
                               .Bind(c => new Node273())
                               .Bind(c => new Node274())
                               .Bind(c => new Node275())
                               .Bind(c => new Node276())
                               .Bind(c => new Node277())
                               .Bind(c => new Node278())
                               .Bind(c => new Node279())
                               .Bind(c => new Node280())
                               .Bind(c => new Node281())
                               .Bind(c => new Node282())
                               .Bind(c => new Node283())
                               .Bind(c => new Node284())
                               .Bind(c => new Node285())
                               .Bind(c => new Node286())
                               .Bind(c => new Node287())
                               .Bind(c => new Node288())
                               .Bind(c => new Node289())
                               .Bind(c => new Node290())
                               .Bind(c => new Node291())
                               .Bind(c => new Node292())
                               .Bind(c => new Node293())
                               .Bind(c => new Node294())
                               .Bind(c => new Node295())
                               .Bind(c => new Node296())
                               .Bind(c => new Node297())
                               .Bind(c => new Node298())
                               .Bind(c => new Node299())
                               .Bind(c => new Node300())
                               .Bind(c => new Node301())
                               .Bind(c => new Node302())
                               .Bind(c => new Node303())
                               .Bind(c => new Node304())
                               .Bind(c => new Node305())
                               .Bind(c => new Node306())
                               .Bind(c => new Node307())
                               .Bind(c => new Node308())
                               .Bind(c => new Node309())
                               .Bind(c => new Node310())
                               .Bind(c => new Node311())
                               .Bind(c => new Node312())
                               .Bind(c => new Node313())
                               .Bind(c => new Node314())
                               .Bind(c => new Node315())
                               .Bind(c => new Node316())
                               .Bind(c => new Node317())
                               .Bind(c => new Node318())
                               .Bind(c => new Node319())
                               .Bind(c => new Node320())
                               .Bind(c => new Node321())
                               .Bind(c => new Node322())
                               .Bind(c => new Node323())
                               .Bind(c => new Node324())
                               .Bind(c => new Node325())
                               .Bind(c => new Node326())
                               .Bind(c => new Node327())
                               .Bind(c => new Node328())
                               .Bind(c => new Node329())
                               .Bind(c => new Node330())
                               .Bind(c => new Node331())
                               .Bind(c => new Node332())
                               .Bind(c => new Node333())
                               .Bind(c => new Node334())
                               .Bind(c => new Node335())
                               .Bind(c => new Node336())
                               .Bind(c => new Node337())
                               .Bind(c => new Node338())
                               .Bind(c => new Node339())
                               .Bind(c => new Node340())
                               .Bind(c => new Node341())
                               .Bind(c => new Node342())
                               .Bind(c => new Node343())
                               .Bind(c => new Node344())
                               .Bind(c => new Node345())
                               .Bind(c => new Node346())
                               .Bind(c => new Node347())
                               .Bind(c => new Node348())
                               .Bind(c => new Node349())
                               .Bind(c => new Node350())
                               .Bind(c => new Node351())
                               .Bind(c => new Node352())
                               .Bind(c => new Node353())
                               .Bind(c => new Node354())
                               .Bind(c => new Node355())
                               .Bind(c => new Node356())
                               .Bind(c => new Node357())
                               .Bind(c => new Node358())
                               .Bind(c => new Node359())
                               .Bind(c => new Node360())
                               .Bind(c => new Node361())
                               .Bind(c => new Node362())
                               .Bind(c => new Node363())
                               .Bind(c => new Node364())
                               .Bind(c => new Node365())
                               .Bind(c => new Node366())
                               .Bind(c => new Node367())
                               .Bind(c => new Node368())
                               .Bind(c => new Node369())
                               .Bind(c => new Node370())
                               .Bind(c => new Node371())
                               .Bind(c => new Node372())
                               .Bind(c => new Node373())
                               .Bind(c => new Node374())
                               .Bind(c => new Node375())
                               .Bind(c => new Node376())
                               .Bind(c => new Node377())
                               .Bind(c => new Node378())
                               .Bind(c => new Node379())
                               .Bind(c => new Node380())
                               .Bind(c => new Node381())
                               .Bind(c => new Node382())
                               .Bind(c => new Node383())
                               .Bind(c => new Node384())
                               .Bind(c => new Node385())
                               .Bind(c => new Node386())
                               .Bind(c => new Node387())
                               .Bind(c => new Node388())
                               .Bind(c => new Node389())
                               .Bind(c => new Node390())
                               .Bind(c => new Node391())
                               .Bind(c => new Node392())
                               .Bind(c => new Node393())
                               .Bind(c => new Node394())
                               .Bind(c => new Node395())
                               .Bind(c => new Node396())
                               .Bind(c => new Node397())
                               .Bind(c => new Node398())
                               .Bind(c => new Node399())
                               .Bind(c => new Node400())
                               .Bind(c => new Node401())
                               .Bind(c => new Node402())
                               .Bind(c => new Node403())
                               .Bind(c => new Node404())
                               .Bind(c => new Node405())
                               .Bind(c => new Node406())
                               .Bind(c => new Node407())
                               .Bind(c => new Node408())
                               .Bind(c => new Node409())
                               .Bind(c => new Node410())
                               .Bind(c => new Node411())
                               .Bind(c => new Node412())
                               .Bind(c => new Node413())
                               .Bind(c => new Node414())
                               .Bind(c => new Node415())
                               .Bind(c => new Node416())
                               .Bind(c => new Node417())
                               .Bind(c => new Node418())
                               .Bind(c => new Node419())
                               .Bind(c => new Node420())
                               .Bind(c => new Node421())
                               .Bind(c => new Node422())
                               .Bind(c => new Node423())
                               .Bind(c => new Node424())
                               .Bind(c => new Node425())
                               .Bind(c => new Node426())
                               .Bind(c => new Node427())
                               .Bind(c => new Node428())
                               .Bind(c => new Node429())
                               .Bind(c => new Node430())
                               .Bind(c => new Node431())
                               .Bind(c => new Node432())
                               .Bind(c => new Node433())
                               .Bind(c => new Node434())
                               .Bind(c => new Node435())
                               .Bind(c => new Node436())
                               .Bind(c => new Node437())
                               .Bind(c => new Node438())
                               .Bind(c => new Node439())
                               .Bind(c => new Node440())
                               .Bind(c => new Node441())
                               .Bind(c => new Node442())
                               .Bind(c => new Node443())
                               .Bind(c => new Node444())
                               .Bind(c => new Node445())
                               .Bind(c => new Node446())
                               .Bind(c => new Node447())
                               .Bind(c => new Node448())
                               .Bind(c => new Node449())
                               .Bind(c => new Node450())
                               .Bind(c => new Node451())
                               .Bind(c => new Node452())
                               .Bind(c => new Node453())
                               .Bind(c => new Node454())
                               .Bind(c => new Node455())
                               .Bind(c => new Node456())
                               .Bind(c => new Node457())
                               .Bind(c => new Node458())
                               .Bind(c => new Node459())
                               .Bind(c => new Node460())
                               .Bind(c => new Node461())
                               .Bind(c => new Node462())
                               .Bind(c => new Node463())
                               .Bind(c => new Node464())
                               .Bind(c => new Node465())
                               .Bind(c => new Node466())
                               .Bind(c => new Node467())
                               .Bind(c => new Node468())
                               .Bind(c => new Node469())
                               .Bind(c => new Node470())
                               .Bind(c => new Node471())
                               .Bind(c => new Node472())
                               .Bind(c => new Node473())
                               .Bind(c => new Node474())
                               .Bind(c => new Node475())
                               .Bind(c => new Node476())
                               .Bind(c => new Node477())
                               .Bind(c => new Node478())
                               .Bind(c => new Node479())
                               .Bind(c => new Node480())
                               .Bind(c => new Node481())
                               .Bind(c => new Node482())
                               .Bind(c => new Node483())
                               .Bind(c => new Node484())
                               .Bind(c => new Node485())
                               .Bind(c => new Node486())
                               .Bind(c => new Node487())
                               .Bind(c => new Node488())
                               .Bind(c => new Node489())
                               .Bind(c => new Node490())
                               .Bind(c => new Node491())
                               .Bind(c => new Node492())
                               .Bind(c => new Node493())
                               .Bind(c => new Node494())
                               .Bind(c => new Node495())
                               .Bind(c => new Node496())
                               .Bind(c => new Node497())
                               .Bind(c => new Node498())
                               .Bind(c => new Node499());
            return kernel.Get<Node1>();
        }

        private sealed class Module : NinjectModule
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
                this.Bind<Node50>().ToSelf().InSingletonScope();
                this.Bind<Node51>().ToSelf().InSingletonScope();
                this.Bind<Node52>().ToSelf().InSingletonScope();
                this.Bind<Node53>().ToSelf().InSingletonScope();
                this.Bind<Node54>().ToSelf().InSingletonScope();
                this.Bind<Node55>().ToSelf().InSingletonScope();
                this.Bind<Node56>().ToSelf().InSingletonScope();
                this.Bind<Node57>().ToSelf().InSingletonScope();
                this.Bind<Node58>().ToSelf().InSingletonScope();
                this.Bind<Node59>().ToSelf().InSingletonScope();
                this.Bind<Node60>().ToSelf().InSingletonScope();
                this.Bind<Node61>().ToSelf().InSingletonScope();
                this.Bind<Node62>().ToSelf().InSingletonScope();
                this.Bind<Node63>().ToSelf().InSingletonScope();
                this.Bind<Node64>().ToSelf().InSingletonScope();
                this.Bind<Node65>().ToSelf().InSingletonScope();
                this.Bind<Node66>().ToSelf().InSingletonScope();
                this.Bind<Node67>().ToSelf().InSingletonScope();
                this.Bind<Node68>().ToSelf().InSingletonScope();
                this.Bind<Node69>().ToSelf().InSingletonScope();
                this.Bind<Node70>().ToSelf().InSingletonScope();
                this.Bind<Node71>().ToSelf().InSingletonScope();
                this.Bind<Node72>().ToSelf().InSingletonScope();
                this.Bind<Node73>().ToSelf().InSingletonScope();
                this.Bind<Node74>().ToSelf().InSingletonScope();
                this.Bind<Node75>().ToSelf().InSingletonScope();
                this.Bind<Node76>().ToSelf().InSingletonScope();
                this.Bind<Node77>().ToSelf().InSingletonScope();
                this.Bind<Node78>().ToSelf().InSingletonScope();
                this.Bind<Node79>().ToSelf().InSingletonScope();
                this.Bind<Node80>().ToSelf().InSingletonScope();
                this.Bind<Node81>().ToSelf().InSingletonScope();
                this.Bind<Node82>().ToSelf().InSingletonScope();
                this.Bind<Node83>().ToSelf().InSingletonScope();
                this.Bind<Node84>().ToSelf().InSingletonScope();
                this.Bind<Node85>().ToSelf().InSingletonScope();
                this.Bind<Node86>().ToSelf().InSingletonScope();
                this.Bind<Node87>().ToSelf().InSingletonScope();
                this.Bind<Node88>().ToSelf().InSingletonScope();
                this.Bind<Node89>().ToSelf().InSingletonScope();
                this.Bind<Node90>().ToSelf().InSingletonScope();
                this.Bind<Node91>().ToSelf().InSingletonScope();
                this.Bind<Node92>().ToSelf().InSingletonScope();
                this.Bind<Node93>().ToSelf().InSingletonScope();
                this.Bind<Node94>().ToSelf().InSingletonScope();
                this.Bind<Node95>().ToSelf().InSingletonScope();
                this.Bind<Node96>().ToSelf().InSingletonScope();
                this.Bind<Node97>().ToSelf().InSingletonScope();
                this.Bind<Node98>().ToSelf().InSingletonScope();
                this.Bind<Node99>().ToSelf().InSingletonScope();
                this.Bind<Node100>().ToSelf().InSingletonScope();
                this.Bind<Node101>().ToSelf().InSingletonScope();
                this.Bind<Node102>().ToSelf().InSingletonScope();
                this.Bind<Node103>().ToSelf().InSingletonScope();
                this.Bind<Node104>().ToSelf().InSingletonScope();
                this.Bind<Node105>().ToSelf().InSingletonScope();
                this.Bind<Node106>().ToSelf().InSingletonScope();
                this.Bind<Node107>().ToSelf().InSingletonScope();
                this.Bind<Node108>().ToSelf().InSingletonScope();
                this.Bind<Node109>().ToSelf().InSingletonScope();
                this.Bind<Node110>().ToSelf().InSingletonScope();
                this.Bind<Node111>().ToSelf().InSingletonScope();
                this.Bind<Node112>().ToSelf().InSingletonScope();
                this.Bind<Node113>().ToSelf().InSingletonScope();
                this.Bind<Node114>().ToSelf().InSingletonScope();
                this.Bind<Node115>().ToSelf().InSingletonScope();
                this.Bind<Node116>().ToSelf().InSingletonScope();
                this.Bind<Node117>().ToSelf().InSingletonScope();
                this.Bind<Node118>().ToSelf().InSingletonScope();
                this.Bind<Node119>().ToSelf().InSingletonScope();
                this.Bind<Node120>().ToSelf().InSingletonScope();
                this.Bind<Node121>().ToSelf().InSingletonScope();
                this.Bind<Node122>().ToSelf().InSingletonScope();
                this.Bind<Node123>().ToSelf().InSingletonScope();
                this.Bind<Node124>().ToSelf().InSingletonScope();
                this.Bind<Node125>().ToSelf().InSingletonScope();
                this.Bind<Node126>().ToSelf().InSingletonScope();
                this.Bind<Node127>().ToSelf().InSingletonScope();
                this.Bind<Node128>().ToSelf().InSingletonScope();
                this.Bind<Node129>().ToSelf().InSingletonScope();
                this.Bind<Node130>().ToSelf().InSingletonScope();
                this.Bind<Node131>().ToSelf().InSingletonScope();
                this.Bind<Node132>().ToSelf().InSingletonScope();
                this.Bind<Node133>().ToSelf().InSingletonScope();
                this.Bind<Node134>().ToSelf().InSingletonScope();
                this.Bind<Node135>().ToSelf().InSingletonScope();
                this.Bind<Node136>().ToSelf().InSingletonScope();
                this.Bind<Node137>().ToSelf().InSingletonScope();
                this.Bind<Node138>().ToSelf().InSingletonScope();
                this.Bind<Node139>().ToSelf().InSingletonScope();
                this.Bind<Node140>().ToSelf().InSingletonScope();
                this.Bind<Node141>().ToSelf().InSingletonScope();
                this.Bind<Node142>().ToSelf().InSingletonScope();
                this.Bind<Node143>().ToSelf().InSingletonScope();
                this.Bind<Node144>().ToSelf().InSingletonScope();
                this.Bind<Node145>().ToSelf().InSingletonScope();
                this.Bind<Node146>().ToSelf().InSingletonScope();
                this.Bind<Node147>().ToSelf().InSingletonScope();
                this.Bind<Node148>().ToSelf().InSingletonScope();
                this.Bind<Node149>().ToSelf().InSingletonScope();
                this.Bind<Node150>().ToSelf().InSingletonScope();
                this.Bind<Node151>().ToSelf().InSingletonScope();
                this.Bind<Node152>().ToSelf().InSingletonScope();
                this.Bind<Node153>().ToSelf().InSingletonScope();
                this.Bind<Node154>().ToSelf().InSingletonScope();
                this.Bind<Node155>().ToSelf().InSingletonScope();
                this.Bind<Node156>().ToSelf().InSingletonScope();
                this.Bind<Node157>().ToSelf().InSingletonScope();
                this.Bind<Node158>().ToSelf().InSingletonScope();
                this.Bind<Node159>().ToSelf().InSingletonScope();
                this.Bind<Node160>().ToSelf().InSingletonScope();
                this.Bind<Node161>().ToSelf().InSingletonScope();
                this.Bind<Node162>().ToSelf().InSingletonScope();
                this.Bind<Node163>().ToSelf().InSingletonScope();
                this.Bind<Node164>().ToSelf().InSingletonScope();
                this.Bind<Node165>().ToSelf().InSingletonScope();
                this.Bind<Node166>().ToSelf().InSingletonScope();
                this.Bind<Node167>().ToSelf().InSingletonScope();
                this.Bind<Node168>().ToSelf().InSingletonScope();
                this.Bind<Node169>().ToSelf().InSingletonScope();
                this.Bind<Node170>().ToSelf().InSingletonScope();
                this.Bind<Node171>().ToSelf().InSingletonScope();
                this.Bind<Node172>().ToSelf().InSingletonScope();
                this.Bind<Node173>().ToSelf().InSingletonScope();
                this.Bind<Node174>().ToSelf().InSingletonScope();
                this.Bind<Node175>().ToSelf().InSingletonScope();
                this.Bind<Node176>().ToSelf().InSingletonScope();
                this.Bind<Node177>().ToSelf().InSingletonScope();
                this.Bind<Node178>().ToSelf().InSingletonScope();
                this.Bind<Node179>().ToSelf().InSingletonScope();
                this.Bind<Node180>().ToSelf().InSingletonScope();
                this.Bind<Node181>().ToSelf().InSingletonScope();
                this.Bind<Node182>().ToSelf().InSingletonScope();
                this.Bind<Node183>().ToSelf().InSingletonScope();
                this.Bind<Node184>().ToSelf().InSingletonScope();
                this.Bind<Node185>().ToSelf().InSingletonScope();
                this.Bind<Node186>().ToSelf().InSingletonScope();
                this.Bind<Node187>().ToSelf().InSingletonScope();
                this.Bind<Node188>().ToSelf().InSingletonScope();
                this.Bind<Node189>().ToSelf().InSingletonScope();
                this.Bind<Node190>().ToSelf().InSingletonScope();
                this.Bind<Node191>().ToSelf().InSingletonScope();
                this.Bind<Node192>().ToSelf().InSingletonScope();
                this.Bind<Node193>().ToSelf().InSingletonScope();
                this.Bind<Node194>().ToSelf().InSingletonScope();
                this.Bind<Node195>().ToSelf().InSingletonScope();
                this.Bind<Node196>().ToSelf().InSingletonScope();
                this.Bind<Node197>().ToSelf().InSingletonScope();
                this.Bind<Node198>().ToSelf().InSingletonScope();
                this.Bind<Node199>().ToSelf().InSingletonScope();
                this.Bind<Node200>().ToSelf().InSingletonScope();
                this.Bind<Node201>().ToSelf().InSingletonScope();
                this.Bind<Node202>().ToSelf().InSingletonScope();
                this.Bind<Node203>().ToSelf().InSingletonScope();
                this.Bind<Node204>().ToSelf().InSingletonScope();
                this.Bind<Node205>().ToSelf().InSingletonScope();
                this.Bind<Node206>().ToSelf().InSingletonScope();
                this.Bind<Node207>().ToSelf().InSingletonScope();
                this.Bind<Node208>().ToSelf().InSingletonScope();
                this.Bind<Node209>().ToSelf().InSingletonScope();
                this.Bind<Node210>().ToSelf().InSingletonScope();
                this.Bind<Node211>().ToSelf().InSingletonScope();
                this.Bind<Node212>().ToSelf().InSingletonScope();
                this.Bind<Node213>().ToSelf().InSingletonScope();
                this.Bind<Node214>().ToSelf().InSingletonScope();
                this.Bind<Node215>().ToSelf().InSingletonScope();
                this.Bind<Node216>().ToSelf().InSingletonScope();
                this.Bind<Node217>().ToSelf().InSingletonScope();
                this.Bind<Node218>().ToSelf().InSingletonScope();
                this.Bind<Node219>().ToSelf().InSingletonScope();
                this.Bind<Node220>().ToSelf().InSingletonScope();
                this.Bind<Node221>().ToSelf().InSingletonScope();
                this.Bind<Node222>().ToSelf().InSingletonScope();
                this.Bind<Node223>().ToSelf().InSingletonScope();
                this.Bind<Node224>().ToSelf().InSingletonScope();
                this.Bind<Node225>().ToSelf().InSingletonScope();
                this.Bind<Node226>().ToSelf().InSingletonScope();
                this.Bind<Node227>().ToSelf().InSingletonScope();
                this.Bind<Node228>().ToSelf().InSingletonScope();
                this.Bind<Node229>().ToSelf().InSingletonScope();
                this.Bind<Node230>().ToSelf().InSingletonScope();
                this.Bind<Node231>().ToSelf().InSingletonScope();
                this.Bind<Node232>().ToSelf().InSingletonScope();
                this.Bind<Node233>().ToSelf().InSingletonScope();
                this.Bind<Node234>().ToSelf().InSingletonScope();
                this.Bind<Node235>().ToSelf().InSingletonScope();
                this.Bind<Node236>().ToSelf().InSingletonScope();
                this.Bind<Node237>().ToSelf().InSingletonScope();
                this.Bind<Node238>().ToSelf().InSingletonScope();
                this.Bind<Node239>().ToSelf().InSingletonScope();
                this.Bind<Node240>().ToSelf().InSingletonScope();
                this.Bind<Node241>().ToSelf().InSingletonScope();
                this.Bind<Node242>().ToSelf().InSingletonScope();
                this.Bind<Node243>().ToSelf().InSingletonScope();
                this.Bind<Node244>().ToSelf().InSingletonScope();
                this.Bind<Node245>().ToSelf().InSingletonScope();
                this.Bind<Node246>().ToSelf().InSingletonScope();
                this.Bind<Node247>().ToSelf().InSingletonScope();
                this.Bind<Node248>().ToSelf().InSingletonScope();
                this.Bind<Node249>().ToSelf().InSingletonScope();
                this.Bind<Node250>().ToSelf().InSingletonScope();
                this.Bind<Node251>().ToSelf().InSingletonScope();
                this.Bind<Node252>().ToSelf().InSingletonScope();
                this.Bind<Node253>().ToSelf().InSingletonScope();
                this.Bind<Node254>().ToSelf().InSingletonScope();
                this.Bind<Node255>().ToSelf().InSingletonScope();
                this.Bind<Node256>().ToSelf().InSingletonScope();
                this.Bind<Node257>().ToSelf().InSingletonScope();
                this.Bind<Node258>().ToSelf().InSingletonScope();
                this.Bind<Node259>().ToSelf().InSingletonScope();
                this.Bind<Node260>().ToSelf().InSingletonScope();
                this.Bind<Node261>().ToSelf().InSingletonScope();
                this.Bind<Node262>().ToSelf().InSingletonScope();
                this.Bind<Node263>().ToSelf().InSingletonScope();
                this.Bind<Node264>().ToSelf().InSingletonScope();
                this.Bind<Node265>().ToSelf().InSingletonScope();
                this.Bind<Node266>().ToSelf().InSingletonScope();
                this.Bind<Node267>().ToSelf().InSingletonScope();
                this.Bind<Node268>().ToSelf().InSingletonScope();
                this.Bind<Node269>().ToSelf().InSingletonScope();
                this.Bind<Node270>().ToSelf().InSingletonScope();
                this.Bind<Node271>().ToSelf().InSingletonScope();
                this.Bind<Node272>().ToSelf().InSingletonScope();
                this.Bind<Node273>().ToSelf().InSingletonScope();
                this.Bind<Node274>().ToSelf().InSingletonScope();
                this.Bind<Node275>().ToSelf().InSingletonScope();
                this.Bind<Node276>().ToSelf().InSingletonScope();
                this.Bind<Node277>().ToSelf().InSingletonScope();
                this.Bind<Node278>().ToSelf().InSingletonScope();
                this.Bind<Node279>().ToSelf().InSingletonScope();
                this.Bind<Node280>().ToSelf().InSingletonScope();
                this.Bind<Node281>().ToSelf().InSingletonScope();
                this.Bind<Node282>().ToSelf().InSingletonScope();
                this.Bind<Node283>().ToSelf().InSingletonScope();
                this.Bind<Node284>().ToSelf().InSingletonScope();
                this.Bind<Node285>().ToSelf().InSingletonScope();
                this.Bind<Node286>().ToSelf().InSingletonScope();
                this.Bind<Node287>().ToSelf().InSingletonScope();
                this.Bind<Node288>().ToSelf().InSingletonScope();
                this.Bind<Node289>().ToSelf().InSingletonScope();
                this.Bind<Node290>().ToSelf().InSingletonScope();
                this.Bind<Node291>().ToSelf().InSingletonScope();
                this.Bind<Node292>().ToSelf().InSingletonScope();
                this.Bind<Node293>().ToSelf().InSingletonScope();
                this.Bind<Node294>().ToSelf().InSingletonScope();
                this.Bind<Node295>().ToSelf().InSingletonScope();
                this.Bind<Node296>().ToSelf().InSingletonScope();
                this.Bind<Node297>().ToSelf().InSingletonScope();
                this.Bind<Node298>().ToSelf().InSingletonScope();
                this.Bind<Node299>().ToSelf().InSingletonScope();
                this.Bind<Node300>().ToSelf().InSingletonScope();
                this.Bind<Node301>().ToSelf().InSingletonScope();
                this.Bind<Node302>().ToSelf().InSingletonScope();
                this.Bind<Node303>().ToSelf().InSingletonScope();
                this.Bind<Node304>().ToSelf().InSingletonScope();
                this.Bind<Node305>().ToSelf().InSingletonScope();
                this.Bind<Node306>().ToSelf().InSingletonScope();
                this.Bind<Node307>().ToSelf().InSingletonScope();
                this.Bind<Node308>().ToSelf().InSingletonScope();
                this.Bind<Node309>().ToSelf().InSingletonScope();
                this.Bind<Node310>().ToSelf().InSingletonScope();
                this.Bind<Node311>().ToSelf().InSingletonScope();
                this.Bind<Node312>().ToSelf().InSingletonScope();
                this.Bind<Node313>().ToSelf().InSingletonScope();
                this.Bind<Node314>().ToSelf().InSingletonScope();
                this.Bind<Node315>().ToSelf().InSingletonScope();
                this.Bind<Node316>().ToSelf().InSingletonScope();
                this.Bind<Node317>().ToSelf().InSingletonScope();
                this.Bind<Node318>().ToSelf().InSingletonScope();
                this.Bind<Node319>().ToSelf().InSingletonScope();
                this.Bind<Node320>().ToSelf().InSingletonScope();
                this.Bind<Node321>().ToSelf().InSingletonScope();
                this.Bind<Node322>().ToSelf().InSingletonScope();
                this.Bind<Node323>().ToSelf().InSingletonScope();
                this.Bind<Node324>().ToSelf().InSingletonScope();
                this.Bind<Node325>().ToSelf().InSingletonScope();
                this.Bind<Node326>().ToSelf().InSingletonScope();
                this.Bind<Node327>().ToSelf().InSingletonScope();
                this.Bind<Node328>().ToSelf().InSingletonScope();
                this.Bind<Node329>().ToSelf().InSingletonScope();
                this.Bind<Node330>().ToSelf().InSingletonScope();
                this.Bind<Node331>().ToSelf().InSingletonScope();
                this.Bind<Node332>().ToSelf().InSingletonScope();
                this.Bind<Node333>().ToSelf().InSingletonScope();
                this.Bind<Node334>().ToSelf().InSingletonScope();
                this.Bind<Node335>().ToSelf().InSingletonScope();
                this.Bind<Node336>().ToSelf().InSingletonScope();
                this.Bind<Node337>().ToSelf().InSingletonScope();
                this.Bind<Node338>().ToSelf().InSingletonScope();
                this.Bind<Node339>().ToSelf().InSingletonScope();
                this.Bind<Node340>().ToSelf().InSingletonScope();
                this.Bind<Node341>().ToSelf().InSingletonScope();
                this.Bind<Node342>().ToSelf().InSingletonScope();
                this.Bind<Node343>().ToSelf().InSingletonScope();
                this.Bind<Node344>().ToSelf().InSingletonScope();
                this.Bind<Node345>().ToSelf().InSingletonScope();
                this.Bind<Node346>().ToSelf().InSingletonScope();
                this.Bind<Node347>().ToSelf().InSingletonScope();
                this.Bind<Node348>().ToSelf().InSingletonScope();
                this.Bind<Node349>().ToSelf().InSingletonScope();
                this.Bind<Node350>().ToSelf().InSingletonScope();
                this.Bind<Node351>().ToSelf().InSingletonScope();
                this.Bind<Node352>().ToSelf().InSingletonScope();
                this.Bind<Node353>().ToSelf().InSingletonScope();
                this.Bind<Node354>().ToSelf().InSingletonScope();
                this.Bind<Node355>().ToSelf().InSingletonScope();
                this.Bind<Node356>().ToSelf().InSingletonScope();
                this.Bind<Node357>().ToSelf().InSingletonScope();
                this.Bind<Node358>().ToSelf().InSingletonScope();
                this.Bind<Node359>().ToSelf().InSingletonScope();
                this.Bind<Node360>().ToSelf().InSingletonScope();
                this.Bind<Node361>().ToSelf().InSingletonScope();
                this.Bind<Node362>().ToSelf().InSingletonScope();
                this.Bind<Node363>().ToSelf().InSingletonScope();
                this.Bind<Node364>().ToSelf().InSingletonScope();
                this.Bind<Node365>().ToSelf().InSingletonScope();
                this.Bind<Node366>().ToSelf().InSingletonScope();
                this.Bind<Node367>().ToSelf().InSingletonScope();
                this.Bind<Node368>().ToSelf().InSingletonScope();
                this.Bind<Node369>().ToSelf().InSingletonScope();
                this.Bind<Node370>().ToSelf().InSingletonScope();
                this.Bind<Node371>().ToSelf().InSingletonScope();
                this.Bind<Node372>().ToSelf().InSingletonScope();
                this.Bind<Node373>().ToSelf().InSingletonScope();
                this.Bind<Node374>().ToSelf().InSingletonScope();
                this.Bind<Node375>().ToSelf().InSingletonScope();
                this.Bind<Node376>().ToSelf().InSingletonScope();
                this.Bind<Node377>().ToSelf().InSingletonScope();
                this.Bind<Node378>().ToSelf().InSingletonScope();
                this.Bind<Node379>().ToSelf().InSingletonScope();
                this.Bind<Node380>().ToSelf().InSingletonScope();
                this.Bind<Node381>().ToSelf().InSingletonScope();
                this.Bind<Node382>().ToSelf().InSingletonScope();
                this.Bind<Node383>().ToSelf().InSingletonScope();
                this.Bind<Node384>().ToSelf().InSingletonScope();
                this.Bind<Node385>().ToSelf().InSingletonScope();
                this.Bind<Node386>().ToSelf().InSingletonScope();
                this.Bind<Node387>().ToSelf().InSingletonScope();
                this.Bind<Node388>().ToSelf().InSingletonScope();
                this.Bind<Node389>().ToSelf().InSingletonScope();
                this.Bind<Node390>().ToSelf().InSingletonScope();
                this.Bind<Node391>().ToSelf().InSingletonScope();
                this.Bind<Node392>().ToSelf().InSingletonScope();
                this.Bind<Node393>().ToSelf().InSingletonScope();
                this.Bind<Node394>().ToSelf().InSingletonScope();
                this.Bind<Node395>().ToSelf().InSingletonScope();
                this.Bind<Node396>().ToSelf().InSingletonScope();
                this.Bind<Node397>().ToSelf().InSingletonScope();
                this.Bind<Node398>().ToSelf().InSingletonScope();
                this.Bind<Node399>().ToSelf().InSingletonScope();
                this.Bind<Node400>().ToSelf().InSingletonScope();
                this.Bind<Node401>().ToSelf().InSingletonScope();
                this.Bind<Node402>().ToSelf().InSingletonScope();
                this.Bind<Node403>().ToSelf().InSingletonScope();
                this.Bind<Node404>().ToSelf().InSingletonScope();
                this.Bind<Node405>().ToSelf().InSingletonScope();
                this.Bind<Node406>().ToSelf().InSingletonScope();
                this.Bind<Node407>().ToSelf().InSingletonScope();
                this.Bind<Node408>().ToSelf().InSingletonScope();
                this.Bind<Node409>().ToSelf().InSingletonScope();
                this.Bind<Node410>().ToSelf().InSingletonScope();
                this.Bind<Node411>().ToSelf().InSingletonScope();
                this.Bind<Node412>().ToSelf().InSingletonScope();
                this.Bind<Node413>().ToSelf().InSingletonScope();
                this.Bind<Node414>().ToSelf().InSingletonScope();
                this.Bind<Node415>().ToSelf().InSingletonScope();
                this.Bind<Node416>().ToSelf().InSingletonScope();
                this.Bind<Node417>().ToSelf().InSingletonScope();
                this.Bind<Node418>().ToSelf().InSingletonScope();
                this.Bind<Node419>().ToSelf().InSingletonScope();
                this.Bind<Node420>().ToSelf().InSingletonScope();
                this.Bind<Node421>().ToSelf().InSingletonScope();
                this.Bind<Node422>().ToSelf().InSingletonScope();
                this.Bind<Node423>().ToSelf().InSingletonScope();
                this.Bind<Node424>().ToSelf().InSingletonScope();
                this.Bind<Node425>().ToSelf().InSingletonScope();
                this.Bind<Node426>().ToSelf().InSingletonScope();
                this.Bind<Node427>().ToSelf().InSingletonScope();
                this.Bind<Node428>().ToSelf().InSingletonScope();
                this.Bind<Node429>().ToSelf().InSingletonScope();
                this.Bind<Node430>().ToSelf().InSingletonScope();
                this.Bind<Node431>().ToSelf().InSingletonScope();
                this.Bind<Node432>().ToSelf().InSingletonScope();
                this.Bind<Node433>().ToSelf().InSingletonScope();
                this.Bind<Node434>().ToSelf().InSingletonScope();
                this.Bind<Node435>().ToSelf().InSingletonScope();
                this.Bind<Node436>().ToSelf().InSingletonScope();
                this.Bind<Node437>().ToSelf().InSingletonScope();
                this.Bind<Node438>().ToSelf().InSingletonScope();
                this.Bind<Node439>().ToSelf().InSingletonScope();
                this.Bind<Node440>().ToSelf().InSingletonScope();
                this.Bind<Node441>().ToSelf().InSingletonScope();
                this.Bind<Node442>().ToSelf().InSingletonScope();
                this.Bind<Node443>().ToSelf().InSingletonScope();
                this.Bind<Node444>().ToSelf().InSingletonScope();
                this.Bind<Node445>().ToSelf().InSingletonScope();
                this.Bind<Node446>().ToSelf().InSingletonScope();
                this.Bind<Node447>().ToSelf().InSingletonScope();
                this.Bind<Node448>().ToSelf().InSingletonScope();
                this.Bind<Node449>().ToSelf().InSingletonScope();
                this.Bind<Node450>().ToSelf().InSingletonScope();
                this.Bind<Node451>().ToSelf().InSingletonScope();
                this.Bind<Node452>().ToSelf().InSingletonScope();
                this.Bind<Node453>().ToSelf().InSingletonScope();
                this.Bind<Node454>().ToSelf().InSingletonScope();
                this.Bind<Node455>().ToSelf().InSingletonScope();
                this.Bind<Node456>().ToSelf().InSingletonScope();
                this.Bind<Node457>().ToSelf().InSingletonScope();
                this.Bind<Node458>().ToSelf().InSingletonScope();
                this.Bind<Node459>().ToSelf().InSingletonScope();
                this.Bind<Node460>().ToSelf().InSingletonScope();
                this.Bind<Node461>().ToSelf().InSingletonScope();
                this.Bind<Node462>().ToSelf().InSingletonScope();
                this.Bind<Node463>().ToSelf().InSingletonScope();
                this.Bind<Node464>().ToSelf().InSingletonScope();
                this.Bind<Node465>().ToSelf().InSingletonScope();
                this.Bind<Node466>().ToSelf().InSingletonScope();
                this.Bind<Node467>().ToSelf().InSingletonScope();
                this.Bind<Node468>().ToSelf().InSingletonScope();
                this.Bind<Node469>().ToSelf().InSingletonScope();
                this.Bind<Node470>().ToSelf().InSingletonScope();
                this.Bind<Node471>().ToSelf().InSingletonScope();
                this.Bind<Node472>().ToSelf().InSingletonScope();
                this.Bind<Node473>().ToSelf().InSingletonScope();
                this.Bind<Node474>().ToSelf().InSingletonScope();
                this.Bind<Node475>().ToSelf().InSingletonScope();
                this.Bind<Node476>().ToSelf().InSingletonScope();
                this.Bind<Node477>().ToSelf().InSingletonScope();
                this.Bind<Node478>().ToSelf().InSingletonScope();
                this.Bind<Node479>().ToSelf().InSingletonScope();
                this.Bind<Node480>().ToSelf().InSingletonScope();
                this.Bind<Node481>().ToSelf().InSingletonScope();
                this.Bind<Node482>().ToSelf().InSingletonScope();
                this.Bind<Node483>().ToSelf().InSingletonScope();
                this.Bind<Node484>().ToSelf().InSingletonScope();
                this.Bind<Node485>().ToSelf().InSingletonScope();
                this.Bind<Node486>().ToSelf().InSingletonScope();
                this.Bind<Node487>().ToSelf().InSingletonScope();
                this.Bind<Node488>().ToSelf().InSingletonScope();
                this.Bind<Node489>().ToSelf().InSingletonScope();
                this.Bind<Node490>().ToSelf().InSingletonScope();
                this.Bind<Node491>().ToSelf().InSingletonScope();
                this.Bind<Node492>().ToSelf().InSingletonScope();
                this.Bind<Node493>().ToSelf().InSingletonScope();
                this.Bind<Node494>().ToSelf().InSingletonScope();
                this.Bind<Node495>().ToSelf().InSingletonScope();
                this.Bind<Node496>().ToSelf().InSingletonScope();
                this.Bind<Node497>().ToSelf().InSingletonScope();
                this.Bind<Node498>().ToSelf().InSingletonScope();
                this.Bind<Node499>().ToSelf().InSingletonScope();
            }
        }
    }
}
