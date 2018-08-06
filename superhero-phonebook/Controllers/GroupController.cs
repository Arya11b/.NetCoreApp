using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using superhero_phonebook.Models;


namespace superhero_phonebook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : Controller
{
    private readonly HeroContext _context;

    public GroupController(HeroContext context)
    {
        _context = context;
    }

    // GET: api/<controller>
    [HttpGet]
    public IEnumerable<Group> Get()
    {
        return _context.groups.ToList();
    }

    // GET api/<controller>/5
    [HttpGet("{id}", Name = "GetGroupById")]
    public Group GetGroupById(int id)
    {
        var result = _context.groups.Find(id);
        return result;
    }
    // POST api/<controller>
    [HttpPost]
    public IActionResult Post([FromBody]Group group)
    {
        _context.groups.Add(group);
        _context.SaveChanges();
        return CreatedAtRoute("GetGroupById", new { id = group.id }, group);
    }

    // PUT api/<controller>/5
    [HttpPut("{id}")]
    public IActionResult Update(int id, Group newGroup)
    {
        var group = _context.groups.Find(id);
        if (group == null)
        {
            return NotFound();
        }
        group.name = newGroup.name;
        _context.groups.Update(group);
        _context.SaveChanges();
        return NoContent();
    }

    // DELETE api/<controller>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        Group result;
        if ((result = _context.groups.Find(id)) != null)
        {
            _context.groups.Remove(result);
            _context.SaveChanges();
        }

    }
}
}
