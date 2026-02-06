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
    public class NegativeStackModel : PageModel
    {
        public List<NegativeStackChartData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<NegativeStackChartData>
            {
                new NegativeStackChartData { Age = "90 - 94", Male = 123, Female = 153, MalePercent = "0.03%", FemalePercent = "0.04%", MalePercentValue= 0.03, FemalePercentValue= -0.04 },
                new NegativeStackChartData { Age = "85 - 89", Male = 407, Female = 457, MalePercent = "0.1%", FemalePercent = "0.11%", MalePercentValue= 0.1, FemalePercentValue= -0.11 },
                new NegativeStackChartData { Age = "80 - 84", Male = 879, Female = 970, MalePercent = "0.21%", FemalePercent = "0.23%", MalePercentValue= 0.21, FemalePercentValue= -0.23 },
                new NegativeStackChartData { Age = "75 - 79", Male = 1609, Female = 1768, MalePercent = "0.39%", FemalePercent = "0.42%", MalePercentValue= 0.39, FemalePercentValue= -0.42 },
                new NegativeStackChartData { Age = "70 - 74", Male = 2769, Female = 3004, MalePercent = "0.66%", FemalePercent = "0.72%", MalePercentValue= 0.66, FemalePercentValue= -0.72 },
                new NegativeStackChartData { Age = "65 - 69", Male = 4250, Female = 4511, MalePercent = "1.02%", FemalePercent = "1.08%", MalePercentValue= 1.02, FemalePercentValue= -1.08 },
                new NegativeStackChartData { Age = "60 - 64", Male = 6152, Female = 6369, MalePercent = "1.48%", FemalePercent = "1.53%", MalePercentValue= 1.48, FemalePercentValue= -1.53 },
                new NegativeStackChartData { Age = "55 - 59", Male = 7741, Female = 7976, MalePercent = "1.86%", FemalePercent = "1.91%", MalePercentValue= 1.86, FemalePercentValue= -1.91 },
                new NegativeStackChartData { Age = "50 - 54", Male = 9643, Female = 10086, MalePercent = "2.31%", FemalePercent = "2.42%", MalePercentValue= 2.31, FemalePercentValue= -2.42 },
                new NegativeStackChartData { Age = "45 - 49", Male = 11332, Female = 11585, MalePercent = "2.72%", FemalePercent = "2.78%", MalePercentValue= 2.72, FemalePercentValue= -2.78 },
                new NegativeStackChartData { Age = "40 - 44", Male = 13569, Female = 13713, MalePercent = "3.25%", FemalePercent = "3.29%", MalePercentValue= 3.25, FemalePercentValue= -3.29 },
                new NegativeStackChartData { Age = "35 - 39", Male = 16293, Female = 15999, MalePercent = "3.91%", FemalePercent = "3.84%", MalePercentValue= 3.91, FemalePercentValue= -3.84 },
                new NegativeStackChartData { Age = "30 - 34", Male = 18805, Female = 18038, MalePercent = "4.51%", FemalePercent = "4.32%", MalePercentValue= 4.51, FemalePercentValue= -4.32 },
                new NegativeStackChartData { Age = "25 - 29", Male = 20023, Female = 19216, MalePercent = "4.8%", FemalePercent = "4.61%", MalePercentValue= 4.8, FemalePercentValue= -4.61 },
                new NegativeStackChartData { Age = "20 - 24", Male = 20428, Female = 19689, MalePercent = "4.9%", FemalePercent = "4.72%", MalePercentValue= 4.9, FemalePercentValue= -4.72 },
                new NegativeStackChartData { Age = "15 - 19", Male = 19663, Female = 18950, MalePercent = "4.71%", FemalePercent = "4.54%", MalePercentValue= 4.71, FemalePercentValue= -4.54 },
                new NegativeStackChartData { Age = "10 - 14", Male = 18701, Female = 17859, MalePercent = "4.48%", FemalePercent = "4.28%", MalePercentValue= 4.48, FemalePercentValue= -4.28 },
                new NegativeStackChartData { Age = "05 - 09", Male = 19863, Female = 18942, MalePercent = "4.76%", FemalePercent = "4.54%", MalePercentValue= 4.76, FemalePercentValue= -4.54 },
                new NegativeStackChartData { Age = "00 - 04", Male = 18171, Female = 17316, MalePercent = "4.36%", FemalePercent = "4.15%", MalePercentValue= 4.36, FemalePercentValue= -4.15 }
            };
        }
    }
    public class NegativeStackChartData
    {
        public string Age;
        public double Female;
        public double Male;
        public string MalePercent;
        public string FemalePercent;
        public double MalePercentValue;
        public double FemalePercentValue;
    }
}
