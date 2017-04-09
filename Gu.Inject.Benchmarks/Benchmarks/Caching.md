``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-3667U CPU 2.00GHz, ProcessorCount=4
Frequency=2435878 Hz, Resolution=410.5296 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0
  DefaultJob : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0


```
 |            Method |       Mean |    StdErr |    StdDev | Scaled | Scaled-StdDev |  Gen 0 | Allocated |
 |------------------ |----------- |---------- |---------- |------- |-------------- |------- |---------- |
 |               New |  6.1784 ns | 0.1299 ns | 0.4861 ns |   1.00 |          0.00 | 0.0072 |      16 B |
 | TryDequeueEnqueue | 49.4140 ns | 0.9835 ns | 3.9339 ns |   8.04 |          0.84 |      - |       7 B |
