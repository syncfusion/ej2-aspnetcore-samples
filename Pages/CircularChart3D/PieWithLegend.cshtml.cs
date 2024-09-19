#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser_NET8.Pages.CircularChart3D;

public class PieWithLegendModel : PageModel
{
    public List<PieWithLegendChartData> ChartPoints = new List<PieWithLegendChartData>();
    
    public void OnGet()
    {
        ChartPoints.Add(new PieWithLegendChartData { X = "Chrome", Y = 62.92, Text = "62.92%" });
        ChartPoints.Add(new PieWithLegendChartData { X = "Internet Explorer", Y = 6.12, Text = "6.12%" });
        ChartPoints.Add(new PieWithLegendChartData { X = "Opera", Y = 3.15, Text = "3.15%" });
        ChartPoints.Add(new PieWithLegendChartData { X = "Edge", Y = 5.5, Text = "5.5%" });
        ChartPoints.Add(new PieWithLegendChartData { X = "Safari", Y = 19.97, Text = "19.97%" });
        ChartPoints.Add(new PieWithLegendChartData { X = "Others", Y = 2.34, Text = "2.34%" });

    }
}
public class PieWithLegendChartData
{
    public string X;
    public double Y;
    public string Text;
}