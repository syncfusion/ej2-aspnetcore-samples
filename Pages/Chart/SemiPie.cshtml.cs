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
    public class SemiPieModel : PageModel
    {
        public List<SemiPieChartData> PieChartPoints { get; set; }

        public void OnGet()
        {
            PieChartPoints = new List<SemiPieChartData>
            {
                new SemiPieChartData { Browser =  "Chrome", Users = 100, DataLabelMappingName = "Chrome (100M)<br>40%", tooltipMappingName="40%" },
                new SemiPieChartData { Browser =  "UC Browser", Users = 40, DataLabelMappingName = "UC Browser (40M)<br>16%", tooltipMappingName="16%" },
                new SemiPieChartData { Browser =  "Opera", Users = 30, DataLabelMappingName = "Opera (30M)<br>12%", tooltipMappingName="12%" },
                new SemiPieChartData { Browser =  "Safari", Users = 30, DataLabelMappingName = "Safari (30M)<br>12%", tooltipMappingName="12%" },
                new SemiPieChartData { Browser =  "Firefox", Users = 25, DataLabelMappingName = "Firefox (25M)<br>10%", tooltipMappingName="10%" },
                new SemiPieChartData { Browser =  "Others", Users = 25, DataLabelMappingName = "Others (25M)<br>10%", tooltipMappingName="10%" }
            };
        }
    }
    public class SemiPieChartData
    {
        public string Browser;
        public double Users;
        public string DataLabelMappingName;
        public string tooltipMappingName;
    }
}