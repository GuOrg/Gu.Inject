``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.557 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0


```
|         Method |       Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------------- |-----------:|-----------:|-----------:|------:|--------:|-------:|-------:|------:|----------:|
|       GuInject |   414.0 ns |  0.9404 ns |  0.7853 ns |  1.00 |    0.00 | 0.0100 |      - |     - |      64 B |
|        Ninject | 1,384.4 ns |  5.0394 ns |  4.7139 ns |  3.34 |    0.01 | 0.1755 |      - |     - |    1112 B |
| SimpleInjector | 5,559.1 ns | 54.6641 ns | 45.6470 ns | 13.43 |    0.11 | 1.7014 | 0.0763 |     - |   10744 B |
