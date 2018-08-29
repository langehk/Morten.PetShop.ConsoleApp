using System.Collections.Generic;
using Morten.PetShop.Core.DomainService;
using Morten.PetShop.Entities;


namespace Morten.PetShop.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
        public IEnumerable<Pet> ReadPets()
        {
            return FakeDB.Pets;
        }
    }
}