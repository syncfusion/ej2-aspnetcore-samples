using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart
{
    public class StackedSmartLabelsModel : PageModel
    {
        public List<StackedSmartLabelsChartData> ChartPoints { get; set; }

        public void OnGet()
        {
            ChartPoints = new List<StackedSmartLabelsChartData>
            {
                new StackedSmartLabelsChartData { X = "Q1 2025", Samsung = 72.3, Apple = 56.2, Xiaomi = 42.7, Oppo = 7.4, Vivo = 5.2, Others = 70.7 },
                new StackedSmartLabelsChartData { X = "Q2 2025", Samsung = 75.9, Apple = 57.1, Xiaomi = 43.9, Oppo = 6.2, Vivo = 3.9, Others = 4.9 },
                new StackedSmartLabelsChartData { X = "Q3 2025", Samsung = 80.1, Apple = 60.3, Xiaomi = 46.0, Oppo = 4.8, Vivo = 3.9, Others = 78.9 },
                new StackedSmartLabelsChartData { X = "Q4 2025", Samsung = 85.5, Apple = 62.7, Xiaomi = 48.9, Oppo = 6.4, Vivo = 5.8, Others = 81.5 }
            };
        }
    }

    public class StackedSmartLabelsChartData
    {
        public string X { get; set; }
        public double Samsung { get; set; }
        public double Apple { get; set; }
        public double Xiaomi { get; set; }
        public double Oppo { get; set; }
        public double Vivo { get; set; }
        public double Others { get; set; }
    }
}