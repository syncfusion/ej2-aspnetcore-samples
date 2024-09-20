#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser_NET8.Pages.Grid;

public class SortingAPIModel : PageModel
{
    public List<OrdersDetails> DataSource { get; set; }
    public List<object> columns { get; set; }
    public List<object> direction { get; set; }
    public void OnGet()
    {
        DataSource = OrdersDetails.GetAllRecords();
        List<object> dd = new List<object>();
        dd.Add(new { text = "Order ID", value = "OrderID" });
        dd.Add(new { text = "Customer Name", value = "CustomerID" });
        dd.Add(new { text = "Order Date", value = "OrderDate" });
        dd.Add(new { text = "Freight", value = "Freight" });

        columns = dd;
        direction = new List<object>();
        direction.Add(new { text = "Ascending", value = "Ascending" });
        direction.Add(new { text = "Descending", value = "Descending" });
    }
}