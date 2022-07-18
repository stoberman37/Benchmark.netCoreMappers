
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;
using ObjectsMapperBenchmark.Case2;

namespace ObjectsMapperBenchmark
{
	[SimpleJob(RunStrategy.Throughput)]
	[MemoryDiagnoser]
	[KeepBenchmarkFiles(false)]
	[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
	[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
	public class Case2Container
	{
		private readonly Case2UserModelMapper _mapperlyMapper;
		private readonly IMapper _autoMapper;

		[Params(1, 10, 100, 1000, 10000, 100000, 1000000)]
		//[Params(1, 100, 1000)]
		public int Count { get; set; }

		private List<Case2.UserModel> _models;
		[GlobalSetup]
		public void GlobalSetup()
		{
			_models = Case2.UserModel.GenerateMockList(Count);
		}

		public Case2Container()
		{
			_mapperlyMapper = new Case2UserModelMapper();

			//Automapper Configuration 
			var mapperConfig = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<Case2.AddressModel, Case2.Address>();
				cfg.CreateMap<Case2.ContactModel, Case2.Contact>();
				cfg.CreateMap<Case2.UserModel, Case2.User>();
			});
			_autoMapper = mapperConfig.CreateMapper();

		}

		//[Benchmark]
		//[BenchmarkCategory("Case2a")]
		//public void AutoMapper_Single()
		//{
		//	var result = _autoMapper.Map<Case2.ContactModel, ContactType>(_models[0].Contacts[0]);
		//	var r2 = _autoMapper.Map<Case2.AddressModel, Case2.Address>(AddressModel.GenerateMock());
		//}

		[Benchmark]
		[BenchmarkCategory("Case2")]
		public void Mapperly_Array()
		{
			var result = _mapperlyMapper.MapArray(_models);
		}

		[Benchmark]
		[BenchmarkCategory("Case2")]
		public void AutoMapper_Array()
		{
			var result = _autoMapper.Map<IEnumerable<Case2.UserModel>, Case2.User[]>(_models);
		}

		[Benchmark]
		[BenchmarkCategory("Case2")]
		public void ManualMapper_Array()
		{
			var result = _models.Select(m => m.Map()).ToArray();
		}

		[Benchmark]
		[BenchmarkCategory("Case2")]
		public void Mapperly_List()
		{
			_mapperlyMapper.MapList(_models);
		}

		[Benchmark]
		[BenchmarkCategory("Case2")]
		public void AutoMapper_List()
		{
			var result = _autoMapper.Map<IEnumerable<Case2.UserModel>, List<Case2.User>>(_models);
		}

		[Benchmark()]
		[BenchmarkCategory("Case2")]
		public void ManualMapper_List()
		{
			var result = _models.Select(m => m.Map()).ToList();
		}
	}
}
