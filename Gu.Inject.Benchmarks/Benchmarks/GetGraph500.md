``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.572 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|        Ninject | 1,188.89 ns | 20.592 ns | 22.888 ns |  2.65 |    0.06 | 0.1354 |     - |     - |    1064 B |
| SimpleInjector |    27.33 ns |  0.493 ns |  0.548 ns |  0.06 |    0.00 |      - |     - |     - |         - |
|         DryIoc | 2,753.46 ns | 17.655 ns | 14.743 ns |  6.16 |    0.14 | 0.3967 |     - |     - |    3120 B |
|       GuInject |   449.31 ns |  8.902 ns |  9.525 ns |  1.00 |    0.00 | 0.0467 |     - |     - |     368 B |
|  GuInjectBound |   445.76 ns |  7.572 ns | 10.859 ns |  0.99 |    0.03 | 0.0467 |     - |     - |     368 B |
