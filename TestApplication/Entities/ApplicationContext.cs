using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using Entities.Models;
using Entities.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Entities
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new KindConfiguration());
            modelBuilder.ApplyConfiguration(new ShipperConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
        public DbSet<Kind> Kinds { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
    }
}
