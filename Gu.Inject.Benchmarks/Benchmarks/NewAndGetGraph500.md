``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.508 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |        Mean |     Error |      StdDev |      Median |  Ratio | RatioSD |    Gen 0 |   Gen 1 | Gen 2 |  Allocated |
|--------------- |------------:|----------:|------------:|------------:|-------:|--------:|---------:|--------:|------:|-----------:|
|        Ninject | 39,631.2 μs | 788.82 μs | 2,119.12 μs | 39,419.0 μs | 190.39 |   10.00 | 230.7692 |       - |     - | 1914.19 KB |
| SimpleInjector | 38,905.3 μs | 774.43 μs | 2,171.58 μs | 37,890.4 μs | 193.89 |   12.36 | 153.8462 | 76.9231 |     - | 1403.03 KB |
|         DryIoc |    842.9 μs |  16.79 μs |    29.41 μs |    837.1 μs |   4.17 |    0.20 |  90.8203 | 21.4844 |     - |  696.24 KB |
|       GuInject |    202.6 μs |   3.88 μs |     4.47 μs |    203.1 μs |   1.00 |    0.00 |  11.4746 |  0.9766 |     - |   88.23 KB |
