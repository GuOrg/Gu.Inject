``` ini

BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17763.503 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0


```
|                       Method |      Mean |     Error |    StdDev | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|----------------------------- |----------:|----------:|----------:|------------:|------------:|------------:|--------------------:|
|              GetConstructors |  55.35 ns | 1.0368 ns | 0.9191 ns |      0.0050 |           - |           - |                32 B |
| GetConstructorsGetParameters |  58.56 ns | 0.2128 ns | 0.1990 ns |      0.0050 |           - |           - |                32 B |
|                   InvokeCtor | 137.57 ns | 2.3956 ns | 2.1237 ns |      0.0036 |           - |           - |                24 B |
|      ActivatorCreateInstance |  60.58 ns | 0.0932 ns | 0.0779 ns |      0.0037 |           - |           - |                24 B |
|         GetConstructorInvoke | 209.84 ns | 4.0938 ns | 4.2040 ns |      0.0088 |           - |           - |                56 B |
