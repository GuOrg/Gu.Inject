``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.572 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |        Mean |     Error |      StdDev |  Ratio | RatioSD |    Gen 0 |   Gen 1 | Gen 2 |  Allocated |
|--------------- |------------:|----------:|------------:|-------:|--------:|---------:|--------:|------:|-----------:|
|        Ninject | 39,394.1 μs | 807.61 μs | 2,343.03 μs | 315.90 |   21.22 | 230.7692 | 76.9231 |     - | 2112.81 KB |
| SimpleInjector | 39,756.2 μs | 945.29 μs | 2,787.21 μs | 336.84 |   15.95 | 153.8462 | 76.9231 |     - | 1404.48 KB |
|         DryIoc |    822.6 μs |  16.09 μs |    19.75 μs |   6.46 |    0.17 |  90.8203 | 21.4844 |     - |  696.24 KB |
|       GuInject |    127.6 μs |   1.40 μs |     1.31 μs |   1.00 |    0.00 |  12.9395 |  1.7090 |     - |   99.34 KB |
|  GuInjectBound |    334.1 μs |   7.54 μs |    21.50 μs |   2.62 |    0.19 |  36.6211 | 10.7422 |     - |  282.66 KB |
