#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.CircularChart3D;

public class DonutModel : PageModel
{
    public List<DonutChartData> ChartPoints { get; set; }
    public void OnGet()
    {
        ChartPoints = new List<DonutChartData>
        {
            new DonutChartData { X = "Tesla",   Y = 137429 },
            new DonutChartData { X = "Aion",    Y = 80308 },
            new DonutChartData { X = "Wuling",  Y = 76418 },
            new DonutChartData { X = "Changan", Y = 52849 },
            new DonutChartData { X = "Geely",   Y = 47234 },
            new DonutChartData { X = "Nio",     Y = 31041 },
            new DonutChartData { X = "Neta",    Y = 22449 },
            new DonutChartData { X = "BMW",     Y = 18733 }
        };
    }
}
public class DonutChartData
{
    public string X;
    public double Y;
}