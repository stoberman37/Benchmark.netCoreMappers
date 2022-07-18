using System;
using System.Collections.Generic;
using Riok.Mapperly.Abstractions;

namespace ObjectsMapperBenchmark.Case2
{
    public class User
    {
        public User(int id, DateTime birthDate, string name, double score, Address address, IList<Contact> contacts)
        {
            Id = id;
            BirthDate = birthDate;
            Name = name;
            Score = score;
            Address = address;
            Contacts = contacts;
        }

        public User()
        {

        }

        public int Id { get; set; }

        public DateTime BirthDate { get; set; }

        public string Name { get; set; }

        public double Score { get; set; }

        public Address Address { get; set; }

        public IList<Contact> Contacts { get; set; }
    }
}
