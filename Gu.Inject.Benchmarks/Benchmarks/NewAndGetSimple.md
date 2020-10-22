``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.508 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |         Mean |        Error |       StdDev |    Ratio | RatioSD |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------------- |-------------:|-------------:|-------------:|---------:|--------:|-------:|-------:|------:|----------:|
|        Ninject | 977,517.2 ns | 19,530.87 ns | 44,084.43 ns | 1,215.13 |   53.05 | 3.9063 | 1.9531 |     - |   31432 B |
| SimpleInjector | 308,241.5 ns |  6,110.65 ns | 11,918.36 ns |   388.29 |   16.17 | 9.2773 | 2.9297 |     - |   74462 B |
|         DryIoc |   4,037.2 ns |     79.15 ns |    116.01 ns |     4.90 |    0.18 | 0.5722 |      - |     - |    4544 B |
|      Gu.Inject |     822.8 ns |     11.47 ns |     10.17 ns |     1.00 |    0.00 | 0.0954 |      - |     - |     752 B |
|  GuInjectBound |   1,465.5 ns |     27.03 ns |     42.09 ns |     1.79 |    0.06 | 0.1621 |      - |     - |    1280 B |
