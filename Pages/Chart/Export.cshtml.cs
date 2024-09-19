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
    public class ExportModel : PageModel
    {
        public List<ExportData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<ExportData>
            {
                new ExportData {Country="India", GigaWatts = 35.5, DataLabelMappingName="35.5GW"},
                new ExportData {Country="China", GigaWatts = 18.3, DataLabelMappingName="18.3GW"},
                new ExportData {Country="Italy", GigaWatts = 17.6, DataLabelMappingName="17.6GW"},
                new ExportData {Country="Japan", GigaWatts = 13.6, DataLabelMappingName="13.6GW"},
                new ExportData {Country="United state", GigaWatts = 12, DataLabelMappingName="12GW"},
                new ExportData {Country="Spain", GigaWatts = 5.6, DataLabelMappingName="5.6GW"},
                new ExportData {Country="France", GigaWatts = 4.6, DataLabelMappingName="4.6GW"},
                new ExportData {Country="Australia", GigaWatts = 3.3, DataLabelMappingName="3.3GW"},
                new ExportData {Country="Belgium", GigaWatts = 3, DataLabelMappingName="3GW"},
                new ExportData {Country="United Kingdom", GigaWatts = 2.9, DataLabelMappingName="2.9GW"},
            };
            bool isMobile = Request.Headers["User-Agent"].ToString().Contains("Mobi");
            if (isMobile)
            {
                ChartPoints[0].DataLabelMappingName = "35.5";
                ChartPoints[1].DataLabelMappingName = "18.3";
                ChartPoints[2].DataLabelMappingName = "17.6";
                ChartPoints[3].DataLabelMappingName = "13.6";
                ChartPoints[4].DataLabelMappingName = "12";
                ChartPoints[5].DataLabelMappingName = "5.6";
                ChartPoints[6].DataLabelMappingName = "4.6";
                ChartPoints[7].DataLabelMappingName = "3.3";
                ChartPoints[8].DataLabelMappingName = "3";
                ChartPoints[9].DataLabelMappingName = "2.9";
            };
        }
    }
    public class ExportData
    {
        public string Country;
        public double GigaWatts;
        public string DataLabelMappingName;
    }
}
