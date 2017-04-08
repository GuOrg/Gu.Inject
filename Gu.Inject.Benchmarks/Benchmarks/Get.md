```ini

BenchmarkDotNet=v0.9.7.0
OS=Microsoft Windows NT 6.1.7601 Service Pack 1
Processor=Intel(R) Xeon(R) CPU X5687 3.60GHz, ProcessorCount=8
Frequency=3515820 ticks, Resolution=284.4287 ns, Timer=ACPI
HostCLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
JitModules=clrjit-v4.6.1590.0

Type=Get  Mode=Throughput  

```
         Method |        Median |      StdDev | Scaled |  Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
--------------- |-------------- |------------ |------- |------- |------ |------ |------------------- |
        Ninject | 4,596.4139 ns | 140.9864 ns |  88.39 | 304,00 |     - |     - |             571,83 |
 SimpleInjector |    50.8747 ns |   1.3655 ns |   0.98 |   2,41 |     - |     - |               4,76 |
       GuInject |    52.0005 ns |   0.9497 ns |   1.00 |   6,84 |     - |     - |              12,89 |
