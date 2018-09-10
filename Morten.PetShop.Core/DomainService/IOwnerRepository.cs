using System;
using System.Collections.Generic;
using EASV.PetShop.Entities;

namespace EASV.PetShop.Core.DomainService
{
    public interface IOwnerRepository
    {
        // C R U D 


        //Create data
        Owner Create(Owner owner);

        //Read data
        Owner ReadById(int id);
        IEnumerable<Owner> ReadAll();

        //Update data
        Owner Update(Owner OwnerUpdate);

        //Delete data 

        Owner Delete(int id);

    }
}
