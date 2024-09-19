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
        public IActionResult SortingFiltering()
        {
            List<object> data = new List<object>()
            {
                new { EmployeeID= "5389863",  EmployeeName= "Liuka Tewkesberry",  Gender= "Female",  Department= "Human Resources",  DateOfJoining= "08-22-2018",  Salary= "32940.53", City= "Valencia" },
                new { EmployeeID= "9141760",  EmployeeName= "Maurine McGreal",  Gender= "Female",  Department= "Accounting",  DateOfJoining= "02-19-2016",  Salary= "12769.67", City= "Thị Xã Lai Châu" },
                new { EmployeeID= "0440371",  EmployeeName= "Abby Marcum",  Gender= "Male",  Department= "Legal",  DateOfJoining= "03-12-2019",  Salary= "18565.98", City= "Lachute" },
                new { EmployeeID= "4319060",  EmployeeName= "Colet Dreghorn",  Gender= "Male",  Department= "Marketing",  DateOfJoining= "11-02-2018",  Salary= "36075.62", City= "Cincinnati" },
                new { EmployeeID= "8524811",  EmployeeName= "Morey Ilyin",  Gender= "Male",  Department= "Sales",  DateOfJoining= "07-13-2018",  Salary= "19845.66", City= "Liudu" },
                new { EmployeeID= "3536836",  EmployeeName= "Justus Eilert",  Gender= "Male",  Department= "Services",  DateOfJoining= "08-30-2016",  Salary= "25054.73", City= "Kitamilo" },
                new { EmployeeID= "6035100",  EmployeeName= "Lorelle Whyberd",  Gender= "Female",  Department= "Marketing",  DateOfJoining= "09-16-2010",  Salary= "21552.49", City= "Qandala" },
                new { EmployeeID= "9595117",  EmployeeName= "Hans Sponer",  Gender= "Male",  Department= "Legal",  DateOfJoining= "11-25-2019",  Salary= "12751.78", City= "Parakou" },
                new { EmployeeID= "9251706",  EmployeeName= "Esme Beaglehole",  Gender= "Female",  Department= "Engineering",  DateOfJoining= "11-24-2017",  Salary= "34244.64", City= "Saint-Ambroise" },
                new { EmployeeID= "5041677",  EmployeeName= "Hans Sponer",  Gender= "Female",  Department= "Marketing",  DateOfJoining= "01-21-2019",  Salary= "25722.37", City= "Huashi" },
                new { EmployeeID= "9596007",  EmployeeName= "Glen Lambrechts",  Gender= "Male",  Department= "Human Resources",  DateOfJoining= "09-25-2019",  Salary= "47190.81", City= "Krajan Nglinggis" },
                new { EmployeeID= "3506310",  EmployeeName= "Judy Crick",  Gender= "Female",  Department= "Human Resources",  DateOfJoining= "10-22-2013",  Salary= "14168.85", City= "Jianchang" },
                new { EmployeeID= "0283605",  EmployeeName= "Megen McSherry",  Gender= "Female",  Department= "Engineering",  DateOfJoining= "10-19-2016",  Salary= "49673.94", City= "Talisayan" },
                new { EmployeeID= "5918336",  EmployeeName= "Aloysius Blunden",  Gender= "Male",  Department= "Services",  DateOfJoining= "06-16-2010",  Salary= "23992.84", City= "Italó" },
                new { EmployeeID= "7239057",  EmployeeName= "Bruce Pook",  Gender= "Male",  Department= "Services",  DateOfJoining= "08-15-2019",  Salary= "46169.78", City= "Drawsko" },
                new { EmployeeID= "2603324",  EmployeeName= "Reggie Gethins",  Gender= "Female",  Department= "Training",  DateOfJoining= "05-03-2014",  Salary= "48793.33", City= "Baiqiao" },
                new { EmployeeID= "8641019",  EmployeeName= "Happy Terrell",  Gender= "Female",  Department= "Product Management",  DateOfJoining= "01-07-2010",  Salary= "11971.89", City= "Bandar-e Lengeh" },
                new { EmployeeID= "2229621",  EmployeeName= "Dermot Swithenby",  Gender= "Male",  Department= "Business Development",  DateOfJoining= "05-31-2017",  Salary= "14627.52", City= "Da’an" },
                new { EmployeeID= "6507226",  EmployeeName= "Dusty Naulls",  Gender= "Female",  Department= "Engineering",  DateOfJoining= "05-17-2012",  Salary= "49569.60", City= "Kelowna" },
                new { EmployeeID= "9588238",  EmployeeName= "oycey Gemlbett",  Gender= "Male",  Department= "Accounting",  DateOfJoining= "08-19-2014",  Salary= "11400.60", City= "Quezon" },
                new { EmployeeID= "4783061",  EmployeeName= "Gregoire Craik",  Gender= "Male",  Department= "Support",  DateOfJoining= "01-07-2015",  Salary= "28536.96", City= "Sacramento" },
                new { EmployeeID= "1086662",  EmployeeName= "Paquito Keetch",  Gender= "Male",  Department= "Legal",  DateOfJoining= "07-20-2017",  Salary= "10948.94", City= "Xieshui" },
                new { EmployeeID= "7111790",  EmployeeName= "Siouxie Lippini",  Gender= "Female",  Department= "Engineering",  DateOfJoining= "02-08-2012",  Salary= "42688.51", City= "Bigoudine" },
                new { EmployeeID= "9189124",  EmployeeName= "Valerye Russell",  Gender= "Female",  Department= "Services",  DateOfJoining= "07-17-2012",  Salary= "32651.96", City= "Pichilemu" },
                new { EmployeeID= "6015219",  EmployeeName= "Patience Ludman",  Gender= "Female",  Department= "Training",  DateOfJoining= "09-25-2018",  Salary= "17589.61", City= "Binjiang" },
                new { EmployeeID= "5210163",  EmployeeName= "Helene Borsay",  Gender= "Female",  Department= "Services",  DateOfJoining= "01-19-2018",  Salary= "34017.42", City= "Chengkan" },
                new { EmployeeID= "6656266",  EmployeeName= "Garrek Fatharly",  Gender= "Male",  Department= "Business Development",  DateOfJoining= "08-22-2018",  Salary= "49775.81", City= "San Antonio Oeste" },
                new { EmployeeID= "8740096",  EmployeeName= "Fulton Culverhouse",  Gender= "Male",  Department= "Product Management",  DateOfJoining= "01-11-2014",  Salary= "36633.61", City= "Borlänge" },
                new { EmployeeID= "7875847",  EmployeeName= "Lavena Yandle",  Gender= "Female",  Department= "Accounting",  DateOfJoining= "08-31-2016",  Salary= "25835.58", City= "Borino" },
                new { EmployeeID= "8436792",  EmployeeName= "Sophia Cowwell",  Gender= "Female",  Department= "Product Management",  DateOfJoining= "08-06-2011",  Salary= "46836.53", City= "Fécamp" },
                new { EmployeeID= "2789522",  EmployeeName= "Dode Bowmen",  Gender= "Female",  Department= "Sales",  DateOfJoining= "02-21-2010",  Salary= "27575.10", City= "Karangwaru" },
                new { EmployeeID= "2816501",  EmployeeName= "Peggi Grishelyov",  Gender= "Female",  Department= "Accounting",  DateOfJoining= "12-08-2012",  Salary= "41712.59", City= "San Antonio" },
                new { EmployeeID= "5648843",  EmployeeName= "Ailsun Porker",  Gender= "Female",  Department= "Services",  DateOfJoining= "11-23-2016",  Salary= "46533.06", City= "Mayisyan" },
                new { EmployeeID= "3645602",  EmployeeName= "Licha McKee",  Gender= "Female",  Department= "Research and Development",  DateOfJoining= "08-29-2018",  Salary= "31008.69", City= "Wenqiao" },
                new { EmployeeID= "7413262",  EmployeeName= "Ives Tunn",  Gender= "Male",  Department= "Product Management",  DateOfJoining= "08-31-2018",  Salary= "27791.30", City= "Tabia" },
                new { EmployeeID= "9348082",  EmployeeName= "Cathy Bugdale",  Gender= "Female",  Department= "Training",  DateOfJoining= "04-23-2016",  Salary= "31759.16", City= "Azul" },
                new { EmployeeID= "7109150",  EmployeeName= "Waverley Gingedale",  Gender= "Male",  Department= "Accounting",  DateOfJoining= "09-04-2011",  Salary= "27893.84", City= "Frýdek-Místek" },
                new { EmployeeID= "1119404",  EmployeeName= "Cooper Capes",  Gender= "Male",  Department= "Sales",  DateOfJoining= "01-02-2016",  Salary= "26407.41", City= "Ash Sharyah" },
                new { EmployeeID= "9560117",  EmployeeName= "Shayna Potebury",  Gender= "Female",  Department= "Human Resources",  DateOfJoining= "10-23-2012",  Salary= "35332.31", City= "Baluk" },
                new { EmployeeID= "2598799",  EmployeeName= "Doro Gaitone",  Gender= "Female",  Department= "Sales",  DateOfJoining= "02-04-2012",  Salary= "22904.55", City= "Wulingyuan" },
                new { EmployeeID= "6767113",  EmployeeName= "Chantal Ventam",  Gender= "Female",  Department= "Training",  DateOfJoining= "07-02-2014",  Salary= "25515.12", City= "Xinshui" },
                new { EmployeeID= "3735396",  EmployeeName= "Tobie Brodeur",  Gender= "Male",  Department= "Training",  DateOfJoining= "08-11-2015",  Salary= "24508.84", City= "Xin’an" },
                new { EmployeeID= "2942841",  EmployeeName= "Feodor MacDermid",  Gender= "Male",  Department= "Human Resources",  DateOfJoining= "06-02-2019",  Salary= "14844.80", City= "Rantauambacang" },
                new { EmployeeID= "1511001",  EmployeeName= "Allyce Decker",  Gender= "Female",  Department= "Support",  DateOfJoining= "04-14-2017",  Salary= "39356.65", City= "Saint Paul" },
                new { EmployeeID= "9062663",  EmployeeName= "Ricard Connock",  Gender= "Male",  Department= "Product Management",  DateOfJoining= "11-25-2010",  Salary= "27421.61", City= "Lokorae" },
                new { EmployeeID= "6210073",  EmployeeName= "Minerva Greenham",  Gender= "Female",  Department= "Support",  DateOfJoining= "05-23-2014",  Salary= "48300.27", City= "Pakemitan" },
                new { EmployeeID= "1830385",  EmployeeName= "Cyb Gallant",  Gender= "Female",  Department= "Accounting",  DateOfJoining= "11-25-2010",  Salary= "36518.72", City= "Berëzovyy" },
                new { EmployeeID= "7466629",  EmployeeName= "Harman Free",  Gender= "Male",  Department= "Human Resources",  DateOfJoining= "07-15-2012",  Salary= "35939.87", City= "Watodei" },
                new { EmployeeID= "2963633",  EmployeeName= "Kylie Phettis",  Gender= "Female",  Department= "Marketing",  DateOfJoining= "03-18-2011",  Salary= "26038.56", City= "Huangzhai" },
            };
            ViewBag.FilteringData = data;
            return View();
        }

        public IActionResult SortOpen(IFormCollection openRequest)
        {
            OpenRequest open = new OpenRequest();
            open.File = openRequest.Files[0];
            return Content(Workbook.Open(open));
        }

        public IActionResult SortSave(SaveSettings saveSettings)
        {
            return Workbook.Save(saveSettings);
        }
    }
}