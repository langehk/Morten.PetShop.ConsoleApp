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

            //var changeTracker = _ctx.ChangeTracker.Entries<Owner>();
            //if (owner.Pet != null && 
            //    _ctx.ChangeTracker.Entries<Owner>()
            //    .FirstOrDefault(ce => ce.Entity.OwnerId == owner.Pet.PetId) == null)
            //{
            //    _ctx.Attach(owner.Pet);
            //}

            //var ow = _ctx.Owners.Add(owner).Entity;
            //_ctx.SaveChanges();
            //return ow;

            _ctx.Attach(owner).State = EntityState.Added;
            _ctx.SaveChanges();
            return owner;
        }

        public Owner Delete(int id)
        {
            var ownerRemoved = _ctx.Remove(new Owner { OwnerId = id }).Entity;
            _ctx.SaveChanges();
            return ownerRemoved;
        }

        public Owner ReadById(int id)
        {
            
            var changeTracker = _ctx.ChangeTracker.Entries<Owner>();

            return _ctx.Owners
                       .Include(p => p.Pets)
                       .FirstOrDefault(o => o.OwnerId == id);
        }

        //https://localhost:5001/api/owners?CurrentPage=1&ItemsPrPage=10

        public IEnumerable<Owner> ReadAll(Filter filter)
        {
            

            if (filter == null)
            {
                return _ctx.Owners;
            }
            return _ctx.Owners
               .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
               .Take(filter.ItemsPrPage);
           
        }

        public int Count()
        {
            return _ctx.Owners.Count();
        }
     

        public Owner Update(Owner ownerUpdate)
        {
            //_ctx.Attach(ownerUpdate).State = EntityState.Modified;
            //_ctx.SaveChanges();
            //foreach (var owner in _ctx.Owners.Where(o => o.Pet.PetId == ownerUpdate.OwnerId))
            //{
            //    if (!petUpdate.Owners.Exists(ow => ow.Id == owner.Id))
            //    {
            //        owner.Pet = null;
            //        _ctx.Entry(owner).Reference(o => o.Pet).IsModified = true;
            //    }
            //}
            //_ctx.SaveChanges();
            return ownerUpdate;
        }

      
    }
}
