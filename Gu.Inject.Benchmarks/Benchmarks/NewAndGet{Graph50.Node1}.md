```ini

BenchmarkDotNet=v0.9.7.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-3667U CPU 2.00GHz, ProcessorCount=4
Frequency=2435878 ticks, Resolution=410.5296 ns, Timer=TSC
HostCLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
JitModules=clrjit-v4.6.1637.0

Type=NewAndGet`1  Mode=Throughput  

```
         Method |        Median |     StdDev | Scaled | Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
--------------- |-------------- |----------- |------- |------ |------ |------ |------------------- |
        Ninject | 1,751.2278 us | 34.1647 us | 216.01 | 67,00 | 16,00 |     - |          22 788,34 |
 SimpleInjector |   606.6148 us | 78.7202 us |  74.82 | 95,94 |     - |     - |          26 942,25 |
       GuInject |     8.1072 us |  0.2039 us |   1.00 |  2,08 |     - |     - |             580,71 |
