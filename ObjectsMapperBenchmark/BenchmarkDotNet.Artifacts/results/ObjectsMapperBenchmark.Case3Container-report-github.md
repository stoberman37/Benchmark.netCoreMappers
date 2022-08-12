``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-8850H CPU 2.60GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.107
  [Host] : .NET 6.0.7 (6.0.722.32202), X64 RyuJIT DEBUG

RunStrategy=Throughput  

```
|          Method | Count | Mean | Error |
|---------------- |------ |-----:|------:|
| TinyMapper_Test |     1 |   NA |    NA |

Benchmarks with issues:
  Case3Container.TinyMapper_Test: Job-JIMHUV(RunStrategy=Throughput) [Count=1]
