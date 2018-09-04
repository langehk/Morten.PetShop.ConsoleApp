using EASV.PetRestAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EAST.PetRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly PetContext _context;

        public PetController(PetContext context)
        {
            _context = context;

            if (_context.PetItems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.PetItems.Add(new PetItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }



        [HttpGet]
        public ActionResult<List<PetItem>> GetAll()
        {
            return _context.PetItems.ToList();
        }

        [HttpGet("{id}", Name = "GetPet")]
        public ActionResult<PetItem> GetById(long id)
        {
            var item = _context.PetItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
    }
}