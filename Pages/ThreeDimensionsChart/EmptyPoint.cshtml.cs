using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.ThreeDimensionsChart;

public class EmptyPointModel : PageModel
{
    public List<EmptyPointChartData> ChartPoints { get; set; }
    public void OnGet()
    {
        ChartPoints = new List<EmptyPointChartData>
        {
            new EmptyPointChartData { X = "Italy",        Y = 10 },
            new EmptyPointChartData { X = "Kenya",        Y = 4  },
            new EmptyPointChartData { X = "France",       Y = 10 },
            new EmptyPointChartData { X = "Hungary",      Y = 0  },
            new EmptyPointChartData { X = "Australia",    Y = 17 },
            new EmptyPointChartData { X = "Brazil",       Y = 7  },
            new EmptyPointChartData { X = "Netherlands",  Y = 10 },
            new EmptyPointChartData { X = "Unspecified",  Y = Double.NaN },
            new EmptyPointChartData { X = "Germany",      Y = 10 },
            new EmptyPointChartData { X = "Serbia",       Y = 3  }
        };
    }
}
public class EmptyPointChartData
{
    public string X;
    public double Y;
}