using System;
using System.Collections.Generic;
using System.Linq;
using EASV.PetShop.Core.DomainService;
using EASV.PetShop.Entities;
using Microsoft.EntityFrameworkCore;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        readonly PetAppContext _ctx;


        public PetRepository(PetAppContext ctx)
        {
            _ctx = ctx;
        }


        public Pet Create(Pet pet)
        {
            var pe = _ctx.Pets.Add(pet).Entity;
            _ctx.SaveChanges();
            return pe;
        }

        public Pet Delete(int id)
        {
            var petRemoved = _ctx.Remove(new Pet { PetId = id }).Entity;
            _ctx.SaveChanges();
            return petRemoved;
        }

        public Pet ReadById(int id)
        {
            return _ctx.Pets
                       .FirstOrDefault(p => p.PetId == id);
            
        }

        public Pet ReadyByIdIncludeOwners(int id)
        {
            return _ctx.Pets
                       .Include(p => p.PetOwner)
                       .FirstOrDefault(p => p.PetId == id);
        }

        public IEnumerable<Pet> ReadByPrice()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> ReadByType(string type)
        {
            //var foundPetType = _ctx
            //    .Find(new Pet {PetType =type }).Entity;
            //    _ctx.SaveChanges();

            //return foundPetType;
            return null;

        }


        //foreach (var petByType in FakeDB.Pets)
        //{
        //    if (petByType.PetType == type)
        //    {
        //        return petByType;
        //    }
        //}
        //return null;




        public IEnumerable<Pet> ReadPets()
        {
            return _ctx.Pets;
        }

        public Pet ReadByIdIncludeOwners(int id)
        {
            return _ctx.Pets
                       .Include(p => p.PetOwner)
                       .FirstOrDefault(p => p.PetId == id);
        }

        public Pet Update(Pet petUpdate)
        {
            throw new NotImplementedException();
        }
    }
}

