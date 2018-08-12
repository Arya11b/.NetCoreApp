using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using superhero_phonebook.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace superhero_phonebook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperPowerController : ControllerBase
    {
        private readonly HeroContext _context;

        public SuperPowerController(HeroContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<SuperPower> Get()
        {
            return _context.superPowers.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetSuperPowerById")]
        public SuperPower GetSuperPowerById(int id)
        {
            var result = _context.superPowers.Find(id);
            return result;
        }
        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]SuperPower superPower)
        {
            _context.superPowers.Add(superPower);
            _context.SaveChanges();
            return CreatedAtRoute("GetSuperPowerById", new { id = superPower.id }, superPower);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, SuperPower newSuperPower)
        {
            var superPower = _context.superPowers.Find(id);
            if (superPower == null)
            {
                return NotFound();
            }
            superPower.category = newSuperPower.category;
            superPower.power = newSuperPower.power;
            superPower.type = newSuperPower.type;
            _context.superPowers.Update(superPower);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SuperPower result;
            if ((result = _context.superPowers.Find(id)) != null)
            {
                _context.superPowers.Remove(result);
                _context.SaveChanges();
            }

        }
    }
}

