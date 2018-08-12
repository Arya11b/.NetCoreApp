using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace superhero_phonebook.Models
{
    public class SuperPower
    {
        public int id { get; set; }
        public int parentId { get; set; }
        public string power { get; set; }
        public string type { get; set; }
        public string category { get; set; }
        public SuperPower(int id, int parentId, string power, string type, string category)
        {
            this.id = id;
            this.parentId = parentId;
            this.power = power;
            this.category = category;
            this.type = type;
        }
    }
}
