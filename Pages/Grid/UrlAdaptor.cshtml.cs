#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Base;
using EJ2CoreSampleBrowser.Models;
using System.Collections;

namespace EJ2CoreSampleBrowser.Pages.Grid;

public class UrlAdaptorModel : PageModel
{
    public void OnGet()
    {
        
    }

    public JsonResult OnPostUrlDatasource([FromBody] DataManagerRequest dm)
    {
        IEnumerable DataSource = Orders.GetAllRecords();
        DataOperations operation = new DataOperations();
        if (dm.Search != null && dm.Search.Count > 0)
        {
            DataSource = operation.PerformSearching(DataSource, dm.Search);  //Search
        }
        if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
        {
            DataSource = operation.PerformSorting(DataSource, dm.Sorted);
        }
        if (dm.Where != null && dm.Where.Count > 0) //Filtering
        {
            DataSource = operation.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
        }
        int count = DataSource.Cast<Orders>().Count();
        if (dm.Skip != 0)
        {
            DataSource = operation.PerformSkip(DataSource, dm.Skip); //Paging
        }
        if (dm.Take != 0)
        {
            DataSource = operation.PerformTake(DataSource, dm.Take);
        }
        return dm.RequiresCounts ? new JsonResult(new { result = DataSource, count = count }) : new JsonResult(DataSource);
    }
}