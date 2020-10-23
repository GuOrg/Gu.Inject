``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.572 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |------------:|----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|        Ninject | 1,200.13 ns |  4.711 ns |  3.934 ns | 1,199.98 ns |  2.69 |    0.09 | 0.1354 |     - |     - |    1064 B |
| SimpleInjector |    29.81 ns |  0.596 ns |  1.044 ns |    29.33 ns |  0.07 |    0.00 |      - |     - |     - |         - |
|         DryIoc | 2,754.29 ns | 18.878 ns | 15.764 ns | 2,759.23 ns |  6.17 |    0.20 | 0.3967 |     - |     - |    3120 B |
|       GuInject |   446.72 ns |  8.800 ns | 13.701 ns |   442.20 ns |  1.00 |    0.00 | 0.0467 |     - |     - |     368 B |
|  GuInjectBound |   436.44 ns |  2.668 ns |  2.365 ns |   435.83 ns |  0.98 |    0.03 | 0.0467 |     - |     - |     368 B |
