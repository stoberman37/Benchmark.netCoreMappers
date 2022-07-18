using System;
using System.Collections.Generic;

namespace ObjectsMapperBenchmark{
    public class UserModel
    {
        public int Id { get; set; }

        public DateTime BornAt { get; set; }

        public string Name { get; set; }

        public double Points { get; set; }

        public AddressModel Location { get; set; }

        public List<ContactModel> ContactList { get; set; }
    }
}
