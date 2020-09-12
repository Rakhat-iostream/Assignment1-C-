using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace week2
{
    public class Esportsman
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string NickName { get; set; }

        public DateTime Birthday { get; set; }

        public int MMR { get; set; }

        public override string ToString()
        {
            return $"{Name} {Surname} {NickName}";
        }
    }
}
