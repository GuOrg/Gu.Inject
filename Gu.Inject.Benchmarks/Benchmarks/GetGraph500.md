``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-3667U CPU 2.00GHz, ProcessorCount=4
Frequency=2435878 Hz, Resolution=410.5296 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0


```
 |         Method |          Mean |     StdErr |      StdDev |        Median | Scaled | Scaled-StdDev |  Gen 0 | Allocated |
 |--------------- |-------------- |----------- |------------ |-------------- |------- |-------------- |------- |---------- |
 |        Ninject | 5,219.5863 ns | 55.3864 ns | 501.5449 ns | 5,032.1835 ns |  34.80 |          3.34 | 0.4893 |   1.39 kB |
 | SimpleInjector | 7,546.0423 ns | 22.3550 ns |  83.6448 ns | 7,536.4411 ns |  50.31 |          0.71 | 2.1830 |   5.37 kB |
 |       GuInject |   149.9894 ns |  0.3831 ns |   1.4335 ns |   149.8120 ns |   1.00 |          0.00 | 0.0341 |      84 B |
