#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Chart;

public class UpdateDataSource : PageModel
{
    public List<UpdateChartData> ChartPoints = new List<UpdateChartData>();
    public void OnGet()
    {
        ChartPoints.Add(new UpdateChartData { X = "Jewellery", Y = 75 });
        ChartPoints.Add(new UpdateChartData { X = "Shoes", Y = 45 });
        ChartPoints.Add(new UpdateChartData { X = "Footwear", Y = 73 });
        ChartPoints.Add(new UpdateChartData { X = "Pet Services", Y = 53 });
        ChartPoints.Add(new UpdateChartData { X = "Business Clothing", Y = 85 });
        ChartPoints.Add(new UpdateChartData { X = "Office Supplies", Y = 68 });
        ChartPoints.Add(new UpdateChartData { X = "Food", Y = 45 });
    }
}
public class UpdateChartData
{
    public string? X;
    public double Y;
}