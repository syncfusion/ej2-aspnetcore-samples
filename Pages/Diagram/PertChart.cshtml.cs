#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Diagram;

public class PertChartModel : PageModel
{
   public List<pertChartDataDetails> Nodes { get; set; }
    public void OnGet()
    {
       Nodes = pertChartDataDetails.GetAllRecords();
    }
}
public class pertChartDataDetails
    {
        public string Id { get; set; }
        public string Branch { get; set; }
        public string Duration { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string[] Category { get; set; }

        public pertChartDataDetails(string Id, string Branch, string[] Category, string Duration, string StartDate, string EndDate)
        {
            this.Id = Id;
            this.Branch = Branch;
            this.Category = Category;
            this.Duration = Duration;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }
        public static List<pertChartDataDetails> GetAllRecords()
        {
            List<pertChartDataDetails> data = new List<pertChartDataDetails>();
            data.Add(new pertChartDataDetails("Start Project", "root", null, "4", "04/19/2018", "08/19/2018"));
            data.Add(new pertChartDataDetails("Design", "", new string[] { "Start Project" },
         "2", "08/20/2018", "10/20/2018"));
            data.Add(new pertChartDataDetails("Formalize Specification", "", new string[] { "Start Project" },
         "2", "10/21/2018", "12/22/2018"));
            data.Add(new pertChartDataDetails("Write Documentation", "", new string[] { "Start Project" },
         "1", "12/23/2018", "01/22/2019"));
            data.Add(new pertChartDataDetails("Release Prototype", "", new string[] { "Design" },
         "1", "01/23/2019", " 02/23/2019"));
            data.Add(new pertChartDataDetails("Testing", "", new string[] { "Formalize Specification", "Release Prototype" },
         "2", "02/24/2019", "04/22/2019"));
            data.Add(new pertChartDataDetails("Release Project", "", new string[] { "Release Prototype" },
         "1", "04/23/2019", "05/24/2019"));
            data.Add(new pertChartDataDetails("Review Changes", "", new string[] { "Write Documentation" },
         "1", "05/25/2019", " 06/26/2019"));
            data.Add(new pertChartDataDetails("Publish Documentation", "", new string[] { "Review Changes" },
         "1", "06/21/2019", " 07/22/2019"));
            data.Add(new pertChartDataDetails("Finish", "", new string[] { "Publish Documentation", "Release Project" },
         "1", "07/23/2019", "08/24/2019"));

            return data;
        }
    }