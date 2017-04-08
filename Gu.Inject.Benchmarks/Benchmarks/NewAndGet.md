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
        Ninject | 365.9524 us | 4.9956 us | 277.76 | 214,00 |     - |     - |          10 625,47 |
 SimpleInjector | 252.4238 us | 5.1897 us | 191.59 | 304,00 |     - |     - |          16 263,72 |
       GuInject |   1.3175 us | 0.0316 us |   1.00 |   3,30 |  0,07 |     - |             176,97 |
