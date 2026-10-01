using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.ThreeDimensionsChart;

public class CylinderModel : PageModel
{
    public List<CylinderChartData> ChartPoints { get; set; }
    public void OnGet()
    {
        ChartPoints = new List<CylinderChartData>
        {
            new CylinderChartData { X = "Czechia",     Y = 1.11 },
            new CylinderChartData { X = "Spain",       Y = 1.66 },
            new CylinderChartData { X = "USA",         Y = 1.56 },
            new CylinderChartData { X = "Germany",     Y = 3.1  },
            new CylinderChartData { X = "Russia",      Y = 1.35 },
            new CylinderChartData { X = "Slovakia",    Y = 1    },
            new CylinderChartData { X = "South Korea", Y = 3.16 },
            new CylinderChartData { X = "France",      Y = 0.92 }
        };
    }
}
public class CylinderChartData
{
    public string X;
    public double Y;
}