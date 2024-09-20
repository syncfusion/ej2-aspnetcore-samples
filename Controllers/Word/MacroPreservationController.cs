#region Copyright
// Copyright Syncfusion Inc. 2001 - 2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Data;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Xml;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.Word
{
    public partial class WordController : Controller
    {
        #region MacroPreservation       
        public ActionResult MacroPreservation(string Button)
        {
            string basePath = _hostingEnvironment.WebRootPath;          
            string dataPath = basePath + @"/Word/MacroTemplate.dotm";
            string contenttype1 = "application/msword";
            FileStream fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);           
            if (Button == null)
                return View();
            if (Button == "View Template")
            {
                return File(fileStream, contenttype1, "MacroTemplate.dotm");
            }
            try
            {
                string dataPathMacro = basePath + @"/Word/MacroTemplate.dotm";
                fileStream = new FileStream(dataPathMacro, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                // Load the template.
                WordDocument document = new WordDocument(fileStream,FormatType.Dotm);
                fileStream.Dispose();
                fileStream = null;                
                //Create MailMergeDataTable
                MailMergeDataTable mailMergeDataTableProductListData = GetMailMergeDataTableProductListData();
                // Execute Mail Merge with groups.
                document.MailMerge.ExecuteGroup(mailMergeDataTableProductListData);
            
                #region Document SaveOption
                //Save as .docm format
                FormatType type = FormatType.Word2013Docm;
                string filename = "MacroPreservation.docm";
                string contenttype = "application/msword";
                #endregion Document SaveOption
                MemoryStream ms = new MemoryStream();
                document.Save(ms, type);
                document.Close();
                ms.Position = 0;
                return File(ms, contenttype, filename);
            }
            catch (Exception)
            { }
            return View();
        }
      
        #endregion MacroPreservation
       
	    /// <summary>
        /// Gets the mail merge data table.
        /// </summary>     
        private MailMergeDataTable GetMailMergeDataTableProductListData()
        {
            List<Products> product = new List<Products>();
            FileStream fs = new FileStream(_hostingEnvironment.WebRootPath + @"/Word/ProductList.xml", FileMode.Open, FileAccess.Read);
            XmlReader reader = XmlReader.Create(fs);
            if (reader == null)
                throw new Exception("reader");
            while (reader.NodeType != XmlNodeType.Element)
                reader.Read();
            if (reader.LocalName != "ProductList")
                throw new XmlException("Unexpected xml tag " + reader.LocalName);
            reader.Read();
            while (reader.NodeType == XmlNodeType.Whitespace)
                reader.Read();
            while (reader.LocalName != "ProductList")
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.LocalName)
                    {
                        case "Products":
                            product.Add(GetProductsDetails(reader));
                            break;
                    }
                }
                else
                {
                    reader.Read();
                    if ((reader.LocalName == "ProductList") && reader.NodeType == XmlNodeType.EndElement)
                        break;
                }
            }
            MailMergeDataTable dataTable = new MailMergeDataTable("Products", product);
            reader.Dispose();
            fs.Dispose();
            return dataTable;
        }
        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <param name="reader">The reader.</param>       
        private Products GetProductsDetails(XmlReader reader)
        {
            if (reader == null)
                throw new Exception("reader");
            while (reader.NodeType != XmlNodeType.Element)
                reader.Read();
            if (reader.LocalName != "Products")
                throw new XmlException("Unexpected xml tag " + reader.LocalName);
            reader.Read();
            while (reader.NodeType == XmlNodeType.Whitespace)
                reader.Read();
            Products product = new Products();
            while (reader.LocalName != "Products")
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.LocalName)
                    {
                        case "ProductName":
                            product.ProductName = reader.ReadElementContentAsString();
                            break;
                        case "Binary":
                            product.Binary = reader.ReadElementContentAsString();
                            break;
                        case "Source":
                            product.Source = reader.ReadElementContentAsString();
                            break;

                        default:
                            reader.Skip();
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
            return product;
        }
    }


    public class Products
    {
        #region Fields
        private string m_productName;
        private string m_binary;
        private string m_source;

        #endregion
        #region Properties
        public string ProductName
        {
            get { return m_productName; }
            set { m_productName = value; }
        }
        public string Binary
        {
            get { return m_binary; }
            set { m_binary = value; }
        }
        public string Source
        {
            get { return m_source; }
            set { m_source = value; }
        }

        #endregion
        #region Constructor
        public Products(string productName, string binary, string source)
        {
            m_productName = productName;
            m_binary = binary;
            m_source = source;

        }
        public Products()
        { }
        #endregion
    }
}

