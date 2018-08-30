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
     

        /*
         * Sortere ud fra 5 billigeste
         */
        public List<Pet> GetFiveCheapest()
        {
            var listQuery = _petRepo.ReadAll();
            listQuery.OrderBy(pet => pet.Price);
                                                 // Forskellige ting man kan sortere efter, ud fra et query.
                    
            return listQuery.Take(5).ToList();   //DET ER HER MAN EXECUTER SIN QUERY.
        }
    /*
     * Update pet
     */ 
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


        //Sort list of pets by price
        public List<Pet> SortByprice()
        {
            var list = _petRepo.ReadAll();
            var query = list.OrderBy(Pet => Pet.Price);
            return query.ToList();
        }

       
    }
}