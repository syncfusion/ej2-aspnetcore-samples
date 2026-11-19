using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class RowHeightModel : PageModel
{
    public List<OrdersDetails> DataSource { get; set; }
    public List<object> toolbar { get; set; }
    public void OnGet()
    {
        DataSource = OrdersDetails.GetAllRecords();
        toolbar = new List<object>();
        toolbar.Add(new { prefixIcon = "e-small-icon", id = "big", align = "Right", tooltipText = "Row-height-big" });
        toolbar.Add(new { prefixIcon = "e-medium-icon", id = "medium", align = "Right", tooltipText = "Row-height-medium" });
        toolbar.Add(new { prefixIcon = "e-big-icon", id = "small", align = "Right", tooltipText = "Row-height-small" });
    }
}