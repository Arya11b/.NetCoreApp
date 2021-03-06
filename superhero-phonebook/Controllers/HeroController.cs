﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using superhero_phonebook.Models;


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
        [HttpGet("name={alias}", Name = "GetByAlias")]
        public Hero GetByName(string alias)
        {
            var result = _context.heroes.SingleOrDefault(hero => hero.alias == alias);
            return result;
        }
        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Hero person)
        {
            try
            {
                _context.heroes.Add(person);
                _context.SaveChanges();
            }
            catch (System.ArgumentException) { }
            return CreatedAtRoute("GetById", new { id = person.id }, person);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, Hero person)
        {
            var hero = _context.heroes.Find(id);
            if (hero == null)
            {
                return NotFound();
            }

            hero.firstName = person.firstName;
            hero.lastName = person.lastName;
            hero.alias = person.alias;
            hero.picture = person.picture;
            hero.parentId = person.parentId;

            _context.heroes.Update(hero);
            _context.SaveChanges();
            return NoContent();
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
