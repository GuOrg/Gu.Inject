``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.508 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |        Mean |     Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |------------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|        Ninject | 1,288.16 ns | 24.227 ns |  23.794 ns |  0.38 |    0.02 | 0.1354 |     - |     - |    1064 B |
| SimpleInjector |    40.48 ns |  0.791 ns |   1.083 ns |  0.01 |    0.00 |      - |     - |     - |         - |
|         DryIoc | 3,064.19 ns | 60.782 ns |  67.559 ns |  0.91 |    0.05 | 0.3738 |     - |     - |    2960 B |
|       GuInject | 3,301.14 ns | 81.370 ns | 224.117 ns |  1.00 |    0.00 |      - |     - |     - |     168 B |
