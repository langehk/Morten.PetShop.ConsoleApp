using System;
using System.Collections.Generic;
using System.Text;
using EASV.PetShop.Entities;

namespace EASV.PetShop.Core.ApplicationService
{
    public interface IPetService
    {
        List<Pet> GetPets();
        Pet NewPet(string petName,
                   string type,
                   DateTime birthDate,
                   DateTime soldDate,
                   string color,
                   string previousOwner,
                   double price);
        Pet CreatePet(Pet pet);

        Pet FindPetByIdIncludeOwners(int id);

        Pet DeletePet(int id);

        Pet FindPetById(int id);

        Pet UpdatePet(Pet petUpdate);

        List<Pet> FindPetByType(string type);

        List<Pet> SortByPrice();

        List<Pet> Get5CheapestPets();
     
    }
}