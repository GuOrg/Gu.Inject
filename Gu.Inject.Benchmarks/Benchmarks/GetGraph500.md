``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.508 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |        Mean |      Error |       StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |------------:|-----------:|-------------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|        Ninject | 1,264.38 ns |  12.720 ns |    11.276 ns | 1,261.58 ns | 0.258 |    0.05 | 0.1354 |     - |     - |    1064 B |
| SimpleInjector |    39.85 ns |   0.766 ns |     1.049 ns |    39.79 ns | 0.009 |    0.00 |      - |     - |     - |         - |
|         DryIoc | 2,851.17 ns |  56.740 ns |   102.313 ns | 2,848.90 ns | 0.652 |    0.13 | 0.3738 |     - |     - |    2960 B |
|       GuInject | 4,281.40 ns | 368.973 ns | 1,003.818 ns | 3,800.00 ns | 1.000 |    0.00 |      - |     - |     - |     168 B |
