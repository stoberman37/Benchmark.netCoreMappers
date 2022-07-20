namespace ObjectsMapperBenchmark.Case3
{
    public class Address
    {
        public Address(string zipCode, string street, string number)
        {
            ZipCode = zipCode;
            Street = street;
            City = number;
        }

        public Address()
        {

        }

        public string ZipCode { get; set; }

        public string Street { get; set; }

        public string City { get; set; }
    }
}
