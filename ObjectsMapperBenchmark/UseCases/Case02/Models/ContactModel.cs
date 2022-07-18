using System.Collections.Generic;
using Bogus;

namespace ObjectsMapperBenchmark.Case2
{
    public class ContactModel
    {
        public ContactType ContactType { get; set; }

        public string Description { get; set; }

        public static List<ContactModel> GenerateMockList(int count) => new Faker<ContactModel>()
	        .RuleFor(r => r.ContactType, f => f.Random.Enum<ContactType>())
	        .RuleFor(r => r.Description, f => f.Random.String())
	        .Generate(count);
    }
}
