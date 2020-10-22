``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.508 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |        Mean |     Error |      StdDev |      Median |  Ratio | RatioSD |    Gen 0 |   Gen 1 | Gen 2 |  Allocated |
|--------------- |------------:|----------:|------------:|------------:|-------:|--------:|---------:|--------:|------:|-----------:|
|        Ninject | 36,935.9 μs | 714.92 μs |   668.73 μs | 36,711.3 μs | 196.59 |    3.70 | 214.2857 | 71.4286 |     - | 2106.32 KB |
| SimpleInjector | 37,206.3 μs | 673.06 μs | 1,491.46 μs | 36,551.7 μs | 203.27 |   11.54 | 153.8462 | 76.9231 |     - | 1403.99 KB |
|         DryIoc |    863.0 μs |  17.24 μs |    41.97 μs |    859.8 μs |   4.72 |    0.24 |  89.8438 | 21.4844 |     - |  696.26 KB |
|       GuInject |    188.2 μs |   0.98 μs |     0.87 μs |    187.9 μs |   1.00 |    0.00 |  11.4746 |  0.9766 |     - |   88.23 KB |
|  GuInjectBound |  9,677.9 μs | 192.33 μs |   293.71 μs |  9,612.1 μs |  51.28 |    1.93 |  31.2500 |       - |     - |  315.46 KB |
