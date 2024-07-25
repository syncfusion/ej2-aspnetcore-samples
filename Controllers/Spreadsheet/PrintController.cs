#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Spreadsheet;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class SpreadsheetController : Controller
    {
        public IActionResult Print()
        {
            List<object> printData = new List<object>()
            {
                new { CustomerName= "Sarah Johnson", MailID= "sarah.johnson@example.com", Model= "Taurus", Noofcars= "2", DeliveryDate= "7/11/2020", Amount= "8529.22" },
                new { CustomerName= "Michael Smith", MailID= "michael.smith@example.com", Model= "Sparrow", Noofcars= "1", DeliveryDate= "7/13/2021", Amount= "17866.19" },
                new { CustomerName= "Emily Davis", MailID= "emily.davis@example.com", Model= "Grand Cherokee", Noofcars= "1", DeliveryDate= "9/4/2020", Amount= "13853.09" },
                new { CustomerName= "John Anderson", MailID= "john.anderson@example.com", Model= "GTO", Noofcars= "3", DeliveryDate= "12/15/2022", Amount= "2338.74" },
                new { CustomerName= "Jessica Martinez", MailID= "jessica.martinez@example.com", Model= "LX", Noofcars= "2", DeliveryDate= "10/8/2019", Amount= "9578.45" },
                new { CustomerName= "Daniel Thompson", MailID= "daniel.thompson@example.com", Model= "Catera", Noofcars= "1", DeliveryDate= "7/1/2022", Amount= "19141.62" },
                new { CustomerName= "Samantha Harris", MailID= "samantha.harris@example.com", Model= "Series 7", Noofcars= "3", DeliveryDate= "12/20/2020", Amount= "6543.30" },
                new { CustomerName= "Christopher Wilson", MailID= "christopher.wilson@example.com", Model= "Corvette", Noofcars= "2", DeliveryDate= "11/24/2019", Amount= "13035.06" },
                new { CustomerName= "Ashley Brown", MailID= "ashley.brown@example.com", Model= "Regal", Noofcars= "1", DeliveryDate= "5/12/2019", Amount= "18488.80" },
                new { CustomerName= "Matthew Taylor", MailID= "matthew.taylor@example.com", Model= "S4", Noofcars= "2", DeliveryDate= "12/30/2019", Amount= "12317.04" },
                new { CustomerName= "Olivia Garcia", MailID= "olivia.garcia@example.com", Model= "TL", Noofcars= "3", DeliveryDate= "12/18/2023", Amount= "6230.13" },
                new { CustomerName= "David Hernandez", MailID= "david.hernandez@example.com", Model= "Club Wagon", Noofcars= "2", DeliveryDate= "2/2/2020", Amount= "9709.49" },
                new { CustomerName= "Emma Moore", MailID= "emma.moore@example.com", Model= "V8 Vantage", Noofcars= "2", DeliveryDate= "11/19/2019", Amount= "9766.10" },
                new { CustomerName= "Andrew Lewis", MailID= "andrew.lewis@example.com", Model= "Caravan", Noofcars= "3", DeliveryDate= "2/8/2019", Amount= "7685.49" },
                new { CustomerName= "Elizabeth Clark", MailID= "elizabeth.clark@example.com", Model= "Bravada", Noofcars= "1", DeliveryDate= "8/5/2021", Amount= "18012.45" },
                new { CustomerName= "James Walker", MailID= "james.walker@example.com", Model= "Colorado", Noofcars= "3", DeliveryDate= "5/30/2021", Amount= "2785.49" },
                new { CustomerName= "Ava Rodriguez", MailID= "ava.rodriguez@example.com", Model= "Runner", Noofcars= "3", DeliveryDate= "12/10/2021", Amount= "9967.74" },
                new { CustomerName= "Ryan White", MailID= "ryan.white@example.com", Model= "TSX", Noofcars= "3", DeliveryDate= "10/23/2019", Amount= "5584.33" },
                new { CustomerName= "Madison Lee", MailID= "madison.lee@example.com", Model= "Pathfinder", Noofcars= "2", DeliveryDate= "12/24/2020", Amount= "5286.53" },
                new { CustomerName= "Nicholas Martin", MailID= "nicholas.martin@example.com", Model= "Charger", Noofcars= "2", DeliveryDate= "11/20/2023", Amount= "13511.91" },
                new { CustomerName= "Sophia Hall", MailID= "sophia.hall@example.com", Model= "Bonneville", Noofcars= "2", DeliveryDate= "11/19/2023", Amount= "6498.19" },
                new { CustomerName= "Joshua Young", MailID= "joshua.young@example.com", Model= "B-Series", Noofcars= "2", DeliveryDate= "10/30/2019", Amount= "10359.67" },
                new { CustomerName= "Isabella King", MailID= "isabella.king@example.com", Model= "Voyager", Noofcars= "3", DeliveryDate= "4/6/2023", Amount= "8118.39" },
                new { CustomerName= "Joseph Allen", MailID= "joseph.allen@example.com", Model= "Grand Prix", Noofcars= "1", DeliveryDate= "10/13/2021", Amount= "10204.37" },
                new { CustomerName= "Charlotte Scott", MailID= "charlotte.scott@example.com", Model= "Sunbird", Noofcars= "3", DeliveryDate= "10/22/2023", Amount= "6528.06" },
                new { CustomerName= "William Green", MailID= "william.green@example.com", Model= "Mirage", Noofcars= "2", DeliveryDate= "9/12/2019", Amount= "5619.25" },
                new { CustomerName= "Amelia Adams", MailID= "amelia.adams@example.com", Model= "XK", Noofcars= "1", DeliveryDate= "5/12/2021", Amount= "5091.43" },
                new { CustomerName= "Ethan Carter", MailID= "ethan.carter@example.com", Model= "Accord", Noofcars= "1", DeliveryDate= "9/3/2023", Amount= "14566.08" },
                new { CustomerName= "Mia Turner", MailID= "mia.turner@example.com", Model= "Range Rover Sport", Noofcars= "2", DeliveryDate= "2/22/2023", Amount= "5284.87" },
                new { CustomerName= "Alexander Baker", MailID= "alexander.baker@example.com", Model= "Runner", Noofcars= "3", DeliveryDate= "12/25/2023", Amount= "5524.25" },
                new { CustomerName= "Chloe Hill", MailID= "chloe.hill@example.com", Model= "TSX", Noofcars= "3", DeliveryDate= "2/25/2023", Amount= "2543.25" },
                new { CustomerName= "Benjamin Nelson", MailID= "benjamin.nelson@example.com", Model= "Pathfinder", Noofcars= "2", DeliveryDate= "11/19/2023", Amount= "8524.35" },
                new { CustomerName= "Grace Mitchell", MailID= "grace.mitchell@example.com", Model= "Charger", Noofcars= "2", DeliveryDate= "10/30/2019", Amount= "9542.35" },
                new { CustomerName= "Jacob Perez", MailID= "jacob.perez@example.com", Model= "Bonneville", Noofcars= "3", DeliveryDate= "4/6/2023", Amount= "8872.52" },
                new { CustomerName= "Avery Roberts", MailID= "avery.roberts@example.com", Model= "B-Series", Noofcars= "1", DeliveryDate= "10/13/2021", Amount= "12884.52" },
                new { CustomerName= "Ethan Thomas", MailID= "ethan.thomas@example.com", Model= "Voyager", Noofcars= "1", DeliveryDate= "10/22/2023", Amount= "19352.24" },
                new { CustomerName= "Lily Phillips", MailID= "lily.phillips@example.com", Model= "Grand Prix", Noofcars= "2", DeliveryDate= "9/12/2019", Amount= "8546.24" },
                new { CustomerName= "Samuel Davis", MailID= "samuel.davis@example.com", Model= "Sunbird", Noofcars= "3", DeliveryDate= "2/8/2019", Amount= "8844.25" },
                new { CustomerName= "Zoey Campbell", MailID= "zoey.campbell@example.com", Model= "Mirage", Noofcars= "2", DeliveryDate= "8/5/2021", Amount= "9635.25" },
                new { CustomerName= "Daniel Cooper", MailID= "daniel.cooper@example.com", Model= "XK", Noofcars= "3", DeliveryDate= "5/30/2021", Amount= "7854.24" },
                new { CustomerName= "Madeline Collins", MailID= "madeline.collins@example.com", Model= "Accord", Noofcars= "1", DeliveryDate= "12/10/2021", Amount= "14297.36" },
                new { CustomerName= "Nathan Edwards", MailID= "nathan.edwards@example.com", Model= "Range Rover Sport", Noofcars= "2", DeliveryDate= "12/24/2020", Amount= "8745.35" },
                new { CustomerName= "Evelyn Stewart", MailID= "evelyn.stewart@example.com", Model= "Runner", Noofcars= "1", DeliveryDate= "11/20/2023", Amount= "17825.52" },
                new { CustomerName= "Alexander Rivera", MailID= "alexander.rivera@example.com", Model= "TSX", Noofcars= "1", DeliveryDate= "12/20/2020", Amount= "15994.34" },
                new { CustomerName= "Sophia Henderson", MailID= "sophia.henderson@example.com", Model= "Pathfinder", Noofcars= "2", DeliveryDate= "8/30/2019", Amount= "9154.34" },
                new { CustomerName= "Isaac Morris", MailID= "isaac.morris@example.com", Model= "Charger", Noofcars= "3", DeliveryDate= "12/13/2023", Amount= "13082.34" },
                new { CustomerName= "Claire Rogers", MailID= "claire.rogers@example.com", Model= "Bonneville", Noofcars= "3", DeliveryDate= "10/1/2019", Amount= "7963.35" },
                new { CustomerName= "Luke Flores", MailID= "luke.flores@example.com", Model= "B-Series", Noofcars= "3", DeliveryDate= "10/31/2023", Amount= "6734.35" },
                new { CustomerName= "Aubrey Long", MailID= "aubrey.long@example.com", Model= "Voyager", Noofcars= "1", DeliveryDate= "8/21/2019", Amount= "12864.35" },
                new { CustomerName= "Julian Coleman", MailID= "julian.coleman@example.com", Model= "Grand Prix", Noofcars= "2", DeliveryDate= "7/7/2021", Amount= "7985.36" },
                new { CustomerName= "Leah Reed", MailID= "leah.reed@example.com", Model= "Sunbird", Noofcars= "1", DeliveryDate= "2/3/2022", Amount= "19245.36" },
                new { CustomerName= "Gabriel Bell", MailID= "gabriel.bell@example.com", Model= "Mirage", Noofcars= "3", DeliveryDate= "1/23/2021", Amount= "7835.36" },
                new { CustomerName= "Natalie Ward", MailID= "natalie.ward@example.com", Model= "XK", Noofcars= "1", DeliveryDate= "8/6/2020", Amount= "16324.35" },
                new { CustomerName= "Lucas Brooks", MailID= "lucas.brooks@example.com", Model= "Accord", Noofcars= "2", DeliveryDate= "11/1/2019", Amount= "8845.34" },
                new { CustomerName= "Hailey Mitchell", MailID= "hailey.mitchell@example.com", Model= "Range Rover Sport", Noofcars= "1", DeliveryDate= "8/17/2023", Amount= "12684.35" },
                new { CustomerName= "Jackson Ward", MailID= "jackson.ward@example.com", Model= "Runner", Noofcars= "1", DeliveryDate= "3/3/2019", Amount= "15093.36" }

            };
            List<object> yearlyReportDataSource = new List<object>()
            {
                new { Model= "Accord", Year2018= "0", Year2019= "2", Year2020= "0", Year2021= "1", Year2022= "0", Year2023= "1" },
                new { Model= "Bonneville", Year2018= "2", Year2019= "3", Year2020= "0", Year2021= "0", Year2022= "0", Year2023= "3" },
                new { Model= "Bravada", Year2018= "0", Year2019= "0", Year2020= "0", Year2021= "1", Year2022= "0", Year2023= "0" },
                new { Model= "B-Series", Year2018= "3", Year2019= "2", Year2020= "0", Year2021= "1", Year2022= "0", Year2023= "0" },
                new { Model= "Caravan", Year2018= "0", Year2019= "3", Year2020= "0", Year2021= "0", Year2022= "0", Year2023= "0" },
                new { Model= "Catera", Year2018= "0", Year2019= "0", Year2020= "0", Year2021= "0", Year2022= "1", Year2023= "0" },
                new { Model= "Charger", Year2018= "5", Year2019= "2", Year2020= "0", Year2021= "0", Year2022= "0", Year2023= "0" },
                new { Model= "Club Wagon", Year2018= "0", Year2019= "0", Year2020= "2", Year2021= "0", Year2022= "0", Year2023= "0" },
                new { Model= "Colorado", Year2018= "0", Year2019= "0", Year2020= "0", Year2021= "3", Year2022= "0", Year2023= "0" },
                new { Model= "Corvette", Year2018= "0", Year2019= "2", Year2020= "0", Year2021= "0", Year2022= "0", Year2023= "0" },
                new { Model= "Grand Cherokee", Year2018= "0", Year2019= "0", Year2020= "1", Year2021= "0", Year2022= "0", Year2023= "0" },
                new { Model= "Grand Prix", Year2018= "0", Year2019= "2", Year2020= "0", Year2021= "3", Year2022= "0", Year2023= "0" },
                new { Model= "GTO", Year2018= "0", Year2019= "0", Year2020= "0", Year2021= "0", Year2022= "3", Year2023= "0" },
                new { Model= "LX", Year2018= "0", Year2019= "2", Year2020= "0", Year2021= "0", Year2022= "0", Year2023= "0" },
                new { Model= "Mirage", Year2018= "0", Year2019= "2", Year2020= "0", Year2021= "5", Year2022= "0", Year2023= "0" },
                new { Model= "Pathfinder", Year2018= "2", Year2019= "2", Year2020= "2", Year2021= "0", Year2022= "0", Year2023= "0" },
                new { Model= "Range Rover Sport", Year2018= "1", Year2019= "0", Year2020= "2", Year2021= "0", Year2022= "0", Year2023= "2" },
                new { Model= "Regal", Year2018= "0", Year2019= "1", Year2020= "0", Year2021= "0", Year2022= "0", Year2023= "0" },
                new { Model= "Runner", Year2018= "1", Year2019= "1", Year2020= "0", Year2021= "3", Year2022= "0", Year2023= "3" },
                new { Model= "S4", Year2018= "0", Year2019= "2", Year2020= "0", Year2021= "0", Year2022= "0", Year2023= "0" },
                new { Model= "Series 7", Year2018= "0", Year2019= "0", Year2020= "3", Year2021= "0", Year2022= "0", Year2023= "0" },
                new { Model= "Sparrow", Year2018= "0", Year2019= "0", Year2020= "0", Year2021= "1", Year2022= "0", Year2023= "0" },
                new { Model= "Sunbird", Year2018= "3", Year2019= "3", Year2020= "0", Year2021= "0", Year2022= "1", Year2023= "0" },
                new { Model= "Taurus", Year2018= "0", Year2019= "0", Year2020= "2", Year2021= "0", Year2022= "0", Year2023= "0" },
                new { Model= "TL", Year2018= "3", Year2019= "0", Year2020= "0", Year2021= "0", Year2022= "0", Year2023= "0" },
                new { Model= "TSX", Year2018= "0", Year2019= "3", Year2020= "1", Year2021= "0", Year2022= "0", Year2023= "3" },
                new { Model= "V8 Vantage", Year2018= "0", Year2019= "2", Year2020= "0", Year2021= "0", Year2022= "0", Year2023= "0" },
                new { Model= "Voyager", Year2018= "1", Year2019= "1", Year2020= "0", Year2021= "0", Year2022= "0", Year2023= "3" },
                new { Model= "XK", Year2018= "0", Year2019= "0", Year2020= "1", Year2021= "4", Year2022= "0", Year2023= "0" }

            };
            ViewBag.PrintData = printData;
            ViewBag.YearlyReport = yearlyReportDataSource;
            ViewBag.ImageSource = this.GetImageSource();
            return View();
        }

        public string GetImageSource()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/Spreadsheet/SpreadsheetImage.txt");
            return allText;
        }

        public IActionResult PrintOpen(IFormCollection openRequest)
        {
            OpenRequest open = new OpenRequest();
            open.File = openRequest.Files[0];
            return Content(Workbook.Open(open));
        }

        public IActionResult PrintSave(SaveSettings saveSettings)
        {
            return Workbook.Save(saveSettings);
        }
    }
}
