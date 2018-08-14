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
public class CitiesListController : ControllerBase
{
    private readonly HeroContext _context;

    public CitiesListController(HeroContext context)
    {
        _context = context;
    }

    // GET: api/<controller>
    [HttpGet]
    public IEnumerable<CitiesList> Get()
    {
        return _context.citiesLists.ToList();
    }

    // GET api/<controller>/5
    [HttpGet("{id}", Name = "GetCitiesListById")]
    public CitiesList GetCitiesListById(int id)
    {
        var result = _context.citiesLists.Find(id);
        return result;
    }
    // POST api/<controller>
    [HttpPost]
    public IActionResult Post([FromBody]CitiesList citiesList)
    {
        _context.citiesLists.Add(citiesList);
        _context.SaveChanges();
        return CreatedAtRoute("GetCitiesListById", new { id = citiesList.id }, citiesList);
    }

    // PUT api/<controller>/5
    [HttpPut("{id}")]
    public IActionResult Update(int id, CitiesList newCitiesList)
    {
        var citiesList = _context.citiesLists.Find(id);
        if (citiesList == null)
        {
            return NotFound();
        }
        citiesList.parentId = newCitiesList.parentId;
        citiesList.cityId = newCitiesList.cityId;
            _context.citiesLists.Update(citiesList);
        _context.SaveChanges();
        return NoContent();
    }

    // DELETE api/<controller>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        CitiesList result;
        if ((result = _context.citiesLists.Find(id)) != null)
        {
            _context.citiesLists.Remove(result);
            _context.SaveChanges();
        }

    }
}
}
