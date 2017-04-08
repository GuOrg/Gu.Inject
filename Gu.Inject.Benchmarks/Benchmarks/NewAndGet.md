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
--------------- |------------ |---------- |------- |------- |------ |------ |------------------- |
        Ninject | 369.0512 us | 7.4750 us | 190.76 | 244,56 |     - |     - |          11 581,24 |
 SimpleInjector | 253.2481 us | 6.8782 us | 130.90 | 304,00 |     - |     - |          15 541,77 |
       GuInject |   1.9347 us | 0.0381 us |   1.00 |   6,38 |  0,16 |     - |             329,88 |
