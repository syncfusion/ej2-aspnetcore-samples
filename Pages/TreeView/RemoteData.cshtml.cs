using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Navigations;
using Syncfusion.EJ2;

namespace EJ2CoreSampleBrowser.Pages.TreeView
{
    public class RemoteDataModel : PageModel
    {
        public TreeViewFieldsSettings ChildData = new();
        public void OnGet()
        {
            
            ChildData.Query = "new ej.data.Query().from('Orders').select('OrderID,EmployeeID,ShipName').take(5)";
            ChildData.Id = "OrderID";
            ChildData.Text = "ShipName";
            ChildData.ParentID = "EmployeeID";
            ChildData.DataSource = new DataManager
            {
                Url = "https://services.odata.org/V4/Northwind/Northwind.svc",
                Adaptor = "ODataV4Adaptor",
                CrossDomain = true
            };
        }
    }
}
