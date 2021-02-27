``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.804 (2004/?/20H1)
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]     : .NET Core 6.0.0 (CoreCLR 6.0.21.10212, CoreFX 6.0.21.10212), X64 RyuJIT
  Job-HWLJXH : .NET Core 6.0.0 (CoreCLR 6.0.21.10212, CoreFX 6.0.21.10212), X64 RyuJIT

RunStrategy=Throughput  

```
|        Method |       Mean |    Error |    StdDev |     Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------- |-----------:|---------:|----------:|-----------:|-------:|------:|------:|----------:|
|   AgileMapper | 2,424.4 ns | 41.40 ns |  53.83 ns | 2,425.1 ns | 1.0071 |     - |     - |   3.09 KB |
|               |            |          |           |            |        |       |       |           |
|    TinyMapper | 4,830.9 ns | 95.63 ns |  98.20 ns | 4,811.1 ns | 0.6866 |     - |     - |   2.11 KB |
|               |            |          |           |            |        |       |       |           |
| ExpressMapper | 3,189.3 ns | 58.73 ns |  87.90 ns | 3,173.7 ns | 1.5564 |     - |     - |   4.79 KB |
|               |            |          |           |            |        |       |       |           |
|    AutoMapper | 1,994.9 ns | 39.55 ns | 114.73 ns | 1,953.6 ns | 0.6065 |     - |     - |   1.86 KB |
|               |            |          |           |            |        |       |       |           |
| ManualMapping |   465.7 ns |  5.41 ns |   4.52 ns |   466.4 ns | 0.3695 |     - |     - |   1.13 KB |
|               |            |          |           |            |        |       |       |           |
|       Mapster |   454.6 ns |  6.03 ns |   5.03 ns |   454.6 ns | 0.6065 |     - |     - |   1.86 KB |
