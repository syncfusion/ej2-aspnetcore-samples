#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.FAB
{
    public class OverviewModel : PageModel
    {
        public List<OrderDetails> Order { get; set; }

        public void OnGet()
        {
            Order = new List<OrderDetails>();
            Order.Add(new OrderDetails { OrderID = 10248, CustomerID = "VINET", Freight = 32.38, ShipCountry = "France" });
            Order.Add(new OrderDetails { OrderID = 10249, CustomerID = "TOMSP", Freight = 11.61, ShipCountry = "Germany" });
            Order.Add(new OrderDetails { OrderID = 10250, CustomerID = "HANAR", Freight = 65.83, ShipCountry = "Brazil" });
            Order.Add(new OrderDetails { OrderID = 10251, CustomerID = "VICTE", Freight = 41.34, ShipCountry = "France" });
            Order.Add(new OrderDetails { OrderID = 10252, CustomerID = "SUPRD", Freight = 51.3, ShipCountry = "Belgium" });
            Order.Add(new OrderDetails { OrderID = 10253, CustomerID = "HANAR", Freight = 58.17, ShipCountry = "Brazil" });
            Order.Add(new OrderDetails { OrderID = 10254, CustomerID = "CHOPS", Freight = 22.98, ShipCountry = "Switzerland" });
            Order.Add(new OrderDetails { OrderID = 10255, CustomerID = "RICSU", Freight = 148.33, ShipCountry = "Switzerland" });
            Order.Add(new OrderDetails { OrderID = 10256, CustomerID = "WELLI", Freight = 13.97, ShipCountry = "Brazil" });
            Order.Add(new OrderDetails { OrderID = 10257, CustomerID = "HILAA", Freight = 81.91, ShipCountry = "Venezuela" });
        }
    }

    public class OrderDetails
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }
}