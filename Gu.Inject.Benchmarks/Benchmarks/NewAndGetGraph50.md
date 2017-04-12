``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-3667U CPU 2.00GHz, ProcessorCount=4
Frequency=2435878 Hz, Resolution=410.5296 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0


```
 |         Method |          Mean |     StdDev | Scaled | Scaled-StdDev |  Gen 0 | Allocated |
 |--------------- |-------------- |----------- |------- |-------------- |------- |---------- |
 |        Ninject | 4,410.5559 us | 63.2444 us |  42.62 |          0.69 |      - | 183.68 kB |
 | SimpleInjector | 1,186.1895 us |  9.9300 us |  11.46 |          0.13 |      - |  77.27 kB |
 |       GuInject |   103.4845 us |  0.9006 us |   1.00 |          0.00 | 8.7162 |  20.75 kB |
