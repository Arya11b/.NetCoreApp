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
    public class PhoneController : ControllerBase
    {
        private readonly HeroContext _context;

        public PhoneController(HeroContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Phone> Get()
        {
            return _context.phones.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetPhoneById")]
        public Phone GetPhoneById(int id)
        {
            var result = _context.phones.Find(id);
            return result;
        }
        //Get By Parent Id
        [HttpGet("p={parentId}", Name = "GetPhoneByParentId")]
        public IEnumerable<Phone> GetByParentId(int parentId)
        {
            var result = _context.phones.Where(x => x.parentId == parentId);
            return result.ToList();
        }
        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Phone phoneNumber)
        {
            _context.phones.Add(phoneNumber);
            _context.SaveChanges();
            return CreatedAtRoute("GetPhoneById", new { id = phoneNumber.id }, phoneNumber);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, Phone newPhone)
        {
            var phone = _context.phones.Find(id);
            if (phone == null)
            {
                return NotFound();
            }
            phone.parentId = newPhone.parentId;
            phone.code = newPhone.code;
            phone.place = newPhone.place;
            phone.number = newPhone.number;
            _context.phones.Update(phone);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Phone result;
            if ((result = _context.phones.Find(id)) != null)
            {
                _context.phones.Remove(result);
                _context.SaveChanges();
            }

        }
    }
}
