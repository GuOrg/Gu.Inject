``` ini

BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17763.503 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0


```
|         Method |       Mean |      Error |     StdDev |  Ratio | RatioSD | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|--------------- |-----------:|-----------:|-----------:|-------:|--------:|------------:|------------:|------------:|--------------------:|
|        Ninject | 496.883 us | 13.0313 us | 38.0129 us | 475.26 |   44.44 |      5.8594 |      1.9531 |           - |             40945 B |
| SimpleInjector | 216.128 us |  2.2669 us |  1.7699 us | 203.46 |    6.64 |      8.3008 |      2.6855 |           - |             52735 B |
|       GuInject |   1.068 us |  0.0211 us |  0.0374 us |   1.00 |    0.00 |      0.1297 |      0.0038 |           - |               829 B |
