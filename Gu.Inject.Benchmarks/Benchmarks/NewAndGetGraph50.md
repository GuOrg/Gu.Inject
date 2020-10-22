``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.508 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |        Mean |     Error |     StdDev |      Median | Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------------- |------------:|----------:|-----------:|------------:|------:|--------:|--------:|-------:|------:|----------:|
|        Ninject | 4,525.25 μs | 91.034 μs | 264.105 μs | 4,435.61 μs | 67.94 |    2.99 | 23.4375 | 7.8125 |     - | 224.08 KB |
| SimpleInjector | 3,764.81 μs | 74.764 μs | 195.645 μs | 3,747.81 μs | 57.76 |    4.84 | 23.4375 | 7.8125 |     - | 201.15 KB |
|         DryIoc |    82.58 μs |  1.650 μs |   4.288 μs |    81.94 μs |  1.30 |    0.07 |  9.1553 | 0.3662 |     - |  70.31 KB |
|       GuInject |    65.48 μs |  1.260 μs |   1.401 μs |    65.30 μs |  1.00 |    0.00 |       - |      - |     - |  16.49 KB |
