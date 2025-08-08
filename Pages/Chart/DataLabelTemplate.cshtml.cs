#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class DataLabelTemplateModel : PageModel
    {
        public List<TemplateData> PopulationDetails { get; set; }
        public void OnGet()
        {
            PopulationDetails = new List<TemplateData>
            {
                new TemplateData { Sports= "Tennis", Boys= 50, Girls= 38 },
                new TemplateData { Sports= "Badminton", Boys= 30, Girls= 40 },
                new TemplateData { Sports= "Cycling", Boys= 37, Girls= 20 },
                new TemplateData { Sports= "Football", Boys= 60, Girls= 21 },
                new TemplateData { Sports= "Hockey", Boys= 15, Girls= 8 }
            };
        }
    }
    public class TemplateData
    {
        public string Sports;
        public double Boys;
        public double Girls;
    }
}
