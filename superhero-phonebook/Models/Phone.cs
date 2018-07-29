using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace superhero_phonebook.Models
{
    public class Phone
    {
        public int id { get; set; }
        public string number { get; set; }
        public string place { get; set; }
        public string code { get; set; }
        public int parentId { get; set; }
        public Phone(int id,int parentId,string number,string place,string code)
        {
            this.id = id;
            this.parentId = parentId;
            this.number = number;
            this.place = place;
            this.code = code;
        }
    }
}
