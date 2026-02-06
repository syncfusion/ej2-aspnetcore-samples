#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.CircularChart3D;

public class PieModel : PageModel
{
    public List<PieChartData> ChartPoints { get; set; }
    public void OnGet()
    {
        ChartPoints = new List<PieChartData>
        {
            new PieChartData { X = "Canada",         Y = 46,  Text= "Canada: 46" },
            new PieChartData { X = "Hungary",        Y = 30,  Text= "Hungary: 30" },
            new PieChartData { X = "Germany",        Y = 79,  Text= "Germany: 79" },
            new PieChartData { X = "Mexico",         Y = 13,  Text= "Mexico: 13" },
            new PieChartData { X = "China",          Y = 56,  Text= "China: 56" },
            new PieChartData { X = "India",          Y = 41,  Text= "India: 41" },
            new PieChartData { X = "Bangladesh",     Y = 25,  Text= "Bangladesh: 25" },
            new PieChartData { X = "United States",  Y = 32,  Text= "United States: 32" },
            new PieChartData { X = "Belgium",        Y = 34,  Text= "Belgium: 34" }               
        };
    }
}
public class PieChartData
{
    public string X;
    public double Y;
    public string Text;
}