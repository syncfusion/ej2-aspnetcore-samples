#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.XlsIO;
using Syncfusion.Drawing;
using System.Globalization;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Data;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Controllers.XlsIO
{
 
    public partial class XlsIOController : Controller
    {
        public static List<Sales> _sales = new List<Sales>();
        public static List<Sales> businessObjects = null;

        public IActionResult UrlDatasource([FromBody]Data dm)
        {
            var order = _sales;
            var Data = order.ToList();
            int count = order.Count();
            return dm.requiresCounts ? Json(new { result = Data.Skip(dm.skip).Take(dm.take), count = count }) : Json(Data);
        }
        //For Session 
        //public HttpSessionStateBase Session { get; }
        public ActionResult CLRObjects(string saveOption, string button)
        {            
            string basePath = _hostingEnvironment.WebRootPath;

            ViewBag.exportButtonState = "disabled=\"disabled\"";

            ///SaveOption Null
            if (saveOption == null || button == null)
            {
                _sales = new List<Sales>();
                return View();
            }

            //Start Business Object Functions
            if (button == "Input Template")
            {
                //Step 1 : Instantiate the spreadsheet creation engine.
                ExcelEngine excelEngine = new ExcelEngine();
                //Step 2 : Instantiate the excel application object.
                IApplication application = excelEngine.Excel;

                FileStream inputStream = new FileStream(basePath + @"/XlsIO/ExportSales.xlsx", FileMode.Open, FileAccess.Read);

                // Opening the Existing Worksheet from a Workbook.
                IWorkbook workbook = application.Workbooks.Open(inputStream);
                try
                {
                    string ContentType = null;
                    string fileName = null;
                    workbook.Version = ExcelVersion.Excel2013;
                    ContentType = "Application/msexcel";
                    fileName = "ExportSales.xlsx";
                    MemoryStream ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    ms.Position = 0;

                    return File(ms, ContentType, fileName);
                }
                catch (Exception)
                {
                }

            }
            else if (button == "Import From Excel")
            {
                //Step 1 : Instantiate the spreadsheet creation engine.
                ExcelEngine excelEngine = new ExcelEngine();
                //Step 2 : Instantiate the excel application object.
                IApplication application = excelEngine.Excel;
                FileStream inputStream = new FileStream(basePath + @"/XlsIO/ExportSales.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = application.Workbooks.Open(inputStream);
                IWorksheet sheet = workbook.Worksheets[0];
                //Export Bussiness Objects
                List<Sales> businessObjects = sheet.ExportData<Sales>(1, 1, 41, 4);
                //Close the workbook.
                workbook.Close();
                excelEngine.Dispose();
                int temp = 1;
                foreach (Sales sale in businessObjects)
                {
                    sale.ID = temp;
                    temp++;
                }
                //Set the grid value to the Session
                _sales = businessObjects;
                //ViewBag.DataSource = _sales;
                ViewBag.exportButtonState = "";
                return View();
            }
            else
            {
                //New instance of XlsIO is created.[Equivalent to launching Microsoft Excel with no workbooks open].
                //The instantiation process consists of two steps.

                //Instantiate the spreadsheet creation engine.
                ExcelEngine excelEngine = new ExcelEngine();
                IApplication application = excelEngine.Excel;

                if (saveOption == "Xls")
                    application.DefaultVersion = ExcelVersion.Excel97to2003;
                else
                    application.DefaultVersion = ExcelVersion.Excel2016;

                //Open an existing spreadsheet which will be used as a template for generating the new spreadsheet.
                //After opening, the workbook object represents the complete in-memory object model of the template spreadsheet.
                IWorkbook workbook;
                workbook = excelEngine.Excel.Workbooks.Create(1);
                //The first worksheet object in the worksheets collection is accessed.
                IWorksheet sheet = workbook.Worksheets[0];
                
                //Import Bussiness Object to worksheet
                sheet.ImportData(_sales, 5, 1, false);
                sheet.Range["E4"].Text = "";
                #region Define Styles
                IStyle pageHeader = workbook.Styles.Add("PageHeaderStyle");
                IStyle tableHeader = workbook.Styles.Add("TableHeaderStyle");

                pageHeader.Font.RGBColor = Color.FromArgb(0, 83, 141, 213);
                pageHeader.Font.FontName = "Calibri";
                pageHeader.Font.Size = 18;
                pageHeader.Font.Bold = true;
                pageHeader.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                pageHeader.VerticalAlignment = ExcelVAlign.VAlignCenter;

                tableHeader.Font.Color = ExcelKnownColors.White;
                tableHeader.Font.Bold = true;
                tableHeader.Font.Size = 11;
                tableHeader.Font.FontName = "Calibri";
                tableHeader.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                tableHeader.VerticalAlignment = ExcelVAlign.VAlignCenter;
                tableHeader.Color = Color.FromArgb(0, 118, 147, 60);
                tableHeader.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
                tableHeader.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
                tableHeader.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Thin;
                tableHeader.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
                #endregion

                #region Apply Styles
                // Apply style for header
                sheet["A1:E1"].Merge();
                sheet["A1"].Text = "Yearly Sales Report";
                sheet["A1"].CellStyle = pageHeader;
                sheet["A2:E2"].Merge();
                sheet["A2"].Text = "Namewise Sales Comparison Report";
                sheet["A2"].CellStyle = pageHeader;
                sheet["A2"].CellStyle.Font.Bold = false;
                sheet["A2"].CellStyle.Font.Size = 16;
                sheet["A3:A4"].Merge();
                sheet["B3:B4"].Merge();
                sheet["E3:E4"].Merge();
                sheet["C3:D3"].Merge();
                sheet["C3"].Text = "Sales";
                sheet["A3:E4"].CellStyle = tableHeader;
                sheet["A3"].Text = "S.ID";
                sheet["B3"].Text = "Sales Person";
                sheet["C4"].Text = "January - June";
                sheet["D4"].Text = "July - December";
                sheet["E3"].Text = "Change(%)";
                sheet.UsedRange.AutofitColumns();
                sheet.Columns[0].ColumnWidth = 10;
                sheet.Columns[1].ColumnWidth = 24;
                sheet.Columns[2].ColumnWidth = 21;
                sheet.Columns[3].ColumnWidth = 21;
                sheet.Columns[4].ColumnWidth = 16;
                #endregion


                try
                {
                    string ContentType = null;
                    string fileName = null;
                    if (saveOption == "Xls")
                    {
                        workbook.Version = ExcelVersion.Excel97to2003;
                        ContentType = "Application/vnd.ms-excel";
                        fileName = "ExportSales.xls";
                    }
                    else
                    {
                        workbook.Version = ExcelVersion.Excel2013;
                        ContentType = "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        fileName = "ExportSales.xlsx";
                    }

                    MemoryStream ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    ms.Position = 0;

                    return File(ms, ContentType, fileName);
                }
                catch (Exception)
                {
                }

                //Close the workbook.
                workbook.Close();
                excelEngine.Dispose();
            }
            return View();
        }
        public ActionResult Update([FromBody]CRUDModel<Sales> myObject)
        {
            List<Sales> salesList = _sales;
            foreach (Sales sale in salesList)
            {
                if (sale.ID == myObject.value.ID)
                {
                    sale.SalesJanJune = myObject.value.SalesJanJune;
                    sale.SalesJulyDec = myObject.value.SalesJulyDec;
                    sale.SalesPerson = myObject.value.SalesPerson;
                    sale.Change = myObject.value.Change;
                }
            }
            _sales = salesList;
            return Json(myObject.value);
        }
    }

    #region Helper Class
    public class Data
    {

        public bool requiresCounts { get; set; }
        public int skip { get; set; }
        public int take { get; set; }
    }
    public class CRUDModel<T> where T : class
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
    //[Serializable]
    public class Sales
    {
        #region Members
        private int m_Id;
        private string m_salesPerson;
        private int m_salesJanJune;
        private int m_salesJulyDec;
        private int m_change;
        #endregion

        #region Prperties
        public int ID
        {
            get
            {
                return m_Id;
            }
            set
            {
                m_Id = value;
            }
        }
        public string SalesPerson
        {
            get
            {
                return m_salesPerson;
            }
            set
            {
                m_salesPerson = value;
            }
        }

        public int SalesJanJune
        {
            get
            {
                return m_salesJanJune;
            }
            set
            {
                m_salesJanJune = value;
            }
        }
        public int SalesJulyDec
        {
            get
            {
                return m_salesJulyDec;
            }
            set
            {
                m_salesJulyDec = value;
            }

        }
        public int Change
        {
            get
            {
                return m_change;
            }
            set
            {
                m_change = value;
            }

        }
        #endregion
    }
    #endregion
}