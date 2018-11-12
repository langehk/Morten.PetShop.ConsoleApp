using System;
using System.Collections.Generic;
using EASV.PetShop.Core.ApplicationService;
using EASV.PetShop.Entities;
using Microsoft.AspNetCore.Authorization;
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

        // GET: api/Owners
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerService.GetOwners();
          
        }

        // GET: api/Owners/5
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Owner> Get(int id)
        {
            if (id < 1) return BadRequest("Id must be larger than 0");

            return Ok(_ownerService.FindOwnerById(id));
        }

        // POST: api/Owners
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            if (string.IsNullOrEmpty(owner.FirstName))
            {
                return BadRequest("Firstname is Required for Creating Owner");
            }
            if (string.IsNullOrEmpty(owner.LastName))
            {
                return BadRequest("Lastname is Required for Creating Owner");
            }
            return _ownerService.CreateOwner(owner);
        }

        // PUT: api/Owners/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (id < 1 || id != owner.OwnerId)
            {
                return BadRequest("Parameter Id and customer ID must be the same");
            }
            return Ok(_ownerService.UpdateOwner(owner));
        }

       

        // DELETE api/owners/5
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            var owner = _ownerService.DeleteOwner(id);
            if (owner == null)
            {
                return StatusCode(404, "Did not find Pet with ID " + id);
            }
            return Ok($"Owner with Id: {id} is Deleted");
        }
    }
}