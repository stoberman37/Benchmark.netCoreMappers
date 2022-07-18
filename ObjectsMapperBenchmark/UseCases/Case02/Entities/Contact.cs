namespace ObjectsMapperBenchmark.Case2
{
    public class Contact
    {
        public Contact(ContactType contactType, string description)
        {
            ContactType = contactType;
            Description = description;
        }

        public Contact()
        {

        }

        public ContactType ContactType { get; set; }

        public string Description { get; set; }
    }
}
