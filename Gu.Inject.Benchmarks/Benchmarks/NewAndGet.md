```ini

BenchmarkDotNet=v0.9.7.0
OS=Microsoft Windows NT 6.1.7601 Service Pack 1
Processor=Intel(R) Xeon(R) CPU X5687 3.60GHz, ProcessorCount=8
Frequency=3515830 ticks, Resolution=284.4279 ns, Timer=ACPI
HostCLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
JitModules=clrjit-v4.6.1590.0

Type=NewAndGet  Mode=Throughput  

```
         Method |      Median |     StdDev | Scaled | Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
--------------- |------------ |----------- |------- |------ |------ |------ |------------------- |
        Ninject | 395.3698 us | 11.5446 us | 241.01 | 37,00 |     - |     - |          10 938,51 |
 SimpleInjector | 232.3487 us | 14.0562 us | 141.64 | 51,16 |  8,19 |     - |          15 330,92 |
       GuInject |   1.6405 us |  0.0387 us |   1.00 |  0,21 |  0,51 |     - |             187,54 |
