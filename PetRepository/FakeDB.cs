using System;
using System.Collections.Generic;
using EASV.PetShop.Entities;

namespace EASV.PetShop.Infrastructure.Data
{
    public static class FakeDB
    {

        public static List<Pet> Pets = new List<Pet>();
        public static List<Owner> Owners = new List<Owner>();

        public static void InitData()
        {
            var owner1 = new Owner()
            {
                OwnerId = 1,
                FirstName = "Lasse",
                LastName = "Larsen"
            };

            Owners.Add(owner1);


            var pet1 = new Pet()
            {
                PetId = 1,
                PetName = "Lars",
                PetType = "Terrier",
                BirthDate = new DateTime(2013, 11, 12),
                SoldDate = new DateTime(2014, 12, 12),
                Color = "Green",
                PreviousOwner = "Lars",
                Price = 23000,
                Owner = new Owner()
                {
                    OwnerId = 1
                }
            };
            Pets.Add(pet1);



            //public static int Id = 1;
            //public static readonly List<Pet> Pets = new List<Pet>();

            //public static int OwnerId = 1;
            //public static readonly List<Owner> Owners = new List<Owner>();
        }
    }
}

