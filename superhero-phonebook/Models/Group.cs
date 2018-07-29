using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace superhero_phonebook.Models
{
    public class Group
{
    public int id { get; set; }
    public List<Hero> heroesGroup { get; set; }
    public Group(int id, List<Hero> heroesGroup)
    {
        this.id = id;
        this.heroesGroup = heroesGroup;
    }
    public Group()
    {
    }
    }
}
