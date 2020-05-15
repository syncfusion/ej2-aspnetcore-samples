using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2;
using Syncfusion.EJ2.DropDowns;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.DropDownTree
{
    
    public partial class DropDownTreeController : Controller
    {

        public IActionResult RemoteData()
        {
            DropDownTreeFields childData = new DropDownTreeFields();
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
            ViewBag.child = childData;
            return View();
        }
    }

   
}