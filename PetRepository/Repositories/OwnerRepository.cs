using System;
using EASV.PetShop.Core.DomainService;
using EASV.PetShop.Entities;
using System.Linq;
using System.Collections.Generic;

namespace EASV.PetShop.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {

        public OwnerRepository()
        {
            if (FakeDB.Owners.Count >= 1) return;
            var owner1 = new Owner()
            {
                Id = FakeDB.Id++,
                FirstName = "Jan",
                LastName = "Jørgensen",

            };
            FakeDB.Owners.Add(owner1);

            var owner2 = new Owner()
            {
                Id = FakeDB.Id++,
                FirstName = "Ole",
                LastName = "Sørensen"
            };

            FakeDB.Owners.Add(owner2);
        }
    

        public Owner Create(Owner owner)
        {
            owner.Id = FakeDB.OwnerId++;
            FakeDB.Owners.Add(owner);
            return owner;
        }

        public Owner Delete(int id)
        {
            var ownerFound = ReadById(id);
            if (ownerFound == null) return null;

            FakeDB.Owners.Remove(ownerFound);
            return ownerFound;

        }

        public IEnumerable<Owner> ReadAll()
        {
            return FakeDB.Owners;
        }

        public Owner ReadById(int id)
        {
            return FakeDB.Owners.FirstOrDefault(owner => owner.Id == id);
        }

        public Owner Update(Owner OwnerUpdate)
        {
            var ownerFromDB = ReadById(OwnerUpdate.Id);
            if (ownerFromDB == null) return null;

            ownerFromDB.FirstName = OwnerUpdate.FirstName;
            ownerFromDB.LastName = OwnerUpdate.LastName;
            if (OwnerUpdate.Pet != null && ownerFromDB.Pet != null)
            {
                ownerFromDB.Pet.Id = OwnerUpdate.Pet.Id;
            }
            return ownerFromDB;
        }
    }
}
