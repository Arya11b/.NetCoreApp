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
        public string phoneNumber { get; set; }
        public string picture { get; set; }
        public Hero(int id,string firstName, string lastName, string alias, string phoneNumber,string picture)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.alias = alias;
            this.picture = picture;
        }
    }
}
