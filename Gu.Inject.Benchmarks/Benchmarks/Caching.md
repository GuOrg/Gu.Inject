``` ini

BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17763.503 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0


```
|            Method |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|------------------ |----------:|----------:|----------:|----------:|------:|--------:|------------:|------------:|------------:|--------------------:|
|               New |  6.695 ns | 0.2021 ns | 0.2962 ns |  6.671 ns |  1.00 |    0.00 |      0.0051 |           - |           - |                32 B |
| TryDequeueEnqueue | 37.997 ns | 0.8285 ns | 1.7655 ns | 37.359 ns |  5.63 |    0.37 |      0.0020 |      0.0011 |      0.0001 |                13 B |
