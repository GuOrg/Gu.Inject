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
        Ninject | 348.3777 us | 8.1795 us | 176.63 | 238,00 |     - |     - |          11 276,07 |
 SimpleInjector | 234.3350 us | 5.8900 us | 118.81 | 372,85 |     - |     - |          19 030,64 |
       GuInject |   1.9724 us | 0.1720 us |   1.00 |  16,40 |     - |     - |             755,72 |
