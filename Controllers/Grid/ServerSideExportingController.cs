using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Syncfusion.EJ2.GridExport;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Grid
{
    public partial class GridController : Controller
    {
        public IActionResult ServerSideExporting()
        {
            var order = OrdersDetails.GetRecords();
            ViewBag.datasource = order;
            return View();
        }

        public ActionResult ExcelExport([FromForm] string gridModel)
        {
            GridExcelExport exp = new GridExcelExport();
            Syncfusion.EJ2.Grids.Grid gridProperty = ConvertGridObject(gridModel);
            return exp.ExcelExport<OrdersDetails>(gridProperty, OrdersDetails.GetRecords());
        }
        public ActionResult CsvExport([FromForm] string gridModel)
        {
            GridExcelExport exp = new GridExcelExport();
            Syncfusion.EJ2.Grids.Grid gridProperty = ConvertGridObject(gridModel);
            return exp.CsvExport<OrdersDetails>(gridProperty, OrdersDetails.GetRecords());
        }
        public ActionResult PdfExport([FromForm] string gridModel)
        {
            GridPdfExport exp = new GridPdfExport();
            Syncfusion.EJ2.Grids.Grid gridProperty = ConvertGridObject(gridModel);
            return exp.PdfExport<OrdersDetails>(gridProperty, OrdersDetails.GetRecords());
        }

        private Syncfusion.EJ2.Grids.Grid ConvertGridObject(string gridProperty)
        {
            Syncfusion.EJ2.Grids.Grid GridModel = (Syncfusion.EJ2.Grids.Grid)Newtonsoft.Json.JsonConvert.DeserializeObject(gridProperty, typeof(Syncfusion.EJ2.Grids.Grid));
            GridColumnModel cols = (GridColumnModel)Newtonsoft.Json.JsonConvert.DeserializeObject(gridProperty, typeof(GridColumnModel));
            GridModel.Columns = cols.columns;
            return GridModel;
        }
    }
}