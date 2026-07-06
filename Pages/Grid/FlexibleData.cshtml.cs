using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class FlexibleDataModel : PageModel
{
    public List<object> urlDataList { get; set; }
    public void OnGet()
    {
       urlDataList = new List<object>();
        urlDataList.Add(new { text = "https://services.syncfusion.com/aspnet/production/api/Orders", value = "ODataV4Adaptor" });
        urlDataList.Add(new { text = "https://services.syncfusion.com/aspnet/production/api/Orders", value = "WebApiAdaptor" });
        urlDataList.Add(new { text = "https://services.syncfusion.com/aspnet/production/api/UrlDataSource", value = "UrlAdaptor" });
        urlDataList.Add(new { text = "https://services.odata.org/V4/Northwind/Northwind.svc/Orders", value = "Custom Binding" });
    }
}