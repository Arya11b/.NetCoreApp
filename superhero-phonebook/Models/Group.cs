using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace superhero_phonebook.Models
{
    public class Group
{
    public int id { get; set; }
    public string name { get; set; }
    public Group(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
    public Group()
    {
    }
    }
}
