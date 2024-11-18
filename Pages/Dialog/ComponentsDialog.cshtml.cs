#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
namespace EJ2CoreSampleBrowser.Pages.Dialog;

public class ComponentsDialog : PageModel
{
    [Required(ErrorMessage = "UserName is Required.")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Date of Birth is Required")]
    public DateTime? DOB { get; set; }

    [Required(ErrorMessage = "Addresss is Required")]
    public string Address { get; set; }

    [Required(ErrorMessage = "City is Required")]
    public string City { get; set; }

    [Required(ErrorMessage = "State is Required")]
    public string State { get; set; }

    public List<LineChartData> chartData = new List<LineChartData>();
    
    public Dictionary<string, object> resetType = new Dictionary<string, object>();
    
    public Dictionary<string, object> submitType = new Dictionary<string, object>();
    
    
    public void OnGet()
    {
        resetType.Add("type", "reset");
        submitType.Add("type", "submit");
        
        chartData.Add(new LineChartData { xValue = new DateTime(2005, 01, 01), yValue = 21, yValue1 = 28 });
        chartData.Add(new LineChartData { xValue = new DateTime(2006, 01, 01), yValue = 24, yValue1 = 44 });
        chartData.Add(new LineChartData { xValue = new DateTime(2007, 01, 01), yValue = 36, yValue1 = 48 });
        chartData.Add(new LineChartData { xValue = new DateTime(2008, 01, 01), yValue = 38, yValue1 = 50 });
        chartData.Add(new LineChartData { xValue = new DateTime(2009, 01, 01), yValue = 54, yValue1 = 66 });
        chartData.Add(new LineChartData { xValue = new DateTime(2010, 01, 01), yValue = 57, yValue1 = 78 });
        chartData.Add(new LineChartData { xValue = new DateTime(2011, 01, 01), yValue = 70, yValue1 = 84 });
    }
}
public class DefaultButtonModels
{
    public string content { get; set; }
    public bool isPrimary { get; set; }
}
public class LineChartData
{
    public DateTime xValue;
    public double yValue;
    public double yValue1;
}
