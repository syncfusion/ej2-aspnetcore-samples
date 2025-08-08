#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using EJ2CoreSampleBrowser.Pages.CircularChart3D;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class PieLegendModel : PageModel
    {
        public List<PieDataPoints> PieChartPoints { get; set; }
        public void OnGet()
        {
            PieChartPoints = new List<PieDataPoints>  
            {
                new PieDataPoints { X = "China",     Y = 35,   Text = "35%" },
                new PieDataPoints { X = "India",     Y = 30,   Text = "30%" },
                new PieDataPoints { X = "USA",       Y = 10.7, Text = "10.7%" },
                new PieDataPoints { X = "Indonesia", Y = 7,    Text = "7%" },
                new PieDataPoints { X = "Brazil",    Y = 5.3,  Text = "5.3%" },
                new PieDataPoints { X = "Others",    Y = 12,   Text = "12%" }

            };
        }
    }
    public class PieDataPoints
    {
        public string X;
        public double Y;
        public string Text;
    }
    
}