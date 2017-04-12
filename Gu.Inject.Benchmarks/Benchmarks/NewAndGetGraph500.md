``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-3667U CPU 2.00GHz, ProcessorCount=4
Frequency=2435878 Hz, Resolution=410.5296 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0


```
 |         Method |           Mean |      StdErr |        StdDev | Scaled | Scaled-StdDev |   Gen 0 | Allocated |
 |--------------- |--------------- |------------ |-------------- |------- |-------------- |-------- |---------- |
 |        Ninject | 38,897.6587 us | 537.2203 us | 2,080.6453 us | 128.38 |          6.95 |       - |   1.56 MB |
 | SimpleInjector | 10,069.2720 us |  30.2513 us |   113.1900 us |  33.23 |          0.64 |       - | 449.69 kB |
 |       GuInject |    303.0636 us |   1.3110 us |     5.0775 us |   1.00 |          0.00 | 20.1823 |     62 kB |
