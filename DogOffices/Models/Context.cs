using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogOffices.Models
{
    public class Context : DbContext
    {
        public DbSet<Company> Companies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
                new Company() { Id = 1, CompanyName = "Viva Spanish", Address = "1234 Main Street", City = "Willoughby", State = "Ohio", ZipCode = 44094, WebsiteUrl = "www.vivaspanish.com", Description = "Viva Spanish provides Spanish language programs for non-public K-8 Ohio Schools. Super dog friendly. At any give time there may be 4 dogs in the office." }
                );



            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=MRDogOffice;Trusted_Connection=True;";

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
