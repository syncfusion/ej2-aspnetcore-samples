#region Copyright
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.OfficeChart;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Xml;
using System;
using Syncfusion.DocIORenderer;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.Word
{

    public partial class WordController : Controller
    {
        #region Pie Chart
        public ActionResult PieChart(string Group1)
        {
            if (Group1 == null)
                return View();
            string basePath = _hostingEnvironment.WebRootPath;
            string datapath = basePath + @"/Word/PieChart.docx";
            //A new document is created.
            FileStream fileStream = new FileStream(datapath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            WordDocument document = new WordDocument(fileStream,FormatType.Docx);
            //Create MailMergeDataTable
            MailMergeDataTable mailMergeDataTable = GetMailMergeDataTableProductDetails();
            //Merge the product table in the Word document
            document.MailMerge.ExecuteGroup(mailMergeDataTable);
            //Find the Placeholder of Pie chart to insert
            TextSelection selection = document.Find("<Pie Chart>", false, false);
            WParagraph paragraph = selection.GetAsOneRange().OwnerParagraph;
            paragraph.ChildEntities.Clear();
            //Create and Append chart to the paragraph
            WChart pieChart = paragraph.AppendChart(446, 270);
            //Set chart data
            pieChart.ChartType = OfficeChartType.Pie;
            pieChart.ChartTitle = "Best Selling Products";
            pieChart.ChartTitleArea.FontName = "Calibri (Body)";
            pieChart.ChartTitleArea.Size = 14;
            GetChartData(pieChart, 0);
            //Create a new chart series with the name “Sales”
            IOfficeChartSerie pieSeries = pieChart.Series.Add("Sales");
            pieSeries.Values = pieChart.ChartData[2, 2, 11, 2];
            //Setting data label
            pieSeries.DataPoints.DefaultDataPoint.DataLabels.IsPercentage = true;
            pieSeries.DataPoints.DefaultDataPoint.DataLabels.Position = OfficeDataLabelPosition.Outside;
            //Setting background color
            pieChart.ChartArea.Fill.ForeColor = Syncfusion.Drawing.Color.FromArgb(242, 242, 242);
            pieChart.PlotArea.Fill.ForeColor = Syncfusion.Drawing.Color.FromArgb(242, 242, 242);
            pieChart.ChartArea.Border.LinePattern = OfficeChartLinePattern.None;
            pieChart.PrimaryCategoryAxis.CategoryLabels = pieChart.ChartData[2, 1, 11, 1];

            string filename = "";
            string contenttype = "";
            MemoryStream ms = new MemoryStream();
            #region Document SaveOption
            if (Group1 == "WordDocx")
            {
                filename = "PieChart.docx";
                contenttype = "application/msword";
                document.Save(ms, FormatType.Docx);
            }
            else if (Group1 == "WordML")
            {
                filename = "PieChart.xml";
                contenttype = "application/msword";
                document.Save(ms, FormatType.WordML);
            }
            else
            {
                filename = "PieChart.pdf";
                contenttype = "application/pdf";
                DocIORenderer renderer = new DocIORenderer();
                renderer.ConvertToPDF(document).Save(ms);
            }
            #endregion Document SaveOption
            document.Close();
            ms.Position = 0;
            return File(ms, contenttype, filename);
        }
        #endregion
        /// <summary>
        /// Gets the mail merge data table.
        /// </summary>        
        private MailMergeDataTable GetMailMergeDataTableProductDetails()
        {
            List<Product> product = new List<Product>();
            FileStream fs = new FileStream(_hostingEnvironment.WebRootPath + @"/Word/Products.xml", FileMode.Open, FileAccess.Read);
            XmlReader reader = XmlReader.Create(fs);
            if (reader == null)
                throw new Exception("reader");
            while (reader.NodeType != XmlNodeType.Element)
                reader.Read();
            if (reader.LocalName != "Products")
                throw new XmlException("Unexpected xml tag " + reader.LocalName);
            reader.Read();
            while (reader.NodeType == XmlNodeType.Whitespace)
                reader.Read();
            while (reader.LocalName != "Products")
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.LocalName)
                    {
                        case "Product":
                            product.Add(GetProduct(reader));
                            break;
                    }
                }
                else
                {
                    reader.Read();
                    if ((reader.LocalName == "Products") && reader.NodeType == XmlNodeType.EndElement)
                        break;
                }
            }
            MailMergeDataTable dataTable = new MailMergeDataTable("Product", product);
            reader.Dispose();
            fs.Dispose();
            return dataTable;
        }
        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <param name="reader">The reader.</param>       
        private Product GetProduct(XmlReader reader)
        {
            if (reader == null)
                throw new Exception("reader");
            while (reader.NodeType != XmlNodeType.Element)
                reader.Read();
            if (reader.LocalName != "Product")
                throw new XmlException("Unexpected xml tag " + reader.LocalName);
            reader.Read();
            while (reader.NodeType == XmlNodeType.Whitespace)
                reader.Read();
            Product product = new Product();
            while (reader.LocalName != "Product")
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.LocalName)
                    {
                        case "SNO":
                            product.SNO = reader.ReadElementContentAsString();
                            break;
                        case "ProductName":
                            product.ProductName = reader.ReadElementContentAsString();
                            break;
                        case "Sum":
                            product.Sum = reader.ReadElementContentAsString();
                            break;
                        
                        default:
                            reader.Skip();
                            break;
                    }
                }
                else
                {
                    reader.Read();
                    if ((reader.LocalName == "Product") && reader.NodeType == XmlNodeType.EndElement)
                        break;
                }
            }
            return product;
        }

        /// <summary>
        /// Gets the mail merge data table.
        /// </summary>        
        private void GetChartData(WChart pieChart, int i)
        {
            FileStream fs = new FileStream(_hostingEnvironment.WebRootPath + @"/Word/Products.xml", FileMode.Open, FileAccess.Read);
            XmlReader reader = XmlReader.Create(fs);
            if (reader == null)
                throw new Exception("reader");
            while (reader.NodeType != XmlNodeType.Element)
                reader.Read();
            if (reader.LocalName != "Products")
                throw new XmlException("Unexpected xml tag " + reader.LocalName);
            reader.Read();
            while (reader.NodeType == XmlNodeType.Whitespace)
                reader.Read();
            while (reader.LocalName != "Products")
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.LocalName)
                    {
                        case "Product":
                            GetProductData(reader,pieChart,ref i);
                            break;
                    }
                }
                else
                {
                    reader.Read();
                    if ((reader.LocalName == "Products") && reader.NodeType == XmlNodeType.EndElement)
                        break;
                }
            }
        }
        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <param name="reader">The reader.</param>       
        private void GetProductData(XmlReader reader,WChart pieChart,ref int i)
        {
            if (reader == null)
                throw new Exception("reader");
            while (reader.NodeType != XmlNodeType.Element)
                reader.Read();
            if (reader.LocalName != "Product")
                throw new XmlException("Unexpected xml tag " + reader.LocalName);
            reader.Read();
            while (reader.NodeType == XmlNodeType.Whitespace)
                reader.Read();
            while (reader.LocalName != "Product")
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.LocalName)
                    {
                        case "ProductName":
                            pieChart.ChartData.SetValue(i + 2, 1, reader.ReadElementContentAsString());
                            break;
                        case "Sum":
                            pieChart.ChartData.SetValue(i + 2, 2, Convert.ToDouble(reader.ReadElementContentAsString()));
                            break;
                        default:
                            reader.Skip();
                            break;
                    }
                }
                else
                {
                    reader.Read();
                    if ((reader.LocalName == "Product") && reader.NodeType == XmlNodeType.EndElement)
                    {
                        i++;
                        break;
                    }
                }
            }
        }
    }

	
    public class Product
    {
        #region Fields
        private string m_sNo;
        private string m_productName;
        private string m_sum;
       
        #endregion
        #region Properties
        public string SNO
        {
            get { return m_sNo; }
            set { m_sNo = value; }
        }
        public string ProductName
        {
            get { return m_productName; }
            set { m_productName = value; }
        }
        public string Sum
        {
            get { return m_sum; }
            set { m_sum = value; }
        }
		
        #endregion
        #region Constructor
        public Product(string sNO, string productName, string sum)
        {
            m_sNo = sNO;
            m_productName = productName;
            m_sum = sum;          
        }
        public Product()
        { }
        #endregion
    }

}


