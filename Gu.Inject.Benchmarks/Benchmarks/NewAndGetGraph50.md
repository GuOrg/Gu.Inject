``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.685 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=5.0.101
  [Host]     : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT
  DefaultJob : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT


```
|            Method |        Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------ |------------:|-----------:|-----------:|-------:|--------:|--------:|--------:|------:|----------:|
|           Ninject | 6,370.17 μs | 121.486 μs | 139.904 μs | 500.51 |   20.65 | 23.4375 |  7.8125 |     - | 236.55 KB |
|    SimpleInjector | 4,650.18 μs |  92.088 μs | 209.732 μs | 365.50 |   17.65 | 23.4375 | 11.7188 |     - | 201.32 KB |
|            DryIoc |    95.16 μs |   1.879 μs |   3.709 μs |   7.50 |    0.41 |  9.5215 |  0.3662 |     - |  73.59 KB |
| ServiceCollection |    27.23 μs |   0.401 μs |   0.375 μs |   2.14 |    0.03 |  3.5400 |  0.2136 |     - |  27.23 KB |
|          GuInject |    12.72 μs |   0.250 μs |   0.390 μs |   1.00 |    0.00 |  1.1292 |  0.0153 |     - |   8.69 KB |
|     GuInjectBound |    25.30 μs |   0.502 μs |   0.968 μs |   1.99 |    0.11 |  2.9297 |  0.0916 |     - |  22.63 KB |
