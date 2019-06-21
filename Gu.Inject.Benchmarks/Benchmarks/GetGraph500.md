``` ini

BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17763.503 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0


```
|         Method |     Mean |     Error |    StdDev |   Median | Ratio | RatioSD | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|--------------- |---------:|----------:|----------:|---------:|------:|--------:|------------:|------------:|------------:|--------------------:|
|        Ninject | 1.389 us | 0.0275 us | 0.0503 us | 1.385 us |  0.46 |    0.06 |      0.1755 |           - |           - |              1112 B |
| SimpleInjector | 5.435 us | 0.0111 us | 0.0087 us | 5.433 us |  1.78 |    0.28 |      1.7014 |      0.0763 |           - |             10744 B |
|       GuInject | 2.990 us | 0.1625 us | 0.4280 us | 2.800 us |  1.00 |    0.00 |           - |           - |           - |                   - |
