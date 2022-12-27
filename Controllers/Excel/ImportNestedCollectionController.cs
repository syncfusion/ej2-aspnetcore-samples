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
using System.Xml.Serialization;

namespace EJ2CoreSampleBrowser.Controllers.Excel
{

    public partial class ExcelController : Controller
    {
        #region Getting Started
        #endregion

        public ActionResult ImportNestedCollection(string LayoutOptions, string button, string checkbox, string rdb1, string textBox)
        {
           
            if (button == null)
                return View();

            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2016;

            //Open an existing spreadsheet which will be used as a template for generating the new spreadsheet.
            //After opening, the workbook object represents the complete in-memory object model of the template spreadsheet.
            IWorkbook workbook = excelEngine.Excel.Workbooks.Create(1);
            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet worksheet = workbook.Worksheets[0];

            IList<Brands> list = GetVehicleDetails();

            ExcelImportDataOptions importDataOptions = new ExcelImportDataOptions();
            importDataOptions.FirstRow = 4;

            if (LayoutOptions == "Default")
                importDataOptions.NestedDataLayoutOptions = ExcelNestedDataLayoutOptions.Default;
            else if (LayoutOptions == "Merge")
                importDataOptions.NestedDataLayoutOptions = ExcelNestedDataLayoutOptions.Merge;
            else if (LayoutOptions == "Repeat")
                importDataOptions.NestedDataLayoutOptions = ExcelNestedDataLayoutOptions.Repeat;

            if (checkbox == "Group")
            {
                if (rdb1 == "Expand")
                {
                    importDataOptions.NestedDataGroupOptions = ExcelNestedDataGroupOptions.Expand;
                }
                else if (rdb1 == "Collapse")
                {
                    importDataOptions.NestedDataGroupOptions = ExcelNestedDataGroupOptions.Collapse;
                    if (textBox != string.Empty)
                    {
                        importDataOptions.CollapseLevel = int.Parse(textBox);
                    }
                }
            }

            worksheet.ImportData(list, importDataOptions);

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
            worksheet["A1:C2"].Merge();
            worksheet["A1"].Text = "Automobile Brands in the US";
            worksheet["A1"].CellStyle = pageHeader;

            worksheet["A4:C4"].CellStyle = tableHeader;

            worksheet["A1:C1"].CellStyle.Font.Bold = true;
            worksheet.UsedRange.AutofitColumns();

            #endregion

            try
            {
                MemoryStream ms = new MemoryStream();
                workbook.SaveAs(ms);
                ms.Position = 0;
                return File(ms, "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ImportData.xlsx");
            }
            catch (Exception)
            {
            }

            workbook.Close();
            excelEngine.Dispose();

            return View();
        }

        #region Helper Methods
        private IList<Brands> GetVehicleDetails()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(BrandObjects));
            string basePath = _hostingEnvironment.WebRootPath;
            FileStream inputStream = new FileStream(basePath + @"/XlsIO/ExportData.xml", FileMode.Open, FileAccess.Read);
            TextReader textReader = new StreamReader(inputStream);
            BrandObjects brands = (BrandObjects)deserializer.Deserialize(textReader);

            List<Brands> list = new List<Brands>();
            string brandName = brands.BrandObject[0].BrandName;
            string vehicleType = brands.BrandObject[0].VahicleType;
            string modelName = brands.BrandObject[0].ModelName;
            Brands brand = new Brands(brandName);
            brand.VehicleTypes = new List<VehicleTypes>();

            VehicleTypes vehicle = new VehicleTypes(vehicleType);
            vehicle.Models = new List<Model>();
            Model model = new Model(modelName);

            brand.VehicleTypes.Add(vehicle);
            list.Add(brand);

            foreach (BrandObject brandObj in brands.BrandObject)
            {
                if (brandName == brandObj.BrandName)
                {
                    if (vehicleType == brandObj.VahicleType)
                    {
                        vehicle.Models.Add(new Model(brandObj.ModelName));
                        continue;
                    }
                    else
                    {
                        vehicle = new VehicleTypes(brandObj.VahicleType);
                        vehicle.Models = new List<Model>();
                        vehicle.Models.Add(new Model(brandObj.ModelName));
                        brand.VehicleTypes.Add(vehicle);
                        vehicleType = brandObj.VahicleType;
                    }
                    continue;
                }
                else
                {
                    brand = new Brands(brandObj.BrandName);
                    vehicle = new VehicleTypes(brandObj.VahicleType);
                    vehicle.Models = new List<Model>();
                    vehicle.Models.Add(new Model(brandObj.ModelName));
                    brand.VehicleTypes = new List<VehicleTypes>();
                    brand.VehicleTypes.Add(vehicle);
                    vehicleType = brandObj.VahicleType;
                    list.Add(brand);
                    brandName = brandObj.BrandName;
                }
            }
            textReader.Close();
            return list;
        }
        #endregion
    }

    #region Helper Class
    [XmlRootAttribute("BrandObjects")]
    public class BrandObjects
    {
        [XmlElement("BrandObject")]
        public BrandObject[] BrandObject { get; set; }
    }
    public class BrandObject
    {
        public string BrandName { get; set; }
        public string VahicleType { get; set; }
        public string ModelName { get; set; }
    }
    //[Serializable]
    public class Brands
    {
        private string m_brandName;
        [DisplayNameAttribute("Brand")]
        public string BrandName
        {
            get { return m_brandName; }
            set { m_brandName = value; }
        }

        private IList<VehicleTypes> m_vehicles;
        public IList<VehicleTypes> VehicleTypes
        {
            get { return m_vehicles; }
            set { m_vehicles = value; }
        }

        public Brands(string brandName)
        {
            m_brandName = brandName;
        }
    }

    public class VehicleTypes
    {
        private string m_vehicle;
        [DisplayNameAttribute("Vehicle Type")]
        public string Vehicle
        {
            get { return m_vehicle; }
            set { m_vehicle = value; }
        }

        private IList<Model> m_models;
        public IList<Model> Models
        {
            get { return m_models; }
            set { m_models = value; }
        }

        public VehicleTypes(string vehicle)
        {
            m_vehicle = vehicle;
        }
    }
    #endregion
}
