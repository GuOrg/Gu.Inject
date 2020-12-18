``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1256 (1909/November2018Update/19H2)
Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.101
  [Host]     : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT
  DefaultJob : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT


```
|            Method |        Mean |      Error |     StdDev |      Median |  Ratio | RatioSD |    Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------ |------------:|-----------:|-----------:|------------:|-------:|--------:|---------:|--------:|------:|----------:|
|           Ninject | 9,186.02 μs | 180.173 μs | 387.841 μs | 9,174.85 μs | 351.86 |   21.96 | 109.3750 | 46.8750 |     - | 239.35 KB |
|    SimpleInjector | 7,629.20 μs | 151.272 μs | 376.720 μs | 7,508.45 μs | 300.08 |   18.30 |  93.7500 | 31.2500 |     - | 202.78 KB |
|            DryIoc |   227.46 μs |   4.996 μs |  14.172 μs |   225.42 μs |   8.78 |    0.70 |  36.1328 |       - |     - |  73.82 KB |
| ServiceCollection |    49.50 μs |   1.268 μs |   3.617 μs |    49.65 μs |   1.78 |    0.18 |  10.0708 |       - |     - |  20.68 KB |
|          GuInject |    26.41 μs |   0.520 μs |   0.778 μs |    26.35 μs |   1.00 |    0.00 |   4.0283 |       - |     - |   8.27 KB |
|     GuInjectBound |    53.05 μs |   1.051 μs |   1.367 μs |    52.78 μs |   2.01 |    0.08 |  10.8643 |       - |     - |  22.22 KB |
