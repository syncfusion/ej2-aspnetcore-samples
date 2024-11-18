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
    public class StripLineRecurrenceModel : PageModel
    {
        public List<StripLineRecurrenceChartData> PollutionReports { get; set; }
        public List<ChartStripLine> xAxisStrips { get; set; }
        public List<ChartStripLine> yAxisStrips { get; set; }

        public void OnGet()
        {
            PollutionReports = new List<StripLineRecurrenceChartData>
            {
                new StripLineRecurrenceChartData { Period = new DateTime(1970, 1, 1), PollutionRate1 = 16500, PollutionRate2 = 8000 },
                new StripLineRecurrenceChartData { Period = new DateTime(1975, 1, 1), PollutionRate1 = 16000, PollutionRate2 = 7600 },
                new StripLineRecurrenceChartData { Period = new DateTime(1980, 1, 1), PollutionRate1 = 15400, PollutionRate2 = 6400 },
                new StripLineRecurrenceChartData { Period = new DateTime(1985, 1, 1), PollutionRate1 = 15800, PollutionRate2 = 3700 },
                new StripLineRecurrenceChartData { Period = new DateTime(1990, 1, 1), PollutionRate1 = 14000, PollutionRate2 = 7200 },
                new StripLineRecurrenceChartData { Period = new DateTime(1995, 1, 1), PollutionRate1 = 10500, PollutionRate2 = 2300 },
                new StripLineRecurrenceChartData { Period = new DateTime(2000, 1, 1), PollutionRate1 = 13300, PollutionRate2 = 4000 },
                new StripLineRecurrenceChartData { Period = new DateTime(2005, 1, 1), PollutionRate1 = 12800, PollutionRate2 = 4800 }
            };
            
            xAxisStrips = new List<ChartStripLine>
            {
                new ChartStripLine {
                    StartFromAxis = true, Size = 5, SizeType=Syncfusion.EJ2.Charts.SizeType.Years,
                    IsRepeat = true, RepeatEvery = "10", Visible = true , Color="rgba(167,169,171, 0.1)"
                }
            };

            yAxisStrips = new List<ChartStripLine>
            {
                new ChartStripLine {
                    StartFromAxis = true, Size = 2000,
                    IsRepeat = true, RepeatEvery = "4000", Visible = true , Color="rgba(167,169,171, 0.1)"
                }
            };
        }
    }
    public class StripLineRecurrenceChartData
    {
        public DateTime Period;
        public double PollutionRate1;
        public double PollutionRate2;
    }
}