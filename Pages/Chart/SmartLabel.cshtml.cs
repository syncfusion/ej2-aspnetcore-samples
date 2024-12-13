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
    public class SmartLabelModel : PageModel
    {
        public List<SmartLabelsChartData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<SmartLabelsChartData>
            {
                new SmartLabelsChartData { Country =  "USA",           Medal = 46, DataLabelMappingName = "United States of America: 46" },
                new SmartLabelsChartData { Country =  "China",         Medal = 26, DataLabelMappingName = "China: 26" },
                new SmartLabelsChartData { Country =  "Russia",        Medal = 19, DataLabelMappingName = "Russia: 19" },
                new SmartLabelsChartData { Country =  "Germany",       Medal = 17, DataLabelMappingName = "Germany: 17" },
                new SmartLabelsChartData { Country =  "Kazhakastan",   Medal = 3,  DataLabelMappingName = "Kazhakastan: 3" },
                new SmartLabelsChartData { Country =  "New Zealand",   Medal = 4,  DataLabelMappingName = "New Zealand: 4" },
                new SmartLabelsChartData { Country =  "South Korea",   Medal = 9,  DataLabelMappingName = "South Korea: 9" },
                new SmartLabelsChartData { Country =  "Great Britain", Medal = 27, DataLabelMappingName = "Great Britain: 27" },
                new SmartLabelsChartData { Country =  "Switzerland",   Medal = 3,  DataLabelMappingName = "Switzerland: 3" },
                new SmartLabelsChartData { Country =  "Australia",     Medal = 8,  DataLabelMappingName = "Australia: 8" },
                new SmartLabelsChartData { Country =  "Netherlands",   Medal = 8,  DataLabelMappingName = "Netherlands: 8" },
                new SmartLabelsChartData { Country =  "Columbia",      Medal = 3,  DataLabelMappingName = "Columbia: 3" },
                new SmartLabelsChartData { Country =  "Uzebekistan",   Medal = 4,  DataLabelMappingName = "Uzebekistan: 4" },
                new SmartLabelsChartData { Country =  "Japan",         Medal = 12, DataLabelMappingName = "Japan: 12" },
                new SmartLabelsChartData { Country =  "France",        Medal = 10, DataLabelMappingName = "France: 10" },                                            
                new SmartLabelsChartData { Country =  "Italy",         Medal = 8,  DataLabelMappingName = "Italy: 8" },                                                                                                             
                new SmartLabelsChartData { Country =  "Argentina",     Medal = 3,  DataLabelMappingName = "Argentina: 3" },
                new SmartLabelsChartData { Country =  "South Africa",  Medal = 2,  DataLabelMappingName = "South Africa: 2" },
                new SmartLabelsChartData { Country =  "North Korea",   Medal = 2,  DataLabelMappingName = "North Korea: 2" }
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