#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class DonutWithGradientModel : PageModel
    {
        public List<GradientDonutData>? ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<GradientDonutData>
            {
                new GradientDonutData { Country = "Austria", Share = 38.03, DataLabelMappingName = "Austria: 38.03%" },
                new GradientDonutData { Country = "Belgium", Share = 33.7, DataLabelMappingName = "Belgium: 33.7%" },
                new GradientDonutData { Country = "Germany", Share = 31.27, DataLabelMappingName = "Germany: 31.27%" },
                new GradientDonutData { Country = "The Netherlands", Share = 29.71, DataLabelMappingName = "The Netherlands: 29.71%" },
                new GradientDonutData { Country = "Lithuania", Share = 27.72, DataLabelMappingName = "Lithuania: 27.72%" },
                new GradientDonutData { Country = "Czechia", Share = 27.37, DataLabelMappingName = "Czechia: 27.37%" },
                new GradientDonutData { Country = "Poland", Share = 22.1, DataLabelMappingName = "Poland: 22.1%" },
                new GradientDonutData { Country = "Ireland", Share = 18.87, DataLabelMappingName = "Ireland: 18.87%" },
                new GradientDonutData { Country = "Croatia", Share = 14.88, DataLabelMappingName = "Croatia: 14.88%" }
            };
        }
    }
    public class GradientDonutData
    {
        public string? Country { get; set; }
        public double Share { get; set; }
        public string? DataLabelMappingName { get; set; }
    }
}
