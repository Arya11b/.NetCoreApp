using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace superhero_phonebook.Models
{
    public class CitiesList
    {
        public int id { get; set; }
        public int cityId { get; set; }
        public int parentId { get; set; }
        public CitiesList(int id, int cityId, int parentId)
        {
            this.id = id;
            this.parentId = parentId;
            this.cityId = cityId;
        }
        public CitiesList()
        {
            this.id = 0;
        }
    }
}
