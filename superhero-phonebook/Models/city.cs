﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace superhero_phonebook.Models
{
    public class City
    {
    public int id { get; set; }
    public string province { get; set; }
    public string city { get; set; }
        public City(int id, string province, string city)
        {
            this.id = id;
            this.city = city;
            this.province = province;
        }
    }
}
