``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.572 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |        Mean |     Error |      StdDev |  Ratio | RatioSD |    Gen 0 |   Gen 1 | Gen 2 |  Allocated |
|--------------- |------------:|----------:|------------:|-------:|--------:|---------:|--------:|------:|-----------:|
|        Ninject | 39,833.0 μs | 925.03 μs | 2,727.48 μs | 361.86 |   27.69 | 214.2857 | 71.4286 |     - | 2112.02 KB |
| SimpleInjector | 36,167.6 μs | 136.91 μs |   114.33 μs | 321.22 |   10.12 | 142.8571 | 71.4286 |     - |  1399.6 KB |
|         DryIoc |    838.1 μs |  16.70 μs |    26.49 μs |   7.41 |    0.33 |  90.8203 | 21.4844 |     - |  696.24 KB |
|       GuInject |    112.7 μs |   2.21 μs |     3.10 μs |   1.00 |    0.00 |  11.5967 |  1.5869 |     - |   89.55 KB |
|  GuInjectBound |    304.9 μs |   3.33 μs |     2.96 μs |   2.71 |    0.09 |  36.6211 |  9.7656 |     - |  282.65 KB |
