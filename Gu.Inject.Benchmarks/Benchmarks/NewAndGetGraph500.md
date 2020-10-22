``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.508 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |        Mean |     Error |      StdDev |  Ratio | RatioSD |    Gen 0 |   Gen 1 | Gen 2 |  Allocated |
|--------------- |------------:|----------:|------------:|-------:|--------:|---------:|--------:|------:|-----------:|
|        Ninject | 38,973.2 μs | 930.58 μs | 2,714.56 μs | 157.20 |   18.84 | 214.2857 |       - |     - | 1939.42 KB |
| SimpleInjector | 37,248.5 μs | 701.33 μs | 1,171.77 μs | 148.25 |   10.50 | 142.8571 | 71.4286 |     - |    1400 KB |
|         DryIoc |    838.0 μs |  16.66 μs |    26.43 μs |   3.33 |    0.25 |  86.9141 | 21.4844 |     - |  666.07 KB |
|       GuInject |    252.6 μs |  10.37 μs |    28.40 μs |   1.00 |    0.00 |        - |       - |     - |   86.74 KB |
