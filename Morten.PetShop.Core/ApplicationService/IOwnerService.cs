﻿using System;
using System.Collections.Generic;
using EASV.PetShop.Entities;

namespace EASV.PetShop.Core.ApplicationService
{
    public interface IOwnerService
    {
        //New owner
        Owner New(string FirstName,
                  string LastName
                 );

        //Create //POST
        Owner CreateOwner(Owner o);

        //Read //GET
        Owner FindOwnerById(int id);

        List<Owner> GetAllOwners();

        //Update //PUT
        Owner UpdateOwner(Owner OwnerUpdate);

        //Delete //DELETE
        Owner DeleteOwner(int id);
    }
}
