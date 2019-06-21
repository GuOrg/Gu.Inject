``` ini

BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17763.503 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0


```
|         Method |        Mean |        Error |        StdDev |  Ratio | RatioSD | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|--------------- |------------:|-------------:|--------------:|-------:|--------:|------------:|------------:|------------:|--------------------:|
|        Ninject | 51,574.4 us | 1,260.466 us | 1,294.4053 us | 263.47 |    7.64 |    300.0000 |    100.0000 |           - |          2284.03 KB |
| SimpleInjector | 12,074.3 us |   240.943 us |   486.7171 us |  63.48 |    3.22 |    125.0000 |     62.5000 |           - |           785.65 KB |
|       GuInject |    195.8 us |     1.055 us |     0.9869 us |   1.00 |    0.00 |     14.4043 |      1.2207 |           - |            89.55 KB |
