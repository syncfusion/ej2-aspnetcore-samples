#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.PivotTable;

public class Sorting : PageModel
{
    public List<FieldData> fieldData = new List<FieldData>();
    public List<DropDownData> sortData = new List<DropDownData>();
    public void OnGet()
    {
        fieldData.Add(new FieldData { Field = "Country", Order = "Country_asc" });
        fieldData.Add(new FieldData { Field = "Products", Order = "Products_asc" });
        fieldData.Add(new FieldData { Field = "Year", Order = "Year_asc" });
        fieldData.Add(new FieldData { Field = "Order Source", Order = "Order Source_asc" });
        
        sortData.Add(new DropDownData { Name = "Ascending", Value = "Ascending" });
        sortData.Add(new DropDownData { Name = "Descending", Value = "Descending" });
    }
}
public class FieldData
{
    public string Field { get; set; }
    public string Order { get; set; }
}