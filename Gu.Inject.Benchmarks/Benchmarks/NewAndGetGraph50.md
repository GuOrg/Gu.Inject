``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.557 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0


```
|         Method |        Mean |       Error |      StdDev |  Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------- |------------:|------------:|------------:|-------:|--------:|--------:|--------:|------:|----------:|
|       GuInject |    14.64 us |   0.1118 us |   0.0934 us |   1.00 |    0.00 |  1.2360 |  0.0153 |     - |   7.63 KB |
|        Ninject | 5,798.62 us | 114.5018 us | 127.2685 us | 394.28 |    7.88 | 39.0625 | 15.6250 |     - | 268.94 KB |
| SimpleInjector | 1,389.24 us |  37.0706 us |  30.9556 us |  94.89 |    2.53 | 17.5781 |  1.9531 |     - | 110.63 KB |
