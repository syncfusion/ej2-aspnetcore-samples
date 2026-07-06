using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Dynamic;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class ExpandoObjectBindingModel : PageModel
{
    public List<ExpandoObject> ExpandoOrders { get; set; } = new List<ExpandoObject>();

    public void OnGet()
    {
        string[] customerIDs = { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" };
        string[] shipCountrys = { "USA", "UK", "Denmark", "Australia", "India" };
        ExpandoOrders = Enumerable.Range(1, 75).Select((x) =>
        {
            dynamic d = new ExpandoObject();
            d.OrderID = 1000 + x;
            d.CustomerID = customerIDs[x % customerIDs.Length];
            d.Freight = (new double[] { 2, 1, 4, 5, 3 })[new Random().Next(5)] * x;
            d.OrderDate = (new DateTime[] { new DateTime(2010, 11, 5), new DateTime(2018, 10, 3), new DateTime(1995, 9, 9), new DateTime(2012, 8, 2), new DateTime(2015, 4, 11) })[new Random().Next(5)];
            d.ShipCountry = shipCountrys[x % shipCountrys.Length];
            return d;
        }).Cast<ExpandoObject>().ToList<ExpandoObject>();
    }
}