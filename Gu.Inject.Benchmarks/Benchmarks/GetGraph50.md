``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.508 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|        Ninject | 1,442.84 ns | 27.320 ns | 79.261 ns | 16.83 |    1.50 | 0.1354 |     - |     - |    1064 B |
| SimpleInjector |    28.97 ns |  0.574 ns |  0.726 ns |  0.33 |    0.01 |      - |     - |     - |         - |
|         DryIoc | 2,974.61 ns | 59.361 ns | 72.900 ns | 34.16 |    1.22 | 0.3967 |     - |     - |    3120 B |
|       GuInject |    87.30 ns |  1.714 ns |  1.974 ns |  1.00 |    0.00 | 0.0132 |     - |     - |     104 B |
|  GuInjectBound |    77.42 ns |  1.528 ns |  2.467 ns |  0.90 |    0.04 | 0.0173 |     - |     - |     136 B |
