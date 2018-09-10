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

        // GET api/orders -- READ All
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return Ok();
        }

        // GET api/orders/5 -- READ By Id
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            if (id < 1) return BadRequest("Id must be greater then 0");

            return Ok();
        }

        // POST api/orders -- CREATE
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            return Ok();
        }

        // PUT api/orders/5 -- Update
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (id < 1 || id != owner.Id)
            {
                return BadRequest("Parameter Id and order ID must be the same");
            }

            return Ok();
        }

        // DELETE api/orders/5
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            return Ok($"Order with Id: {id} is Deleted");
        }
    }
}