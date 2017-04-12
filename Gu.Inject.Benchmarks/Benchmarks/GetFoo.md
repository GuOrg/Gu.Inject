``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-3667U CPU 2.00GHz, ProcessorCount=4
Frequency=2435878 Hz, Resolution=410.5296 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0


```
 |         Method |          Mean |     StdDev | Scaled | Scaled-StdDev |  Gen 0 | Allocated |
 |--------------- |-------------- |----------- |------- |-------------- |------- |---------- |
 |        Ninject | 4,963.2895 ns | 70.2442 ns |  32.44 |          0.61 | 0.4608 |   1.39 kB |
 | SimpleInjector |    62.5121 ns |  1.5561 ns |   0.41 |          0.01 | 0.0034 |      12 B |
 |       GuInject |   153.0247 ns |  2.0584 ns |   1.00 |          0.00 | 0.0334 |      84 B |
