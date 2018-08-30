using System;
using System.Collections.Generic;
using System.Text;
using Morten.PetShop.Entities;

namespace Morten.PetShop.Core.ApplicationService
{
    public interface IPetService
    {
        Pet NewPet(string name, 
                   string type, 
                   DateTime birthDate, 
                   DateTime soldDate, 
                   string color, 
                   string previousOwner, 
                   double price);


        Pet CreatePet(Pet p);

        Pet FindPetById(int id);

        List<Pet> FindPetByType(string searchValue);

        List<Pet> SortByprice();

        List<Pet> GetFiveCheapest();

        List<Pet> GetAllPets();

        Pet UpdatePet(Pet petUpdate);

        Pet DeletePet(int idForDelete);
     
    }
}