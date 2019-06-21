``` ini

BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17763.503 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0


```
|                    Method |         Mean |       Error |      StdDev |    Ratio | RatioSD | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|-------------------------- |-------------:|------------:|------------:|---------:|--------:|------------:|------------:|------------:|--------------------:|
|                       New |     3.125 ns |   0.1297 ns |   0.1332 ns |     1.00 |    0.00 |      0.0038 |           - |           - |                24 B |
| ConstructorDelegateInvoke |     4.779 ns |   0.0524 ns |   0.0490 ns |     1.53 |    0.07 |      0.0038 |           - |           - |                24 B |
| CreateConstructorDelegate | 5,811.342 ns | 115.4993 ns | 235.9344 ns | 1,856.76 |   93.94 |      0.2060 |      0.0992 |      0.0229 |              1305 B |
|     ConstructorInfoInvoke |   137.273 ns |   2.6694 ns |   2.4969 ns |    43.83 |    1.92 |      0.0036 |           - |           - |                24 B |
|   ActivatorCreateInstance |    59.948 ns |   1.6011 ns |   1.7132 ns |    19.24 |    1.04 |      0.0037 |           - |           - |                24 B |
