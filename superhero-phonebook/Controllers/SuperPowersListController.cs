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
    public class SuperPowersListController : ControllerBase
    {
        private readonly HeroContext _context;

        public SuperPowersListController(HeroContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<SuperPowersList> Get()
        {
            return _context.superPowersLists.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetSuperPowersListById")]
        public SuperPowersList GetSuperPowersListById(int id)
        {
            var result = _context.superPowersLists.Find(id);
            return result;
        }
        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]SuperPowersList superPowersList)
        {
            _context.superPowersLists.Add(superPowersList);
            _context.SaveChanges();
            return CreatedAtRoute("GetSuperPowersListById", new { id = superPowersList.id }, superPowersList);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, SuperPowersList newSuperPowersList)
        {
            var superPowersList = _context.superPowersLists.Find(id);
            if (superPowersList == null)
            {
                return NotFound();
            }
            superPowersList.parentId = newSuperPowersList.parentId;
            superPowersList.superPowerId = newSuperPowersList.superPowerId;
            _context.superPowersLists.Update(superPowersList);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SuperPowersList result;
            if ((result = _context.superPowersLists.Find(id)) != null)
            {
                _context.superPowersLists.Remove(result);
                _context.SaveChanges();
            }

        }
    }
}
