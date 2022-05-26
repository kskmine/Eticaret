using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eticaret.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryApıController : ControllerBase
    {
        CategoryDbContext _context;

        public CategoryApıController(CategoryDbContext context )
        {
            _context = context;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _context.Categories.ToList();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] Category cat)
        {
            _context.Categories.Add(cat);
            _context.SaveChanges();
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Category cat)
        {
            cat.Id = id;
            _context.Attach(cat);
            _context.Entry(cat).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();               
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var silinecek = _context.Categories.FirstOrDefault(c => c.Id == id);
            _context.Remove(silinecek);
            _context.SaveChanges();
        }
    }
}
