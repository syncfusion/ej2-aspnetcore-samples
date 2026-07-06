using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class InversedSplineModel : PageModel
    {
        public void OnGet()
        {
        }
        public List<InversedLineChartData> ChartPoints = new List<InversedLineChartData>
            {
                new InversedLineChartData { Country = "United States", Y = 194.55 },
                new InversedLineChartData { Country = "Japan", Y = 146.2 },
                new InversedLineChartData { Country = "China", Y = 65.1 },
                new InversedLineChartData { Country = "France", Y = 84.9 },
                new InversedLineChartData { Country = "India", Y = 140.1 },
                new InversedLineChartData { Country = "Canada", Y = 160.7 },
                new InversedLineChartData { Country = "Brazil", Y = 68.4 },
                new InversedLineChartData { Country = "United Kingdom", Y = 100.2 },
                new InversedLineChartData { Country = "Sweden", Y = 162 },
                new InversedLineChartData { Country = "Netherlands", Y = 132.3 },
                new InversedLineChartData { Country = "Bangladesh", Y = 27.7 }
            };
    }
    public class InversedLineChartData
    {
        public string Country;
        public double Y;
    }
}
