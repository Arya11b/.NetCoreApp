using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace superhero_phonebook.Models
{
    public class SuperPowersList
    {
        public int id { get; set; }
        public int superPowerId { get; set; }
        public int parentId { get; set; }
        public SuperPowersList(int id, int superPowerId,int parentId)
        {
            this.id = id;
            this.parentId = parentId;
            this.superPowerId = superPowerId;
        }
        public SuperPowersList()
        {
            this.id = 0;
        }
    }
}
