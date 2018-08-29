using System;
using System.Collections.Generic;
using Morten.PetShop.Entities;
using Morten.PetShop.Core.DomainService;
using System.Linq;
using System.Text;

namespace Morten.PetShop.Core.ApplicationService.Implementation
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public List<Pet> GetPets()
        {
            return _petRepository.ReadPets().ToList();
        }

        //List<Pet> IPetService.GetPets()
        //{
        //    return _petRepository.ReadPets().ToList();
        //}
    }
}