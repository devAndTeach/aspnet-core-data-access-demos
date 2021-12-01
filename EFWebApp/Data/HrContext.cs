using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFWebApp.Models;

namespace EFWebApp.Data
{
    public class HrContext : DbContext
    {
        public HrContext(DbContextOptions<HrContext> options):base(options)
        {

        }

        public DbSet<Person> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("People");
            modelBuilder.Entity<Person>().HasData(
                new { PersonId = 1, FirstName = "James", LastName = "Smith" },
                new { PersonId = 2, FirstName = "Arthur", LastName = "Adams" }
            );
        }
    }
}
