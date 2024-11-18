#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Charts;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class StripLineModel : PageModel
    {
        public List<StripLineChartData> WeatherReportsA { get; set; }
        public List<StripLineChartData> WeatherReportsB { get; set; }
        public List<ChartStripLine>  yaxisstriplines { get; set; }

        public void OnGet()
        {
            WeatherReportsA = new List<StripLineChartData>
            {
               new StripLineChartData { X = new DateTime(2023, 5, 1), Wind = 19 },
               new StripLineChartData { X = new DateTime(2023, 5, 2), Wind = 17 },
               new StripLineChartData { X = new DateTime(2023, 5, 3), Wind = 14 },
               new StripLineChartData { X = new DateTime(2023, 5, 4), Wind = 9 },
               new StripLineChartData { X = new DateTime(2023, 5, 5), Wind = 10 },
               new StripLineChartData { X = new DateTime(2023, 5, 6), Wind = 8 },
               new StripLineChartData { X = new DateTime(2023, 5, 7), Wind = 8 },
               new StripLineChartData { X = new DateTime(2023, 5, 8), Wind = 16 },
               new StripLineChartData { X = new DateTime(2023, 5, 9), Wind = 9 },
               new StripLineChartData { X = new DateTime(2023, 5, 10), Wind = 13 },
               new StripLineChartData { X = new DateTime(2023, 5, 11), Wind = 7 },
               new StripLineChartData { X = new DateTime(2023, 5, 12), Wind = 12 },
               new StripLineChartData { X = new DateTime(2023, 5, 13), Wind = 10 },
                new StripLineChartData { X = new DateTime(2023, 5, 14), Wind = 5 },
                new StripLineChartData { X = new DateTime(2023, 5, 15), Wind = 8 }
            };
            
            WeatherReportsB = new List<StripLineChartData>
            {
                new StripLineChartData { X = new DateTime(2023, 5, 1), Gust = 30 },
                new StripLineChartData { X = new DateTime(2023, 5, 2), Gust = 28 },
                new StripLineChartData { X = new DateTime(2023, 5, 3), Gust = 26 },
                new StripLineChartData { X = new DateTime(2023, 5, 4), Gust = 19 },
                new StripLineChartData { X = new DateTime(2023, 5, 5), Gust = 21 },
                new StripLineChartData { X = new DateTime(2023, 5, 6), Gust = 14 },
                new StripLineChartData { X = new DateTime(2023, 5, 7), Gust = 13 },
                new StripLineChartData { X = new DateTime(2023, 5, 8), Gust = 29 },
                new StripLineChartData { X = new DateTime(2023, 5, 9), Gust = 19 },
                new StripLineChartData { X = new DateTime(2023, 5, 10), Gust = 20 },
                new StripLineChartData { X = new DateTime(2023, 5, 11), Gust = 15 },
                new StripLineChartData { X = new DateTime(2023, 5, 12), Gust = 25 },
                new StripLineChartData { X = new DateTime(2023, 5, 13), Gust = 20 },
                new StripLineChartData { X = new DateTime(2023, 5, 14), Gust = 10 },
                new StripLineChartData { X = new DateTime(2023, 5, 15), Gust = 15 }
            };

            yaxisstriplines = new List<ChartStripLine>();
            ChartStripLine stripy1 = new ChartStripLine();
            stripy1.Start = "0";
            stripy1.End = "5";
            stripy1.Text = "Calm";
            stripy1.Color = "rgba(68, 170, 213, 0.1)";
            stripy1.HorizontalAlignment = Anchor.Start;
            stripy1.Visible = true;
            stripy1.TextStyle = new ChartFont { Size = "13px" };
            stripy1.Border = new ChartBorder { Width = 0 };
            yaxisstriplines.Add(stripy1);

            ChartStripLine stripy2 = new ChartStripLine();
            stripy2.Start = "5";
            stripy2.End = "8";
            stripy2.Text = "Light Air";
            stripy2.Color = "rgba(0, 0, 0, 0)";
            stripy2.HorizontalAlignment = Anchor.Start;
            stripy2.Visible = true;
            stripy2.TextStyle = new ChartFont { Size = "13px" };
            stripy2.Border = new ChartBorder { Width = 0 };
            yaxisstriplines.Add(stripy2);

            ChartStripLine stripy3 = new ChartStripLine();
            stripy3.Start = "8";
            stripy3.End = "11";
            stripy3.Text = "Light Breeze";
            stripy3.Color = "rgba(68, 170, 213, 0.1)";
            stripy3.HorizontalAlignment = Anchor.Start;
            stripy3.Visible = true;
            stripy3.TextStyle = new ChartFont { Size = "13px" };
            stripy3.Border = new ChartBorder { Width = 0 };
            yaxisstriplines.Add(stripy3);
            
            ChartStripLine stripy4 = new ChartStripLine();
            stripy4.Start = "11";
            stripy4.End = "18";
            stripy4.Text = "Gentle Breeze";
            stripy4.Color = "rgba(0, 0, 0, 0)";
            stripy4.HorizontalAlignment = Anchor.Start;
            stripy4.Visible = true;
            stripy4.TextStyle = new ChartFont { Size = "13px" };
            stripy4.Border = new ChartBorder { Width = 0 };
            yaxisstriplines.Add(stripy4);
            
            ChartStripLine stripy5 = new ChartStripLine();
            stripy5.Start = "18";
            stripy5.End = "28";
            stripy5.Text = "Moderate Breeze";
            stripy5.Color = "rgba(68, 170, 213, 0.1)";
            stripy5.HorizontalAlignment = Anchor.Start;
            stripy5.Visible = true;
            stripy5.TextStyle = new ChartFont { Size = "13px" };
            stripy5.Border = new ChartBorder { Width = 0 };
            yaxisstriplines.Add(stripy5);
            
            ChartStripLine stripy6 = new ChartStripLine();
            stripy6.Start = "28";
            stripy6.End = "30";
            stripy6.Text = "Fresh Breeze";
            stripy6.Color = "rgba(0, 0, 0, 0)";
            stripy6.HorizontalAlignment = Anchor.Start;
            stripy6.Visible = true;
            stripy6.TextStyle = new ChartFont { Size = "13px" };
            stripy6.Border = new ChartBorder { Width = 0 };
            yaxisstriplines.Add(stripy6);
        }
    }
    public class StripLineChartData
    {
        public DateTime X;
        public double Wind;
        public double Gust;
    }
}