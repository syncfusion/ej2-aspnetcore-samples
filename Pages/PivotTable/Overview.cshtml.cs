using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace EJ2CoreSampleBrowser.Pages.PivotTable
{
    public class OverviewModel : PageModel
    {
        public List<UniversityData> data;
        public string[] filterMembers;
        public string[] excludeFields;

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
        }
        public void OnGet()
        {
            string result = System.IO.File.ReadAllText("./wwwroot/scripts/pivotData/universitydata.json");
            data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UniversityData>>(result);
            filterMembers = new string[] { "Africa", "Latin America" };
            excludeFields = new string[] { "link", "logo" };          
        }
    }
}
