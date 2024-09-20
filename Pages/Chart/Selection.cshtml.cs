#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser_NET8.Pages.Chart
{
    public class SelectionModel : PageModel
    {
        public List<SelectionData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<SelectionData>
            {
                new SelectionData { Country = "China", Children = 17, Adult = 54, SeniorAdult = 9  },
                new SelectionData { Country = "USA", Children = 19, Adult = 67, SeniorAdult = 14 },
                new SelectionData { Country = "India", Children = 29, Adult = 65, SeniorAdult = 6  },
                new SelectionData { Country = "Japan", Children = 13, Adult = 61, SeniorAdult = 26 },
                new SelectionData { Country = "Brazil", Children = 24, Adult = 68, SeniorAdult = 8  }
            };
        }
    }
    public class SelectionData
    {
        public string Country;
        public double Children;
        public double Adult;
        public double SeniorAdult;
    }
}