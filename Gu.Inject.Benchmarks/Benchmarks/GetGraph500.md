``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.508 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |         Mean |      Error |       StdDev |       Median |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |-------------:|-----------:|-------------:|-------------:|-------:|--------:|-------:|------:|------:|----------:|
|        Ninject | 18,666.67 ns | 766.082 ns | 2,018.167 ns | 17,900.00 ns | 209.48 |   17.55 |      - |     - |     - |    1064 B |
| SimpleInjector |  1,606.45 ns |  31.673 ns |    72.136 ns |  1,600.00 ns |  18.80 |    1.21 |      - |     - |     - |         - |
|         DryIoc |  2,759.44 ns |  16.314 ns |    13.623 ns |  2,764.16 ns |  31.56 |    0.84 | 0.3967 |     - |     - |    3120 B |
|       GuInject |     87.99 ns |   1.728 ns |     2.185 ns |     87.63 ns |   1.00 |    0.00 | 0.0132 |     - |     - |     104 B |
|  GuInjectBound |     76.06 ns |   0.147 ns |     0.130 ns |     76.04 ns |   0.87 |    0.02 | 0.0173 |     - |     - |     136 B |
