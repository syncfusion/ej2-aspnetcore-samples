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

public class MasterDetailsExportModel : PageModel
{
    public List<OrdersDetails> DataSource { get; set; }
    public List<EmployeeView> EmpDataSource { get; set; }
    public List<Customer> CustomerDataSource { get; set; }

    public void OnGet()
    {
        DataSource = OrdersDetails.GetAllRecords();
        EmpDataSource = EmployeeView.GetAllRecords();
        CustomerDataSource = Customer.GetAllRecords();
    }
}