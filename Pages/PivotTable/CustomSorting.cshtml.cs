#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.PivotTable;

public class CustomSorting : PageModel
{
    public List<CustomSortingFields> customSortingFields = new List<CustomSortingFields>();
    public void OnGet()
    {
        customSortingFields.Add(new CustomSortingFields { Field = "Country", Order = "Country_asc", caption = "Country" });
        customSortingFields.Add(new CustomSortingFields { Field = "Products", Order = "Products_desc", caption = "Products" });
        customSortingFields.Add(new CustomSortingFields { Field = "Year", Order = "Year_desc", caption = "Year" });
        customSortingFields.Add(new CustomSortingFields { Field = "Order_Source", Order = "Order_Source_asc", caption = "Order Source" });
    }
}
public class CustomSortingFields
{
    public string Field { get; set; }
    public string Order { get; set; }
    public string caption { get; set; }
}