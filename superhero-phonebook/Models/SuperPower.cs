using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace superhero_phonebook.Models
{
    public class SuperPower
    {
        public int id { get; set; }
        public string power { get; set; }
        public string category { get; set; }
        public SuperPower(int id, string power, string category)
        {
            this.id = id;
            this.power = power;
            this.category = category;
        }
    }
}
