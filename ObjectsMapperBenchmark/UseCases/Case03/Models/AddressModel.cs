using Bogus;

namespace ObjectsMapperBenchmark.Case3
{
    public class AddressModel
    {
        public string Identifier { get; set; }

        public string Address { get; set; }

        public static Case3.AddressModel GenerateMock() => new Faker<Case3.AddressModel>()
	        .RuleFor(r => r.Identifier, f => f.Random.String())
	        .RuleFor(r => r.Address, f => f.Address.FullAddress());

    }
}
