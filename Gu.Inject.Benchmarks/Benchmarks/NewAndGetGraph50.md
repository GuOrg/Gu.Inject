``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-3667U CPU 2.00GHz, ProcessorCount=4
Frequency=2435878 Hz, Resolution=410.5296 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0


```
 |         Method |          Mean |     StdDev | Scaled | Scaled-StdDev |  Gen 0 | Allocated |
 |--------------- |-------------- |----------- |------- |-------------- |------- |---------- |
 |        Ninject | 4,425.7875 us | 59.0675 us |  48.78 |          0.80 |      - | 183.68 kB |
 | SimpleInjector | 1,214.0124 us | 15.9778 us |  13.38 |          0.22 | 1.8229 |  77.37 kB |
 |       GuInject |    90.7330 us |  0.9540 us |   1.00 |          0.00 | 5.8268 |   17.8 kB |
