using System;
using EASV.PetShop.Entities;
using Microsoft.EntityFrameworkCore;

namespace PetShop.Infrastructure.Data
{
    public class PetAppContext : DbContext
    {
        public PetAppContext(DbContextOptions<PetAppContext> opt): base(opt)
        {
            
        }

        public  DbSet<Pet> Pets { get; set;}

        public DbSet<Owner> Owners { get; set; }

    }
}
