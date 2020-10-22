``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.508 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |        Mean |     Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |------------:|----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|        Ninject | 1,253.58 ns | 20.967 ns |  16.369 ns | 1,248.23 ns |  0.35 |    0.02 | 0.1335 |     - |     - |    1064 B |
| SimpleInjector |    41.31 ns |  0.708 ns |   0.662 ns |    41.19 ns |  0.01 |    0.00 |      - |     - |     - |         - |
|         DryIoc | 2,977.87 ns | 82.147 ns | 230.349 ns | 2,894.96 ns |  0.88 |    0.07 | 0.3738 |     - |     - |    2960 B |
|       GuInject | 3,438.60 ns | 68.314 ns | 148.510 ns | 3,400.00 ns |  1.00 |    0.00 |      - |     - |     - |     168 B |
