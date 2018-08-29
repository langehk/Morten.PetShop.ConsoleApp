using System;
using System.Collections.Generic;
using System.Text;
using Morten.PetShop.Entities;

namespace Morten.PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadPets();

    }
}