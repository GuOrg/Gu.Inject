``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.508 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|                    Method |         Mean |       Error |      StdDev |       Median |    Ratio | RatioSD |  Gen 0 |  Gen 1 |  Gen 2 | Allocated |
|-------------------------- |-------------:|------------:|------------:|-------------:|---------:|--------:|-------:|-------:|-------:|----------:|
|                       New |     2.880 ns |   0.1315 ns |   0.1230 ns |     2.841 ns |     1.00 |    0.00 | 0.0031 |      - |      - |      24 B |
| ConstructorDelegateInvoke |     4.706 ns |   0.1709 ns |   0.2994 ns |     4.599 ns |     1.66 |    0.13 | 0.0031 |      - |      - |      24 B |
| CreateConstructorDelegate | 3,890.188 ns | 124.2352 ns | 360.4289 ns | 3,868.823 ns | 1,440.62 |  114.29 | 0.1526 | 0.0763 | 0.0229 |    1231 B |
|     ConstructorInfoInvoke |    95.487 ns |   1.9430 ns |   2.5264 ns |    95.412 ns |    33.23 |    1.69 | 0.0030 |      - |      - |      24 B |
|   ActivatorCreateInstance |    38.547 ns |   1.0399 ns |   2.8468 ns |    37.691 ns |    13.41 |    1.33 | 0.0030 |      - |      - |      24 B |
