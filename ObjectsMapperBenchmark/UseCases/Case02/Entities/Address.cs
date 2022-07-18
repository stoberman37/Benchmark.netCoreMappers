namespace ObjectsMapperBenchmark.Case2
{
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
    }
}
