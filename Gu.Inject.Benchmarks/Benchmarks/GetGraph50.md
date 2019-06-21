``` ini

BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17763.503 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0


```
|         Method |       Mean |      Error |     StdDev | Ratio | RatioSD | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|--------------- |-----------:|-----------:|-----------:|------:|--------:|------------:|------------:|------------:|--------------------:|
|        Ninject | 1,339.0 ns |  5.7356 ns |  4.4780 ns | 10.86 |    0.04 |      0.1755 |           - |           - |              1112 B |
| SimpleInjector |   609.1 ns | 12.1256 ns | 22.7749 ns |  4.94 |    0.17 |      0.1850 |      0.0010 |           - |              1168 B |
|       GuInject |   123.3 ns |  0.4807 ns |  0.3753 ns |  1.00 |    0.00 |      0.0265 |           - |           - |               168 B |
