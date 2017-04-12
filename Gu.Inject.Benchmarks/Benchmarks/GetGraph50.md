``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-3667U CPU 2.00GHz, ProcessorCount=4
Frequency=2435878 Hz, Resolution=410.5296 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0


```
 |         Method |          Mean |      StdDev | Scaled | Scaled-StdDev |  Gen 0 | Allocated |
 |--------------- |-------------- |------------ |------- |-------------- |------- |---------- |
 |        Ninject | 5,486.7607 ns | 160.4916 ns |  35.02 |          1.29 | 0.4852 |   1.39 kB |
 | SimpleInjector |   821.8564 ns |  16.3422 ns |   5.25 |          0.16 | 0.2327 |     584 B |
 |       GuInject |   156.7617 ns |   3.8268 ns |   1.00 |          0.00 | 0.0350 |      84 B |
