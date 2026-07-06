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