using System;
using EASV.PetShop.Entities;
using Microsoft.EntityFrameworkCore;

namespace PetShop.Infrastructure.Data
{
    public class PetAppContext : DbContext
    {
        public PetAppContext(DbContextOptions<PetAppContext> opt): base(opt) {}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
                .HasOne<Owner>(p => p.PetOwner)
                .WithMany(o => o.Pets)
                        .OnDelete(DeleteBehavior.SetNull);
                
        }

        public  DbSet<Pet> Pets { get; set;}

        public DbSet<Owner> Owners { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
