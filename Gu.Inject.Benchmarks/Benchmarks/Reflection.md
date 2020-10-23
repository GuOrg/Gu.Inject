``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.572 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|                       Method |      Mean |    Error |   StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |----------:|---------:|---------:|-------:|------:|------:|----------:|
|              GetConstructors |  36.61 ns | 0.174 ns | 0.146 ns | 0.0041 |     - |     - |      32 B |
| GetConstructorsGetParameters |  40.15 ns | 0.871 ns | 0.856 ns | 0.0041 |     - |     - |      32 B |
|                   InvokeCtor |  91.84 ns | 1.247 ns | 1.042 ns | 0.0030 |     - |     - |      24 B |
|      ActivatorCreateInstance |  35.82 ns | 0.781 ns | 1.389 ns | 0.0030 |     - |     - |      24 B |
|         GetConstructorInvoke | 150.26 ns | 3.030 ns | 5.615 ns | 0.0069 |     - |     - |      56 B |
