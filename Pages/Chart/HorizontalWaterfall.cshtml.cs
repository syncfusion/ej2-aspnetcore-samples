using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class HorizontalWaterfallModel : PageModel
    {
        public List<HorizontalChartData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<HorizontalChartData>
            {
                new HorizontalChartData { X = "JAN",   Y = 55 },
                new HorizontalChartData { X = "MAR",   Y = 42 },
                new HorizontalChartData { X = "JUNE",  Y = -12 },
                new HorizontalChartData { X = "AUG",   Y = 40 },
                new HorizontalChartData { X = "OCT",   Y = -26 },
                new HorizontalChartData { X = "DEC",   Y = 45 },
                new HorizontalChartData { X = "2023" }
            };
        }
    }
    public class HorizontalChartData
    {
        public string X;
        public double Y;
    }
}
