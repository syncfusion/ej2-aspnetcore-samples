#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class DataTableBindingModel : PageModel
{
    public DataTable datasource { get; set; }
    public void OnGet()
    {
        DataTable dt = new DataTable("Table");
        dt.Columns.AddRange(new DataColumn[6] { new DataColumn("OrderID", typeof(long)),
            new DataColumn("EmployeeID",typeof(int)),
            new DataColumn("CustomerID", typeof(string)),
            new DataColumn("Freight", typeof(double)),
            new DataColumn("OrderDate",typeof(DateTime)),
            new DataColumn("ShipCountry",typeof(string))
        });
        int code = 10000;
        for (int i = 1; i < 10; i++)
        {
            dt.Rows.Add(code + 1, i + 0, "ALFKI", 2.3 * i,  new DateTime(1991, 05, 15), "Denmark");
            dt.Rows.Add(code + 2, i + 2, "ANATR", 3.3 * i, new DateTime(1990, 04, 04), "Brazil");
            dt.Rows.Add(code + 3, i + 1, "ANTON", 4.3 * i, new DateTime(1957, 11, 30), "Germany");
            dt.Rows.Add(code + 4, i + 3, "BLONP", 5.3 * i, new DateTime(1930, 10, 22), "Austria");
            dt.Rows.Add(code + 5, i + 4, "BOLID", 6.3 * i, new DateTime(1953, 02, 18), "Switzerland");
            code += 5;
        }
        datasource = dt;
    }
}