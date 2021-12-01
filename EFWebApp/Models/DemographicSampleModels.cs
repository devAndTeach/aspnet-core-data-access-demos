using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFWebApp.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public  ICollection<City> Cities { get; set; }
        public  ICollection<Citizen> People { get; set; }
    }

    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int CountryId { get; set; }
        public   Country Country { get; set; }
        public   ICollection<Person> People { get; set; }
    }

    public class Citizen
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CountryId { get; set; }
        public   Country Country { get; set; }
        public int CityId { get; set; }
        public   City City { get; set; }
    }
}
