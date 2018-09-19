using System;
using EASV.PetShop.Entities;

namespace PetShop.Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDB(PetAppContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();


            var owner1 = ctx.Owners.Add(new Owner()
            {
                OwnerId = 1,
                FirstName = "Per",
                LastName = "Ibsen"
            }).Entity;

            var owner2 = ctx.Owners.Add(new Owner()
            {
                OwnerId = 2,
                FirstName = "Ole",
                LastName = "Larsen"
            }).Entity;


            var pet1 = ctx.Pets.Add(new Pet()
            {
                PetId = 1,
                PetName = "Lars",
                PetType = "Terrier",
                BirthDate = new DateTime(2013, 11, 12),
                SoldDate = new DateTime(2014, 12, 12),
                Color = "Green",
                PreviousOwner = "Lars",
                Price = 23000,
                PetOwner = owner1

            }).Entity;

            var pet2 = ctx.Pets.Add(new Pet()
            {
                PetId = 2,
                PetName = "Ole",
                PetType = "Golden Retriever",
                BirthDate = new DateTime(2013, 11, 12),
                SoldDate = new DateTime(2014, 12, 12),
                Color = "Green",
                PreviousOwner = "Jan",
                Price = 90999,
                PetOwner = owner2
            }).Entity;


            ctx.SaveChanges();
        }
    }
}
