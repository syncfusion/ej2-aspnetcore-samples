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
    public class RangeBarModel : PageModel
    {
        public List<RangeBarChartData> ChartPoints { get; set; }

        public void OnGet()
        {
            ChartPoints = new List<RangeBarChartData>
            {
                new RangeBarChartData { Month = "Jan", CA_LowTemp = 28, CA_HighTemp = 72, Text = "January", CO_LowTemp = 38, CO_HighTemp = 78 },
                new RangeBarChartData { Month = "Feb", CA_LowTemp = 25, CA_HighTemp = 75, Text = "February", CO_LowTemp = 38, CO_HighTemp = 78 },
                new RangeBarChartData { Month = "Mar", CA_LowTemp = 18, CA_HighTemp = 65, Text = "March", CO_LowTemp = 27, CO_HighTemp = 78 },
                new RangeBarChartData { Month = "Apr", CA_LowTemp = 22, CA_HighTemp = 69, Text = "April", CO_LowTemp = 38, CO_HighTemp = 78 },
                new RangeBarChartData { Month = "May", CA_LowTemp = 56, CA_HighTemp = 87, Text = "May", CO_LowTemp = 28, CO_HighTemp = 79 },
                new RangeBarChartData { Month = "Jun", CA_LowTemp = 48, CA_HighTemp = 75, Text = "June", CO_LowTemp = 38, CO_HighTemp = 78 },
                new RangeBarChartData { Month = "Jul", CA_LowTemp = 40, CA_HighTemp = 78, Text = "July", CO_LowTemp = 37, CO_HighTemp = 66 },
                new RangeBarChartData { Month = "Aug", CA_LowTemp = 35, CA_HighTemp = 73, Text = "August", CO_LowTemp = 38, CO_HighTemp = 78 },
                new RangeBarChartData { Month = "Sep", CA_LowTemp = 43, CA_HighTemp = 64, Text = "September", CO_LowTemp = 25, CO_HighTemp = 52 },
                new RangeBarChartData { Month = "Oct", CA_LowTemp = 38, CA_HighTemp = 77, Text = "October", CO_LowTemp = 38, CO_HighTemp = 78 },
                new RangeBarChartData { Month = "Nov", CA_LowTemp = 28, CA_HighTemp = 54, Text = "November", CO_LowTemp = 20, CO_HighTemp = 60 },
                new RangeBarChartData { Month = "Dec", CA_LowTemp = 29, CA_HighTemp = 56, Text = "December", CO_LowTemp = 20, CO_HighTemp = 60 }
            };
        }
    }
    public class RangeBarChartData
    {
        public string Month;
        public double CA_LowTemp;
        public double CA_HighTemp;
        public string Text;
        public double CO_LowTemp;
        public double CO_HighTemp;
    }
}