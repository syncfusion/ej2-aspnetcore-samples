#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using EJ2CoreSampleBrowser.Models;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class PivotTableController : Controller
    {
        private IWebHostEnvironment _hostingEnvironment;

        public PivotTableController(IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        public IActionResult Overview()
        {
            var data = new UniversityData().ReadJSONData(_hostingEnvironment.ContentRootPath + "\\wwwroot\\scripts\\pivotData\\universitydata.json");
            ViewBag.DataSource = data;
            ViewBag.filterMembers = new string[] { "Africa", "Latin America" };
            ViewBag.excludeFields = new string[] { "link", "logo" };
            return View();
        }

        public class UniversityData
        {
            public string university { get; set; }
            public int year { get; set; }
            public int rank_display { get; set; }
            public string country { get; set; }
            public string city { get; set; }
            public string region { get; set; }
            public string type { get; set; }
            public string research_output { get; set; }
            public int? student_faculty_ratio { get; set; }
            public string international_students { get; set; }
            public string faculty_count { get; set; }
            public string link { get; set; }
            public string logo { get; set; }



            public List<UniversityData> ReadJSONData(string url)
            {
                WebClient myWebClient = new WebClient();
                Stream myStream = myWebClient.OpenRead(url);
                StreamReader stream = new StreamReader(myStream);
                string result = stream.ReadToEnd();
                stream.Close();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<UniversityData>>(result);
            }
        }
    }
}
