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
        Ninject | 365.0683 us | 5.7578 us | 152.43 | 227,65 |     - |     - |          11 030,81 |
 SimpleInjector | 252.9606 us | 7.5912 us | 105.62 | 321,00 |     - |     - |          16 777,89 |
       GuInject |   2.3950 us | 0.0304 us |   1.00 |   7,91 |  0,15 |     - |             426,27 |
