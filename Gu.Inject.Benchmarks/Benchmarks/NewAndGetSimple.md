``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.572 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |         Mean |       Error |       StdDev |       Median |    Ratio | RatioSD |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------------- |-------------:|------------:|-------------:|-------------:|---------:|--------:|-------:|-------:|------:|----------:|
|        Ninject | 899,464.7 ns | 7,520.88 ns |  8,953.07 ns | 896,834.4 ns | 1,027.13 |   51.80 | 3.9063 | 1.9531 |     - |   31432 B |
| SimpleInjector | 312,891.1 ns | 6,141.63 ns | 10,090.87 ns | 312,643.3 ns |   359.12 |   21.22 | 9.2773 | 2.9297 |     - |   74450 B |
|         DryIoc |   3,915.5 ns |    77.73 ns |    168.97 ns |   3,881.6 ns |     4.52 |    0.24 | 0.5722 |      - |     - |    4544 B |
|      Gu.Inject |     863.7 ns |    17.17 ns |     35.46 ns |     846.9 ns |     1.00 |    0.00 | 0.1049 |      - |     - |     824 B |
|  GuInjectBound |   1,151.9 ns |    22.31 ns |     21.91 ns |   1,148.9 ns |     1.34 |    0.06 | 0.1354 |      - |     - |    1064 B |
