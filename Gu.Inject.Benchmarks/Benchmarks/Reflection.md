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
              GetConstructors |  70.6069 ns |  1.3113 ns | 138,84 |     - |     - |               6,20 |
 GetConstructorsGetParameters |  76.6192 ns | 13.9754 ns | 147,02 |     - |     - |               6,57 |
                   InvokeCtor | 215.0034 ns | 18.1995 ns | 118,00 |     - |     - |               5,37 |
      ActivatorCreateInstance |  92.8205 ns |  6.2437 ns | 113,94 |     - |     - |               5,13 |
         GetConstructorInvoke | 288.6917 ns | 11.8423 ns | 263,00 |     - |     - |              11,87 |
