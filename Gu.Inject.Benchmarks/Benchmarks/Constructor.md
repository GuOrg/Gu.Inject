``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.572 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|                    Method |         Mean |      Error |      StdDev |    Ratio | RatioSD |  Gen 0 |  Gen 1 |  Gen 2 | Allocated |
|-------------------------- |-------------:|-----------:|------------:|---------:|--------:|-------:|-------:|-------:|----------:|
|                       New |     2.713 ns |  0.0299 ns |   0.0249 ns |     1.00 |    0.00 | 0.0031 |      - |      - |      24 B |
| ConstructorDelegateInvoke |     4.422 ns |  0.1595 ns |   0.2530 ns |     1.69 |    0.11 | 0.0031 |      - |      - |      24 B |
| CreateConstructorDelegate | 4,087.580 ns | 86.5553 ns | 255.2102 ns | 1,513.31 |   82.97 | 0.1564 | 0.0763 | 0.0229 |    1232 B |
|     ConstructorInfoInvoke |    93.045 ns |  1.8878 ns |   1.9386 ns |    34.33 |    0.79 | 0.0030 |      - |      - |      24 B |
|   ActivatorCreateInstance |    33.821 ns |  0.7750 ns |   1.3161 ns |    12.52 |    0.57 | 0.0030 |      - |      - |      24 B |
