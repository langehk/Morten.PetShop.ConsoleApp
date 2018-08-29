using System;
using System.Collections.Generic;
using Morten.PetShop.Entities;

namespace Morten.PetShop.Infrastructure.Data
{
    public static class FakeDB
    {
        public static IEnumerable<Pet> Pets;


        /*
         * When the program starts, the following data is initialized
         */
        public static void InitData()
        {

            var pet1 = new Pet()
            {
                Id = 1,
                Name = "Allan",
                Type = "Gravhund",
                BirthDate = new DateTime(2003, 11, 11),
                SoldDate = new DateTime(2008, 10, 10),
                Color = "Sort",
                PreviousOwner = "Lars",
                Price = 7200,
            };

            var pet2 = new Pet()
            {
                Id = 2,
                Name = "BRian",
                Type = "Chefer",
                BirthDate = new DateTime(2001, 01, 11),
                SoldDate = new DateTime(2004, 08, 10),
                Color = "Grøn",
                PreviousOwner = "Lars",
                Price = 5050,
            };

            Pets = new List<Pet> { pet1, pet2 };
        }
    }
}