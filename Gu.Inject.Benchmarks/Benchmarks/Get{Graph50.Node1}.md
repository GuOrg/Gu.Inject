```ini

BenchmarkDotNet=v0.9.7.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-3667U CPU 2.00GHz, ProcessorCount=4
Frequency=2435878 ticks, Resolution=410.5296 ns, Timer=TSC
HostCLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
JitModules=clrjit-v4.6.1637.0

Type=Get`1  Mode=Throughput  

```
         Method |        Median |      StdDev | Scaled |  Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
--------------- |-------------- |------------ |------- |------- |------ |------ |------------------- |
        Ninject | 5,398.7639 ns | 314.4117 ns |  35.47 | 770,00 |     - |     - |             585,19 |
 SimpleInjector |   154.4857 ns |   6.4007 ns |   1.01 |  60,62 |     - |     - |              45,31 |
       GuInject |   152.2115 ns |   2.3985 ns |   1.00 |  28,96 |     - |     - |              21,68 |
