
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;

namespace ObjectsMapperBenchmark
{
	[SimpleJob(RunStrategy.Throughput)]
	[MemoryDiagnoser]
	[KeepBenchmarkFiles(false)]
	[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
	[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
	public class Case1Container
	{
		private readonly Case1UserModelMapper _mapperlyMapper;
		private readonly IMapper _autoMapper;

		[Params(1, 10, 100, 1000, 10000, 100000, 1000000)]
		//[Params(1, 1000)]
		public int Count { get; set; }

		private List<Case1.UserModel> _models;
		[GlobalSetup]
		public void GlobalSetup()
		{
			_models = Case1.UserModel.GenerateMockList(Count);
		}

		public Case1Container()
		{
			_mapperlyMapper = new Case1UserModelMapper();

			//Automapper Configuration 
			var mapperConfig = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<Case1.UserModel, Case1.User>();
			});
			_autoMapper = mapperConfig.CreateMapper();

		}

		[Benchmark]
		[BenchmarkCategory("Case1")]
		public void Mapperly_Array()
		{
			var result = _mapperlyMapper.MapArray(_models);
		}

		[Benchmark]
		[BenchmarkCategory("Case1")]
		public void AutoMapper_Array()
		{
			var result = _autoMapper.Map<IEnumerable<Case1.UserModel>, Case1.User[]>(_models);
		}

		[Benchmark]
		[BenchmarkCategory("Case1")]
		public void ManualMapper_Array()
		{
			var result = _models.Select(m => m.Map()).ToArray();
		}

		[Benchmark]
		[BenchmarkCategory("Case1")]
		public void Mapperly_List()
		{
			_mapperlyMapper.MapList(_models);
		}

		[Benchmark]
		[BenchmarkCategory("Case1")]
		public void AutoMapper_List()
		{
			var result = _autoMapper.Map<IEnumerable<Case1.UserModel>, List<Case1.User>>(_models);
		}

		[Benchmark(Baseline = true)]
		[BenchmarkCategory("Case1")]
		public void ManualMapper_List()
		{
			var result = _models.Select(m => m.Map()).ToList();
		}
	}
}
