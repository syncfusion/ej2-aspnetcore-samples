#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.PivotTable;

public class Hyperlink : PageModel
{
    public List<HyperOptions> hyperOptions = new List<HyperOptions>();
    public List<HyperMeasures> hyperMeasures = new List<HyperMeasures>();
    public void OnGet()
    {
        hyperOptions.Add(new HyperOptions { value = "allcells", text = "All cells" });
        hyperOptions.Add(new HyperOptions { value = "rowheader", text = "Row headers" });
        hyperOptions.Add(new HyperOptions { value = "columnheader", text = "Column headers" });
        hyperOptions.Add(new HyperOptions { value = "valuecells", text = "Value cells" });
        hyperOptions.Add(new HyperOptions { value = "summarycells", text = "Summary cells" });
        hyperOptions.Add(new HyperOptions { value = "conditional", text = "Condition based option" });
        hyperOptions.Add(new HyperOptions { value = "headertext", text = "Header based option" });
        
        hyperMeasures.Add(new HyperMeasures { value = "In_Stock", text = "In Stock" });
        hyperMeasures.Add(new HyperMeasures { value = "Sold", text = "Units Sold" });
        hyperMeasures.Add(new HyperMeasures { value = "Amount", text = "Sold Amount" });
    }
}
public class HyperOptions
{
    public string value { get; set; }
    public string text { get; set; }
}
public class HyperMeasures
{
    public string value { get; set; }
    public string text { get; set; }
}