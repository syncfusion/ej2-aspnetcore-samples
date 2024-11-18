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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Syncfusion.EJ2.Spreadsheet;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class SpreadsheetController : Controller
    {
        public IActionResult DefaultFunctionalities()
        {
            List<object> data = new List<object>()
            {
                new { CustomerName= "Romona Heaslip",  Model= "Taurus",  Color= "Aquamarine",  PaymentMode= "Debit Card",  DeliveryDate= "07-11-2015",  Amount= "8529.22" },
                new { CustomerName= "Clare Batterton",  Model= "Sparrow",  Color= "Pink",  PaymentMode= "Cash On Delivery",  DeliveryDate= "07-13-2016",  Amount= "17866.19" },
                new { CustomerName= "Eamon Traise",  Model= "Grand Cherokee",  Color= "Blue",  PaymentMode= "Net Banking",  DeliveryDate= "09-04-2015",  Amount= "13853.09" },
                new { CustomerName= "Julius Gorner",  Model= "GTO",  Color= "Aquamarine",  PaymentMode= "Credit Card",  DeliveryDate= "12-15-2017",  Amount= "2338.74" },
                new { CustomerName= "Jenna Schoolfield",  Model= "LX",  Color= "Yellow",  PaymentMode= "Credit Card",  DeliveryDate= "10-08-2014",  Amount= "9578.45" },
                new { CustomerName= "Marylynne Harring",  Model= "Catera",  Color= "Green",  PaymentMode= "Cash On Delivery",  DeliveryDate= "07-01-2017",  Amount= "19141.62" },
                new { CustomerName= "Vilhelmina Leipelt",  Model= "7 Series",  Color= "Goldenrod",  PaymentMode= "Credit Card",  DeliveryDate= "12-20-2015",  Amount= "6543.30" },
                new { CustomerName= "Barby Heisler",  Model= "Corvette",  Color= "Red",  PaymentMode= "Credit Card",  DeliveryDate= "11-24-2014",  Amount= "13035.06" },
                new { CustomerName= "Karyn Boik",  Model= "Regal",  Color= "Indigo",  PaymentMode= "Debit Card",  DeliveryDate= "05-12-2014",  Amount= "18488.80" },
                new { CustomerName= "Jeanette Pamplin",  Model= "S4",  Color= "Fuscia",  PaymentMode= "Net Banking",  DeliveryDate= "12-30-2014",  Amount= "12317.04" },
                new { CustomerName= "Cristi Espinos",  Model= "TL",  Color= "Aquamarine",  PaymentMode= "Credit Card",  DeliveryDate= "12-18-2013",  Amount= "6230.13" },
                new { CustomerName= "Issy Humm",  Model= "Club Wagon",  Color= "Pink",  PaymentMode= "Cash On Delivery",  DeliveryDate= "02-02-2015",  Amount= "9709.49" },
                new { CustomerName= "Tuesday Fautly",  Model= "V8 Vantage",  Color= "Crimson",  PaymentMode= "Debit Card",  DeliveryDate= "11-19-2014",  Amount= "9766.10" },
                new { CustomerName= "Rosemaria Thomann",  Model= "Caravan",  Color= "Violet",  PaymentMode= "Net Banking",  DeliveryDate= "02-08-2014",  Amount= "7685.49" },
                new { CustomerName= "Lyell Fuentez",  Model= "Bravada",  Color= "Violet",  PaymentMode= "Debit Card",  DeliveryDate= "08-05-2016",  Amount= "18012.45" },
                new { CustomerName= "Raynell Layne",  Model= "Colorado",  Color= "Pink",  PaymentMode= "Credit Card",  DeliveryDate= "05-30-2016",  Amount= "2785.49" },
                new { CustomerName= "Raye Whines",  Model= "4Runner",  Color= "Red",  PaymentMode= "Debit Card",  DeliveryDate= "12-10-2016",  Amount= "9967.74" },
                new { CustomerName= "Virgina Aharoni",  Model= "TSX",  Color= "Pink",  PaymentMode= "Cash On Delivery",  DeliveryDate= "10-23-2014",  Amount= "5584.33" },
                new { CustomerName= "Peta Cheshir",  Model= "Pathfinder",  Color= "Red",  PaymentMode= "Net Banking",  DeliveryDate= "12-24-2015",  Amount= "5286.53" },
                new { CustomerName= "Jule Urion",  Model= "Charger",  Color= "Violet",  PaymentMode= "Debit Card",  DeliveryDate= "11-20-2013",  Amount= "13511.91" },
                new { CustomerName= "Lew Gilyatt",  Model= "Bonneville",  Color= "Crimson",  PaymentMode= "Credit Card",  DeliveryDate= "11-19-2013",  Amount= "6498.19" },
                new { CustomerName= "Jobey Fortun",  Model= "B-Series",  Color= "Blue",  PaymentMode= "Net Banking",  DeliveryDate= "10-30-2014",  Amount= "10359.67" },
                new { CustomerName= "Blondie Crump",  Model= "Voyager",  Color= "Turquoise",  PaymentMode= "Credit Card",  DeliveryDate= "04-06-2018",  Amount= "8118.39" },
                new { CustomerName= "Florentia Binns",  Model= "Grand Prix",  Color= "Orange",  PaymentMode= "Cash On Delivery",  DeliveryDate= "10-13-2016",  Amount= "10204.37" },
                new { CustomerName= "Jaquelin Galtone",  Model= "Sunbird",  Color= "Red",  PaymentMode= "Net Banking",  DeliveryDate= "10-22-2013",  Amount= "6528.06" },
                new { CustomerName= "Hakeem Easseby",  Model= "Mirage",  Color= "Crimson",  PaymentMode= "Debit Card",  DeliveryDate= "09-12-2014",  Amount= "5619.25" },
                new { CustomerName= "Nickolaus Gidman",  Model= "XK",  Color= "Orange",  PaymentMode= "Debit Card",  DeliveryDate= "05-12-2016",  Amount= "5091.43" },
                new { CustomerName= "Jenine Iglesia",  Model= "Accord",  Color= "Orange",  PaymentMode= "Debit Card",  DeliveryDate= "09-03-2018",  Amount= "14566.08" },
                new { CustomerName= "Fax Witherspoon",  Model= "Range Rover Sport",  Color= "Orange",  PaymentMode= "Credit Card",  DeliveryDate= "02-22-2018",  Amount= "5284.87" }
            };
            ViewBag.DefaultData = data;
            return View();
        }

        public IActionResult Open(IFormCollection openRequest)
        {
            OpenRequest open = new OpenRequest();
            if (openRequest.Files.Count != 0)
            {
                open.File = openRequest.Files[0];
            }
            open.Password = openRequest["Password"];
            if (openRequest["SheetIndex"].Count != 0)
            {
                open.SheetIndex = int.Parse(openRequest["SheetIndex"]);
            }
            open.SheetPassword = openRequest["SheetPassword"];
            return Content(Workbook.Open(open));

        }

        public IActionResult Save(SaveSettings saveSettings)
        {
            return Workbook.Save(saveSettings);
        }
    }
}
