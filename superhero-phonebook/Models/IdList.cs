using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace superhero_phonebook.Models
{
    public class IdList
    {
        public int id { get; set; }
        public IdList(int id)
        {
            this.id = id;
        }
        public IdList()
        {
            this.id = 0;
        }
    }
}
