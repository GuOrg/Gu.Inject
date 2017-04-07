```ini

BenchmarkDotNet=v0.9.7.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-3667U CPU 2.00GHz, ProcessorCount=4
Frequency=2435872 ticks, Resolution=410.5306 ns, Timer=TSC
HostCLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
JitModules=clrjit-v4.6.1637.0

Type=Get  Mode=Throughput  

```
         Method |         Median |      StdDev | Scaled |  Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
--------------- |--------------- |------------ |------- |------- |------ |------ |------------------- |
        Ninject | 12,517.5000 ns | 905.8521 ns | 252.86 | 238,00 | 66,00 |     - |             913,76 |
 SimpleInjector |     47.5594 ns |   1.2773 ns |   0.96 |   1,66 |     - |     - |               4,65 |
       GuInject |     49.5028 ns |   3.0440 ns |   1.00 |   4,25 |     - |     - |              12,08 |
