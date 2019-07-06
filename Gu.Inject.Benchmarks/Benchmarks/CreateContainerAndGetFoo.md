``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.557 (1809/October2018Update/Redstone5)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0


```
|         Method |         Mean |         Error |        StdDev |       Median |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------------- |-------------:|--------------:|--------------:|-------------:|-------:|--------:|-------:|-------:|------:|----------:|
|       GuInject |     775.4 ns |      5.770 ns |      5.397 ns |     775.3 ns |   1.00 |    0.00 | 0.2012 |      - |     - |   1.24 KB |
|         DryIoc |   1,197.0 ns |     34.715 ns |     35.650 ns |   1,182.1 ns |   1.55 |    0.05 | 0.2098 |      - |     - |    1.3 KB |
|        Ninject | 512,434.0 ns | 16,666.086 ns | 38,626.189 ns | 497,071.5 ns | 686.75 |   81.38 | 6.8359 | 1.4648 |     - |  43.02 KB |
| SimpleInjector | 184,288.4 ns |  2,188.485 ns |  2,047.110 ns | 183,735.4 ns | 237.69 |    3.68 | 5.1270 | 0.2441 |     - |  32.22 KB |
