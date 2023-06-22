#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Grid
{
    public partial class GridController : Controller
    {

        // GET: FlexibleDataBinding
        public IActionResult FlexibleData()
        {
            List<object> urlDataList = new List<object>();
            urlDataList.Add(new { text = "https://services.syncfusion.com/aspnet/production/api/Orders", value = "ODataV4Adaptor" });
            urlDataList.Add(new { text = "https://services.syncfusion.com/aspnet/production/api/Orders", value = "WebApiAdaptor" });
            urlDataList.Add(new { text = "https://services.syncfusion.com/aspnet/production/api/UrlDataSource", value = "UrlAdaptor" });
            urlDataList.Add(new { text = "https://services.odata.org/V4/Northwind/Northwind.svc/Orders", value = "Custom Binding" });
            ViewBag.UrlDataList = urlDataList;
            return View();
        }
    }
}
