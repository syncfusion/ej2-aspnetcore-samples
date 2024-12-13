#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class PareToModel : PageModel
    {
        public List<PareToData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<PareToData>
            {
                new PareToData { DefectCategory = "Button Defect", Y = 23 },
                new PareToData { DefectCategory = "Pocket Defect", Y = 16 },
                new PareToData { DefectCategory = "Collar Defect", Y = 10 },
                new PareToData { DefectCategory = "Cuff Defect", Y = 7 },
                new PareToData { DefectCategory = "Sleeve Defect", Y = 6 },
                new PareToData { DefectCategory = "Other Defect", Y = 2 }
            };
        }
    }
    public class PareToData
    {
        public string DefectCategory;
        public double Y;
    }
}