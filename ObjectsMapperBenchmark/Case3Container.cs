
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;
using Nelibur.ObjectMapper;
using ObjectsMapperBenchmark.Case3;

namespace ObjectsMapperBenchmark
{
	[SimpleJob(RunStrategy.Throughput)]
	[MemoryDiagnoser]
	[KeepBenchmarkFiles(false)]
	[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
	[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
	public class Case3Container
	{
		private readonly Case3UserModelMapper _mapperlyMapper;
		private readonly IMapper _autoMapper;

		//[Params(1, 10, 100, 1000, 10000, 100000, 1000000)]
		[Params(1)]
		public int Count { get; set; }

		private List<Case3.UserModel> _models;
		[GlobalSetup]
		public void GlobalSetup()
		{
			_models = Case3.UserModel.GenerateMockList(Count);
		}

		public Case3Container()
		{
			_mapperlyMapper = new Case3UserModelMapper();

			//Automapper Configuration 
			var mapperConfig = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<ContactModel, Contact>()
					.ForMember(dest => dest.ContactType, opt => opt.MapFrom(s => (ContactType)s.ContactType))
					.ForMember(dest => dest.Description, opt => opt.MapFrom(s => s.Contact));

				cfg.CreateMap<AddressModel, Address>()
					.ForMember(dest => dest.ZipCode, opt => opt.MapFrom(s => s.Identifier))
					.ForMember(dest => dest.Street, opt => opt.MapFrom((s, d) => s.Address.Split(',')[0]))
					.ForMember(dest => dest.City, opt => opt.MapFrom((s, d) => s.Address.Split(',')[1]));

				cfg.CreateMap<UserModel, User>()
					.ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.Id))
					.ForMember(dest => dest.Name, opt => opt.MapFrom(s => s.Name))
					.ForMember(dest => dest.Score, opt => opt.MapFrom(s => s.Points))
					.ForMember(dest => dest.BirthDate, opt => opt.MapFrom(s => s.BornAt))
					.ForMember(dest => dest.Address, opt => opt.MapFrom(s => s.Location))
					.ForMember(dest => dest.Contacts, opt => opt.MapFrom(s => s.ContactList));
			});
			_autoMapper = mapperConfig.CreateMapper();

			// TinyMapper
			Nelibur.ObjectMapper.TinyMapper.Bind<ContactModel, Contact>(c =>
			{
				c.Bind(s => s.ContactType, d => d.ContactType);
				c.Bind(s => s.Contact, d => d.Description);
			});
			Nelibur.ObjectMapper.TinyMapper.Bind<AddressModel, Address>(c =>
			{
				c.Bind(s => s.Identifier, d => d.ZipCode);
				c.Bind(s => s.Address.Split(',', StringSplitOptions.None).First(), d => d.Street);
				//c.Bind(s => s.Address.Split(',', StringSplitOptions.None)[1], d => d.City);
			});
			Nelibur.ObjectMapper.TinyMapper.Bind<UserModel, User>(c =>
			{
				//c.Bind(s => s.Id, d => d.Id);
				//c.Bind(s => s.Name, d => d.Name);
				//c.Bind(s => s.Points, d => d.Score);
				//c.Bind(s => s.BornAt, d => d.BirthDate);
				//c.Bind(s => s.Location, d => d.Address);
				//c.Bind(s => s.ContactList, d => d.Contacts);
			});
		}

		[Benchmark]
		[BenchmarkCategory("Case3a")]
		public void TinyMapper_Test()
		{
			var c = ContactModel.GenerateMockList(1)[0];
			var result = TinyMapper.Map<Case3.ContactModel, Case3.Contact>(c);
		}

		[Benchmark]
		[BenchmarkCategory("Case3")]
		public void Mapperly_Array()
		{
			var result = _mapperlyMapper.MapArray(_models);
		}

		[Benchmark]
		[BenchmarkCategory("Case3")]
		public void AutoMapper_Array()
		{
			var result = _autoMapper.Map<IEnumerable<Case3.UserModel>, Case3.User[]>(_models);
		}

		[Benchmark]
		[BenchmarkCategory("Case3")]
		public void ManualMapper_Array()
		{
			var result = _models.Select(m => m.Map()).ToArray();
		}

		[Benchmark]
		[BenchmarkCategory("Case3")]
		public void Mapperly_List()
		{
			_mapperlyMapper.MapList(_models);
		}

		[Benchmark]
		[BenchmarkCategory("Case3")]
		public void AutoMapper_List()
		{
			var result = _autoMapper.Map<IEnumerable<Case3.UserModel>, List<Case3.User>>(_models);
		}

		[Benchmark()]
		[BenchmarkCategory("Case3")]
		public void ManualMapper_List()
		{
			var result = _models.Select(m => m.Map()).ToList();
		}

		[Benchmark]
		[BenchmarkCategory("Case3")]
		public void TinyMapper_Array()
		{
			var result = TinyMapper.Map<IEnumerable<Case3.UserModel>, Case3.User[]>(_models);
		}

		[Benchmark]
		[BenchmarkCategory("Case3")]
		public void TinyMapper_List()
		{
			var result = TinyMapper.Map<IEnumerable<Case3.UserModel>, List<Case3.User>>(_models);
		}
	}
}
