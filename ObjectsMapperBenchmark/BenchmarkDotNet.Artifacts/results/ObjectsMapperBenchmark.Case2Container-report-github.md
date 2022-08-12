``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-8850H CPU 2.60GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.107
  [Host]     : .NET 6.0.7 (6.0.722.32202), X64 RyuJIT
  Job-QINLBX : .NET 6.0.7 (6.0.722.32202), X64 RyuJIT

RunStrategy=Throughput  

```
|              Method |  Count |       Mean |    Error |    StdDev |     Median |      Gen 0 |      Gen 1 | Allocated |
|-------------------- |------- |-----------:|---------:|----------:|-----------:|-----------:|-----------:|----------:|
|      Mapperly_Array | 100000 |   478.3 ms |  3.98 ms |   3.53 ms |   478.5 ms | 36000.0000 | 12000.0000 |    218 MB |
|                     |        |            |          |           |            |            |            |           |
|    AutoMapper_Array | 100000 |   620.9 ms |  9.88 ms |   9.24 ms |   616.2 ms | 48000.0000 | 16000.0000 |    291 MB |
|                     |        |            |          |           |            |            |            |           |
|  ManualMapper_Array | 100000 |   496.6 ms |  9.89 ms |   9.25 ms |   493.2 ms | 36000.0000 | 12000.0000 |    216 MB |
|                     |        |            |          |           |            |            |            |           |
|       Mapperly_List | 100000 |   480.2 ms |  9.58 ms |  10.25 ms |   481.4 ms | 36000.0000 | 12000.0000 |    218 MB |
|                     |        |            |          |           |            |            |            |           |
|     AutoMapper_List | 100000 |   643.9 ms |  8.87 ms |   7.41 ms |   643.3 ms | 48000.0000 | 16000.0000 |    291 MB |
|                     |        |            |          |           |            |            |            |           |
|   ManualMapper_List | 100000 |   498.7 ms |  4.72 ms |   4.41 ms |   498.6 ms | 36000.0000 | 12000.0000 |    217 MB |
|                     |        |            |          |           |            |            |            |           |
|    TinyMapper_Array | 100000 | 1,362.8 ms | 14.68 ms |  11.46 ms | 1,367.5 ms | 88000.0000 | 22000.0000 |    527 MB |
|                     |        |            |          |           |            |            |            |           |
|     TinyMapper_List | 100000 | 1,445.8 ms | 34.33 ms | 101.24 ms | 1,430.0 ms | 88000.0000 | 22000.0000 |    528 MB |
|                     |        |            |          |           |            |            |            |           |
| ExpressMapper_Array | 100000 |   735.0 ms | 13.86 ms |  14.83 ms |   729.4 ms | 49000.0000 | 16000.0000 |    297 MB |
|                     |        |            |          |           |            |            |            |           |
|  ExpressMapper_List | 100000 |   821.7 ms | 12.51 ms |  11.09 ms |   820.8 ms | 49000.0000 | 16000.0000 |    295 MB |
|                     |        |            |          |           |            |            |            |           |
|   AgileMapper_Array | 100000 | 1,451.9 ms | 36.97 ms | 107.84 ms | 1,435.3 ms | 94000.0000 | 31000.0000 |    564 MB |
|                     |        |            |          |           |            |            |            |           |
|    AgileMapper_List | 100000 | 1,178.7 ms | 23.39 ms |  40.97 ms | 1,160.3 ms | 93000.0000 | 31000.0000 |    563 MB |
|                     |        |            |          |           |            |            |            |           |
|       Mapster_Array | 100000 |   555.7 ms | 10.93 ms |  10.23 ms |   553.9 ms | 37000.0000 | 12000.0000 |    224 MB |
|                     |        |            |          |           |            |            |            |           |
|        Mapster_List | 100000 |   557.7 ms |  4.56 ms |   3.56 ms |   558.7 ms | 37000.0000 | 12000.0000 |    225 MB |
