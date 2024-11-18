#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class ChartPerformanceModel : PageModel
    {
        private bool isPointsLoaded;
        private Random randomNum = new Random();
        public List<LineChartData> chartData { get; set; }
        private bool visibleProperty;
        private double value = 0;
        public void OnGet()
        {
            chartData = new List<LineChartData>();
            isPointsLoaded = true;
            visibleProperty = true;
            for (int pts = 0; pts < 100000; pts++)
            {
                if (pts % 3 == 0)
                {
                    value -= (randomNum.Next(0, 100) / 3) * 4;
                }
                else if (pts % 2 == 0)
                {
                    value += (randomNum.Next(0, 100) / 3) * 4;
                }
                if (value < 0)
                {
                    value = value * -1;
                }
                if (value >= 12000)
                {
                    value = randomNum.Next(1000, 11000);
                }
                chartData.Add(new LineChartData() { X = new DateTime(2005, 1, 1).AddHours(pts), Y = value });
            }

        }
    }
    public class LineChartData
    {
        public DateTime X;
        public double Y;
        public DateTime Period;
        public double Can_Growth;
        public double Viet_Growth;
        public double Mal_Growth;
        public double Egy_Growth;
        public double Ind_Growth;
    }
}
