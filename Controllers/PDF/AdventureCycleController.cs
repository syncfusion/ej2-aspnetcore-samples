#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System.Data;
using System.IO;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Syncfusion.Drawing;

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        #region Private Members

        #endregion
        //
        // GET: /AdventureCycle/

        public ActionResult AdventureCycle()
        {
            List<string> styleList = new List<string>();

            foreach (var style in Enum.GetValues(typeof(PdfGridBuiltinStyle)))
            {
                styleList.Add(style.ToString());
            }
            ViewData.Add("styleName", new SelectList(styleList));

            return View();
        }

        [HttpPost]
        public ActionResult AdventureCycle(string styleName, string Header, string Bandedrow, string Bandedcolumn, string Firstcolumn, string Lastcolumn, string Lastrow, string InsideBrowser)
        {
            if (styleName == "" || styleName == null)
                styleName = "GridTable4";
            //Create PDF document
            PdfDocument doc = new PdfDocument();

            //Set font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 7);

            //Create Pdf ben for drawing broder
            PdfPen borderPen = new PdfPen(PdfBrushes.DarkBlue);
            borderPen.Width = 0;

            //Create DataTable for source
            PdfPage page = doc.Pages.Add();


            //Use DataTable as source
            PdfGrid grid = new PdfGrid();

            //Create dataset with the "Customers" table from Norwind database
            IEnumerable<Orders> orders = Provider.GetOrdersData(_hostingEnvironment.WebRootPath);

            grid.Style.AllowHorizontalOverflow = true;

            //Set Data source
            grid.DataSource = orders;

            #region PdfGridBuiltinStyleSettings
            PdfGridBuiltinStyleSettings setting = new PdfGridBuiltinStyleSettings();
            setting.ApplyStyleForHeaderRow = Header != null ? true : false;
            setting.ApplyStyleForBandedRows = Bandedrow != null ? true : false;
            setting.ApplyStyleForBandedColumns = Bandedcolumn != null ? true : false;
            setting.ApplyStyleForFirstColumn = Firstcolumn != null ? true : false;
            setting.ApplyStyleForLastColumn = Lastcolumn != null ? true : false;
            setting.ApplyStyleForLastRow = Lastrow != null ? true : false;
            #endregion 

            //Set layout properties
            PdfLayoutFormat format = new PdfLayoutFormat();
            format.Break = PdfLayoutBreakType.FitElement;
            format.Layout = PdfLayoutType.Paginate;

            PdfGridBuiltinStyle style = ConvertToPdfGridBuiltStyle(styleName);

            grid.ApplyBuiltinStyle(style, setting);
            grid.Style.Font = font;
            grid.Style.CellPadding.All = 2;
            grid.Style.AllowHorizontalOverflow = false;
            //Draw table
            grid.Draw(page, PointF.Empty, format);

            MemoryStream stream = new MemoryStream();

            //Save the PDF document 
            doc.Save(stream);

            //Close the PDF document
            doc.Close(true);

            stream.Position = 0;

            //Download the PDF document in the browser.
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
            fileStreamResult.FileDownloadName = "AdventureCycle.pdf";
            return fileStreamResult;
        }
        # region Helpher Methods


        private PdfGridBuiltinStyle ConvertToPdfGridBuiltStyle(string styleName)
        {
            PdfGridBuiltinStyle value = (PdfGridBuiltinStyle)Enum.Parse(typeof(PdfGridBuiltinStyle), styleName);
            return value;
        }

        internal sealed class Provider
        {
            public static IEnumerable<Orders> GetOrdersData(string webRootPath)
            {
                string dataPath = webRootPath + @"/PDF/";
                //Read the file
                FileStream xmlStream = new FileStream(dataPath + "Orders.xml", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                using (StreamReader reader = new StreamReader(xmlStream, true))
                {
                    string data = reader.ReadToEnd();
                    data = data.Replace(" xmlns=\"http://www.tempuri.org/DataSet1.xsd\"", "");
                    return XElement.Parse(data)
                        .Elements("Orders")
                        .Select(c => new Orders
                        {
                            OrderID = c.Element("OrderID") != null ? c.Element("OrderID").Value : "",
                            CustomerID = c.Element("CustomerID") != null ? c.Element("CustomerID").Value : "",
                            ShipName = c.Element("ShipName") != null ? c.Element("ShipName").Value : "",
                            ShipAddress = c.Element("ShipAddress") != null ? c.Element("ShipAddress").Value : "",
                            ShipCity = c.Element("ShipCity") != null ? c.Element("ShipCity").Value : "",
                            ShipPostalCode = c.Element("ShipPostalCode") != null ? c.Element("ShipPostalCode").Value : "",
                            ShipCountry = c.Element("ShipCountry") != null ? c.Element("ShipCountry").Value : "",
                        });
                }
            }
        }
        #endregion
    }
    public class Orders
    {
        public string OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
    }
}
