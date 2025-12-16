#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class MultiSortingModel : PageModel
{
    public List<OrdersDetails> DataSource { get; set; }
    public List<object> cols { get; set; }
    public void OnGet()
    {
        DataSource = OrdersDetails.GetAllRecords();
        cols = new List<object>();
        cols.Add(new { field = "OrderDate", direction = "Ascending" });
        cols.Add(new { field = "Freight", direction= "Descending" });
    }

}