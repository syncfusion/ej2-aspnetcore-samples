using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class TabController : Controller
    {
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

        List<DataFields> quotaData = new List<DataFields>();
        List<DataFields> genderData = new List<DataFields>();
        List<DataFields> berthData = new List<DataFields>();
        List<CitiesFields> citiesData = new List<CitiesFields>();
        public IActionResult Wizard()
        {
            quotaData.Add(new DataFields { ID = "1", Text = "Business Class" });
            quotaData.Add(new DataFields { ID = "2", Text = "Economy Class" });
            quotaData.Add(new DataFields { ID = "3", Text = "Common Class" });

            genderData.Add(new DataFields { ID = "1", Text = "Male" });
            genderData.Add(new DataFields { ID = "2", Text = "Female" });

            berthData.Add(new DataFields { ID = "1", Text = "Upper" });
            berthData.Add(new DataFields { ID = "2", Text = "Lower" });
            berthData.Add(new DataFields { ID = "3", Text = "Middle" });
            berthData.Add(new DataFields { ID = "4", Text = "Window" });
            berthData.Add(new DataFields { ID = "5", Text = "Aisle" });

            citiesData.Add(new CitiesFields { Name = "Chicago", Fare = 300 });
            citiesData.Add(new CitiesFields { Name = "San Francisco", Fare = 125 });
            citiesData.Add(new CitiesFields { Name = "Los Angeles", Fare = 175 });
            citiesData.Add(new CitiesFields { Name = "Seattle", Fare = 250 });
            citiesData.Add(new CitiesFields { Name = "Florida", Fare = 150 });

            ViewBag.headerTextOne = new TabHeader { Text = "New Booking" };
            ViewBag.headerTextTwo = new TabHeader { Text = "Train List" };
            ViewBag.headerTextThree = new TabHeader { Text = "Add Passenger" };
            ViewBag.headerTextFour = new TabHeader { Text = "Make Payment" };

            ViewBag.quota = quotaData;
            ViewBag.gender = genderData;
            ViewBag.berth = berthData;
            ViewBag.citiesData = citiesData;

            ViewBag.min = DateTime.Now;
            ViewBag.max = DateTime.Now.AddMonths(3);
			ViewBag.value = DateTime.Now;

            return View();
        }
    }
}
