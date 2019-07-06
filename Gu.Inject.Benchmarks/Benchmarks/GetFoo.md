``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.557 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0


```
|         Method |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|       GuInject |   385.42 ns | 3.5837 ns | 2.7979 ns |  1.00 |    0.00 | 0.0100 |     - |     - |      64 B |
|        Ninject | 1,337.34 ns | 8.5022 ns | 7.9529 ns |  3.47 |    0.04 | 0.1755 |     - |     - |    1112 B |
| SimpleInjector |    51.02 ns | 0.4304 ns | 0.3816 ns |  0.13 |    0.00 | 0.0038 |     - |     - |      24 B |
