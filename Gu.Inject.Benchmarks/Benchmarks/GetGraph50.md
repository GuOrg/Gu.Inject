``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-3667U CPU 2.00GHz, ProcessorCount=4
Frequency=2435878 Hz, Resolution=410.5296 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0


```
 |         Method |          Mean |     StdErr |     StdDev | Scaled | Scaled-StdDev |  Gen 0 | Allocated |
 |--------------- |-------------- |----------- |----------- |------- |-------------- |------- |---------- |
 |        Ninject | 5,169.3762 ns | 12.5128 ns | 48.4618 ns |  34.41 |          0.91 | 0.4934 |   1.39 kB |
 | SimpleInjector |   813.7279 ns |  9.0025 ns | 33.6841 ns |   5.42 |          0.25 | 0.2652 |     584 B |
 |       GuInject |   150.3227 ns |  1.0648 ns |  3.9842 ns |   1.00 |          0.00 | 0.0341 |      84 B |
