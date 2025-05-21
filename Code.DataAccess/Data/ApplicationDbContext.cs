using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Code.Models;
using Microsoft.EntityFrameworkCore;

namespace Code.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {
        }

        public DbSet<Clips> Movies { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clips>().HasData(
                new Clips { Id = 1, Name = "Python Lists", Description = "In this video we are going to talk about lists in Python" },
                new Clips { Id = 2, Name = "Java Introduction", Description = "Let's dive into Java , not the coffee! The ultimate course for learning Java is here" },
                new Clips { Id = 3, Name = "ASP.NET Core", Description = "The power of web designing is here , learn ASP.NET Core now!" });

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Author = "Ali", Description = "This is Aliz. book", ISBN = "Qrssww123", ListPrice = 100, Price = 1000, Price100 = 50, Price50 = 12, Title = "Aliz in Jungle" , ClipsId = 1 , ImageUrl = "" },
                new Product { Id = 2, Author = "Ili", Description = "This is Iliz. book", ISBN = "Q233ssww123", ListPrice = 100, Price = 1000, Price100 = 50, Price50 = 12, Title = "Iliz in Jungle" , ClipsId = 1 , ImageUrl = "" },
                new Product { Id = 3, Author = "Gholi", Description = "This is Gholiz. book", ISBN = "adfadrssww123", ListPrice = 100, Price = 1000, Price100 = 50, Price50 = 12, Title = "Gholliz in Jungle" , ClipsId = 2 , ImageUrl = "" });
        }

    }
}
