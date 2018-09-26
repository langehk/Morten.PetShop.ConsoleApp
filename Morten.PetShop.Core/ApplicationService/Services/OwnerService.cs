using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EASV.PetShop.Core.DomainService;
using EASV.PetShop.Entities;

namespace EASV.PetShop.Core.ApplicationService.Services
{
    public class OwnerService : IOwnerService
    {
        readonly IOwnerRepository _ownerRepo;
        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepo = ownerRepository;
        }

        public Owner CreateOwner(Owner owner)
        {
            return _ownerRepo.Create(owner);
        }

        public Owner DeleteOwner(int id)
        {
            return _ownerRepo.Delete(id);
        }

        public Owner FindOwnerById(int id)
        {
            return _ownerRepo.ReadById(id);
        }

        public List<Owner> GetOwners()
        {
            return _ownerRepo.ReadAll().ToList();
        }

        public Owner NewOwner(string firstName, string lastName)
        {
            var owner = new Owner()
            {
                FirstName = firstName,
                LastName = lastName
            };
            return owner;
        }

        public Owner UpdateOwner(Owner ownerUpdate)
        {
            //var ownerUpdate = FindOwnerById(owner.OwnerId);

            //ownerUpdate.FirstName = owner.FirstName;

            //ownerUpdate.LastName = owner.LastName;

            //return ownerUpdate;

            return _ownerRepo.Update(ownerUpdate);
        }

        public List<Owner> GetFilteredOwners(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPrPage < 0)
            {
                throw new InvalidDataException("CurrentPage and ItemsPage Must zero or more");
            }
            if ((filter.CurrentPage - 1 * filter.ItemsPrPage) >= _ownerRepo.Count())
            {
                throw new InvalidDataException("Index out bounds, CurrentPage is to high");
            }
            return _ownerRepo.ReadAll(filter).ToList();
        }

       
    }
}
