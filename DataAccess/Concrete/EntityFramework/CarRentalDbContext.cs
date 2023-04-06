using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Mappings;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class CarRentalDbContext :DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ModelImage> ModelImages { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }


         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Database=carRentalDb; Username=postgres; Password=Burcum2855");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            new UserMap().Configure(modelBuilder.Entity<User>());
            new OperationClaimMap().Configure(modelBuilder.Entity<OperationClaim>());
            new UserOperationClaimMap().Configure(modelBuilder.Entity<UserOperationClaim>());



            new BrandMap().Configure(modelBuilder.Entity<Brand>());
            new ColorMap().Configure(modelBuilder.Entity<Color>());
            new ModelMap().Configure(modelBuilder.Entity<Model>());
            new ModelImageMap().Configure(modelBuilder.Entity<ModelImage>());
            new CustomerMap().Configure(modelBuilder.Entity<Customer>());
            new BlogMap().Configure(modelBuilder.Entity<Blog>());
            new TestimonialMap().Configure(modelBuilder.Entity<Testimonial>());

            base.OnModelCreating(modelBuilder);
        }
    }
}