namespace ObjectsMapperBenchmark{
    public class Address
    {
        public Address(string zipCode, string street, string number)
        {
            ZipCode = zipCode;
            Street = street;
            Number = number;
        }

        public Address()
        {

        }

        public string ZipCode { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public static Address Create(AddressModel addressModel) => new Address
        {
            ZipCode = addressModel.Identifier,
            Street = addressModel.Address.Split(";")[0],
            Number = addressModel.Address.Split(";")[1]
        };
    }
}
