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
        public string picture { get; set; }
        public int parentId { get; set; }
        public List<CitiesList> cityId { get; set; }
        public List<SuperPowersList> superPowerId { get; set; }
        public Hero(int id,string firstName, string lastName, string alias,string picture,int parentId, List<CitiesList> cityId, List<SuperPowersList> superPowerId)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.alias = alias;
            this.picture = picture;
            this.parentId = parentId;
            this.cityId = cityId;
            this.superPowerId = superPowerId;
        }
        public Hero()
        {

        }
    }
}
