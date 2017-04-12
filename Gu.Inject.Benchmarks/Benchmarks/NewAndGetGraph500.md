```ini

BenchmarkDotNet=v0.9.7.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-3667U CPU 2.00GHz, ProcessorCount=4
Frequency=2435878 ticks, Resolution=410.5296 ns, Timer=TSC
HostCLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
JitModules=clrjit-v4.6.1637.0

Type=NewAndGet`1  Mode=Throughput  

```
         Method |         Median |      StdDev | Scaled | Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
--------------- |--------------- |------------ |------- |------ |------ |------ |------------------- |
        Ninject | 29,895.4320 us | 873.2243 us | 115.13 | 46,00 | 22,00 |     - |         612 015,70 |
 SimpleInjector |  7,997.8605 us | 704.7247 us |  30.80 | 16,22 |  5,10 |     - |         201 711,02 |
       GuInject |    259.6640 us |  17.9077 us |   1.00 |  3,81 |     - |     - |          21 737,33 |
