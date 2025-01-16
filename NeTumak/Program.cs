using NeTumak.Classes;
using System;
namespace NeTumak
{
    class Program
    {
        static void Main(string[] args)
        {
            Task2();
        }
        static void Task2()
        {
            List<Person> people = new List<Person>
            {
                new Person("Алексей", ["выход сериала"]),
                new Person("Мария", ["концерт" ]),
                new Person("Дмитрий", ["выставка картин"])
            };
            List<string> events = new List<string>
            {
                "выход сериала",
                "концерт",
                "соревнование"
            };
            foreach (string ev in events)
            {
                foreach (Person person in people)
                {
                    person.ReactToEvent(ev);
                }
            }

        }
    }
}