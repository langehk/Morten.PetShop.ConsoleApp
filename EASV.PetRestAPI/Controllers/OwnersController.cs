using System;
using System.Collections.Generic;
using EASV.PetShop.Core.ApplicationService;
using EASV.PetShop.Entities;
using Microsoft.AspNetCore.Mvc;


namespace EASV.PetRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET api/owners -- READ All
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerService.GetAllOwners();
        }

        // GET api/owners/5 -- READ By Id
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            if (id < 1) return BadRequest("Id must be greater then 0");

            return _ownerService.FindOwnerById(id);
        }

        // POST api/owners -- CREATE
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            if (string.IsNullOrEmpty(owner.FirstName))
            {
                return BadRequest("Pet name is required for creating a pet");
            }

            if (string.IsNullOrEmpty(owner.LastName))
            {
                return BadRequest("Pet type is Required for Creating a pet");
            }
            //return StatusCode(503, "HORRIBLE ERROR CALL TECH SUPPORT");
            return _ownerService.CreateOwner(owner);
        }

        // PUT api/owner/5 -- Update
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (id < 1 || id != owner.Id)
            {
                return BadRequest("Parameter Id and owner ID must be the same");
            }

            return Ok();
        }

        // DELETE api/owners/5
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            return Ok($"owner with Id: {id} is Deleted");
        }
    }
}