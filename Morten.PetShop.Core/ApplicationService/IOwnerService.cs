using System;
using System.Collections.Generic;
using EASV.PetShop.Entities;

namespace EASV.PetShop.Core.ApplicationService
{
    public interface IOwnerService
    {

        List<Owner> GetOwners();
        List<Owner> GetFilteredOwners(Filter filter);

        Owner NewOwner(string firstName, string lastName);

        Owner CreateOwner(Owner owner);
        Owner FindOwnerById(int id);
        Owner UpdateOwner(Owner owner);
        Owner DeleteOwner(int id);
    }
}
