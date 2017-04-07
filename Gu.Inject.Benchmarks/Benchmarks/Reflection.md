```ini

BenchmarkDotNet=v0.9.7.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-3667U CPU 2.00GHz, ProcessorCount=4
Frequency=2435872 ticks, Resolution=410.5306 ns, Timer=TSC
HostCLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
JitModules=clrjit-v4.6.1637.0

Type=Reflection  Mode=Throughput  

```
                       Method |      Median |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
----------------------------- |------------ |---------- |------- |------ |------ |------------------- |
              GetConstructors |  72.9278 ns | 0.9045 ns | 136,87 |     - |     - |               5,98 |
 GetConstructorsGetParameters |  76.4438 ns | 0.6783 ns | 139,38 |     - |     - |               6,11 |
                   InvokeCtor | 215.0923 ns | 3.5876 ns | 109,62 |     - |     - |               4,89 |
      ActivatorCreateInstance |  92.1474 ns | 2.8470 ns | 112,39 |     - |     - |               4,93 |
         GetConstructorInvoke | 292.1167 ns | 3.6520 ns | 277,00 |     - |     - |              12,23 |
