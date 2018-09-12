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
            var pet = _petRepo.ReadById(id);
            pet.Owner = _ownerRepo
                .ReadById(pet.Owner.OwnerId);

            return pet;
        }

        public List<Pet> FindPetByType(string type)
        {
            var list = _petRepo.ReadPets();
            var question = list.Where(pet => pet.PetType.Equals(type));
            question.OrderBy(pet => pet.PetType);
            return question.ToList();
        }

        public List<Pet> Get5CheapestPets()
        {
            return _petRepo.ReadPets().OrderBy(pet => pet.Price).Take(5).ToList();
        }

        public List<Pet> GetPets()
        {
            return _petRepo.ReadPets().ToList();
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
            };
            return pet;
        }

        public List<Pet> SortByPrice()
        {
            var list = _petRepo.ReadPets();
            var question = list.OrderBy(pet => pet.Price);
            return question.ToList();

        }

        public Pet UpdatePet(Pet petUpdate)
        {
            var pet = FindPetById(petUpdate.PetId);
            pet.PetName = petUpdate.PetName;
            pet.PetType = petUpdate.PetType;
            pet.BirthDate = petUpdate.BirthDate;
            pet.SoldDate = petUpdate.SoldDate;
            pet.Color = petUpdate.Color;
            pet.PreviousOwner = petUpdate.PreviousOwner;
            pet.Price = petUpdate.Price;
            return pet;
        }
    }
}