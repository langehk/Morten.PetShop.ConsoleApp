using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EASV.PetShop.Core.DomainService;
using EASV.PetShop.Entities;

namespace EASV.PetShop.Core.ApplicationService.Services
{
    public class PetService : IPetService
    {
        readonly IPetRepository _petRepo;
        readonly IOwnerRepository _ownerRepo;

        public PetService(IPetRepository petRepository, IOwnerRepository ownerRepository)
        {
            _petRepo = petRepository;
            _ownerRepo = ownerRepository;
        }

        public Pet CreatePet(Pet pet)
        {
            return _petRepo.Create(pet);
        }

        public Pet DeletePet(int id)
        {
            return _petRepo.Delete(id);
        }

        public Pet FindPetById(int id)
        {
            return _petRepo.ReadById(id);
        }

        public List<Pet> FindPetByType(string type)
        {

            //return _petRepo.ReadByType(type);

            var list = _petRepo.ReadAll();
            var question = list.Where(pet => pet.PetType.Equals(type));
            question.OrderBy(pet => pet.PetType);
            return question.ToList();
        }

        public Pet FindPetByIdIncludeOwners(int id)
        {
           
            var pet = _petRepo.ReadyByIdIncludeOwners(id);
            return pet;

           
        }

        public List<Pet> Get5CheapestPets()
        {
            return _petRepo.ReadAll().OrderBy(pet => pet.Price).Take(5).ToList();
        }

        public List<Pet> GetPets()
        {
            return _petRepo.ReadAll().ToList();
        }

        public Pet NewPet(string petName, string type, DateTime birthDate, DateTime soldDate, string color, string previousOwner, double price)
        {
            var pet = new Pet()
            {
                PetName = petName,
                PetType = type,
                BirthDate = birthDate,
                SoldDate = soldDate,
                Color = color,
                PreviousOwner = previousOwner,
                Price = price
                //Owner = new Owner() { OwnerId = ownerId,
                    //FirstName = firstName,
                    //LastName = lastName}
            };
            return pet;
        }

        public List<Pet> SortByPrice()
        {
            var list = _petRepo.ReadAll();
            var question = list.OrderBy(pet => pet.Price);
            return question.ToList();

        }

        public Pet UpdatePet(Pet petUpdate)
        {
            return _petRepo.Update(petUpdate);
        }
    }
}