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
    public class DonutModel : PageModel
    {
        public List<DoughnutChartData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<DoughnutChartData>
            {
                new DoughnutChartData { Browser = "Chrome", Users = 63.5, DataLabelMappingName = "Chrome: 63.5%" },
                new DoughnutChartData { Browser = "Safari", Users = 25.0, DataLabelMappingName = "Safari: 25.0%" },
                new DoughnutChartData { Browser = "Samsung Internet", Users = 6.0, DataLabelMappingName = "Samsung Internet: 6.0%" },
                new DoughnutChartData { Browser = "UC Browser", Users = 2.5, DataLabelMappingName = "UC Browser: 2.5%" },
                new DoughnutChartData { Browser = "Opera", Users = 1.5, DataLabelMappingName = "Opera: 1.5%" },
                new DoughnutChartData { Browser = "Others", Users = 1.5, DataLabelMappingName = "Others: 1.5%" }

            };
        }
    }
    public class DoughnutChartData
    {
        public string Browser;
        public double Users;
        public string DataLabelMappingName;

    }
}
