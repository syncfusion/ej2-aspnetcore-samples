#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.TreeView
{
    public class LocalDataModel : PageModel
    {
        public List<Continents> Continents = new List<Continents>();
        public List<Countries> Countries = new List<Countries>();
        public List<object> ListData = new List<object>();
        public void OnGet()
        {
            ListData.Add(new
            {
                id = 1,
                name = "Australia",
                hasChild = true,
                expanded = true
            });
            ListData.Add(new
            {
                id = 2,
                pid = 1,
                name = "New South Wales",

            });
            ListData.Add(new
            {
                id = 3,
                pid = 1,
                name = "Victoria"
            });

            ListData.Add(new
            {
                id = 4,
                pid = 1,
                name = "South Australia"
            });
            ListData.Add(new
            {
                id = 6,
                pid = 1,
                name = "Western Australia",

            });
            ListData.Add(new
            {
                id = 7,
                name = "Brazil",
                hasChild = true
            });
            ListData.Add(new
            {
                id = 8,
                pid = 7,
                name = "Paran�"
            });
            ListData.Add(new
            {
                id = 9,
                pid = 7,
                name = "Cear�"
            });
            ListData.Add(new
            {
                id = 10,
                pid = 7,
                name = "Acre"
            });
            ListData.Add(new
            {
                id = 11,
                name = "China",
                hasChild = true
            });
            ListData.Add(new
            {
                id = 12,
                pid = 11,
                name = "Guangzhou"
            });
            ListData.Add(new
            {
                id = 13,
                pid = 11,
                name = "Shanghai"
            });
            ListData.Add(new
            {
                id = 14,
                pid = 11,
                name = "Beijing"
            });
            ListData.Add(new
            {
                id = 15,
                pid = 11,
                name = "Shantou"

            });
            ListData.Add(new
            {
                id = 16,
                name = "France",
                hasChild = true

            });
            ListData.Add(new
            {
                id = 17,
                pid = 16,
                name = "Pays de la Loire"

            });
            ListData.Add(new
            {
                id = 18,
                pid = 16,
                name = "Aquitaine"

            });
            ListData.Add(new
            {
                id = 19,
                pid = 16,
                name = "Brittany"

            });
            ListData.Add(new
            {
                id = 20,
                pid = 16,
                name = "Lorraine"
            });
            ListData.Add(new
            {
                id = 21,
                name = "India",
                hasChild = true

            });
            ListData.Add(new
            {
                id = 22,
                pid = 21,
                name = "Assam"

            });
            ListData.Add(new
            {
                id = 23,
                pid = 21,
                name = "Bihar"
            });
            ListData.Add(new
            {
                id = 24,
                pid = 21,
                name = "Tamil Nadu"

            });

            Continents.Add(new Continents
            {
                Code = "NA",
                Name = "North America",
                Expanded = true,
                Child = Countries,
            });
            Countries.Add(new Countries { Code = "USA", Name = "United States of America", Selected = true });
            Countries.Add(new Countries { Code = "CUB", Name = "Cuba" });
            Countries.Add(new Countries { Code = "MEX", Name = "Mexico" });
            List<Countries> countries2 = new List<Countries>();
            Continents.Add(new Continents
            {
                Code = "AF",
                Name = "Africa",
                Child = countries2,
            });
            countries2.Add(new Countries { Code = "NGA", Name = "Nygeria" });
            countries2.Add(new Countries { Code = "EGY", Name = "Egypt" });
            countries2.Add(new Countries { Code = "ZAF", Name = "South Africa" });
            List<Countries> countries3 = new List<Countries>();
            Continents.Add(new Continents
            {
                Code = "AS",
                Name = "Asia",
                Child = countries3,
            });
            countries3.Add(new Countries { Code = "CHN", Name = "China" });
            countries3.Add(new Countries { Code = "IND", Name = "India" });
            countries3.Add(new Countries { Code = "JPN", Name = "Japan" });
            List<Countries> countries4 = new List<Countries>();
            Continents.Add(new Continents
            {
                Code = "EU",
                Name = "Europe",
                Child = countries4,
            });
            countries4.Add(new Countries { Code = "DNK", Name = "Denmark" });
            countries4.Add(new Countries { Code = "FIN", Name = "Finland" });
            countries4.Add(new Countries { Code = "AUT", Name = "Austria" });

            List<Countries> countries5 = new List<Countries>();
            Continents.Add(new Continents
            {
                Code = "SA",
                Name = "South America",
                Child = countries5,
            });
            countries5.Add(new Countries { Code = "BRA", Name = "Brazil" });
            countries5.Add(new Countries { Code = "COL", Name = "Colombia" });
            countries5.Add(new Countries { Code = "ARG", Name = "Argentina" });

            List<Countries> countries6 = new List<Countries>();
            Continents.Add(new Continents
            {
                Code = "OC",
                Name = "Oceania",
                Child = countries6,
            });
            countries6.Add(new Countries { Code = "AUS", Name = "Australia" });
            countries6.Add(new Countries { Code = "NZL", Name = "Newzealand" });
            countries6.Add(new Countries { Code = "WSM", Name = "Samoa" });

            List<Countries> countries7 = new List<Countries>();
            Continents.Add(new Continents
            {
                Code = "AN",
                Name = "Antartica",
                Child = countries7,
            });
            countries7.Add(new Countries { Code = "BVT", Name = "Bouvet Island" });
            countries7.Add(new Countries { Code = "ATF", Name = "French Southern Lands" });
        }
    }
    public class Continents
    {
        public string Code;
        public string Name;
        public bool Expanded;
        public bool Selected;
        public List<Countries> Child;

    }
    public class Countries
    {
        public string Code;
        public string Name;
        public bool Expanded;
        public bool Selected;

    }
}
