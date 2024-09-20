#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2;
using Syncfusion.EJ2.DropDowns;
namespace EJ2CoreSampleBrowser_NET8.Pages.DropDownTree;

public class RemoteData : PageModel
{
    public DropDownTreeFields childData = new DropDownTreeFields();
    public void OnGet()
    {
        childData.Query = "new ej.data.Query().from('Orders').select('OrderID,EmployeeID,ShipName').take(5)";
        childData.Value = "OrderID";
        childData.Text = "ShipName";
        childData.ParentValue = "EmployeeID";
        childData.DataSource = new DataManager
        {
            Url = "https://services.odata.org/V4/Northwind/Northwind.svc",
            Adaptor = "ODataV4Adaptor",
            CrossDomain = true
        };
    }
}