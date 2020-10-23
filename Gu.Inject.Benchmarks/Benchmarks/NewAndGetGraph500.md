``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.572 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |        Mean |     Error |    StdDev |  Ratio | RatioSD |    Gen 0 |   Gen 1 | Gen 2 |  Allocated |
|--------------- |------------:|----------:|----------:|-------:|--------:|---------:|--------:|------:|-----------:|
|        Ninject | 37,186.2 μs | 491.43 μs | 704.79 μs | 309.08 |   13.01 | 230.7692 | 76.9231 |     - | 2114.66 KB |
| SimpleInjector | 35,988.8 μs |  91.36 μs |  80.99 μs | 301.33 |   10.47 | 142.8571 | 71.4286 |     - | 1399.76 KB |
|         DryIoc |    820.5 μs |   8.78 μs |   6.85 μs |   6.88 |    0.27 |  90.8203 | 21.4844 |     - |  696.24 KB |
|       GuInject |    120.1 μs |   2.38 μs |   4.29 μs |   1.00 |    0.00 |  13.6719 |  1.9531 |     - |  105.59 KB |
|  GuInjectBound |    303.4 μs |   2.74 μs |   2.29 μs |   2.54 |    0.09 |  36.6211 |  9.7656 |     - |   282.5 KB |
