``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.508 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|        Ninject | 1,296.79 ns | 25.743 ns | 54.860 ns | 14.87 |    0.57 | 0.1354 |     - |     - |    1064 B |
| SimpleInjector |    28.62 ns |  0.570 ns |  1.013 ns |  0.32 |    0.01 |      - |     - |     - |         - |
|         DryIoc | 2,800.07 ns | 55.336 ns | 65.873 ns | 32.43 |    1.10 | 0.3967 |     - |     - |    3120 B |
|       GuInject |    86.65 ns |  1.725 ns |  1.529 ns |  1.00 |    0.00 | 0.0132 |     - |     - |     104 B |
|  GuInjectBound |    78.49 ns |  1.278 ns |  1.133 ns |  0.91 |    0.02 | 0.0173 |     - |     - |     136 B |
