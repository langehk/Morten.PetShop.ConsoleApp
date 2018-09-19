using System;
using System.Collections.Generic;
using System.Linq;
using EASV.PetShop.Core.DomainService;
using EASV.PetShop.Entities;
using Microsoft.EntityFrameworkCore;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {

        readonly PetAppContext _ctx;

        public OwnerRepository(PetAppContext ctx)
        {
            _ctx = ctx;
        }

        public Owner Create(Owner owner)
        {
            var ow = _ctx.Owners.Add(owner).Entity;
            _ctx.SaveChanges();
            return ow;
        }

        public Owner Delete(int id)
        {
            var ownerRemoved = _ctx.Remove(new Owner { OwnerId = id }).Entity;
            _ctx.SaveChanges();
            return ownerRemoved;
        }

        public Owner ReadById(int id)
        {
            //return _ctx.Owners
                       //.FirstOrDefault(o => o.OwnerId == id);
            

            return _ctx.Owners
                       .Include(p => p.Pets)
                       .FirstOrDefault(o => o.OwnerId == id);
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return _ctx.Owners;
        }

        public Owner Update(Owner owner)
        {
            throw new NotImplementedException();
        }
    }
}
