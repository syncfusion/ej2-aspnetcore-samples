#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace EJ2CoreSampleBrowser.Pages.Grid;

public class DialogTemplateModel : PageModel
{
    public List<OrdersDetails> DataSource { get; set; }

    public void OnGet()
    {
        DataSource = OrdersDetails.GetAllRecords();
    }

    public ActionResult OnPostEditPartial([FromBody] CRUDAction<DialogTemplateAddEditModel> value)
    {
        ViewData["DataSource"] = OrdersDetails.GetAllRecords();
        return new PartialViewResult
        {
            ViewName = "_DialogEditPartial",
            ViewData = new ViewDataDictionary<DialogTemplateAddEditModel>(ViewData, value.value)
        };
    }

    public ActionResult OnPostAddPartial([FromBody] CRUDAction<DialogTemplateAddEditModel> value)
    {
        ViewData["DataSource"] = OrdersDetails.GetAllRecords();
        return new PartialViewResult
        {
            ViewName = "_DialogAddPartial",
            ViewData = new ViewDataDictionary<DialogTemplateAddEditModel>(ViewData, value.value)
        };
    }

}

public class CRUDAction<T> where T : class
{
    public string action { get; set; }
    public string table { get; set; }
    public string keyColumn { get; set; }
    public object key { get; set; }
    public T value { get; set; }
    public List<T> added { get; set; }
    public List<T> changed { get; set; }
    public List<T> deleted { get; set; }
    public IDictionary<string, object> @params { get; set; }
}

public class DialogTemplateAddEditModel
{
    [Required]
    public int? OrderID { get; set; }
    [Required, MinLength(3)]
    public string CustomerID { get; set; }
    public int? EmployeeID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
    public bool Verified { get; set; }
    public DateTime? OrderDate { get; set; }
    public string ShipName { get; set; }
    public string ShipCountry { get; set; }
    public DateTime ShippedDate { get; set; }
    public string ShipAddress { get; set; }
}