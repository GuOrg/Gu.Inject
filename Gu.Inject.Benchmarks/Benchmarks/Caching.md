``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.508 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|            Method |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|               New |  7.278 ns | 0.2152 ns | 0.2113 ns |  1.00 |    0.00 | 0.0041 |     - |     - |      32 B |
| TryDequeueEnqueue | 19.640 ns | 0.4747 ns | 0.6498 ns |  2.69 |    0.10 |      - |     - |     - |         - |
