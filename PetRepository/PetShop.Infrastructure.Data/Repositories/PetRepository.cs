using System;
using System.Collections.Generic;
using System.Linq;
using EASV.PetShop.Core.DomainService;
using EASV.PetShop.Entities;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        readonly PetAppContext _ctx;


        public PetRepository(PetAppContext ctx)
        {
            _ctx = ctx;      
        }

        /*
         *  Opretter et pet.
         */
        public Pet Create(Pet pet)
        {
            var pe = _ctx.Pets.Add(pet).Entity;
            _ctx.SaveChanges();
            return pe;
        }

        public Pet Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Pet ReadById(int id)
        {
            return _ctx.Pets
                       .FirstOrDefault(c => c.PetId == id);
                        
        }

        public IEnumerable<Pet> ReadByPrice()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> ReadByType(string type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> ReadPets()
        {
            return _ctx.Pets;
        }

        public Pet Update(Pet petUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
