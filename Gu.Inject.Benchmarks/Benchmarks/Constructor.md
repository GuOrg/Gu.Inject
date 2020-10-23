``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.572 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|                    Method |         Mean |       Error |      StdDev |    Ratio | RatioSD |  Gen 0 |  Gen 1 |  Gen 2 | Allocated |
|-------------------------- |-------------:|------------:|------------:|---------:|--------:|-------:|-------:|-------:|----------:|
|                       New |     2.654 ns |   0.0443 ns |   0.0346 ns |     1.00 |    0.00 | 0.0031 |      - |      - |      24 B |
| ConstructorDelegateInvoke |     4.243 ns |   0.0787 ns |   0.0698 ns |     1.60 |    0.03 | 0.0031 |      - |      - |      24 B |
| CreateConstructorDelegate | 4,098.108 ns | 102.6304 ns | 299.3777 ns | 1,570.75 |  106.28 | 0.1564 | 0.0763 | 0.0191 |    1232 B |
|     ConstructorInfoInvoke |    97.390 ns |   2.0170 ns |   3.3699 ns |    37.17 |    1.37 | 0.0030 |      - |      - |      24 B |
|   ActivatorCreateInstance |    34.328 ns |   0.6203 ns |   0.5802 ns |    12.96 |    0.28 | 0.0030 |      - |      - |      24 B |
