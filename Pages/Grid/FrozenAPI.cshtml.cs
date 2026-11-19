using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class FrozenAPIModel : PageModel
{
    public List<OrdersDetails> DataSource { get; set; }
    public List<object> columns { get; set; }
    public List<object> direction { get; set; }
    public void OnGet()
    {
        DataSource = OrdersDetails.GetAllRecords();
        List<object> dd = new List<object>();
        dd.Add(new { name = "Order ID", id = "OrderID" });
        dd.Add(new { name = "Freight", id = "Freight" });
        dd.Add(new { name = "Customer ID", id = "CustomerID" });
        dd.Add(new { name = "Order Date", id = "OrderDate" });
        dd.Add(new { name = "Ship Name", id = "ShipName" });
        dd.Add(new { name = "Ship Address", id = "ShipAddress" });
        dd.Add(new { name = "Ship City", id = "ShipCity" });
        dd.Add(new { name = "Ship Country", id = "ShipCountry" });
        columns = dd;
        direction = new List<object>();
        direction.Add(new { name = "Left", id = "Left" });
        direction.Add(new { name = "Right", id = "Right" });
        direction.Add(new { name = "Center", id = "Center" });
        direction.Add(new { name = "Fixed", id = "Fixed" });
    }
}