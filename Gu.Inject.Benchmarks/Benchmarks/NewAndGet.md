```ini

BenchmarkDotNet=v0.9.7.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-3667U CPU 2.00GHz, ProcessorCount=4
Frequency=2435872 ticks, Resolution=410.5306 ns, Timer=TSC
HostCLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
JitModules=clrjit-v4.6.1637.0

Type=NewAndGet  Mode=Throughput  

```
   Method |      Median |    StdDev | Scaled |  Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
--------- |------------ |---------- |------- |------- |------ |------ |------------------- |
  Ninject | 342.1977 us | 4.1718 us |   1.00 | 226,00 |     - |     - |          10 713,35 |
 GuInject |   1.6391 us | 0.0251 us |   0.00 |  12,20 |     - |     - |             564,65 |
