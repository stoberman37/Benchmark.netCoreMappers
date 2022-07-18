
using System;
using System.Collections.Generic;

namespace ObjectsMapperBenchmark.Case1
{
    public class User
    {
        public User(int id, DateTime birthDate, string name, double score)
        {
            Id = id;
            BirthDate = birthDate;
            Name = name;
            Score = score;
        }

        public User()
        {
        }

        public int Id { get; set; }

        public DateTime BirthDate { get; set; }

        public string Name { get; set; }

        public double Score { get; set; }
    }
}
