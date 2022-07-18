using BenchmarkDotNet.Attributes;
using Bogus;

namespace ObjectsMapperBenchmark.Case2
{
    public class AddressModel
    {
        public string ZipCode { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

		public static AddressModel GenerateMock()
		{
			return new Faker<AddressModel>()
				.RuleFor(r => r.ZipCode, f => f.Address.ZipCode("?????"))
				.RuleFor(r => r.Street, f => f.Address.StreetName())
				.RuleFor(r => r.Number, f => f.Random.Number(1, 9999).ToString());
		}
	}
}
