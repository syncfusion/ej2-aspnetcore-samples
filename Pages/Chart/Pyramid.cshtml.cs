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
    public class PyramidModel : PageModel
    {
        public List<PyramidChartData> ChartPoints { get; set; }

        public void OnGet()
        {
            ChartPoints = new List<PyramidChartData>
            {
                new PyramidChartData { Foods = "Oils",        Calories = 2,  DataLabelMappingName = "Oils: 2%" },
                new PyramidChartData { Foods = "Protein",     Calories = 10, DataLabelMappingName = "Protein: 4710%" },
                new PyramidChartData { Foods = "Fruits",      Calories = 15, DataLabelMappingName = "Fruits: 15%" },
                new PyramidChartData { Foods = "Dairy",       Calories = 23, DataLabelMappingName = "Dairy: 23%" },
                new PyramidChartData { Foods = "Vegetables",  Calories = 23, DataLabelMappingName = "Vegetables: 23%" },
                new PyramidChartData { Foods = "Grains",      Calories = 27, DataLabelMappingName = "Grains: 27%" }

            };
        }
    }
    public class PyramidChartData
    {
        public string Foods;
        public double Calories;
        public string DataLabelMappingName;
    }
}