using System;
using System.Collections.Generic;
using EASV.PetShop.Entities;
using System.Text;

namespace EASV.PetShop.Core.DomainService
{
    public interface IOwnerRepository
    {
        
        Owner Create(Owner owner);
        Owner ReadById(int id);
        Owner Update(Owner owner);
        Owner Delete(int id);
        IEnumerable<Owner> ReadAll(Filter filter = null);
        int Count();

    }
}
