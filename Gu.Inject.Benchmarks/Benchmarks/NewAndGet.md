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
        Ninject | 416.7784 us | 59.7108 us | 290.06 | 222,48 |     - |     - |          11 030,82 |
 SimpleInjector | 250.8212 us |  5.5225 us | 174.56 | 304,00 |     - |     - |          16 263,47 |
       GuInject |   1.4368 us |  0.0373 us |   1.00 |   4,04 |  0,07 |     - |             210,88 |
