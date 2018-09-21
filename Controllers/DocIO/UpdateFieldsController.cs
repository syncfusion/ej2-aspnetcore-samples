#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.Data;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.Pdf;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.DocIO
{
    public partial class DocIOController : Controller
    {
        #region Update Fields
        public ActionResult UpdateFields(string Group1, string Button)
        {
            string basePath = _hostingEnvironment.WebRootPath;         
            string dataPath = basePath + @"/DocIO/TemplateUpdateFields.docx";
            FileStream fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            if (Group1 == null)
                return View();
            string contenttype1 = "application/vnd.ms-word.document.12";
            if (Button == "View Template")
            {
                return File(fileStream, contenttype1, "TemplateUpdateFields.docx");
            }
            //Loads the template document.
            string dataPathField = basePath + @"/DocIO/TemplateUpdateFields.docx";
            FileStream fileStreamField = new FileStream(dataPathField, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            WordDocument document = new WordDocument(fileStreamField,FormatType.Docx);
            fileStreamField.Dispose();
            fileStreamField = null;
            
            //Create MailMergeDataTable
            MailMergeDataTable mailMergeDataTableStock = GetMailMergeDataTableStock();
            // Execute Mail Merge with groups.
            document.MailMerge.ExecuteGroup(mailMergeDataTableStock);
            //Update fields in the document.
            document.UpdateDocumentFields();

            FormatType type = FormatType.Docx;
            string filename = "Sample.docx";
            string contenttype = "application/vnd.ms-word.document.12";
            #region Document SaveOption
            //Save as .doc format
            if (Group1 == "WordDoc")
            {
                type = FormatType.Doc;
                filename = "Sample.doc";
                contenttype = "application/msword";
            }
            //Save as .xml format
            else if (Group1 == "WordML")
            {
                type = FormatType.WordML;
                filename = "Sample.xml";
                contenttype = "application/msword";
            }
            #endregion Document SaveOption
            MemoryStream ms = new MemoryStream();
            document.Save(ms, type);
            document.Close();
            ms.Position = 0;
            return File(ms, contenttype, filename);
        }
        #endregion Update Fields

        /// <summary>
        /// Gets the mail merge data table.
        /// </summary>       
        private MailMergeDataTable GetMailMergeDataTableStock()
        {
            List<StockDetails> stockDetails = new List<StockDetails>();
            FileStream fs = new FileStream(_hostingEnvironment.WebRootPath + @"/DocIO/StockDetails.xml", FileMode.Open, FileAccess.Read);
            XmlReader reader = XmlReader.Create(fs);
            if (reader == null)
                throw new Exception("reader");
            while (reader.NodeType != XmlNodeType.Element)
                reader.Read();
            if (reader.LocalName != "StockMarket")
               throw new XmlException("Unexpected xml tag " + reader.LocalName);
            reader.Read();
            while (reader.NodeType == XmlNodeType.Whitespace)
                reader.Read();
            while (reader.LocalName != "StockMarket")
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.LocalName)
                    {
                        case "StockDetails":
                            stockDetails.Add(GetStockDetails(reader));
                            break;
                    }
                }
                else
                {
                    reader.Read();
                    if ((reader.LocalName == "StockMarket") && reader.NodeType == XmlNodeType.EndElement)
                        break;
                }
            }
            MailMergeDataTable dataTable = new MailMergeDataTable("StockDetails", stockDetails);          
            reader.Dispose();
            fs.Dispose();
            return dataTable;
        }
		
        /// <summary>
        /// Gets the StockDetails.
        /// </summary>
        /// <param name="reader">The reader.</param>
        
        private StockDetails GetStockDetails(XmlReader reader)
        {
            if (reader == null)
                throw new Exception("reader");
            while (reader.NodeType != XmlNodeType.Element)
                reader.Read();
            if (reader.LocalName != "StockDetails")
                throw new XmlException("Unexpected xml tag " + reader.LocalName);
            reader.Read();
            while (reader.NodeType == XmlNodeType.Whitespace)
                reader.Read();
            StockDetails stockDetails = new StockDetails();
            while (reader.LocalName != "StockDetails")
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.LocalName)
                    {
                        case "TradeNo":
                            stockDetails.TradeNo = reader.ReadElementContentAsString();
                            break;
                        case "CompanyName":
                            stockDetails.CompanyName = reader.ReadElementContentAsString();
                            break;
                        case "CostPrice":
                            stockDetails.CostPrice = reader.ReadElementContentAsString();
                            break;
                        case "SharesCount":
                            stockDetails.SharesCount = reader.ReadElementContentAsString();
                            break;
                        case "SalesPrice":
                            stockDetails.SalesPrice = reader.ReadElementContentAsString();
                            break;
                       
                        default:
                            reader.Skip();
                            break;
                    }
                }
                else
                {
                    reader.Read();
                    if ((reader.LocalName == "StockDetails") && reader.NodeType == XmlNodeType.EndElement)
                        break;
                }
            }
            return stockDetails;
        }
    }


    public class StockDetails
    {
        #region Fields
        private string m_tradeNo;
        private string m_companyName;
        private string m_costPrice;
        private string m_sharesCount;
        private string m_salesPrice;        
        #endregion
        #region Properties
        public string TradeNo
        {
            get { return m_tradeNo; }
            set { m_tradeNo = value; }
        }
        public string CompanyName
        {
            get { return m_companyName; }
            set { m_companyName = value; }
        }
        public string CostPrice
        {
            get { return m_costPrice; }
            set { m_costPrice = value; }
        }
        public string SharesCount
        {
            get { return m_sharesCount; }
            set { m_sharesCount = value; }
        }
        public string SalesPrice
        {
            get { return m_salesPrice; }
            set { m_salesPrice = value; }
        }
       
        #endregion
        #region Constructor
        public StockDetails(string tradeNo, string companyName, string costPrice, string sharesCount, string salesPrice)
        {
            m_tradeNo = tradeNo;
            m_companyName = companyName;
            m_costPrice = costPrice;
            m_sharesCount = sharesCount;
            m_salesPrice = salesPrice;
    }
        public StockDetails()
        { }
        #endregion
    }
}
