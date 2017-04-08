```ini

BenchmarkDotNet=v0.9.7.0
OS=Microsoft Windows NT 6.1.7601 Service Pack 1
Processor=Intel(R) Xeon(R) CPU X5687 3.60GHz, ProcessorCount=8
Frequency=3515820 ticks, Resolution=284.4287 ns, Timer=ACPI
HostCLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
JitModules=clrjit-v4.6.1590.0

Type=Reflection  Mode=Throughput  

```
                       Method |      Median |     StdDev | Gen 0 | Gen 1 | Gen 2 | Bytes Allocated/Op |
----------------------------- |------------ |----------- |------ |------ |------ |------------------- |
              GetConstructors |  61.9244 ns |  2.0229 ns | 55,53 |     - |     - |               7,13 |
 GetConstructorsGetParameters |  66.2811 ns |  2.2967 ns | 46,11 |     - |     - |               5,93 |
                   InvokeCtor | 206.5621 ns |  4.4459 ns | 37,73 |     - |     - |               5,53 |
      ActivatorCreateInstance |  92.2340 ns |  8.7025 ns | 33,13 |     - |     - |               4,82 |
         GetConstructorInvoke | 271.3738 ns | 14.0951 ns | 83,00 |     - |     - |              11,39 |
