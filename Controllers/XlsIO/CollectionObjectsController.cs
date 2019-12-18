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
using System.ComponentModel;

namespace EJ2CoreSampleBrowser.Controllers.XlsIO
{
 
    public partial class XlsIOController : Controller
    {
        public static List<Brand> _sales = new List<Brand>();
        public static List<Brand> businessObjects = null;

        public IActionResult UrlDatasource([FromBody]Data dm)
        {
            var order = _sales;
            var Data = order.ToList();
            int count = order.Count();
            return dm.requiresCounts ? Json(new { result = Data.Skip(dm.skip).Take(dm.take), count = count }) : Json(Data);
        }
        //For Session 
        //public HttpSessionStateBase Session { get; }
        public ActionResult CollectionObjects(string saveOption, string button)
        {            
            string basePath = _hostingEnvironment.WebRootPath;

            ViewBag.exportButtonState = "disabled=\"disabled\"";

            ///SaveOption Null
            if (saveOption == null || button == null)
            {
                _sales = new List<Brand>();
                return View();
            }

            //Start Business Object Functions
            if (button == "Input Template")
            {
                //Step 1 : Instantiate the spreadsheet creation engine.
                ExcelEngine excelEngine = new ExcelEngine();
                //Step 2 : Instantiate the excel application object.
                IApplication application = excelEngine.Excel;

                FileStream inputStream = new FileStream(basePath + @"/XlsIO/ExportData.xlsx", FileMode.Open, FileAccess.Read);

                // Opening the Existing Worksheet from a Workbook.
                IWorkbook workbook = application.Workbooks.Open(inputStream);
                try
                {
                    string ContentType = null;
                    string fileName = null;
                    workbook.Version = ExcelVersion.Excel2013;
                    ContentType = "Application/msexcel";
                    fileName = "ExportData.xlsx";
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
                FileStream inputStream = new FileStream(basePath + @"/XlsIO/ExportData.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = application.Workbooks.Open(inputStream);
                IWorksheet sheet = workbook.Worksheets[0];
                //Export Bussiness Objects
                Dictionary<string, string> mappingProperties = new Dictionary<string, string>();
                mappingProperties.Add("Brand", "BrandName");
                mappingProperties.Add("Vehicle Type", "VehicleType.VehicleName");
                mappingProperties.Add("Model", "VehicleType.Model.ModelName");

                List<Brand> businessObjects = sheet.ExportData<Brand>(4, 1, 141, 3, mappingProperties);
                //Close the workbook.
                workbook.Close();
                excelEngine.Dispose();
                int temp = 1;
                foreach (Brand brand in businessObjects)
                {
                    brand.ID = temp;
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
                sheet.ImportData(_sales, 4, 1, true);

                #region Define Styles
                IStyle pageHeader = workbook.Styles.Add("PageHeaderStyle");
                IStyle tableHeader = workbook.Styles.Add("TableHeaderStyle");

                pageHeader.Font.FontName = "Calibri";
                pageHeader.Font.Size = 16;
                pageHeader.Font.Bold = true;
                pageHeader.Color = Color.FromArgb(0, 146, 208, 80);
                pageHeader.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                pageHeader.VerticalAlignment = ExcelVAlign.VAlignCenter;

                tableHeader.Font.Bold = true;
                tableHeader.Font.FontName = "Calibri";
                tableHeader.Color = Color.FromArgb(0, 146, 208, 80);

                #endregion

                #region Apply Styles
                // Apply style for header
                sheet["A1:C2"].Merge();
                sheet["A1"].Text = "Automobile Brands in the US";
                sheet["A1"].CellStyle = pageHeader;

                sheet["A4:C4"].CellStyle = tableHeader;

                sheet["A1:C1"].CellStyle.Font.Bold = true;
                sheet.UsedRange.AutofitColumns();

                #endregion

                try
                {
                    string ContentType = null;
                    string fileName = null;
                    if (saveOption == "Xls")
                    {
                        workbook.Version = ExcelVersion.Excel97to2003;
                        ContentType = "Application/vnd.ms-excel";
                        fileName = "ExportData.xls";
                    }
                    else
                    {
                        workbook.Version = ExcelVersion.Excel2013;
                        ContentType = "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        fileName = "ExportData.xlsx";
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
        public ActionResult Update([FromBody]CRUDModel<Brand> myObject)
        {
            List<Brand> salesList = _sales;
            foreach (Brand brand in salesList)
            {
                if (brand.ID == myObject.value.ID)
                {
                    brand.BrandName = myObject.value.BrandName;
                    brand.VehicleType.VehicleName = myObject.value.VehicleType.VehicleName;
                    brand.VehicleType.Model.ModelName = myObject.value.VehicleType.Model.ModelName;
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
    public class Brand
    {
        private int m_Id;
        [Bindable(false)]
        public int ID
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        private string m_brandName;
        [DisplayNameAttribute("Brand")]
        public string BrandName
        {
            get { return m_brandName; }
            set { m_brandName = value; }
        }

        private VehicleType m_vehicleType;
        public VehicleType VehicleType
        {
            get { return m_vehicleType; }
            set { m_vehicleType = value; }
        }

        public Brand(string brandName)
        {
            m_brandName = brandName;
        }
        public Brand()
        {

        }
    }

    public class VehicleType
    {
        private string m_vehicleName;
        [DisplayNameAttribute("Vehicle Type")]
        public string VehicleName
        {
            get { return m_vehicleName; }
            set { m_vehicleName = value; }
        }

        private Model m_model;
        public Model Model
        {
            get { return m_model; }
            set { m_model = value; }
        }

        public VehicleType(string vehicle)
        {
            m_vehicleName = vehicle;
        }
        public VehicleType()
        {

        }
    }

    public class Model
    {
        private string m_modelName;
        [DisplayNameAttribute("Model")]
        public string ModelName
        {
            get { return m_modelName; }
            set { m_modelName = value; }
        }

        public Model(string name)
        {
            m_modelName = name;
        }
        public Model()
        {

        }
    }
    #endregion
}