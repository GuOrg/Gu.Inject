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
              GetConstructors |  70.1901 ns |  1.6489 ns | 146,44 |     - |     - |               6,69 |
 GetConstructorsGetParameters |  74.3408 ns | 12.8826 ns | 146,44 |     - |     - |               6,69 |
                   InvokeCtor | 211.2488 ns | 45.1777 ns | 100,00 |     - |     - |               4,67 |
      ActivatorCreateInstance |  89.0034 ns |  4.2972 ns | 111,87 |     - |     - |               5,12 |
         GetConstructorInvoke | 280.3673 ns |  5.8758 ns | 264,96 |     - |     - |              12,23 |
