``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.685 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=5.0.101
  [Host]     : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT
  DefaultJob : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT


```
|            Method |        Mean |     Error |     StdDev |  Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------ |------------:|----------:|-----------:|-------:|--------:|--------:|-------:|------:|----------:|
|           Ninject | 5,822.14 μs | 49.910 μs |  46.686 μs | 434.34 |   20.15 | 23.4375 | 7.8125 |     - | 236.55 KB |
|    SimpleInjector | 4,584.39 μs | 91.151 μs | 162.021 μs | 349.72 |   17.48 | 23.4375 | 7.8125 |     - | 201.28 KB |
|            DryIoc |   116.87 μs |  2.129 μs |   1.991 μs |   8.72 |    0.44 |  9.5215 | 0.3662 |     - |  73.59 KB |
| ServiceCollection |    33.12 μs |  0.650 μs |   1.050 μs |   2.53 |    0.15 |  3.5400 | 0.2136 |     - |  27.23 KB |
|          GuInject |    13.14 μs |  0.261 μs |   0.532 μs |   1.00 |    0.00 |  1.1292 | 0.0153 |     - |   8.69 KB |
|     GuInjectBound |    25.65 μs |  0.510 μs |   0.809 μs |   1.96 |    0.10 |  2.9297 | 0.0916 |     - |  22.63 KB |
