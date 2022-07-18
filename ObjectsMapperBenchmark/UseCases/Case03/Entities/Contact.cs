namespace ObjectsMapperBenchmark{
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

        public static Contact Create(ContactModel contactModel) => new Contact
        {
            ContactType = (ContactType)contactModel.ContactType,
            Description = contactModel.Contact
        };
    }
}
