#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.DropDownTree;

public class LocalData : PageModel
{
    public List<object> listdata = new List<object>();
    public List<Continents> continents = new List<Continents>();
    public void OnGet()
    {
        listdata.Add(new
        {
            id = 1,
            name = "Australia",
            hasChild = true,
            expanded = true
        });
        listdata.Add(new
        {
            id = 2,
            pid = 1,
            name = "New South Wales",

        });
        listdata.Add(new
        {
            id = 3,
            pid = 1,
            name = "Victoria"
        });

        listdata.Add(new
        {
            id = 4,
            pid = 1,
            name = "South Australia"
        });
        listdata.Add(new
        {
            id = 6,
            pid = 1,
            name = "Western Australia",

        });
        listdata.Add(new
        {
            id = 7,
            name = "Brazil",
            hasChild = true
        });
        listdata.Add(new
        {
            id = 8,
            pid = 7,
            name = "Paraná"
        });
        listdata.Add(new
        {
            id = 9,
            pid = 7,
            name = "Ceará"
        });
        listdata.Add(new
        {
            id = 10,
            pid = 7,
            name = "Acre"
        });
        listdata.Add(new
        {
            id = 11,
            name = "China",
            hasChild = true
        });
        listdata.Add(new
        {
            id = 12,
            pid = 11,
            name = "Guangzhou"
        });
        listdata.Add(new
        {
            id = 13,
            pid = 11,
            name = "Shanghai"
        });
        listdata.Add(new
        {
            id = 14,
            pid = 11,
            name = "Beijing"
        });
        listdata.Add(new
        {
            id = 15,
            pid = 11,
            name = "Shantou"

        });
        listdata.Add(new
        {
            id = 16,
            name = "France",
            hasChild = true

        });
        listdata.Add(new
        {
            id = 17,
            pid = 16,
            name = "Pays de la Loire"

        });
        listdata.Add(new
        {
            id = 18,
            pid = 16,
            name = "Aquitaine"

        });
        listdata.Add(new
        {
            id = 19,
            pid = 16,
            name = "Brittany"

        });
        listdata.Add(new
        {
            id = 20,
            pid = 16,
            name = "Lorraine"
        });
        listdata.Add(new
        {
            id = 21,
            name = "India",
            hasChild = true

        });
        listdata.Add(new
        {
            id = 22,
            pid = 21,
            name = "Assam"

        });
        listdata.Add(new
        {
            id = 23,
            pid = 21,
            name = "Bihar"
        });
        listdata.Add(new
        {
            id = 24,
            pid = 21,
            name = "Tamil Nadu"

        });
        
        
        List<Countries> countries = new List<Countries>();
        continents.Add(new Continents
        {
            code = "NA",
            name = "North America",
            expanded = true,
            child = countries,
        });
        countries.Add(new Countries { code = "USA", name = "United States of America" });
        countries.Add(new Countries { code = "CUB", name = "Cuba" });
        countries.Add(new Countries { code = "MEX", name = "Mexico" });
        List<Countries> countries2 = new List<Countries>();
        continents.Add(new Continents
        {
            code = "AF",
            name = "Africa",
            child = countries2,
        });
        countries2.Add(new Countries { code = "NGA", name = "Nygeria" });
        countries2.Add(new Countries { code = "EGY", name = "Egypt" });
        countries2.Add(new Countries { code = "ZAF", name = "South Africa" });
        List<Countries> countries3 = new List<Countries>();
        continents.Add(new Continents
        {
            code = "AS",
            name = "Asia",
            child = countries3,
        });
        countries3.Add(new Countries { code = "CHN", name = "China" });
        countries3.Add(new Countries { code = "IND", name = "India" });
        countries3.Add(new Countries { code = "JPN", name = "Japan" });
        List<Countries> countries4 = new List<Countries>();
        continents.Add(new Continents
        {
            code = "EU",
            name = "Europe",
            child = countries4,
        });
        countries4.Add(new Countries { code = "DNK", name = "Denmark" });
        countries4.Add(new Countries { code = "FIN", name = "Finland" });
        countries4.Add(new Countries { code = "AUT", name = "Austria" });

        List<Countries> countries5 = new List<Countries>();
        continents.Add(new Continents
        {
            code = "SA",
            name = "South America",
            child = countries5,
        });
        countries5.Add(new Countries { code = "BRA", name = "Brazil" });
        countries5.Add(new Countries { code = "COL", name = "Colombia" });
        countries5.Add(new Countries { code = "ARG", name = "Argentina" });

        List<Countries> countries6 = new List<Countries>();
        continents.Add(new Continents
        {
            code = "OC",
            name = "Oceania",
            child = countries6,
        });
        countries6.Add(new Countries { code = "AUS", name = "Australia" });
        countries6.Add(new Countries { code = "NZL", name = "Newzealand" });
        countries6.Add(new Countries { code = "WSM", name = "Samoa" });

        List<Countries> countries7 = new List<Countries>();
        continents.Add(new Continents
        {
            code = "AN",
            name = "Antartica",
            child = countries7,
        });
        countries7.Add(new Countries { code = "BVT", name = "Bouvet Island" });
        countries7.Add(new Countries { code = "ATF", name = "French Southern Lands" });
    }
}

public class Continents
{
    public string code;
    public string name;
    public bool expanded;
    public bool selected;
    public List<Countries> child;

}
public class Countries
{
    public string code;
    public string name;
    public bool expanded;
    public bool selected;

}