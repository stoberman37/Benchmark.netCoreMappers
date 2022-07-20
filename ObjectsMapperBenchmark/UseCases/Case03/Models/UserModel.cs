using System;
using System.Collections.Generic;
using Bogus;

namespace ObjectsMapperBenchmark.Case3
{
    public class UserModel
    {
        public int Id { get; set; }

        public DateTime BornAt { get; set; }

        public string Name { get; set; }

        public double Points { get; set; }

        public AddressModel Location { get; set; }

        public List<ContactModel> ContactList { get; set; }
        public static List<Case3.UserModel> GenerateMockList(int count)
	        => new Faker<Case3.UserModel>()
		        .RuleFor(r => r.Id, f => f.Random.Int())
		        .RuleFor(r => r.BornAt, f => f.Date.Past())
		        .RuleFor(r => r.Name, f => f.Random.String())
		        .RuleFor(r => r.Points, f => f.Random.Double())
		        .RuleFor(r => r.Location, Case3.AddressModel.GenerateMock())
		        .RuleFor(r => r.ContactList, f => Case3.ContactModel.GenerateMockList(f.Random.Number(2, 100)))
		        .Generate(count);

    }
}
