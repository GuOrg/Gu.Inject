``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-3667U CPU 2.00GHz, ProcessorCount=4
Frequency=2435878 Hz, Resolution=410.5296 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0


```
 |                    Method |          Mean |     StdErr |     StdDev |        Median |   Scaled | Scaled-StdDev |  Gen 0 | Allocated |
 |-------------------------- |-------------- |----------- |----------- |-------------- |--------- |-------------- |------- |---------- |
 |                       New |     2.7559 ns |  0.0863 ns |  0.8590 ns |     2.4864 ns |     1.00 |          0.00 | 0.0056 |      12 B |
 | ConstructorDelegateInvoke |     5.1615 ns |  0.1039 ns |  0.8118 ns |     5.0167 ns |     2.04 |          0.64 | 0.0055 |      12 B |
 | CreateConstructorDelegate | 7,095.1747 ns | 23.3596 ns | 87.4035 ns | 7,098.7229 ns | 2,799.87 |        754.88 | 0.1831 |     781 B |
 |     ConstructorInfoInvoke |   252.6629 ns |  2.5609 ns | 23.4708 ns |   242.1974 ns |    99.70 |         28.50 | 0.0020 |      12 B |
 |   ActivatorCreateInstance |    96.2596 ns |  0.9989 ns |  6.5505 ns |    93.3145 ns |    37.99 |         10.57 | 0.0033 |      12 B |
