``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.557 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0


```
|         Method |        Mean |       Error |      StdDev |  Ratio | RatioSD |    Gen 0 |    Gen 1 | Gen 2 |  Allocated |
|--------------- |------------:|------------:|------------:|-------:|--------:|---------:|---------:|------:|-----------:|
|       GuInject |    147.5 us |   0.4888 us |   0.4572 us |   1.00 |    0.00 |  11.7188 |   1.4648 |     - |    72.8 KB |
|         DryIoc |    316.4 us |   2.4820 us |   2.3216 us |   2.14 |    0.02 |  51.7578 |   8.3008 |     - |  319.14 KB |
|        Ninject | 51,789.3 us | 255.1915 us | 199.2367 us | 350.73 |    1.39 | 200.0000 | 100.0000 |     - | 1973.84 KB |
| SimpleInjector | 46,854.8 us | 889.0834 us | 873.1988 us | 317.36 |    6.37 | 181.8182 |  90.9091 |     - | 1561.47 KB |
