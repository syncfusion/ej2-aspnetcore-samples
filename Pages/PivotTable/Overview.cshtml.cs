#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace EJ2CoreSampleBrowser_NET8.Pages.PivotTable
{
    public class OverviewModel : PageModel
    {
        private IWebHostEnvironment _hostingEnvironment;
        public List<UniversityData> data;
        public string[] filterMembers;
        public string[] excludeFields;

        public OverviewModel(IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
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
        public void OnGet()
        {
            data = new UniversityData().ReadJSONData(_hostingEnvironment.ContentRootPath + "\\wwwroot\\scripts\\pivotData\\universitydata.json");
            filterMembers = new string[] { "Africa", "Latin America" };
            excludeFields = new string[] { "link", "logo" };           
        }
    }
}
