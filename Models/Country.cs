using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class Country
    {
        public string CountryName { get; set; }
        public string CountryId { get; set; }

        public List<Country> CountryList()
        {
            List<Country> country = new List<Country>();
            country.Add(new Country() { CountryName = "Australia", CountryId = "2" });
            country.Add(new Country() { CountryName = "United States", CountryId = "1" });
            return country;
        }
    }
}
