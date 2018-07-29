using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace superhero_phonebook.Models
{
    public class Address
    {
        public int id { get; set; }
        public string addressLoc { get; set; }
        public string place { get; set; } 
        public int parentId { get; set; }
        public Address(int id, string addressLoc, string place)
        {
            this.parentId = parentId;
            this.id = id;
            this.addressLoc = addressLoc;
            this.place = place;
        }
    }
}
