using System;
using System.Collections.Generic;

namespace EASV.PetShop.Entities
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Pet> Pets { get; set; }

        public Pet Pet { get; set; }

        //public int CurrentPetId { get; set; }

        //public Pet  Pet { get; set; }

        //public ICollection<Pet> Pets { get; set; }

     

        //public Pet Pet { get; set; } //Relation til pet   (Type, name)

        //public List<Owner> Owners { get; set; }

    }
}