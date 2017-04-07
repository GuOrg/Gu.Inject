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
-------------- |--------------- |------------ |------- |------- |------ |------ |------------------- |
 NinjectGetFoo | 12,404.3435 ns | 196.9045 ns |   1.00 | 280,00 | 78,00 |     - |           1 063,53 |
      GuInject |     50.0626 ns |   3.6932 ns |   0.00 |   4,89 |     - |     - |              13,60 |
