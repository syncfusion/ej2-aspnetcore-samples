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

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class SpreadsheetController : Controller
    {
        public IActionResult CellFormatting()
        {
            List<object> orderDetails = new List<object>()
            {
                new { OrderID= 10248, CustomerName= "Paul Henriot", OrderDate= "7/4/1996", Address= "59 rue de l Abbaye", City= "Reims", PostalCode= "51100", Country= "France", Status= "Delivered", Freight= "$32.38"},
                new { OrderID= 10249, CustomerName= "Karin Josephs", OrderDate= "7/5/1996", Address= "Luisenstr. 48", City= "Münster", PostalCode= "44087", Country= "Germany", Status= "Delivered", Freight= "$11.61"},
                new { OrderID= 10250, CustomerName= "Mario Pontes", OrderDate= "7/8/1996", Address= "Rua do Paço,  67", City= "Rio de Janeiro", PostalCode= "05454876", Country= "Brazil", Status= "Shipped", Freight= "$65.83"},
                new { OrderID= 10251, CustomerName= "Mary Saveley", OrderDate= "7/4/1996", Address= "2,  rue du Commerce", City= "Lyon", PostalCode= "69004", Country= "France", Status= "Delivered", Freight= "$41.34"},
                new { OrderID= 10252, CustomerName= "Pascale Cartrain", OrderDate= "7/8/1996", Address= "Boulevard Tirou,  255", City= "Charleroi", PostalCode= "6000", Country= "Belgium", Status= "Shipped", Freight= "$51.3"},
                new { OrderID= 10253, CustomerName= "Carlos Hernández", OrderDate= "7/1/1996", Address= "Rua do Paço,  67", City= "Rio de Janeiro", PostalCode= "05454876", Country= "Brazil", Status= "Cancelled", Freight= "$58.17"},
                new { OrderID= 10254, CustomerName= "Yang Wang", OrderDate= "7/18/1996", Address= "Hauptstr. 31", City= "Bern", PostalCode= "3012", Country= "Switzerland", Status= "Pending", Freight= "$22.98"},
                new { OrderID= 10255, CustomerName= "Antonio Moreno", OrderDate= "7/7/1996", Address= "Starenweg 5", City= "Genève", PostalCode= "1204", Country= "Switzerland", Status= "Delivered", Freight= "$148.33"},
                new { OrderID= 10256, CustomerName= "Paula Parente", OrderDate= "7/10/1996", Address= "Rua do Mercado,  12", City= "Resende", PostalCode= "08737363", Country= "Brazil", Status= "Shipped", Freight= "$13.97"},
                new { OrderID= 10257, CustomerName= "Michael Holz", OrderDate= "7/9/1996", Address= "Carrera 22 con Ave. Carlos Soublette", City= "San Cristóbal", PostalCode= "5022", Country= "Venezuela", Status= "Delivered", Freight= "$81.91"},
                new { OrderID= 10258, CustomerName= "Roland Mendel", OrderDate= "7/3/1996", Address= "Kirchgasse 6", City= "Graz", PostalCode= "8010", Country= "Austria", Status= "Cancelled", Freight= "$140.51"},
                new { OrderID= 10259, CustomerName= "Francisco Chang", OrderDate= "7/22/1996", Address= "Sierras de Granada 9993", City= "México D.F.", PostalCode= "05022", Country= "Mexico", Status= "Pending", Freight= "$3.25"},
                new { OrderID= 10260, CustomerName= "Henriette Pfalzheim", OrderDate= "7/12/1996", Address= "Mehrheimerstr. 369", City= "Köln", PostalCode= "50739", Country= "Germany", Status= "Delivered", Freight= "$55.09"},
                new { OrderID= 10261, CustomerName= "Bernardo Batista", OrderDate= "7/15/1996", Address= "Rua da Panificadora,  12", City= "Rio de Janeiro", PostalCode= "02389673", Country= "Brazil", Status= "Shipped", Freight= "$3.05"},
                new { OrderID= 10262, CustomerName= "Paula Wilson", OrderDate= "7/8/1996", Address= "2817 Milton Dr.", City= "Albuquerque", PostalCode= "87110", Country= "USA", Status= "Delivered", Freight= "$48.29"}
            };
            ViewBag.orderDetails = orderDetails;
            return View();
        }
    }
}