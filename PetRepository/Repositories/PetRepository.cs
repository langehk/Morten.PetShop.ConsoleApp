using System;
using System.Collections.Generic;
using EASV.PetShop.Core.DomainService;
using EASV.PetShop.Entities;

namespace EASV.PetShop.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        

        static int id = 1;
        public Pet Create(Pet pet)
        {
            pet.PetId = id++;
            FakeDB.Pets.Add(pet);
            return pet;
        }

        public Pet ReadById(int id)
        {
            foreach (var pet in FakeDB.Pets)
            {
                if (pet.PetId == id)
                {
                    return pet;
                }
            }
            return null;

           
        }

        public Pet FindByType(string type)
        {
            foreach (var petByType in FakeDB.Pets)
            {
                if (petByType.PetType == type)
                {
                    return petByType;
                }
            }
            return null;
        }

        public Pet Delete(int id)
        {
            var petFound = this.ReadById(id);
            if (petFound != null)
            {
                FakeDB.Pets.Remove(petFound);
                return petFound;
            }
            return null;
        }

        public IEnumerable<Pet> ReadPets()
        {
            return FakeDB.Pets;
        }

        public Pet Update(Pet petUpdate)
        {
            var petFromDB = this.ReadById(petUpdate.PetId);
            if (petFromDB != null)
            {
                petFromDB.PetName = petUpdate.PetName;
                petFromDB.PetType = petUpdate.PetType;
                petFromDB.BirthDate = petUpdate.BirthDate;
                petFromDB.SoldDate = petUpdate.SoldDate;
                petFromDB.Color = petUpdate.Color;
                petFromDB.PreviousOwner = petUpdate.PreviousOwner;
                petFromDB.Price = petUpdate.Price;
                return petFromDB;
            }
            return null;
        }

        public IEnumerable<Pet> ReadByType(string type)
        {
            var typeFound = this.FindByType(type);
            if (typeFound != null)
            {
                return FakeDB.Pets;
            }
            return null;
        }

        public IEnumerable<Pet> ReadByPrice()
        {
            return FakeDB.Pets;
        }
    }
}