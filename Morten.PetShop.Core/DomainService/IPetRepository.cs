using System;
using System.Collections.Generic;
using System.Text;
using EASV.PetShop.Entities;

namespace EASV.PetShop.Core.DomainService
{   
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadAll();

        Pet Create(Pet pet);

        Pet Delete(int id);
        Pet ReadById(int id);


        Pet Update(Pet petUpdate);

        IEnumerable<Pet> ReadByType(string type);

        IEnumerable<Pet> ReadByPrice();

        Pet ReadyByIdIncludeOwners(int id);
    }
}