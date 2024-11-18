#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class ShowHideColumnModel : PageModel
{
    public List<Category> DataSource { get; set; }
    public List<object> columns { get; set; }
    public void OnGet()
    {
        DataSource = Category.GetAllRecords().ToList();
        List<object> dd = new List<object>();
        dd.Add(new { text = "Category Name", value = "CategoryName" });
        dd.Add(new { text = "Product Name", value = "ProductName" });
        dd.Add(new { text = "Units In Stock", value = "UnitsInStock" });
        dd.Add(new { text = "Discontinued", value = "Discontinued" });
        columns = dd;
    }
}