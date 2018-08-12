using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using superhero_phonebook.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace superherophonebook.Controllers
{
    [Route("api/[controller]")]
[ApiController]
public class CityController : ControllerBase
{
    private readonly HeroContext _context;

    public CityController(HeroContext context)
    {
        _context = context;
    }

    // GET: api/<controller>
    [HttpGet]
    public IEnumerable<City> Get()
    {
        return _context.cities.ToList();
    }

    // GET api/<controller>/5
    [HttpGet("{id}", Name = "GetCityById")]
    public City GetCityById(int id)
    {
        var result = _context.cities.Find(id);
        return result;
    }
    // POST api/<controller>
    [HttpPost]
    public IActionResult Post([FromBody]City city)
    {
        _context.cities.Add(city);
        _context.SaveChanges();
        return CreatedAtRoute("GetCityById", new { id = city.id }, city);
    }

    // PUT api/<controller>/5
    [HttpPut("{id}")]
    public IActionResult Update(int id, City newCity)
    {
        var city = _context.cities.Find(id);
        if (city == null)
        {
            return NotFound();
        }
        city.city = newCity.city;
        city.province = newCity.province;
        _context.cities.Update(city);
        _context.SaveChanges();
        return NoContent();
    }

    // DELETE api/<controller>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        City result;
        if ((result = _context.cities.Find(id)) != null)
        {
            _context.cities.Remove(result);
            _context.SaveChanges();
        }

    }
}
}

