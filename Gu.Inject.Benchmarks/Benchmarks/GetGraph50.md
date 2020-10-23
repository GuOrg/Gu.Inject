``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.572 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|        Ninject | 1,199.31 ns | 11.423 ns |  9.539 ns |  2.70 |    0.07 | 0.1354 |     - |     - |    1064 B |
| SimpleInjector |    29.00 ns |  0.570 ns |  1.070 ns |  0.07 |    0.00 |      - |     - |     - |         - |
|         DryIoc | 2,702.25 ns | 16.235 ns | 14.392 ns |  6.08 |    0.13 | 0.3967 |     - |     - |    3120 B |
|       GuInject |   444.70 ns |  8.308 ns |  8.531 ns |  1.00 |    0.00 | 0.0467 |     - |     - |     368 B |
|  GuInjectBound |   440.68 ns |  1.808 ns |  1.510 ns |  0.99 |    0.02 | 0.0467 |     - |     - |     368 B |
