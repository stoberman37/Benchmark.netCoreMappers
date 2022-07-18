using System;
using System.Collections.Generic;
using Bogus;

namespace ObjectsMapperBenchmark.Case1
{
    public class UserModel
    {
        public int Id { get; set; }

        public DateTime BirthDate { get; set; }

        public string Name { get; set; }

        public double Score { get; set; }

        public static List<UserModel> GenerateMockList(int count) =>
	        new Faker<UserModel>()
		        .RuleFor(r => r.Id, f => f.Random.Int())
		        .RuleFor(r => r.Id, f => f.Random.Int())
		        .RuleFor(r => r.Name, f => f.Name.FullName())
		        .RuleFor(r => r.BirthDate, f => f.Date.Past())
		        .RuleFor(r => r.Score, f => f.Random.Double())
		        .Generate(count);
    }
}
