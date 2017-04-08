```ini

BenchmarkDotNet=v0.9.7.0
OS=Microsoft Windows NT 6.1.7601 Service Pack 1
Processor=Intel(R) Xeon(R) CPU X5687 3.60GHz, ProcessorCount=8
Frequency=3515820 ticks, Resolution=284.4287 ns, Timer=ACPI
HostCLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
JitModules=clrjit-v4.6.1590.0

Type=NewAndGet  Mode=Throughput  

```
         Method |      Median |     StdDev | Scaled | Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
--------------- |------------ |----------- |------- |------ |------ |------ |------------------- |
        Ninject | 411.0255 us | 23.3276 us | 182.30 | 33,00 |     - |     - |          10 258,74 |
 SimpleInjector | 268.3308 us |  5.9740 us | 119.01 | 57,82 |  9,43 |     - |          17 984,93 |
       GuInject |   2.2546 us |  0.0521 us |   1.00 |  4,17 |     - |     - |           1 040,25 |
