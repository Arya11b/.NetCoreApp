using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using superhero_phonebook.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace superhero_phonebook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly HeroContext _context;

        public HeroController(HeroContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return _context.heroes.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetById")]
        public Hero Get(int id)
        {
            var result = _context.heroes.Find(id);
            return result;
        }
        [HttpGet("number={number}", Name = "GetByNumber")]
        public Hero GetByNumber(string number)
        {
            var result = _context.heroes.SingleOrDefault(hero => hero.phoneNumber == number);
            return result;
        }
        [HttpGet("name={alias}", Name = "GetByAlias")]
        public Hero GetByName(string alias)
        {
            var result = _context.heroes.SingleOrDefault(hero => hero.alias == alias);
            return result;
        }
        // POST api/<controller>
        [HttpPost]
        public IActionResult Post(Hero person)
        {
            _context.heroes.Add(person);
            _context.SaveChanges();
            return CreatedAtRoute("GetById", new { id = person.id }, person);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id,Hero person)
        {
            Hero result;
            if ((result = _context.heroes.Find(id)) != null)
            {
                _context.heroes.Update(result);
                _context.SaveChanges();
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Hero result;
            if ((result = _context.heroes.Find(id)) != null)
            {
                _context.heroes.Remove(result);
                _context.SaveChanges();
            }

        }
    }
}
