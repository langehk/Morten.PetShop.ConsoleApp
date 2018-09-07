using System;
using System.Collections.Generic;
using EASV.PetShop.Core.DomainService;
using EASV.PetShop.Entities;

namespace EASV.PetShop.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        
        public PetRepository()

        {
            if (FakeDB.Pets.Count >= 1) return;
            var pet1 = new Pet()
            {
                Id = FakeDB.Id++,
                Name = "Bob",
                Type = "Terrier",
                Color = "Blue",
                BirthDate = new DateTime(2013,03,03),
                SoldDate = new DateTime(2014,02,05),
                PreviousOwner = "Allan",
                Price = 2350

            };
            FakeDB.Pets.Add(pet1);

            var pet2 = new Pet()
            {
                Id = FakeDB.Id++,
                Name = "Jan",
                Type = "Chefer",
                Color = "Grøn",
                BirthDate = new DateTime(2013, 03, 03),
                SoldDate = new DateTime(2014, 02, 05),
                PreviousOwner = "Allan",
                Price = 7777
            };
            FakeDB.Pets.Add(pet2);
        }


        static int id = 1;
        private List<Pet> _pets = new List<Pet>();

        public Pet Create(Pet pet)
        {
            pet.Id = id++;
            _pets.Add(pet);
            return pet;
        }

        /*
         *  Read the pet by ID
         */
        public Pet ReadById(int id)
        {
            foreach (var pet in _pets)
            {
                if (pet.Id == id)
                {
                    return pet;
                }
            }
            return null;
        }

        /*
         *  Read all pets.
         */
        public IEnumerable<Pet> ReadAll()
        {
            return FakeDB.Pets;
        }

       /*
        * Updates the pet, and replaces all values.
        */
        public Pet Update(Pet petUpdate)
        {
            var petFraDB = this.ReadById(petUpdate.Id);
            if (petFraDB != null)
            {
                petFraDB.Name = petUpdate.Name;
                petFraDB.Type = petUpdate.Type;
                petFraDB.BirthDate = petUpdate.BirthDate;
                petFraDB.SoldDate = petUpdate.BirthDate;
                petFraDB.Color = petUpdate.Color;
                petFraDB.PreviousOwner = petUpdate.PreviousOwner;
                petFraDB.Price = petUpdate.Price;
                return petFraDB;
            }
            return null;
        }

        /*
         *  Delete a pet.
         */
        public Pet delete(int id)
        {
            var petFundet = this.ReadById(id);

            if (petFundet != null)
            {
                _pets.Remove(petFundet);
                return petFundet;
            }
            return null;
        }


       
    }
}