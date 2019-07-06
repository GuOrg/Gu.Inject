``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.557 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0


```
|         Method |        Mean |        Error |       StdDev |      Median |  Ratio | RatioSD |    Gen 0 |    Gen 1 | Gen 2 |  Allocated |
|--------------- |------------:|-------------:|-------------:|------------:|-------:|--------:|---------:|---------:|------:|-----------:|
|       GuInject |    158.5 us |     1.969 us |     1.745 us |    158.4 us |   1.00 |    0.00 |  11.7188 |   1.2207 |     - |   72.79 KB |
|        Ninject | 57,474.3 us | 1,414.180 us | 4,080.232 us | 55,458.6 us | 401.05 |   18.28 | 333.3333 | 111.1111 |     - | 2304.92 KB |
| SimpleInjector | 13,017.0 us |   263.507 us |   665.917 us | 12,778.4 us |  86.48 |    5.11 | 125.0000 |  62.5000 |     - |  782.26 KB |
