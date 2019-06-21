``` ini

BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17763.503 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0


```
|         Method |        Mean |       Error |     StdDev |  Ratio | RatioSD | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|--------------- |------------:|------------:|-----------:|-------:|--------:|------------:|------------:|------------:|--------------------:|
|        Ninject | 5,594.05 us | 104.0572 us | 97.3351 us | 457.08 |   14.18 |     39.0625 |     15.6250 |           - |           269.38 KB |
| SimpleInjector | 1,309.93 us |  50.2845 us | 88.0692 us | 108.53 |    7.55 |     19.5313 |      1.9531 |           - |           123.96 KB |
|       GuInject |    12.03 us |   0.2395 us |  0.3728 us |   1.00 |    0.00 |      1.2360 |      0.0153 |           - |             7.69 KB |
