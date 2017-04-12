``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-3667U CPU 2.00GHz, ProcessorCount=4
Frequency=2435878 Hz, Resolution=410.5296 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0


```
 |         Method |          Mean |     StdErr |      StdDev |        Median | Scaled | Scaled-StdDev |  Gen 0 | Allocated |
 |--------------- |-------------- |----------- |------------ |-------------- |------- |-------------- |------- |---------- |
 |        Ninject | 4,934.2377 ns | 47.8980 ns | 214.2064 ns | 4,870.3756 ns |  32.14 |          1.83 | 0.4934 |   1.39 kB |
 | SimpleInjector |    61.6829 ns |  0.6583 ns |   4.1637 ns |    59.9336 ns |   0.40 |          0.03 | 0.0024 |      12 B |
 |       GuInject |   153.7411 ns |  1.5119 ns |   6.2336 ns |   151.1570 ns |   1.00 |          0.00 | 0.0341 |      84 B |
