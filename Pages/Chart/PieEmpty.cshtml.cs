using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class PieEmptyModel : PageModel
    {
        public List<PieChartEmptyPointsData> ChartPoints { get; set; }
        public void OnGet()
        {
            ChartPoints = new List<PieChartEmptyPointsData>
            {
                new PieChartEmptyPointsData { Product= "Action",  ProfitPercentage= 35 },
                new PieChartEmptyPointsData { Product= "Drama",   ProfitPercentage= 25 },
                new PieChartEmptyPointsData { Product= "Comedy",  ProfitPercentage= null },
                new PieChartEmptyPointsData { Product= "Romance", ProfitPercentage= 20 },
                new PieChartEmptyPointsData { Product= "Horror",  ProfitPercentage= 10 },
                new PieChartEmptyPointsData { Product= "Sci-Fi",  ProfitPercentage= null }
            };
        }
    }
    public class PieChartEmptyPointsData
    {
        public string Product;
        public double? ProfitPercentage;
    }
    
}