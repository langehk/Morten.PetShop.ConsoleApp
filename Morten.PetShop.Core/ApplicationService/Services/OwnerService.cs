using System;
using System.Collections.Generic;
using System.Linq;
using EASV.PetShop.Core.DomainService;
using EASV.PetShop.Entities;

namespace EASV.PetShop.Core.ApplicationService.Services
{
    public class OwnerService : IOwnerService
    {
        private IOwnerRepository _repository;

        public OwnerService(IOwnerRepository repository)
        {
            _repository = repository;
        }

       

        public Owner CreateOwner(Owner owner)
        {
            return _repository.Create(owner);
        }

        public Owner DeleteOwner(int id)
        {
            return _repository.Delete(id);
        }

        public Owner FindOwnerById(int id)
        {
            return _repository.ReadById(id);
        }

        public List<Owner> GetAllOwners()
        {
            return _repository.ReadAll().ToList();
        }


        public Owner UpdateOwner(Owner OwnerUpdate)
        {
            return _repository.Update(OwnerUpdate);
        }

        public Owner New(string firstname, string lastname )
        {
            
        var owner = new Owner
            {
                FirstName = firstname,
                LastName = lastname,
               
            };
            return new Owner();
        }

       
    }
}
