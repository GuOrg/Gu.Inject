``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1256 (1909/November2018Update/19H2)
Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.101
  [Host]     : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT
  DefaultJob : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT


```
|            Method |        Mean |      Error |     StdDev |      Median |  Ratio | RatioSD |    Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------ |------------:|-----------:|-----------:|------------:|-------:|--------:|---------:|--------:|------:|----------:|
|           Ninject | 7,748.16 μs | 154.650 μs | 387.986 μs | 7,623.85 μs | 365.83 |   19.79 | 109.3750 | 46.8750 |     - | 239.35 KB |
|    SimpleInjector | 6,592.05 μs | 125.299 μs | 123.060 μs | 6,585.10 μs | 296.92 |   12.70 |  93.7500 | 31.2500 |     - | 202.58 KB |
|            DryIoc |   182.59 μs |   3.631 μs |   6.066 μs |   181.82 μs |   8.25 |    0.33 |  36.1328 |       - |     - |  73.82 KB |
| ServiceCollection |    41.37 μs |   0.809 μs |   0.831 μs |    41.07 μs |   1.86 |    0.09 |  10.0708 |       - |     - |  20.68 KB |
|          GuInject |    22.14 μs |   0.433 μs |   0.622 μs |    22.16 μs |   1.00 |    0.00 |   3.9673 |       - |     - |   8.11 KB |
|     GuInjectBound |    43.76 μs |   0.871 μs |   1.003 μs |    43.59 μs |   1.98 |    0.07 |  10.8032 |       - |     - |  22.06 KB |
