using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class DrilldownModel : PageModel
    {
        public List<CategoryData> ChartData { get; set; }
        public void OnGet()
        {
            ChartData = new List<CategoryData>
            {
                new CategoryData { x = "Asia-Pacific", y = 45 },
                new CategoryData { x = "Europe", y = 25 },
                new CategoryData { x = "North America", y = 25 },
                new CategoryData { x = "Latin America", y = 7 },
                new CategoryData { x = "Middle East & Africa", y = 3 }
            };
        }
    }
    public class CategoryData
    {
        public string x;
        public double y;
    }
}
