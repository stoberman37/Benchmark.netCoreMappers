using System;
using System.Collections.Generic;
using Bogus;

namespace ObjectsMapperBenchmark.Case2
{
    public class UserModel
    {
        public int Id { get; set; }

        public DateTime BirthDate { get; set; }

        public string Name { get; set; }

        public double Score { get; set; }

        public AddressModel Address { get; set; }

        public List<ContactModel> Contacts { get; set; }

        public static List<UserModel> GenerateMockList(int count)
	        => new Faker<UserModel>()
		        .RuleFor(r => r.Id, f => f.Random.Int())
		        .RuleFor(r => r.BirthDate, f => f.Date.Past())
                .RuleFor(r => r.Name, f => f.Random.String())
		        .RuleFor(r => r.Score, f => f.Random.Double())
                .RuleFor(r => r.Address, Case2.AddressModel.GenerateMock())
		        .RuleFor(r => r.Contacts, f => ContactModel.GenerateMockList(f.Random.Number(2, 100)))
		        .Generate(count);
    }
}
