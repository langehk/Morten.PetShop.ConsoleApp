using System;
using System.Collections.Generic;
using System.Text;
using EASV.PetShop.Entities;

namespace EASV.PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        Pet Create(Pet pet);

        Pet ReadById(int id);

        IEnumerable<Pet> ReadAll();

        Pet Update(Pet petUpdate);

        Pet delete(int id);

    }
}