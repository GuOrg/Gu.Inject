``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.572 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|                       Method |      Mean |    Error |   StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |----------:|---------:|---------:|-------:|------:|------:|----------:|
|              GetConstructors |  36.56 ns | 0.222 ns | 0.197 ns | 0.0041 |     - |     - |      32 B |
| GetConstructorsGetParameters |  40.33 ns | 0.847 ns | 1.008 ns | 0.0041 |     - |     - |      32 B |
|                   InvokeCtor |  91.59 ns | 1.795 ns | 1.679 ns | 0.0030 |     - |     - |      24 B |
|      ActivatorCreateInstance |  33.34 ns | 0.745 ns | 0.995 ns | 0.0030 |     - |     - |      24 B |
|         GetConstructorInvoke | 148.11 ns | 3.019 ns | 3.594 ns | 0.0069 |     - |     - |      56 B |
