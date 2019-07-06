``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.557 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0


```
|                    Method |         Mean |      Error |     StdDev |    Ratio | RatioSD |  Gen 0 |  Gen 1 |  Gen 2 | Allocated |
|-------------------------- |-------------:|-----------:|-----------:|---------:|--------:|-------:|-------:|-------:|----------:|
|                       New |     3.593 ns |  0.0901 ns |  0.0799 ns |     1.00 |    0.00 | 0.0038 |      - |      - |      24 B |
| ConstructorDelegateInvoke |     5.003 ns |  0.1063 ns |  0.0888 ns |     1.39 |    0.05 | 0.0038 |      - |      - |      24 B |
| CreateConstructorDelegate | 5,367.013 ns | 75.3351 ns | 70.4685 ns | 1,492.85 |   44.97 | 0.2060 | 0.0992 | 0.0076 |    1304 B |
|     ConstructorInfoInvoke |   137.941 ns |  1.0342 ns |  0.9168 ns |    38.41 |    0.92 | 0.0036 |      - |      - |      24 B |
|   ActivatorCreateInstance |    60.151 ns |  1.2516 ns |  1.3392 ns |    16.79 |    0.53 | 0.0037 |      - |      - |      24 B |
