using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart;

public class ClickPoint : PageModel
{
    public List<ClickPointChartData> ChartPoints = new List<ClickPointChartData>();
    public void OnGet()
    {
        ChartPoints.Add(new ClickPointChartData { X = 20, Y = 20 });
        ChartPoints.Add(new ClickPointChartData { X = 80, Y = 80 });
    }
}
public class ClickPointChartData
{
    public double X;
    public double Y;
}