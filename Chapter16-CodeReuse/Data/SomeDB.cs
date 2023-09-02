using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal static class SomeDB
    {
        public static List<Person> Persons { get; set; } = new List<Person>
        {
            new()
            {
                Id = 1,
                Name = "Yura",
                Age = 25,
            },
            new()
            {
                Id = 2,
                Name = "Dima",
                Age = 51,
            },
            new()
            {
                Id = 3,
                Name = "Vova",
                Age = 15,
            },
        };
    }
}
