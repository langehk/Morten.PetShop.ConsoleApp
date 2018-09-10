using System;
using System.Collections.Generic;

namespace EASV.PetShop.Entities
{
    public class Owner
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Pet Pet { get; set; } //Relation til pet   (Type, name)

        public List<Owner> Owners { get; set; }

    }
}