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
        Ninject | 12,120.9824 ns | 434.5887 ns | 243.46 | 266,00 | 74,00 |     - |           1 042,16 |
 SimpleInjector |     47.4456 ns |   1.0551 ns |   0.95 |   1,97 |     - |     - |               5,64 |
       GuInject |     49.7868 ns |   3.7658 ns |   1.00 |   4,68 |     - |     - |              13,60 |
