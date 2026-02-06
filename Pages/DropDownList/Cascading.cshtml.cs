#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.DropDownList;

public class Cascading : PageModel
{
    public List<State> States = new List<State>();
    public List<Country> Countries = new List<Country>();
    public List<City> Cities = new List<City>();
    public void OnGet()
    {
        States.Add(new State() { StateName = "New York", CountryId = "1", StateId = "101" });
        States.Add(new State() { StateName = "Queensland", CountryId = "2", StateId = "104" });
        States.Add(new State() { StateName = "Tasmania ", CountryId = "2", StateId = "105" });
        States.Add(new State() { StateName = "Victoria", CountryId = "2", StateId = "106" });
        States.Add(new State() { StateName = "Virginia ", CountryId = "1", StateId = "102" });
        States.Add(new State() { StateName = "Washington", CountryId = "1", StateId = "103" });
        
        Countries.Add(new Country() { CountryName = "Australia", CountryId = "2" });
        Countries.Add(new Country() { CountryName = "United States", CountryId = "1" });
        
        Cities.Add(new City() { CityName = "Aberdeen", StateId = "103", CityId = 207 });
        Cities.Add(new City() { CityName = "Alexandria", StateId = "102", CityId = 204 });
        Cities.Add(new City() { CityName = "Albany", StateId = "101", CityId = 201 });
        Cities.Add(new City() { CityName = "Beacon ", StateId = "101", CityId = 202 });
        Cities.Add(new City() { CityName = "Brisbane ", StateId = "104", CityId = 211 });
        Cities.Add(new City() { CityName = "Cairns", StateId = "104", CityId = 212 });
        Cities.Add(new City() { CityName = "Colville ", StateId = "103", CityId = 208 });
        Cities.Add(new City() { CityName = "Devonport", StateId = "105", CityId = 215 });
        Cities.Add(new City() { CityName = "Emporia", StateId = "102", CityId = 206 });
        Cities.Add(new City() { CityName = "Geelong", StateId = "106", CityId = 218 });
        Cities.Add(new City() { CityName = "Hampton ", StateId = "102", CityId = 205 });
        Cities.Add(new City() { CityName = "Healesville ", StateId = "106", CityId = 217 });
        Cities.Add(new City() { CityName = "Hobart", StateId = "105", CityId = 213 });
        Cities.Add(new City() { CityName = "Launceston ", StateId = "105", CityId = 214 });
        Cities.Add(new City() { CityName = "Lockport", StateId = "101", CityId = 203 });
        Cities.Add(new City() { CityName = "Melbourne", StateId = "106", CityId = 216 });
        Cities.Add(new City() { CityName = "Pasco", StateId = "103", CityId = 209 });
        Cities.Add(new City() { CityName = "Townsville", StateId = "104", CityId = 210 });
    }
}

public class State
{
    public string StateName { get; set; }
    public string CountryId { get; set; }
    public string StateId { get; set; }
}

public class Country
{
    public string CountryName { get; set; }
    public string CountryId { get; set; }
}

public class City
{
    public string CityName { get; set; }
    public string StateId { get; set; }
    public int CityId { get; set; }
}