```ini

BenchmarkDotNet=v0.9.7.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-3667U CPU 2.00GHz, ProcessorCount=4
Frequency=2435878 ticks, Resolution=410.5296 ns, Timer=TSC
HostCLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
JitModules=clrjit-v4.6.1637.0

Type=Get`1  Mode=Throughput  

```
         Method |        Median |      StdDev | Scaled |    Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
--------------- |-------------- |------------ |------- |--------- |------ |------ |------------------- |
        Ninject | 5,110.7977 ns | 518.9574 ns |  32.80 |   727,00 |     - |     - |             553,23 |
 SimpleInjector | 2,864.6617 ns |  40.4183 ns |  18.39 | 1 473,24 |     - |     - |           1 101,03 |
       GuInject |   155.8095 ns |   1.5597 ns |   1.00 |    26,87 |     - |     - |              20,13 |
```
