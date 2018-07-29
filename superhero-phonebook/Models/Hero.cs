using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace superhero_phonebook.Models
{
    public class Hero
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string alias { get; set; }
        public List<Phone> phoneNumber { get; set; }
        public string picture { get; set; }
        public List<Address> address { get; set; }
        public int parentId { get; set; }
        public Hero(int id,string firstName, string lastName, string alias, List<Address> address, List<Phone> phoneNumber,string picture)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.alias = alias;
            this.picture = picture;
            this.address = address;
            this.parentId = parentId;
        }
        public Hero()
        {

        }
    }
}
