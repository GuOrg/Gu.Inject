```ini

BenchmarkDotNet=v0.9.7.0
OS=Microsoft Windows NT 6.1.7601 Service Pack 1
Processor=Intel(R) Xeon(R) CPU X5687 3.60GHz, ProcessorCount=8
Frequency=3515820 ticks, Resolution=284.4287 ns, Timer=ACPI
HostCLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
JitModules=clrjit-v4.6.1590.0

Type=Get  Mode=Throughput  

```
         Method |         Median |      StdDev | Scaled | Gen 0 |  Gen 1 | Gen 2 | Bytes Allocated/Op |
--------------- |--------------- |------------ |------- |------ |------- |------ |------------------- |
        Ninject | 11,925.0373 ns | 429.6402 ns | 246.40 | 20,00 | 117,00 |     - |           1 063,50 |
 SimpleInjector |     48.4830 ns |   1.1034 ns |   1.00 |  0,82 |      - |     - |               5,99 |
       GuInject |     48.3980 ns |   2.1806 ns |   1.00 |  2,14 |      - |     - |              14,99 |
