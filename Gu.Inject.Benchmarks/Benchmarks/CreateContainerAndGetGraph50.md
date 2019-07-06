``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.557 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0


```
|         Method |        Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------------- |------------:|-----------:|-----------:|-------:|--------:|--------:|-------:|------:|----------:|
|       GuInject |    13.47 us |  0.0464 us |  0.0362 us |   1.00 |    0.00 |  1.2360 | 0.0153 |     - |   7.64 KB |
|         DryIoc |    28.61 us |  0.3434 us |  0.2867 us |   2.13 |    0.02 |  4.3945 | 0.0916 |     - |  27.06 KB |
|        Ninject | 5,593.27 us | 95.4618 us | 89.2951 us | 414.91 |    7.29 | 31.2500 | 7.8125 |     - | 241.06 KB |
| SimpleInjector | 4,530.76 us | 20.1659 us | 16.8394 us | 336.04 |    1.10 | 23.4375 | 7.8125 |     - | 184.88 KB |
