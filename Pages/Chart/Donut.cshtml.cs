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
    public class DonutModel : PageModel
    {
        public List<DoughnutChartData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<DoughnutChartData>
            {
                new DoughnutChartData { Browser= "Chrome", Users= 61.3, DataLabelMappingName= "Chrome: 61.3%" },
                new DoughnutChartData { Browser= "Safari", Users= 24.6, DataLabelMappingName= "Safari: 24.6%" },
                new DoughnutChartData { Browser= "Edge", Users= 5.0, DataLabelMappingName= "Edge: 5.0%" },
                new DoughnutChartData { Browser= "Samsung Internet", Users= 2.7, DataLabelMappingName= "Samsung Internet: 2.7%" },
                new DoughnutChartData { Browser= "Firefox", Users= 2.6, DataLabelMappingName= "Firefox: 2.6%" },
                new DoughnutChartData { Browser= "Others", Users= 3.6, DataLabelMappingName= "Others: 3.6%" }
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
