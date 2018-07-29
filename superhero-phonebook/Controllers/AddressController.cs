using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using superhero_phonebook.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace superhero_addressbook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly HeroContext _context;

        public AddressController(HeroContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Address> Get()
        {
            return _context.addresses.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetAddressById")]
        public Address GetAddressById(int id)
        {
            var result = _context.addresses.Find(id);
            return result;
        }
        //Get By Parent Id
        [HttpGet("p={parentId}", Name = "GetAddressByParentId")]
        public IEnumerable<Address> GetByParentId(int parentId)
        {
            var result = _context.addresses.Where(x => x.parentId == parentId);
            return result.ToList();
        }
        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Address address)
        {
            _context.addresses.Add(address);
            _context.SaveChanges();
            return CreatedAtRoute("GetAddressById", new { id = address.id }, address);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, Address newAddress)
        {
            var address = _context.addresses.Find(id);
            if (address == null)
            {
                return NotFound();
            }
            address.place = newAddress.place;
            address.addressLoc = newAddress.addressLoc;
            address.parentId = newAddress.parentId;
            _context.addresses.Update(address);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Address result;
            if ((result = _context.addresses.Find(id)) != null)
            {
                _context.addresses.Remove(result);
                _context.SaveChanges();
            }

        }
    }
}
