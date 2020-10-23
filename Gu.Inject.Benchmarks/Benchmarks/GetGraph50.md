``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.572 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|        Ninject | 1,290.96 ns | 25.143 ns | 42.009 ns |  2.85 |    0.13 | 0.1354 |     - |     - |    1064 B |
| SimpleInjector |    27.44 ns |  0.517 ns |  0.483 ns |  0.06 |    0.00 |      - |     - |     - |         - |
|         DryIoc | 2,825.33 ns | 56.287 ns | 82.504 ns |  6.25 |    0.31 | 0.3967 |     - |     - |    3120 B |
|       GuInject |   452.94 ns |  8.993 ns | 14.263 ns |  1.00 |    0.00 | 0.0467 |     - |     - |     368 B |
|  GuInjectBound |   445.49 ns |  8.841 ns | 13.232 ns |  0.99 |    0.05 | 0.0467 |     - |     - |     368 B |
