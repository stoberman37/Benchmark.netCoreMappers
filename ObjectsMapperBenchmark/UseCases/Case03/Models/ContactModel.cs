using System.Collections.Generic;
using System.Linq;
using Bogus;

namespace ObjectsMapperBenchmark.Case3
{
    public class ContactModel
    {
        public int ContactType { get; set; }

        public string Contact { get; set; }

        public static List<Case3.ContactModel> GenerateMockList(int count) => new Faker<Case3.ContactModel>()
	        .RuleFor(r => r.ContactType,
		        f => f.Random.Int(System.Enum.GetValues<Case3.ContactType>().Cast<int>().Min(),
			        System.Enum.GetValues<ContactType>().Cast<int>().Max()))
	        .RuleFor(r => r.Contact, f => f.Random.String())
	        .Generate(count);
    }
}
