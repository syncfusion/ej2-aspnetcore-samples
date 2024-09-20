#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser_NET8.Pages.CircularChart3D;

public class PieRadiusModel : PageModel
{
    public List<PieRadiusData> ChartPoints { get; set; }
    
    public void OnGet()
    {
        ChartPoints = new List<PieRadiusData>
        {
            new PieRadiusData { X = "Argentina",          Y = 505370, R = "100",    Text = "Argentina" },
            new PieRadiusData { X = "Belgium",            Y = 551500, R = "118.7",  Text = "Belgium" },
            new PieRadiusData { X = "Dominican Republic", Y = 312685, R = "137.5",  Text = "Dominican Republic" },
            new PieRadiusData { X = "Cuba",               Y = 350000, R = "124.6",  Text = "Cuba" },
            new PieRadiusData { X = "Egypt",              Y = 301000, R = "150.8",  Text = "Egypt" },
            new PieRadiusData { X = "Kazakhstan",         Y = 300000, R = "155.5",  Text = "Kazakhstan" },
            new PieRadiusData { X = "Somalia",            Y = 357022, R = "160.6",  Text = "Somalia" }
        };
    }
}
public class PieRadiusData
{
    public string X;
    public double Y;
    public string R;
    public string Text;
}