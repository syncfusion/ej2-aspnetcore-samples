#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.DashboardLayout;

public class EditableLayout : PageModel
{
    public List<PieData> pieChartData = new List<PieData>();
    public List<LineData> LineChartData = new List<LineData>();
    public List<LineData> LineChartData1 = new List<LineData>();
    public List<LineData> LineChartData2 = new List<LineData>();
    public List<SplineData> SplineChartData1 = new List<SplineData>();
    public List<SplineData> SplineChartData2 = new List<SplineData>();
    public void OnGet()
    {
        pieChartData.Add(new PieData
        {
            x = "Jan",
            y = 12.5,
            text = "January"
        });
        pieChartData.Add(new PieData
        {
            x = "Feb",
            y = 25,
            text = "February"
        });
        pieChartData.Add(new PieData
        {
            x = "Mar",
            y = 50,
            text = "March"
        });

        LineChartData.Add(new LineData
        {
            x = "Jan",
            y = 37,
        });
        LineChartData.Add(new LineData
        {
            x = "Feb",
            y = 23,
        });
        LineChartData.Add(new LineData
        {
            x = "Mar",
            y = 18,
        });


        LineChartData1.Add(new LineData
        {
            x = "Jan",
            y = 46,
        });
        LineChartData1.Add(new LineData
        {
            x = "Feb",
            y = 27,
        });
        LineChartData1.Add(new LineData
        {
            x = "Mar",
            y = 26,
        });

        LineChartData2.Add(new LineData
        {
            x = "Jan",
            y = 38,
        });
        LineChartData2.Add(new LineData
        {
            x = "Feb",
            y = 17,
        });
        LineChartData2.Add(new LineData
        {
            x = "Mar",
            y = 26,
        });

        SplineChartData1.Add(new SplineData { x = new DateTime(2002, 1, 1), y = 2.2 });
        SplineChartData1.Add(new SplineData { x = new DateTime(2003, 1, 1), y = 3.4 });
        SplineChartData1.Add(new SplineData { x = new DateTime(2004, 1, 1), y = 2.8 });
        SplineChartData1.Add(new SplineData { x = new DateTime(2005, 1, 1), y = 1.6 });
        SplineChartData1.Add(new SplineData { x = new DateTime(2006, 1, 1), y = 2.3 });
        SplineChartData1.Add(new SplineData { x = new DateTime(2007, 1, 1), y = 2.5 });
        SplineChartData1.Add(new SplineData { x = new DateTime(2008, 1, 1), y = 2.9 });
        SplineChartData1.Add(new SplineData { x = new DateTime(2009, 1, 1), y = 3.8 });
        SplineChartData1.Add(new SplineData { x = new DateTime(2010, 1, 1), y = 1.4 });
        SplineChartData1.Add(new SplineData { x = new DateTime(2011, 1, 1), y = 3.1 });
        
        SplineChartData2.Add(new SplineData { x = new DateTime(2002, 1, 1), y = 2 });
        SplineChartData2.Add(new SplineData { x = new DateTime(2003, 1, 1), y = 1.7 });
        SplineChartData2.Add(new SplineData { x = new DateTime(2004, 1, 1), y = 1.8 });
        SplineChartData2.Add(new SplineData { x = new DateTime(2005, 1, 1), y = 2.1 });
        SplineChartData2.Add(new SplineData { x = new DateTime(2006, 1, 1), y = 2.3 });
        SplineChartData2.Add(new SplineData { x = new DateTime(2007, 1, 1), y = 1.7 });
        SplineChartData2.Add(new SplineData { x = new DateTime(2008, 1, 1), y = 1.5 });
        SplineChartData2.Add(new SplineData { x = new DateTime(2009, 1, 1), y = 2.8 });
        SplineChartData2.Add(new SplineData { x = new DateTime(2010, 1, 1), y = 1.5 });
        SplineChartData2.Add(new SplineData { x = new DateTime(2011, 1, 1), y = 2.3 });
    }
}
public class PieData
{
    public string x;
    public double y;
    public string text;
}

public class LineData
{
    public string x;
    public double y;
}

public class SplineData
{
    public DateTime x;
    public double y;
}