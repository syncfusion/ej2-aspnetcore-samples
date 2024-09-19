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
    public class DragAndDropModel : PageModel
    {
        public List<object> ComponentList = new List<object>();
        public List<GridData> GridDataSource = new List<GridData>();
        public List<LineData> ChartDataSource = new List<LineData>();
        public void OnGet()
        {
            ComponentList.Add(new
            {
                text = "DropdownList",
                id = "list-01",
                name = "DropdownList"
            });
            ComponentList.Add(new
            {
                text = "DatePicker",
                id = "list-02",
                name = "DatePicker"
            });
            ComponentList.Add(new
            {
                text = "Calendar",
                id = "list-03",
                name = "Calendar"
            });
            ComponentList.Add(new
            {
                text = "FileUpload",
                id = "list-04",
                name = "FileUpload"
            });
            ComponentList.Add(new
            {
                text = "RichTextEditor",
                id = "list-05",
                name = "RichTextEditor"
            });

            GridDataSource.Add(new GridData
            {
                OrderID = 10248, CustomerID = "VINET", EmployeeID = 5, OrderDate = new DateTime(1991, 05, 15),
                ShipName = "Vins et alcools Chevalier", ShipCity = "Reims", ShipAddress = "59 rue de l Abbaye",
                ShipRegion = "CJ", ShipPostalCode = "51100", ShipCountry = "France", Freight = (decimal?)32.38
            });
            GridDataSource.Add(new GridData
            {
                OrderID = 10249, CustomerID = "TOMSP", EmployeeID = 6, OrderDate = new DateTime(1952, 02, 19),
                ShipName = "Toms Spezialitäten", ShipCity = "Münster", ShipAddress = "Luisenstr. 48", ShipRegion = "CJ",
                ShipPostalCode = "44087", ShipCountry = "Germany", Freight = (decimal?)11.61
            });
            GridDataSource.Add(new GridData
            {
                OrderID = 10250, CustomerID = "HANAR", EmployeeID = 4, OrderDate = new DateTime(1963, 08, 30),
                ShipName = "Hanari Carnes", ShipCity = "Rio de Janeiro", ShipAddress = "Rua do Paço, 67",
                ShipRegion = "RJ", ShipPostalCode = "05454-876", ShipCountry = "Brazil", Freight = (decimal?)65.83
            });
            GridDataSource.Add(new GridData
            {
                OrderID = 10251, CustomerID = "VICTE", EmployeeID = 3, OrderDate = new DateTime(1937, 09, 19),
                ShipName = "Victuailles en stock", ShipCity = "Lyon", ShipAddress = "2, rue du Commerce",
                ShipRegion = "CJ", ShipPostalCode = "69004", ShipCountry = "France", Freight = (decimal?)41.34
            });
            GridDataSource.Add(new GridData
            {
                OrderID = 10252, CustomerID = "SUPRD", EmployeeID = 2, OrderDate = new DateTime(1955, 03, 04),
                ShipName = "Suprêmes délices", ShipCity = "Charleroi", ShipAddress = "Boulevard Tirou, 255",
                ShipRegion = "CJ", ShipPostalCode = "B-6000", ShipCountry = "Belgium", Freight = (decimal?)51.3
            });

            ChartDataSource.Add(new LineData { month = "Jan", sales = 35 });
            ChartDataSource.Add(new LineData { month = "Feb", sales = 28 });
            ChartDataSource.Add(new LineData { month = "Mar", sales = 34 });
            ChartDataSource.Add(new LineData { month = "Apr", sales = 32 });
            ChartDataSource.Add(new LineData { month = "May", sales = 40 });
            ChartDataSource.Add(new LineData { month = "Jun", sales = 32 });
            ChartDataSource.Add(new LineData { month = "Jul", sales = 35 });
            ChartDataSource.Add(new LineData { month = "Aug", sales = 55 });
            ChartDataSource.Add(new LineData { month = "Sep", sales = 38 });
            ChartDataSource.Add(new LineData { month = "Oct", sales = 30 });
            ChartDataSource.Add(new LineData { month = "Nov", sales = 25 });
            ChartDataSource.Add(new LineData { month = "Dec", sales = 32 });
        }
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
