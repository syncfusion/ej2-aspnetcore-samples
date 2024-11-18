#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.PivotTable;

public class ValueFiltering : PageModel
{
    public List<ValueFilterMeasures> filterMeasures = new List<ValueFilterMeasures>();
    public void OnGet()
    {
        filterMeasures.Add(new ValueFilterMeasures { value = "In_Stock", text = "In Stock" });
        filterMeasures.Add(new ValueFilterMeasures { value = "Sold", text = "Units Sold" });
        filterMeasures.Add(new ValueFilterMeasures { value = "Amount", text = "Sold Amount" });
    }
}
public class ValueFilterMeasures
{
    public string value { get; set; }
    public string text { get; set; }
}