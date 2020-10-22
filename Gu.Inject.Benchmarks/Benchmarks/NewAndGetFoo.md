``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.508 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |       Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------------- |-----------:|-----------:|-----------:|-------:|--------:|-------:|-------:|------:|----------:|
|        Ninject | 867.210 μs | 17.0758 μs | 38.1924 μs | 104.93 |    4.40 | 3.9063 | 1.9531 |     - |   31706 B |
| SimpleInjector | 334.798 μs |  6.6291 μs | 12.7721 μs |  41.59 |    1.92 | 9.2773 | 2.9297 |     - |   74556 B |
|         DryIoc |   3.936 μs |  0.0770 μs |  0.1503 μs |   0.48 |    0.02 | 0.5569 |      - |     - |    4384 B |
|       GuInject |   8.173 μs |  0.1101 μs |  0.1352 μs |   1.00 |    0.00 |      - |      - |     - |     816 B |
