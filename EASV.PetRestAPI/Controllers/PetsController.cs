using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EASV.PetShop.Core.ApplicationService;
using EASV.PetShop.Core.ApplicationService.Services;
using EASV.PetShop.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EASV.PetRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {

        private readonly IPetService _petService;

       
        public PetsController(IPetService petService)
        {
            _petService = petService;
        }


    

        // GET api/pets
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            //return new string[] { "value1", "value2" };
            //return new List<Pet>[] { "Name" ,"Color" };
            return _petService.GetAllPets();
        }

        // GET api/pets/5 - READ
        [HttpGet("{id}")]
        public ActionResult<string> GetAction (int id) 
        {
            return "value";
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            if (id < 1) return BadRequest("Id must be greater then 0");

            return _petService.FindPetById(id);

        }

        // POST api/pets  ----- CREATE
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            if (string.IsNullOrEmpty(pet.Name))
            {
                return BadRequest("Pet name is required for creating a pet");
            }

            if (string.IsNullOrEmpty(pet.Type))
            {
                return BadRequest("Pet type is Required for Creating a pet");
            }
            //return StatusCode(503, "HORRIBLE ERROR CALL TECH SUPPORT");
            return _petService.CreatePet(pet);
        }

        // PUT api/pets/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if (id < 1 || id != pet.Id)
            {
                return BadRequest("Parameter Id and pet ID must be the same");
            }

            return Ok(_petService.UpdatePet(pet));

        }

        // DELETE api/pets/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {

            var pet = _petService.DeletePet(id);
            if (pet == null)
            {
                return StatusCode(404, "Did not find Pet with ID " + id);
            }

            return Ok($"Pet with Id: {id} is Deleted");
        }
    }
}
