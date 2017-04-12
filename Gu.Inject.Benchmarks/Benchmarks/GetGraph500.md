``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-3667U CPU 2.00GHz, ProcessorCount=4
Frequency=2435878 Hz, Resolution=410.5296 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0


```
 |         Method |          Mean |     StdErr |      StdDev | Scaled | Scaled-StdDev |  Gen 0 | Allocated |
 |--------------- |-------------- |----------- |------------ |------- |-------------- |------- |---------- |
 |        Ninject | 4,975.4149 ns | 22.9172 ns |  88.7579 ns |  28.92 |          2.14 | 0.4771 |   1.39 kB |
 | SimpleInjector | 7,703.3332 ns | 38.2434 ns | 148.1161 ns |  44.78 |          3.33 | 2.2074 |   5.37 kB |
 |       GuInject |   172.8908 ns |  1.7725 ns |  12.2800 ns |   1.00 |          0.00 | 0.0342 |      84 B |
