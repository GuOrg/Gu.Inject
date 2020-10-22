``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.508 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |        Mean |     Error |     StdDev | Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------------- |------------:|----------:|-----------:|------:|--------:|--------:|-------:|------:|----------:|
|        Ninject | 4,543.02 μs | 90.209 μs | 236.062 μs | 88.23 |    5.28 | 23.4375 | 7.8125 |     - | 236.55 KB |
| SimpleInjector | 3,697.70 μs | 71.428 μs | 191.887 μs | 74.12 |    4.52 | 23.4375 | 7.8125 |     - | 201.04 KB |
|         DryIoc |    91.06 μs |  1.742 μs |   4.914 μs |  1.82 |    0.10 |  9.5215 | 0.3662 |     - |  73.59 KB |
|       GuInject |    50.48 μs |  1.007 μs |   1.378 μs |  1.00 |    0.00 |  2.0142 | 0.0610 |     - |   15.6 KB |
|  GuInjectBound | 1,067.76 μs | 21.025 μs |  25.820 μs | 21.14 |    0.72 |  5.8594 |      - |     - |  50.07 KB |
