#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EJ2CoreSampleBrowser.Controllers.Grid
{
    public partial class GridController : Controller
    {
        public static List<Orderdd> order = new List<Orderdd>();
        public IActionResult DataAnnotation()
        {
            var order = Orderdd.getAllRecords();
            ViewBag.datasource = order;
            ViewBag.type = typeof(Orderdd);
            return View();
        }

        public class Orderdd
        {

            public Orderdd(long OrderId, string Customerid, int EmployeeId, double Freight, string ShipCity)
            {
                this.OrderID = OrderId;
                this.CustomerID = Customerid;
                this.EmployeeID = EmployeeId;
                this.Freight = Freight;
                this.ShipCity = ShipCity;
            }

            public static List<Orderdd> getAllRecords()
            {
                if (order.Count == 0)
                {
                    int code = 10000;
                    for (int i = 1; i < 13; i++)
                    {
                        order.Add(new Orderdd(code + 1, "ALFKI", i + 0, 2.3 * i, "Berlin"));
                        order.Add(new Orderdd(code + 2, "ANATR", i + 2, 3.3 * i, "Madrid"));
                        order.Add(new Orderdd(code + 3, "ANTON", i + 1, 4.3 * i, "Cholchester"));
                        order.Add(new Orderdd(code + 4, "BLONP", i + 3, 5.3 * i, "Marseille"));
                        order.Add(new Orderdd(code + 5, "BOLID", i + 4, 6.3 * i, "Tsawassen"));
                        code += 5;
                    }
                }
                return order;
            }
            [Key]
            [Display(Name = "Order ID")]
            [Required(ErrorMessage = "Order ID is required")]
            public long OrderID { get; set; }
            [Display(Name = "Customer ID")]
            [Required(ErrorMessage = "Customer ID is required")]
            [StringLength(8, MinimumLength = 3, ErrorMessage = "Customer ID length should between 3 and 8")]
            public string CustomerID { get; set; }
            [Display(Name = "Employee ID")]
            [Range(1, 20, ErrorMessage = "Employee ID should be between 1 and 20")]
            public int EmployeeID { get; set; }
            [DisplayFormat(DataFormatString = "c2")]
            [Range(1, 1000, ErrorMessage = "Freight should be between 1 and 1000")]
            public double Freight { get; set; }
            [Display(Name = "Ship City")]
            [Required(ErrorMessage = "Ship City is required")]
            public string ShipCity { get; set; }
        }
    }
}
