using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day13
{
    public class Person
    {
        public string Name { get; }
        public Dictionary<Person, int> Opinions { get; set; } 

        public Person(string name)
        {
            Name = name;
            Opinions = new Dictionary<Person, int>();
        }

        public int GetOpinionAboutPerson(Person person) => Opinions.Single(x => x.Key.Equals(person)).Value;
    }
}
