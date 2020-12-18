``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.685 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=5.0.101
  [Host]     : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT
  DefaultJob : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT


```
|            Method |        Mean |      Error |    StdDev |  Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------ |------------:|-----------:|----------:|-------:|--------:|--------:|-------:|------:|----------:|
|           Ninject | 5,753.29 μs | 102.763 μs | 96.124 μs | 420.55 |   12.37 | 23.4375 | 7.8125 |     - | 236.56 KB |
|    SimpleInjector | 4,792.88 μs |  95.456 μs | 98.027 μs | 351.03 |   11.29 | 23.4375 | 7.8125 |     - | 201.28 KB |
|            DryIoc |   111.21 μs |   2.779 μs |  8.150 μs |   8.74 |    0.46 |  9.5215 | 0.3662 |     - |  73.59 KB |
| ServiceCollection |    29.17 μs |   0.465 μs |  0.412 μs |   2.14 |    0.07 |  3.5400 | 0.1831 |     - |  27.23 KB |
|          GuInject |    13.65 μs |   0.264 μs |  0.304 μs |   1.00 |    0.00 |  1.1139 | 0.0153 |     - |   8.54 KB |
|     GuInjectBound |    28.01 μs |   0.466 μs |  0.413 μs |   2.05 |    0.06 |  2.9297 | 0.0916 |     - |  22.48 KB |
