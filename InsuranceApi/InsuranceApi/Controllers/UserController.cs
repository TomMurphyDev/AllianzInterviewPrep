using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InsuranceApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InsuranceApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;

            if (_context.UserItems.Count() == 0)
            {
                _context.UserItems.Add(new UserItem { FullName = "JohnSmith" });
                _context.SaveChanges();
            }
        }
        //Show All In Memory GET
        [HttpGet]
        public List<UserItem> GetAll()
        {
            return _context.UserItems.ToList();
        }
        //GET all rows with particular ID
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetById(long id)
        {
            var item = _context.UserItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        //Insert Row to memory POST
        [HttpPost]
        public IActionResult Create([FromBody] UserItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.UserItems.Add(item);
            _context.SaveChanges();
            return CreatedAtRoute("GetUser", new { id = item.Id }, item);
        }
        //Update an existing row using PUT
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] UserItem item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var todo = _context.UserItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Address = item.Address;
            todo.FullName = item.FullName;

            _context.UserItems.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }
        //DELETE a row with particular Id
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.UserItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.UserItems.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
