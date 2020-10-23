``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.572 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |       Mean |    Error |   StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |-----------:|---------:|---------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|        Ninject | 1,222.5 ns | 24.17 ns | 41.04 ns | 1,231.5 ns |  2.74 |    0.08 | 0.1354 |     - |     - |    1064 B |
| SimpleInjector | 1,736.4 ns | 32.66 ns | 61.35 ns | 1,700.0 ns |  4.02 |    0.18 |      - |     - |     - |         - |
|         DryIoc | 2,771.4 ns |  6.03 ns |  4.71 ns | 2,772.2 ns |  6.35 |    0.02 | 0.3967 |     - |     - |    3120 B |
|       GuInject |   436.3 ns |  1.05 ns |  0.88 ns |   436.1 ns |  1.00 |    0.00 | 0.0467 |     - |     - |     368 B |
|  GuInjectBound |   439.9 ns |  4.99 ns |  4.16 ns |   438.5 ns |  1.01 |    0.01 | 0.0467 |     - |     - |     368 B |
