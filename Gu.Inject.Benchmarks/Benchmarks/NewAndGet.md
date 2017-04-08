```ini

BenchmarkDotNet=v0.9.7.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-3667U CPU 2.00GHz, ProcessorCount=4
Frequency=2435872 ticks, Resolution=410.5306 ns, Timer=TSC
HostCLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
JitModules=clrjit-v4.6.1637.0

Type=NewAndGet  Mode=Throughput  

```
         Method |      Median |     StdDev | Scaled |  Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
--------------- |------------ |----------- |------- |------- |------ |------ |------------------- |
        Ninject | 341.8698 us |  5.3211 us | 187.80 | 215,95 |     - |     - |          10 713,42 |
 SimpleInjector | 246.7620 us | 19.0195 us | 135.55 | 287,00 |     - |     - |          15 363,78 |
       GuInject |   1.8204 us |  0.0301 us |   1.00 |  13,29 |     - |     - |             642,43 |
