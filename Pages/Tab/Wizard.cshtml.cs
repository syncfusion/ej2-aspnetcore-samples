#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser_NET8.Pages.Tab
{
    public class WizardModel : PageModel
    {
        public List<DataFields> QuotaData = new List<DataFields>();
        public List<DataFields> GenderData = new List<DataFields>();
        public List<DataFields> BerthData = new List<DataFields>();
        public List<CitiesFields> CitiesData = new List<CitiesFields>();
        public void OnGet()
        {
            QuotaData.Add(new DataFields { ID = "1", Text = "Business Class" });
            QuotaData.Add(new DataFields { ID = "2", Text = "Economy Class" });
            QuotaData.Add(new DataFields { ID = "3", Text = "Common Class" });

            GenderData.Add(new DataFields { ID = "1", Text = "Male" });
            GenderData.Add(new DataFields { ID = "2", Text = "Female" });

            BerthData.Add(new DataFields { ID = "1", Text = "Upper" });
            BerthData.Add(new DataFields { ID = "2", Text = "Lower" });
            BerthData.Add(new DataFields { ID = "3", Text = "Middle" });
            BerthData.Add(new DataFields { ID = "4", Text = "Window" });
            BerthData.Add(new DataFields { ID = "5", Text = "Aisle" });

            CitiesData.Add(new CitiesFields { Name = "Chicago", Fare = 300 });
            CitiesData.Add(new CitiesFields { Name = "San Francisco", Fare = 125 });
            CitiesData.Add(new CitiesFields { Name = "Los Angeles", Fare = 175 });
            CitiesData.Add(new CitiesFields { Name = "Seattle", Fare = 250 });
            CitiesData.Add(new CitiesFields { Name = "Florida", Fare = 150 });
        }
    }
    public class DataFields
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }
    public class CitiesFields
    {
        public string Name { get; set; }
        public int Fare { get; set; }
    }
}
