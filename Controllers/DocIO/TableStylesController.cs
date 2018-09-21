#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.IO;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Xml;
using System;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.DocIO
{
    public partial class DocIOController : Controller
    {
        #region Table Styles
        public ActionResult TableStyles(string Group1)
        {
            if (Group1 == null)
                return View();
            string basePath = _hostingEnvironment.WebRootPath;
            string dataPath = string.Empty;
            dataPath = basePath + @"/DocIO/TemplateTableStyle.doc";           
            WordDocument document = new WordDocument();
            FileStream fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            document.Open(fileStream, FormatType.Doc);
            fileStream.Dispose();
            fileStream = null;

            //Create MailMergeDataTable
            MailMergeDataTable mailMergeDataTable = GetMailMergeDataTable();
            // Execute Mail Merge with groups.
            document.MailMerge.ExecuteGroup(mailMergeDataTable);

            #region Built-in table styles
            //Get table to apply style.
            WTable table = (WTable)document.LastSection.Tables[0];

            //Apply built-in table style to the table.
            table.ApplyStyle(BuiltinTableStyle.MediumShading1Accent5);
            #endregion

            FormatType type = FormatType.Docx;
            string filename = "Sample.docx";
            string contenttype = "application/vnd.ms-word.document.12";
            #region Document SaveOption            
            //Save as .xml format
            if (Group1 == "WordML")
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
        #endregion Table Styles
        /// <summary>
        /// Gets the mail merge data table.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception">reader</exception>
        /// <exception cref="XmlException">Unexpected xml tag  + reader.LocalName</exception>
        private MailMergeDataTable GetMailMergeDataTable()
        {
            List<Suppliers> suppliers = new List<Suppliers>();
            FileStream fs = new FileStream(_hostingEnvironment.WebRootPath + @"/DocIO/Suppliers.xml", FileMode.Open, FileAccess.Read);
            XmlReader reader = XmlReader.Create(fs);
            if (reader == null)
                throw new Exception("reader");
            while (reader.NodeType != XmlNodeType.Element)
                reader.Read();
            if (reader.LocalName != "SuppliersList")
                throw new XmlException("Unexpected xml tag " + reader.LocalName);
            reader.Read();
            while (reader.NodeType == XmlNodeType.Whitespace)
                reader.Read();
            while (reader.LocalName != "SuppliersList")
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.LocalName)
                    {
                        case "Suppliers":
                            suppliers.Add(GetSupplier(reader));
                            break;
                    }
                }
                else
                {
                    reader.Read();
                    if ((reader.LocalName == "SuppliersList") && reader.NodeType == XmlNodeType.EndElement)
                        break;
                }
            }
            MailMergeDataTable dataTable = new MailMergeDataTable("Suppliers", suppliers);
            reader.Dispose();
            fs.Dispose();
            return dataTable;
        }
        /// <summary>
        /// Gets the suppliers.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">reader</exception>
        /// <exception cref="XmlException">Unexpected xml tag  + reader.LocalName</exception>
        private Suppliers GetSupplier(XmlReader reader)
        {
            if (reader == null)
                throw new Exception("reader");
            while (reader.NodeType != XmlNodeType.Element)
                reader.Read();
            if (reader.LocalName != "Suppliers")
                throw new XmlException("Unexpected xml tag " + reader.LocalName);
            reader.Read();
            while (reader.NodeType == XmlNodeType.Whitespace)
                reader.Read();
            Suppliers supplier = new Suppliers();
            while (reader.LocalName != "Suppliers")
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.LocalName)
                    {
                        case "SupplierID":
                            supplier.SupplierID = reader.ReadElementContentAsString();
                            break;
                        case "CompanyName":
                            supplier.CompanyName = reader.ReadElementContentAsString();
                            break;
                        case "ContactName":
                            supplier.ContactName = reader.ReadElementContentAsString();
                            break;
                        case "ContactTitle":
                            supplier.ContactTitle = reader.ReadElementContentAsString();
                            break;
                        case "Region":
                            supplier.Region = reader.ReadElementContentAsString();
                            break;
                        case "PostalCode":
                            supplier.PostalCode = reader.ReadElementContentAsString();
                            break;
                        case "Phone":
                            supplier.Phone = reader.ReadElementContentAsString();
                            break;
                        case "Fax":
                            supplier.Fax = reader.ReadElementContentAsString();
                            break;
                        case "HomePage":
                            supplier.HomePage = reader.ReadElementContentAsString();
                            break;
                        case "Address":
                            supplier.Address = reader.ReadElementContentAsString();
                            break;
                        case "City":
                            supplier.City = reader.ReadElementContentAsString();
                            break;
                        case "Country":
                            supplier.Country = reader.ReadElementContentAsString();
                            break;
                        default:
                            reader.Skip();
                            break;
                    }
                }
                else
                {
                    reader.Read();
                    if ((reader.LocalName == "Suppliers") && reader.NodeType == XmlNodeType.EndElement)
                        break;
                }
            }
            return supplier;
        }
    }


    public class Suppliers
    {
        #region Fields
        private string m_id;
        private string m_companyName;
        private string m_contactName;
        private string m_address;
        private string m_city;
        private string m_country;
        private string m_contactTitle;
        private string m_region;
        private string m_postalCode;
        private string m_phone;
        private string m_fax;
        private string m_homePage;
        #endregion
        #region Properties
        public string SupplierID
        {
            get { return m_id; }
            set { m_id = value; }
        }
        public string CompanyName
        {
            get { return m_companyName; }
            set { m_companyName = value; }
        }
        public string ContactName
        {
            get { return m_contactName; }
            set { m_contactName = value; }
        }
        public string ContactTitle
        {
            get { return m_contactTitle; }
            set { m_contactTitle = value; }
        }
        public string Region
        {
            get { return m_region; }
            set { m_region = value; }
        }
        public string PostalCode
        {
            get { return m_postalCode; }
            set { m_postalCode = value; }
        }
        public string Phone
        {
            get { return m_phone; }
            set { m_phone = value; }
        }
        public string Fax
        {
            get { return m_fax; }
            set { m_fax = value; }
        }
        public string HomePage
        {
            get { return m_homePage; }
            set { m_homePage = value; }
        }
        public string Address
        {
            get { return m_address; }
            set { m_address = value; }
        }
        public string City
        {
            get { return m_city; }
            set { m_city = value; }
        }
        public string Country
        {
            get { return m_country; }
            set { m_country = value; }
        }
        #endregion
        #region Constructor
        public Suppliers(string id, string companyName, string contantName, string address, string city, string country)
        {
            m_id = id;
            m_companyName = companyName;
            m_contactName = contantName;
            m_address = address;
            m_city = city;
            m_country = country;
        }
        public Suppliers()
        { }
        #endregion
    }
}
