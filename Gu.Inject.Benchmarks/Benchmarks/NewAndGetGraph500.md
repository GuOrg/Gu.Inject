``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.572 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |        Mean |     Error |    StdDev |  Ratio | RatioSD |    Gen 0 |   Gen 1 | Gen 2 |  Allocated |
|--------------- |------------:|----------:|----------:|-------:|--------:|---------:|--------:|------:|-----------:|
|        Ninject | 37,772.0 μs | 666.45 μs | 556.52 μs | 177.32 |    5.58 | 214.2857 | 71.4286 |     - |  2106.3 KB |
| SimpleInjector | 37,619.8 μs | 495.48 μs | 413.75 μs | 176.59 |    4.67 | 142.8571 | 71.4286 |     - | 1399.61 KB |
|         DryIoc |    870.9 μs |  13.23 μs |  11.73 μs |   4.10 |    0.16 |  90.8203 | 22.4609 |     - |  696.24 KB |
|       GuInject |    211.6 μs |   4.19 μs |   6.14 μs |   1.00 |    0.00 |  14.1602 |  1.4648 |     - |  109.47 KB |
|  GuInjectBound |    423.3 μs |   8.37 μs |  14.88 μs |   2.01 |    0.09 |  35.1563 |  6.8359 |     - |  271.57 KB |
