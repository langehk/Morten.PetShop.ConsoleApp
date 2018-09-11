using System;
using System.Collections.Generic;
using EASV.PetShop.Entities;
using System.Text;

namespace EASV.PetShop.Core.DomainService
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> ReadOwners();
        Owner Create(Owner owner);
        Owner ReadById(int id);
        Owner Update(Owner owner);
        Owner Delete(int id);

    }
}
