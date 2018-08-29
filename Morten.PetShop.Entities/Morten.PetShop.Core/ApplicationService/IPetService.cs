using System;
using System.Collections.Generic;
using Morten.PetShop.Entities;
using System.Text;

namespace Morten.PetShop.Core.ApplicationService
{
    public interface IPetService
    {
        List<Pet> GetPets();
    }
}