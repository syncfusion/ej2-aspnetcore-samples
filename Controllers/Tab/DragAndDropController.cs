#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
        // GET: /<controller>/
        public IActionResult DragAndDrop()
        {
            List<object> componentList = new List<object>();
            componentList.Add(new
            {
                text = "DropdownList",
                id = "list-01",
                name = "DropdownList"
            });
            componentList.Add(new
            {
                text = "DatePicker",
                id = "list-02",
                name = "DatePicker"
            });
            componentList.Add(new
            {
                text = "Calendar",
                id = "list-03",
                name = "Calendar"
            });
            componentList.Add(new
            {
                text = "FileUpload",
                id = "list-04",
                name = "FileUpload"
            });
            componentList.Add(new
            {
                text = "RichTextEditor",
                id = "list-05",
                name = "RichTextEditor"
            });
            ViewBag.data = componentList;
            ViewBag.headerTextOne = new TabHeader { Text = "DataGrid" };
            ViewBag.headerTextTwo = new TabHeader { Text = "Chart" };
            ViewBag.headerTextThree = new TabHeader { Text = "Scheduler" };
            List<GridData> gridDataSource = new List<GridData>
            {
                new GridData { OrderID = 10248, CustomerID = "VINET", EmployeeID = 5, OrderDate = new DateTime(1991, 05, 15), ShipName = "Vins et alcools Chevalier", ShipCity = "Reims", ShipAddress = "59 rue de l Abbaye", ShipRegion = "CJ", ShipPostalCode = "51100", ShipCountry = "France", Freight = (decimal?)32.38 },
                new GridData { OrderID = 10249, CustomerID = "TOMSP", EmployeeID = 6, OrderDate = new DateTime(1952, 02, 19), ShipName = "Toms Spezialitäten", ShipCity = "Münster", ShipAddress = "Luisenstr. 48", ShipRegion = "CJ", ShipPostalCode = "44087", ShipCountry = "Germany", Freight = (decimal?)11.61 },
                new GridData { OrderID = 10250, CustomerID = "HANAR", EmployeeID = 4, OrderDate = new DateTime(1963, 08, 30), ShipName = "Hanari Carnes", ShipCity = "Rio de Janeiro", ShipAddress = "Rua do Paço, 67", ShipRegion = "RJ", ShipPostalCode = "05454-876", ShipCountry = "Brazil", Freight = (decimal?)65.83 },
                new GridData { OrderID = 10251, CustomerID = "VICTE", EmployeeID = 3, OrderDate = new DateTime(1937, 09, 19), ShipName = "Victuailles en stock", ShipCity = "Lyon", ShipAddress = "2, rue du Commerce", ShipRegion = "CJ", ShipPostalCode = "69004", ShipCountry = "France", Freight = (decimal?)41.34 },
                new GridData { OrderID = 10252, CustomerID = "SUPRD", EmployeeID = 2, OrderDate = new DateTime(1955, 03, 04), ShipName = "Suprêmes délices", ShipCity = "Charleroi", ShipAddress = "Boulevard Tirou, 255", ShipRegion = "CJ", ShipPostalCode = "B-6000", ShipCountry = "Belgium", Freight = (decimal?)51.3 }
            };
            ViewBag.gridData = gridDataSource;
            List<LineData> chartDataSource = new List<LineData>
            {
                new LineData { month = "Jan", sales = 35 },
                new LineData { month = "Feb", sales = 28 },
                new LineData { month = "Mar", sales = 34 },
                new LineData { month = "Apr", sales = 32 },
                new LineData { month = "May", sales = 40 },
                new LineData { month = "Jun", sales = 32 },
                new LineData { month = "Jul", sales = 35 },
                new LineData { month = "Aug", sales = 55 },
                new LineData { month = "Sep", sales = 38 },
                new LineData { month = "Oct", sales = 30 },
                new LineData { month = "Nov", sales = 25 },
                new LineData { month = "Dec", sales = 32 },
            };
            ViewBag.chartData = chartDataSource;
            ViewBag.sportsData = new string[] { "Badminton", "Cricket", "Football", "Golf", "Tennis" };
            return View();
        }

        public class LineData
        {
            public string month;
            public double sales;
        }

        public class GridData
        {
            public int? OrderID { get; set; }
            public string CustomerID { get; set; }
            public int? EmployeeID { get; set; }
            public decimal? Freight { get; set; }
            public string ShipCity { get; set; }
            public DateTime OrderDate { get; set; }
            public string ShipName { get; set; }
            public string ShipCountry { get; set; }
            public string ShipRegion { get; set; }
            public string ShipPostalCode { get; set; }
            public string ShipAddress { get; set; }
        }
    }
}
