using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using superhero_phonebook.Models;

namespace superhero_todobook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly HeroContext _context;

        public ToDoController(HeroContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<ToDo> Get()
        {
            return _context.todos.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetToDoById")]
        public ToDo GetToDoById(int id)
        {
            var result = _context.todos.Find(id);
            return result;
        }
        //Get By Parent Id
        [HttpGet("p={parentId}", Name = "GetToDoByParentId")]
        public IEnumerable<ToDo> GetByParentId(int parentId)
        {
            var result = _context.todos.Where(x => x.parentId == parentId);
            return result.ToList();
        }
        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]ToDo todo)
        {
            _context.todos.Add(todo);
            _context.SaveChanges();
            return CreatedAtRoute("GetToDoById", new { id = todo.id }, todo);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, ToDo newToDo)
        {
            var todo = _context.todos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            todo.parentId = newToDo.parentId;
            todo.due = newToDo.due;
            todo.note = newToDo.note;
            _context.todos.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ToDo result;
            if ((result = _context.todos.Find(id)) != null)
            {
                _context.todos.Remove(result);
                _context.SaveChanges();
            }

        }
    }

}