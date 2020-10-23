``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.572 (2004/?/20H1)
Intel Xeon CPU E5-2637 v4 3.50GHz, 2 CPU, 16 logical and 8 physical cores
.NET Core SDK=3.1.403
  [Host]     : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT
  DefaultJob : .NET Core 3.1.9 (CoreCLR 4.700.20.47201, CoreFX 4.700.20.47203), X64 RyuJIT


```
|         Method |        Mean |     Error |    StdDev |  Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------- |------------:|----------:|----------:|-------:|--------:|--------:|--------:|------:|----------:|
|        Ninject | 4,307.95 μs | 27.400 μs | 21.392 μs | 383.59 |    6.30 | 23.4375 |  7.8125 |     - | 236.54 KB |
| SimpleInjector | 3,467.61 μs | 54.557 μs | 45.557 μs | 308.75 |    5.20 | 23.4375 | 11.7188 |     - | 201.13 KB |
|         DryIoc |    79.06 μs |  1.546 μs |  2.406 μs |   7.01 |    0.21 |  9.5215 |  0.3662 |     - |  73.59 KB |
|       GuInject |    11.22 μs |  0.175 μs |  0.155 μs |   1.00 |    0.00 |  1.4496 |  0.0305 |     - |   11.2 KB |
|  GuInjectBound |    21.52 μs |  0.430 μs |  0.669 μs |   1.91 |    0.07 |  2.8992 |  0.0916 |     - |  22.33 KB |
