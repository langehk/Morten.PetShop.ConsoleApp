using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Morten.PetShop.Core.DomainService;
using Morten.PetShop.Entities;

namespace Morten.PetShop.Core.ApplicationService.Services
{
    public class PetService : IPetService
    {
        readonly IPetRepository _petRepo;

        public PetService(IPetRepository petRepository)
        {
            _petRepo = petRepository;
        }

        public Pet NewPet(string name, string type, DateTime birthDate, DateTime soldDate, string color, string previousOwner, double price)
        {
            var pet = new Pet
            {
                Name = name,
                Type = type,
                BirthDate = birthDate,
                SoldDate = soldDate,
                Color = color,
                PreviousOwner = previousOwner,
                Price = price
            };
            return pet;
        }
  
        public Pet CreatePet(Pet p)
        {
            return _petRepo.Create(p);
        }
       
        public List<Pet> GetAllPets()
        {
            return _petRepo.ReadAll().ToList();
        }
  
        public Pet FindPetById(int id)
        {
            return _petRepo.ReadById(id);
        }

        public List<Pet> FindPetByType(string searchValue)
        {
            var list = _petRepo.ReadAll();
            var queryCont = list.Where(pet => pet.Type.Equals(searchValue));
            queryCont.OrderBy(pet => pet.Type);
            return queryCont.ToList();
        }
     
        public List<Pet> SortByPrice()
        {
            throw new NotImplementedException();
        }

        public List<Pet> GetFiveCheapest()
        {
            throw new NotImplementedException();
        }
    
        public Pet UpdatePet(Pet petUpdate)
        {
            var pet = FindPetById(petUpdate.Id);

            pet.Name = petUpdate.Name;

            pet.Type = petUpdate.Type;

            pet.BirthDate = petUpdate.BirthDate;

            pet.SoldDate = petUpdate.SoldDate;

            pet.Color = petUpdate.Color;

            pet.PreviousOwner = petUpdate.PreviousOwner;

            pet.Price = petUpdate.Price;

            return pet;
        }
        //Delete
        public Pet DeletePet(int iDForDelete)
        {
            return _petRepo.delete(iDForDelete);
        }

        public List<Pet> SortByprice()
        {
            throw new NotImplementedException();
        }
    }

    
}