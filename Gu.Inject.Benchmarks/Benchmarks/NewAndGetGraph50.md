``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1256 (1909/November2018Update/19H2)
Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.101
  [Host]     : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT
  DefaultJob : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT


```
|            Method |        Mean |      Error |     StdDev |  Ratio | RatioSD |    Gen 0 |   Gen 1 |  Gen 2 | Allocated |
|------------------ |------------:|-----------:|-----------:|-------:|--------:|---------:|--------:|-------:|----------:|
|           Ninject | 7,589.79 μs | 138.529 μs | 129.580 μs | 318.45 |   17.06 | 109.3750 | 54.6875 | 7.8125 |  238.6 KB |
|    SimpleInjector | 6,621.45 μs |  88.644 μs |  78.580 μs | 279.44 |   11.08 |  93.7500 | 31.2500 |      - | 202.72 KB |
|            DryIoc |   182.76 μs |   3.244 μs |   3.035 μs |   7.67 |    0.39 |  36.1328 |       - |      - |  73.82 KB |
| ServiceCollection |    42.68 μs |   0.838 μs |   0.784 μs |   1.79 |    0.10 |  10.0708 |       - |      - |  20.68 KB |
|          GuInject |    23.61 μs |   0.437 μs |   0.923 μs |   1.00 |    0.00 |   4.0283 |       - |      - |   8.27 KB |
|     GuInjectBound |    32.50 μs |   0.482 μs |   0.963 μs |   1.38 |    0.06 |  10.8643 |       - |      - |  22.22 KB |
