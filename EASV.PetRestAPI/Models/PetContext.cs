using System;
using EASV.PetShop.Entities;
using Microsoft.EntityFrameworkCore;


namespace EASV.PetRestAPI.Models
{
    public class PetContext : DbContext
    {
        public PetContext(DbContextOptions<PetContext> options)
           : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<PetItem> PetItems { get; set; }

    }
}
