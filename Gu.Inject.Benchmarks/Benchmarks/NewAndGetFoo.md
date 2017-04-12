``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-3667U CPU 2.00GHz, ProcessorCount=4
Frequency=2435878 Hz, Resolution=410.5296 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0


```
 |         Method |        Mean |    StdErr |     StdDev | Scaled | Scaled-StdDev |   Gen 0 | Allocated |
 |--------------- |------------ |---------- |----------- |------- |-------------- |-------- |---------- |
 |        Ninject | 398.2949 us | 4.3704 us | 20.9598 us | 244.53 |         13.03 |  1.8880 |  24.06 kB |
 | SimpleInjector | 228.6692 us | 2.6014 us |  9.7337 us | 140.39 |          6.08 | 12.5558 |  36.99 kB |
 |       GuInject |   1.6291 us | 0.0060 us |  0.0232 us |   1.00 |          0.00 |  0.1165 |     451 B |
