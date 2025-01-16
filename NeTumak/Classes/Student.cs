using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeTumak.Classes
{
    internal class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public List<string> ParticipationHistory { get; set; } = new List<string>();

        public bool IsLazy() 
        {
            return ParticipationHistory.Count < 3;
        }
    }
}
