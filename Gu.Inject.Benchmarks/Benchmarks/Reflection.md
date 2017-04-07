```ini

BenchmarkDotNet=v0.9.7.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-3667U CPU 2.00GHz, ProcessorCount=4
Frequency=2435872 ticks, Resolution=410.5306 ns, Timer=TSC
HostCLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
JitModules=clrjit-v4.6.1637.0

Type=Reflection  Mode=Throughput  

```
                       Method |      Median |     StdDev |  Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
----------------------------- |------------ |----------- |------- |------ |------ |------------------- |
              GetConstructors |  70.8315 ns | 12.9323 ns | 158,49 |     - |     - |               6,78 |
 GetConstructorsGetParameters |  80.9529 ns |  8.4346 ns | 158,49 |     - |     - |               6,78 |
                   InvokeCtor | 219.9244 ns | 15.4387 ns | 133,53 |     - |     - |               5,75 |
      ActivatorCreateInstance |  93.8095 ns | 18.2889 ns | 121,81 |     - |     - |               5,22 |
         GetConstructorInvoke | 289.2068 ns | 16.4432 ns | 277,00 |     - |     - |              11,97 |
