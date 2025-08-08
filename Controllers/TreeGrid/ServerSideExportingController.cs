#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.TreeGrid;
using Syncfusion.EJ2.TreeGridExport;

namespace EJ2CoreSampleBrowser_NET6.Controllers.TreeGrid
{
    public partial class TreeGridController : Controller
    {
        public IActionResult ServerSideExporting()
        {
            var order = TreeData.GetDefaultData();
            ViewData["dataSource"] = order;
            return View();
        }
        public IActionResult ExcelExport(string treeGridModel)
        {
            if (treeGridModel == null)
            {
                return View();
            }
            TreeGridExcelExport exp = new TreeGridExcelExport();
            Syncfusion.EJ2.TreeGrid.TreeGrid gridProperty = ConvertTreeGridObject(treeGridModel);
            return exp.ExportToExcel<TreeData>(gridProperty, TreeData.GetDefaultData());
        }

        public IActionResult CsvExport(string treeGridModel)
        {
            if (treeGridModel == null)
            {
                return View();
            }
            TreeGridExcelExport exp = new TreeGridExcelExport();
            Syncfusion.EJ2.TreeGrid.TreeGrid gridProperty = ConvertTreeGridObject(treeGridModel);
            return exp.ExportToCsv<TreeData>(gridProperty, TreeData.GetDefaultData());
        }
        public IActionResult PdfExport(string treeGridModel)
        {
            if (treeGridModel == null)
            {
                return View();
            }
            TreeGridPdfExport exp = new TreeGridPdfExport();
            Syncfusion.EJ2.TreeGrid.TreeGrid gridProperty = ConvertTreeGridObject(treeGridModel);
            return exp.ExportToPdf<TreeData>(gridProperty, TreeData.GetDefaultData());
        }

        private Syncfusion.EJ2.TreeGrid.TreeGrid ConvertTreeGridObject(string gridProperty)
        {
            Syncfusion.EJ2.TreeGrid.TreeGrid TreeGridModel = (Syncfusion.EJ2.TreeGrid.TreeGrid)Newtonsoft.Json.JsonConvert.DeserializeObject(gridProperty, typeof(Syncfusion.EJ2.TreeGrid.TreeGrid));
            TreeGridColumnModel cols = (TreeGridColumnModel)Newtonsoft.Json.JsonConvert.DeserializeObject(gridProperty, typeof(TreeGridColumnModel));
            TreeGridModel.Columns = cols.columns;
            return TreeGridModel;
        }

        public class TreeGridColumnModel
        {
            public List<TreeGridColumn> columns { get; set; }
        }
    }
}
