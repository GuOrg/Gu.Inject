``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-3667U CPU 2.00GHz, ProcessorCount=4
Frequency=2435878 Hz, Resolution=410.5296 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0


```
 |         Method |           Mean |      StdErr |      StdDev | Scaled | Scaled-StdDev |   Gen 0 | Allocated |
 |--------------- |--------------- |------------ |------------ |------- |-------------- |-------- |---------- |
 |        Ninject | 37,302.1641 us | 122.9805 us | 426.0171 us |  57.82 |          1.10 |       - |   1.56 MB |
 | SimpleInjector |  9,901.7958 us | 150.2645 us | 619.5563 us |  15.35 |          0.96 |       - | 459.46 kB |
 |       GuInject |    645.3421 us |   2.7223 us |  10.5436 us |   1.00 |          0.00 | 41.0739 |  94.69 kB |
