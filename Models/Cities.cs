using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class Cities
    {
        public string CityName { get; set; }
        public string StateId { get; set; }
        public int CityId { get; set; }

        public List<Cities> CitiesList()
        {
            List<Cities> cities = new List<Cities>();
            cities.Add(new Cities() { CityName = "Aberdeen", StateId = "103", CityId = 207 });
            cities.Add(new Cities() { CityName = "Alexandria", StateId = "102", CityId = 204 });
            cities.Add(new Cities() { CityName = "Albany", StateId = "101", CityId = 201 });
            cities.Add(new Cities() { CityName = "Beacon ", StateId = "101", CityId = 202 });
            cities.Add(new Cities() { CityName = "Brisbane ", StateId = "104", CityId = 211 });
            cities.Add(new Cities() { CityName = "Cairns", StateId = "104", CityId = 212 });
            cities.Add(new Cities() { CityName = "Colville ", StateId = "103", CityId = 208 });
            cities.Add(new Cities() { CityName = "Devonport", StateId = "105", CityId = 215 });
            cities.Add(new Cities() { CityName = "Emporia", StateId = "102", CityId = 206 });
            cities.Add(new Cities() { CityName = "Geelong", StateId = "106", CityId = 218 });
            cities.Add(new Cities() { CityName = "Hampton ", StateId = "102", CityId = 205 });
            cities.Add(new Cities() { CityName = "Healesville ", StateId = "106", CityId = 217 });
            cities.Add(new Cities() { CityName = "Hobart", StateId = "105", CityId = 213 });
            cities.Add(new Cities() { CityName = "Launceston ", StateId = "105", CityId = 214 });
            cities.Add(new Cities() { CityName = "Lockport", StateId = "101", CityId = 203 });
            cities.Add(new Cities() { CityName = "Melbourne", StateId = "106", CityId = 216 });
            cities.Add(new Cities() { CityName = "Pasco", StateId = "103", CityId = 209 });
            cities.Add(new Cities() { CityName = "Townsville", StateId = "104", CityId = 210 });
            return cities;
        }
    }
}
