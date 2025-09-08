#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid
{
    public class StackedHeadersModel : PageModel
    {
        public class StackedHeaderData
        {
            public int OrderID { get; set; }
            public int CustomerID { get; set; }
            public string CustomerName { get; set; }
            public DateTime OrderDate { get; set; }
            public DateTime ShippedDate { get; set; }
            public double Freight { get; set; }
            public string ShipName { get; set; }
            public string ShipAddress { get; set; }
            public string ShipCity { get; set; }
            public string ShipRegion { get; set; }
            public string ShipCountry { get; set; }
            public int Year { get; set; }
            public int Salary { get; set; }
            public int Feedback { get; set; }
            public string Status { get; set; }
            
            public StackedHeaderData(int orderId, int customerId, string customerName, DateTime orderDate, DateTime shippedDate, double freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipCountry, int year, int salary, int feedback, string status)
            {
                this.OrderID = orderId;
                this.CustomerID = customerId;
                this.CustomerName = customerName;
                this.OrderDate = orderDate;
                this.ShippedDate = shippedDate;
                this.Freight = freight;
                this.ShipName = shipName;
                this.ShipAddress = shipAddress;
                this.ShipCity = shipCity;
                this.ShipRegion = shipRegion;
                this.ShipCountry = shipCountry;
                this.Year = year;
                this.Salary = salary;
                this.Feedback = feedback;
                this.Status = status;
            }

            public static List<StackedHeaderData> GenerateStackedHeaderData(long count)
            {
                string[] customerNames = { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD", "CHOPS", "RICSU", "WELLI", "HILAA", "ERNSH", "CENTC", "OTTIK", "QUEDE" };
                string[] shipCities = { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi", "Bern", "Genève", "Resende", "San Cristóbal", "Graz", "México D.F.", "Köln", "Rio de Janeiro" };
                string[] shipCountries = { "France", "Germany", "Brazil", "Belgium", "Switzerland", "Austria", "Mexico", "Venezuela" };
                string[] statusOptions = { "Delivered", "Delivered", "In-progress", "Delivered", "In-progress", "In-progress", "Delivered", "Delivered", "In-progress", "Delivered" };
                DateTime[] date = { new DateTime(1704067200000), new DateTime(1706745600000), new DateTime(1730467200000), new DateTime(1727788800000), new DateTime(1725206400000), new DateTime(1722528000000), new DateTime(1719849600000),
                                    new DateTime(1717312000000), new DateTime(1714720000000), new DateTime(1712041600000), new DateTime(1709459200000), new DateTime(1706781000000), new DateTime(1704288000000)};
                double[] freightValues = { 10.5, 20.75, 30.0, 40.25, 50.6, 60.85, 70.9, 80.1, 90.45, 100.55 };
                int[] feedbackValues = { 1, 2, 3, 4, 5 };
                List<StackedHeaderData> stackedHeaderData = new List<StackedHeaderData>();
                for (int i = 1; i <= count; i++)
                {
                    stackedHeaderData.Add(new StackedHeaderData(
                        150000 + i,
                        1000 + i,
                        customerNames[i % customerNames.Length],
                        date[i % date.Length],
                        date[i % date.Length],
                        freightValues[i % freightValues.Length],
                        customerNames[i % customerNames.Length] + " Logistics",
                        "Address " + i,
                        shipCities[i % shipCities.Length],
                        null,
                        shipCountries[i % shipCountries.Length],
                        2025,
                        new Random().Next(25000, 55000),
                        statusOptions[i % statusOptions.Length] == "In-progress" ? 0 : feedbackValues[i % feedbackValues.Length],
                        statusOptions[i % statusOptions.Length]
                    ));
                }
                return stackedHeaderData;
            }
        }
    }
}