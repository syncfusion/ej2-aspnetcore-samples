#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.HeatMapChart;

public class CellSelection : PageModel
{
    public double[,] dataSource = new double[7, 5]
    {
        { 2.9, 5.2, 3.4, 5.6, 4.4 },
        { 6.6, 4.8, 8, 3.9, 6.5 },
        { 5.1, 4.6, 5.4, 3.9, 4.3 },
        { 5.2, 4.3, 3.9, 6.2, 6.4 },
        { 7, 3, 1.9, 5.9, 3.5 },
        { 7.8, 5.9, 3.9, 4.3, 4.3 },
        { 6.5, 4.3, 3.9, 5.2, 3.9 },
    };

    public List<ChartData> chartData = new List<ChartData>();
    public List<ChartData> chartData1 = new List<ChartData>();
    public List<ChartData> chartData2 = new List<ChartData>();
    public List<ChartData> chartData3 = new List<ChartData>();
    public List<ChartData> chartData4 = new List<ChartData>();
    public List<ChartData> chartData5 = new List<ChartData>();
    public List<ChartData> chartData6 = new List<ChartData>();
    public void OnGet()
    {
        chartData.Add(new ChartData { x = "2014", y = 2.9 });
        chartData.Add(new ChartData { x = "2015", y = 5.2 });
        chartData.Add(new ChartData { x = "2016", y = 3.4 });
        chartData.Add(new ChartData { x = "2017", y = 5.6 });
        chartData.Add(new ChartData { x = "2018", y = 4.4 });
        
        chartData1.Add(new ChartData { x = "2014", y = 6.6 });
        chartData1.Add(new ChartData { x = "2015", y = 4.8 });
        chartData1.Add(new ChartData { x = "2016", y = 8 });
        chartData1.Add(new ChartData { x = "2017", y = 3.9 });
        chartData1.Add(new ChartData { x = "2018", y = 6.5 });
        
        chartData2.Add(new ChartData { x = "2014", y = 5.1 });
        chartData2.Add(new ChartData { x = "2015", y = 4.6 });
        chartData2.Add(new ChartData { x = "2016", y = 5.4 });
        chartData2.Add(new ChartData { x = "2017", y = 3.9 });
        chartData2.Add(new ChartData { x = "2018", y = 4.3 });
        
        chartData3.Add(new ChartData { x = "2014", y = 5.2 });
        chartData3.Add(new ChartData { x = "2015", y = 4.3 });
        chartData3.Add(new ChartData { x = "2016", y = 3.9 });
        chartData3.Add(new ChartData { x = "2017", y = 6.2 });
        chartData3.Add(new ChartData { x = "2018", y = 6.4 });

        chartData4.Add(new ChartData { x = "2014", y = 7 });
        chartData4.Add(new ChartData { x = "2015", y = 3 });
        chartData4.Add(new ChartData { x = "2016", y = 1.9 });
        chartData4.Add(new ChartData { x = "2017", y = 5.9 });
        chartData4.Add(new ChartData { x = "2018", y = 3.5 });
        
        chartData5.Add(new ChartData { x = "2014", y = 7.8 });
        chartData5.Add(new ChartData { x = "2015", y = 5.9 });
        chartData5.Add(new ChartData { x = "2016", y = 3.9 });
        chartData5.Add(new ChartData { x = "2017", y = 4.3 });
        chartData5.Add(new ChartData { x = "2018", y = 4.5 });
        
        chartData6.Add(new ChartData { x = "2014", y = 6.5 });
        chartData6.Add(new ChartData { x = "2015", y = 4.3 });
        chartData6.Add(new ChartData { x = "2016", y = 3.9 });
        chartData6.Add(new ChartData { x = "2017", y = 5.2 });
        chartData6.Add(new ChartData { x = "2018", y = 3.9 });
    }
}
public class ChartData
{
    public string x;
    public double y;
}