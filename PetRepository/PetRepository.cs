using System.Collections.Generic;

using Morten.PetShop.Entities;
using Morten.PetShop.Core.DomainService;

namespace Morten.PetShop.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
        static int id = 1;
        private List<Pet> _pets = new List<Pet>();

        public Pet Create(Pet video)
        {
            video.Id = id++;
            _pets.Add(video);
            return video;
        }

        public Pet ReadById(int id)
        {
            foreach (var pet in _pets)
            {
                if (pet.Id == id)
                {
                    return pet;
                }
            }
            return null;
        }
        public IEnumerable<Pet> ReadAll()
        {
            return _pets;
        }

       
        public Pet Update(Pet petUpdate)
        {
            var petFraDB = this.ReadById(petUpdate.Id);
            if (petFraDB != null)
            {
                petFraDB.Name = petUpdate.Name;
                petFraDB.Type = petUpdate.Type;
                petFraDB.BirthDate = petUpdate.BirthDate;
                petFraDB.SoldDate = petUpdate.BirthDate;
                petFraDB.Color = petUpdate.Color;
                petFraDB.PreviousOwner = petUpdate.PreviousOwner;
                petFraDB.Price = petUpdate.Price;
                return petFraDB;
            }
            return null;
        }

        public Pet delete(int id)
        {
            var petFundet = this.ReadById(id);

            if (petFundet != null)
            {
                _pets.Remove(petFundet);
                return petFundet;
            }
            return null;
        }
    }
}