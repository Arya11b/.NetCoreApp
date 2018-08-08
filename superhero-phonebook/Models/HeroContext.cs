using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace superhero_phonebook.Models
{
    public class HeroContext : DbContext
    {
        public HeroContext(DbContextOptions<HeroContext> options): base(options)
        {
        }
        public DbSet<Hero> heroes { get; set; }
        public DbSet<Group> groups { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<Phone> phones { get; set; }
        public DbSet<ToDo> todos { get; set; }
    }
}
