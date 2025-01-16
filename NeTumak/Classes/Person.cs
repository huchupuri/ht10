using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeTumak.Classes
{
    internal class Person
    {
        public string Name { get; set; }
        public List<string > Hobby { get; set; }

        public Person(string name, List<string> hobby)
        {
            Name = name;
            Hobby = hobby;
        }
        public void ReactToEvent(string eventName)
        {
            if (Hobby.Contains(eventName))
            {
                Console.WriteLine($"{Name} заинтересован(а)"); 
            }
        }
    }
}
