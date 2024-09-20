#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using Syncfusion.XlsIO;
using Syncfusion.XlsIORenderer;
using Syncfusion.XlsIO.Implementation.PivotTables;

namespace EJ2CoreSampleBrowser.Controllers.Excel
{
    public partial class ExcelController : Controller
    {
        //
        // GET: /PivotTable/

        public ActionResult PivotLayout(string button, string layoutOption, string fileType)
        {
            if (button == null)
                return View();

            string basePath = _hostingEnvironment.WebRootPath;

            //New instance of XlsIO is created.[Equivalent to launching Microsoft Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;
            IWorkbook workbook = null;
            application.DefaultVersion = ExcelVersion.Excel2016;

            if (fileType == "pdf")
            {
                FileStream inputStream = new FileStream(basePath + @"/XlsIO/PivotLayout.xlsx", FileMode.Open, FileAccess.Read);
                workbook = application.Workbooks.Open(inputStream);

                CreatePivotTable(workbook, layoutOption);

                //Intialize the XlsIORenderer Class
                XlsIORenderer renderer = new XlsIORenderer();
                //Intialize the PdfDocument Class
                PdfDocument pdfDoc = new PdfDocument();

                //Intialize the ExcelToPdfConverterSettings class
                XlsIORendererSettings settings = new XlsIORendererSettings();
                settings.LayoutOptions = LayoutOptions.FitSheetOnOnePage;

                pdfDoc = renderer.ConvertToPDF(workbook, settings);
                inputStream.Dispose();

                MemoryStream stream = new MemoryStream();
                pdfDoc.Save(stream);

                try
                {
                    stream.Position = 0;
                    return File(stream, "application/pdf", "PivotLayout.pdf");
                }
                catch (Exception)
                {
                }

            }
            else
            {
                FileStream inputStream = new FileStream(basePath + @"/XlsIO/PivotLayout.xlsx", FileMode.Open, FileAccess.Read);
                workbook = application.Workbooks.Open(inputStream);

                CreatePivotTable(workbook, layoutOption);

                IPivotTable pivotTable = workbook.Worksheets[1].PivotTables[0];
                pivotTable.Layout();

                //To view the pivot table inline formatting in MS Excel, we have to set the IsRefreshOnLoad property as true.
                (workbook.PivotCaches[pivotTable.CacheIndex] as PivotCacheImpl).IsRefreshOnLoad = true;

                try
                {
                    workbook.Version = ExcelVersion.Excel2016;
                    MemoryStream ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    ms.Position = 0;

                    return File(ms, "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "PivotLayout.xlsx");
                }
                catch (Exception)
                {
                }
            }
            //Close the workbook.
            workbook.Close();
            excelEngine.Dispose();
            return View();
        }

        private static void CreatePivotTable(IWorkbook workbook, string layoutOption)
        {
            // The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];
            //Access the sheet to draw pivot table.
            IWorksheet pivotSheet = workbook.Worksheets[1];
            pivotSheet.Activate();
            //Select the data to add in cache
            IPivotCache cache = workbook.PivotCaches.Add(sheet["A1:G20"]);
            //Insert the pivot table. 
            IPivotTable pivotTable = pivotSheet.PivotTables.Add("PivotTable1", pivotSheet["A1"], cache);
            pivotTable.Fields[0].Axis = PivotAxisTypes.Row;
            pivotTable.Fields[1].Axis = PivotAxisTypes.Row;
            pivotTable.Fields[2].Axis = PivotAxisTypes.Row;
            IPivotField field1 = pivotSheet.PivotTables[0].Fields[5];
            pivotTable.DataFields.Add(field1, "Sum of Land Area", PivotSubtotalTypes.Sum);
            IPivotField field2 = pivotSheet.PivotTables[0].Fields[6];
            pivotTable.DataFields.Add(field2, "Sum of Water Area", PivotSubtotalTypes.Sum);

            if (layoutOption == "Outline")
            {
                pivotTable.Options.RowLayout = PivotTableRowLayout.Outline;

                pivotTable.Location = pivotSheet.Range[1, 1, 51, 5];

                //Apply Inline formatting to pivot table
                IPivotCellFormat cellFormat1 = pivotTable.GetCellFormat("B3:E4");
                cellFormat1.BackColorRGB = Color.FromArgb(255, 169, 208, 142);
                IPivotCellFormat cellFormat2 = pivotTable.GetCellFormat("B31:E32");
                cellFormat2.BackColorRGB = Color.FromArgb(255, 244, 176, 132);
            }
            else if (layoutOption == "Tabular")
            {
                pivotTable.Location = pivotSheet.Range[1, 1, 51, 5];

                pivotTable.Options.RowLayout = PivotTableRowLayout.Tabular;

                //Apply Inline formatting to pivot table
                IPivotCellFormat cellFormat1 = pivotTable.GetCellFormat("B2:E2");
                cellFormat1.BackColorRGB = Color.FromArgb(255, 169, 208, 142);
                IPivotCellFormat cellFormat2 = pivotTable.GetCellFormat("B30:E30");
                cellFormat2.BackColorRGB = Color.FromArgb(255, 244, 176, 132);
            }
            else
            {
                pivotTable.Location = pivotSheet.Range[1, 1, 51, 3];

                //Apply Inline formatting to pivot table
                IPivotCellFormat cellFormat1 = pivotTable.GetCellFormat("A3:C4");
                cellFormat1.BackColorRGB = Color.FromArgb(255, 169, 208, 142);
                IPivotCellFormat cellFormat2 = pivotTable.GetCellFormat("A31:C32");
                cellFormat2.BackColorRGB = Color.FromArgb(255, 244, 176, 132);
            }

            //Apply the show values row option in pivot table.
            pivotTable.Options.ShowValuesRow = true;

            //Apply built in style.
            pivotTable.BuiltInStyle = PivotBuiltInStyles.PivotStyleMedium9;
            pivotSheet.Range[1, 1, 1, 14].ColumnWidth = 11;
            pivotSheet.SetColumnWidth(1, 15.29);
            pivotSheet.SetColumnWidth(2, 15.29);

            if (pivotTable.Options.RowLayout == PivotTableRowLayout.Compact)
            {
                pivotSheet.SetColumnWidth(4, 1.0);
                pivotSheet.SetColumnWidth(5, 2.0);
                pivotSheet.SetColumnWidth(6, 0.5);
                pivotSheet.Range[2, 5, 2, 5].CellStyle.Color = Color.FromArgb(255, 169, 208, 142);
                pivotSheet.Range[4, 5, 4, 5].CellStyle.Color = Color.FromArgb(255, 244, 176, 132);
                pivotSheet.Range[2, 7, 2, 7].Text = "County with largest land area";
                pivotSheet.Range[4, 7, 4, 7].Text = "County with smallest land area";
            }
            else
            {
                pivotSheet.SetColumnWidth(6, 1.0);
                pivotSheet.SetColumnWidth(7, 2.0);
                pivotSheet.SetColumnWidth(8, 0.5);
                pivotSheet.Range[2, 7, 2, 7].CellStyle.Color = Color.FromArgb(255, 169, 208, 142);
                pivotSheet.Range[4, 7, 4, 7].CellStyle.Color = Color.FromArgb(255, 244, 176, 132);
                pivotSheet.Range[2, 9, 2, 9].Text = "County with largest land area";
                pivotSheet.Range[4, 9, 4, 9].Text = "County with smallest land area";
            }

            //Activate the pivot sheet.
            pivotSheet.Activate();
        }
    }
}
