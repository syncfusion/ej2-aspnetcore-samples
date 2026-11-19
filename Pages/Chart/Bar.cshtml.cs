using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class BarModel : PageModel
    {
        public List<BarChartData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<BarChartData>
            {
                new BarChartData { Year = "2021",  Count1 = 237, Count2 = 190, Count3 = 143 },
                new BarChartData { Year = "2022",  Count1 = 226.4, Count2 = 153.1, Count3 = 103.3 },
                new BarChartData { Year = "2023",  Count1 = 234.6, Count2 = 145.9, Count3 = 103.1 },
            };
        }
    }
    public class BarChartData
    {
        public string Year;
        public double Count1;
        public double Count2;
        public double Count3;
    }
}
