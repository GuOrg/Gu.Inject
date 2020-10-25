``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.572 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |        Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------------- |------------:|-----------:|-----------:|-------:|--------:|--------:|-------:|------:|----------:|
|        Ninject | 4,680.07 μs | 107.631 μs | 315.663 μs | 411.17 |   16.79 | 23.4375 | 7.8125 |     - | 236.54 KB |
| SimpleInjector | 3,804.99 μs |  79.341 μs | 232.694 μs | 330.38 |   13.93 | 23.4375 | 7.8125 |     - | 201.04 KB |
|         DryIoc |    82.99 μs |   1.643 μs |   2.699 μs |   7.46 |    0.25 |  9.5215 | 0.3662 |     - |  73.59 KB |
|       GuInject |    10.99 μs |   0.101 μs |   0.094 μs |   1.00 |    0.00 |  1.1139 | 0.0153 |     - |   8.53 KB |
|  GuInjectBound |    21.83 μs |   0.429 μs |   0.542 μs |   1.97 |    0.04 |  2.9297 | 0.0916 |     - |  22.48 KB |
