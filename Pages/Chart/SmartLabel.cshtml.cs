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
    public class SmartLabelModel : PageModel
    {
        public List<SmartLabelsChartData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<SmartLabelsChartData>
            {
                new SmartLabelsChartData { Country = "USA",           Medal = 40, DataLabelMappingName = "United States of America: 40" },
                new SmartLabelsChartData { Country = "China",         Medal = 40, DataLabelMappingName = "China: 40" },
                new SmartLabelsChartData { Country = "Japan",         Medal = 20, DataLabelMappingName = "Japan: 20" },
                new SmartLabelsChartData { Country = "Australia",     Medal = 18, DataLabelMappingName = "Australia: 18" },
                new SmartLabelsChartData { Country = "France",        Medal = 16, DataLabelMappingName = "France: 16" },
                new SmartLabelsChartData { Country = "Netherlands",   Medal = 15, DataLabelMappingName = "Netherlands: 15" },
                new SmartLabelsChartData { Country = "Great Britain", Medal = 14, DataLabelMappingName = "Great Britain: 14" },
                new SmartLabelsChartData { Country = "South Korea",   Medal = 13, DataLabelMappingName = "South Korea: 13" },
                new SmartLabelsChartData { Country = "Germany",       Medal = 12, DataLabelMappingName = "Germany: 12" },
                new SmartLabelsChartData { Country = "Italy",         Medal = 12, DataLabelMappingName = "Italy: 12" },
                new SmartLabelsChartData { Country = "NewZealand",    Medal = 10, DataLabelMappingName = "New Zealand: 10" },
                new SmartLabelsChartData { Country = "Canada",        Medal =  9, DataLabelMappingName = "Canada: 9" },
                new SmartLabelsChartData { Country = "Uzbekistan",    Medal =  8, DataLabelMappingName = "Uzbekistan: 8" },
                new SmartLabelsChartData { Country = "Hungary",       Medal =  6, DataLabelMappingName = "Hungary: 6" },
                new SmartLabelsChartData { Country = "Kenya",         Medal =  4, DataLabelMappingName = "Kenya: 4" },
                new SmartLabelsChartData { Country = "Georgia",       Medal =  3, DataLabelMappingName = "Georgia: 3" },
                new SmartLabelsChartData { Country = "North Korea",   Medal =  2, DataLabelMappingName = "North Korea: 2" },
                new SmartLabelsChartData { Country = "Hong Kong",     Medal =  2, DataLabelMappingName = "South Africa: 2" }
            };

            bool isMobile = Request.Headers["User-Agent"].ToString().Contains("Mobi");
            if (isMobile)
            {
                ChartPoints[0].DataLabelMappingName = "USA: 40";
                ChartPoints[3].DataLabelMappingName = "AU: 18";
                ChartPoints[5].DataLabelMappingName = "NL: 15";
                ChartPoints[6].DataLabelMappingName = "GB: 14";
                ChartPoints[7].DataLabelMappingName = "SK: 13";
                ChartPoints[8].DataLabelMappingName = "GE: 12";
                ChartPoints[10].DataLabelMappingName = "NZ: 10";
                ChartPoints[11].DataLabelMappingName = "CA: 9";
                ChartPoints[12].DataLabelMappingName = "UZB: 8";
                ChartPoints[13].DataLabelMappingName = "HU: 6";
                ChartPoints[14].DataLabelMappingName = "KE: 4";
                ChartPoints[15].DataLabelMappingName = "GE: 3";
                ChartPoints[16].DataLabelMappingName = "NK: 2";
                ChartPoints[17].DataLabelMappingName = "HK: 2";
            };
        }
    }
    public class SmartLabelsChartData
    {
        public string Country;
        public double Medal;
        public string DataLabelMappingName;
    }
    
}