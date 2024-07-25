#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Charts;

namespace EJ2CoreSampleBrowser.Controllers.Chart
{
    public partial class ChartController : Controller
    {
       
        public IActionResult Export()
        {
            List<ExportData> ChartPoints = new List<ExportData>
            {
                new ExportData {Country="India", GigaWatts = 35.5, DataLabelMappingName="35.5"},
                new ExportData {Country="China", GigaWatts = 18.3, DataLabelMappingName="18.3"},
                new ExportData {Country="Italy", GigaWatts = 17.6, DataLabelMappingName="17.6"},
                new ExportData {Country="Japan", GigaWatts = 13.6, DataLabelMappingName="13.6"},
                new ExportData {Country="United state", GigaWatts = 12, DataLabelMappingName="12"},
                new ExportData {Country="Spain", GigaWatts = 5.6, DataLabelMappingName="5.6"},
                new ExportData {Country="France", GigaWatts = 4.6, DataLabelMappingName="4.6"},
                new ExportData {Country="Australia", GigaWatts = 3.3, DataLabelMappingName="3.3"},
                new ExportData {Country="Belgium", GigaWatts = 3, DataLabelMappingName="3"},
                new ExportData {Country="United Kingdom", GigaWatts = 2.9, DataLabelMappingName="2.9"},
            };
            ViewBag.ChartPoints = ChartPoints;
            ViewBag.mode = new String[] { "JPEG", "PNG", "SVG", "PDF", "XLSX", "CSV" };
            return View();
        }
        public class ExportData
        {
            public string Country;
            public double GigaWatts;
            public string DataLabelMappingName;
        }

    }
}