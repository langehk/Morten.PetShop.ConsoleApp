using System;
using System.Collections.Generic;
using EASV.PetShop.Core.DomainService;
using EASV.PetShop.Entities;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {

        readonly PetAppContext _ctx;

        public OwnerRepository(PetAppContext ctx)
        {
            _ctx = ctx;
        }


        public Owner Create(Owner owner)
        {
            throw new NotImplementedException();
        }

        public Owner Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Owner ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Owner> ReadOwners()
        {
            throw new NotImplementedException();
        }

        public Owner Update(Owner owner)
        {
            throw new NotImplementedException();
        }
    }
}
