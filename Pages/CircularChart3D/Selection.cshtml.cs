#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.CircularChart3D;

public class SelectionModel : PageModel
{
    public List<SelectionChartData> ChartPoints { get; set; }
    public void OnGet()
    {
        ChartPoints = new List<SelectionChartData>
        {
            new SelectionChartData { X = "Chrome",             Y = 62.92 },
            new SelectionChartData { X = "Internet Explorer",  Y = 6.12  },
            new SelectionChartData { X = "Edge",               Y = 5.5   },
            new SelectionChartData { X = "Opera",              Y = 3.15  },
            new SelectionChartData { X = "Safari",             Y = 19.97 },
            new SelectionChartData { X = "Others",             Y = 2.34  }
        };
    }
}
public class SelectionChartData
{
    public string X;
    public double Y;
}