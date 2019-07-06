``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.557 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0


```
|         Method |       Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------------- |-----------:|----------:|----------:|------:|--------:|-------:|-------:|------:|----------:|
|       GuInject |   381.1 ns |  3.832 ns |  3.397 ns |  1.00 |    0.00 | 0.0100 |      - |     - |      64 B |
|        Ninject | 1,395.1 ns | 27.184 ns | 32.360 ns |  3.64 |    0.10 | 0.1755 |      - |     - |    1112 B |
| SimpleInjector |   609.2 ns | 12.026 ns | 12.350 ns |  1.60 |    0.04 | 0.1850 | 0.0010 |     - |    1168 B |
