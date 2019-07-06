``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.557 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0


```
|         Method |         Mean |       Error |      StdDev |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------------- |-------------:|------------:|------------:|-------:|--------:|-------:|-------:|------:|----------:|
|       GuInject |     852.5 ns |    16.04 ns |    13.39 ns |   1.00 |    0.00 | 0.2003 |      - |     - |   1.23 KB |
|        Ninject | 490,029.8 ns | 9,327.39 ns | 8,724.85 ns | 574.61 |   12.84 | 6.3477 | 2.9297 |     - |  39.55 KB |
| SimpleInjector | 196,708.7 ns | 3,874.89 ns | 7,085.45 ns | 228.24 |   10.32 | 5.6152 | 0.2441 |     - |  35.36 KB |
