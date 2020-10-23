``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.572 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |------------:|----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|        Ninject | 1,290.99 ns | 25.426 ns | 39.586 ns | 1,266.18 ns |  2.92 |    0.11 | 0.1354 |     - |     - |    1064 B |
| SimpleInjector |    26.96 ns |  0.057 ns |  0.047 ns |    26.95 ns |  0.06 |    0.00 |      - |     - |     - |         - |
|         DryIoc | 2,759.42 ns | 25.776 ns | 21.524 ns | 2,750.53 ns |  6.26 |    0.13 | 0.3967 |     - |     - |    3120 B |
|       GuInject |   441.59 ns |  8.475 ns |  9.068 ns |   439.09 ns |  1.00 |    0.00 | 0.0467 |     - |     - |     368 B |
|  GuInjectBound |   440.97 ns |  8.501 ns |  9.449 ns |   436.27 ns |  1.00 |    0.03 | 0.0467 |     - |     - |     368 B |
