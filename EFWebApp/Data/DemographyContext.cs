using EFWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFWebApp.Data
{
    public class DemographyContext : DbContext
    {
        public DemographyContext(DbContextOptions<DemographyContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Citizen> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<Citizen>().HasData(
               new Citizen
               {
                   PersonId = 1,
                   FirstName = "Darius",
                   LastName = "Rucker",
                  
               },
               new Citizen
               {
                   PersonId = 2,
                   FirstName = "Charles",
                   LastName = "Jones",

               },
               new Citizen
               {
                   PersonId = 3,
                   FirstName = "Topher",
                   LastName = "Grace",

               },
               new Citizen
               {
                   PersonId = 4,
                   FirstName = "Sam",
                   LastName = "Kinison",

               }
            );

            modelBuilder.Entity<Country>().ToTable("Countries");
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    CountryId = 1,
                    Name = "USA",
                    Size = 328200000                    
                },
                 new Country
                 {
                     CountryId = 2,
                     Name = "UK",
                     Size = 328200000
                 },
                new Country
                {
                    CountryId = 3,
                    Name = "Egypt",
                    Size = 98400000
                }
            );
        }
    }
}
