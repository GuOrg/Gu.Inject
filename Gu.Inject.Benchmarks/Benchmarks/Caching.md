``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.557 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0


```
|            Method |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 |  Gen 1 |  Gen 2 | Allocated |
|------------------ |----------:|----------:|----------:|------:|--------:|-------:|-------:|-------:|----------:|
|               New |  6.003 ns | 0.1527 ns | 0.1353 ns |  1.00 |    0.00 | 0.0051 |      - |      - |      32 B |
| TryDequeueEnqueue | 36.735 ns | 0.6634 ns | 0.5540 ns |  6.13 |    0.20 | 0.0020 | 0.0011 | 0.0001 |      13 B |
