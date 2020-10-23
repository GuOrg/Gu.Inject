``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.572 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |        Mean |     Error |     StdDev |      Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------- |------------:|----------:|-----------:|------------:|------:|--------:|--------:|--------:|------:|----------:|
|        Ninject | 4,407.45 μs | 83.739 μs | 163.327 μs | 4,310.07 μs | 90.26 |    4.43 | 23.4375 |  7.8125 |     - | 236.54 KB |
| SimpleInjector | 3,609.33 μs | 70.307 μs | 123.138 μs | 3,572.71 μs | 72.93 |    3.44 | 23.4375 | 11.7188 |     - |  201.1 KB |
|         DryIoc |    82.62 μs |  1.643 μs |   1.956 μs |    82.30 μs |  1.68 |    0.06 |  9.5215 |  0.3662 |     - |  73.59 KB |
|       GuInject |    49.16 μs |  0.791 μs |   0.812 μs |    49.11 μs |  1.00 |    0.00 |  2.3193 |  0.0610 |     - |  18.18 KB |
|  GuInjectBound |   103.06 μs |  1.333 μs |   1.247 μs |   103.25 μs |  2.10 |    0.05 |  5.2490 |  0.1221 |     - |  40.23 KB |
