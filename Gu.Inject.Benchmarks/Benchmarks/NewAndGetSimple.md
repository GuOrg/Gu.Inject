``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.572 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |         Mean |       Error |      StdDev |    Ratio | RatioSD |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------------- |-------------:|------------:|------------:|---------:|--------:|-------:|-------:|------:|----------:|
|        Ninject | 884,398.5 ns | 2,969.58 ns | 2,318.46 ns | 1,312.17 |   44.20 | 3.9063 | 1.9531 |     - |  30.68 KB |
| SimpleInjector | 296,309.3 ns | 3,602.18 ns | 3,007.98 ns |   439.78 |   13.42 | 9.2773 | 2.9297 |     - |   72.7 KB |
|         DryIoc |   3,774.2 ns |    65.67 ns |    67.43 ns |     5.60 |    0.22 | 0.5760 |      - |     - |   4.44 KB |
|      Gu.Inject |     672.9 ns |    13.34 ns |    17.81 ns |     1.00 |    0.00 | 0.1783 |      - |     - |   1.37 KB |
|  GuInjectBound |     984.2 ns |    12.89 ns |    11.43 ns |     1.46 |    0.05 | 0.2079 |      - |     - |    1.6 KB |
