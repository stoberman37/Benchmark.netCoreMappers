``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.19041
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host] : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT

Job=InProcess  Toolchain=InProcessEmitToolchain  

```
|               Method |        Mean |       Error |       StdDev |      Median |
|--------------------- |------------:|------------:|-------------:|------------:|
|   MapWithAgileMapper | 30,884.4 ns | 6,466.08 ns | 18,024.84 ns | 22,600.0 ns |
|    MapWithTinyMapper |  5,780.5 ns |   124.09 ns |    181.89 ns |  5,737.5 ns |
| MapWithExpressMapper |  4,564.8 ns |   106.58 ns |    305.81 ns |  4,425.4 ns |
|    MapWithAutoMapper |  2,432.7 ns |    51.78 ns |     74.26 ns |  2,415.5 ns |
| MapWithManualMapping |    721.4 ns |    17.75 ns |     17.44 ns |    716.1 ns |
|       MapWithMapster |    595.5 ns |     8.41 ns |      7.87 ns |    591.1 ns |
