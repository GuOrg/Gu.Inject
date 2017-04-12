``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-3667U CPU 2.00GHz, ProcessorCount=4
Frequency=2435878 Hz, Resolution=410.5296 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0


```
 |         Method |        Mean |    StdDev | Scaled | Scaled-StdDev |  Gen 0 | Allocated |
 |--------------- |------------ |---------- |------- |-------------- |------- |---------- |
 |        Ninject | 367.7778 us | 2.6490 us | 170.76 |          1.99 | 1.6276 |  24.06 kB |
 | SimpleInjector | 213.3155 us | 0.9385 us |  99.04 |          1.02 | 6.9010 |  36.99 kB |
 |       GuInject |   2.1539 us | 0.0209 us |   1.00 |          0.00 | 0.1851 |     607 B |
