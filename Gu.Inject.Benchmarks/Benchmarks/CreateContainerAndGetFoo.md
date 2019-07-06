``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.557 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0


```
|         Method |         Mean |         Error |        StdDev |       Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------------- |-------------:|--------------:|--------------:|-------------:|-------:|--------:|-------:|-------:|------:|----------:|
|       GuInject |     755.7 ns |      4.907 ns |      4.350 ns |     754.8 ns |   1.00 |    0.00 | 0.2012 |      - |     - |   1.24 KB |
|        Ninject | 527,356.1 ns | 17,909.189 ns | 49,923.661 ns | 511,506.5 ns | 699.96 |   94.10 | 8.3008 | 3.4180 |     - |  52.39 KB |
| SimpleInjector | 197,287.4 ns |  3,856.007 ns |  5,147.658 ns | 198,907.8 ns | 260.82 |    7.63 | 5.6152 | 0.2441 |     - |  34.61 KB |
