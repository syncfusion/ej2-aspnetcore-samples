#region Copyright
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using EJ2CoreSampleBrowser.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.Word
{
    public partial class WordController : Controller
    {
        public ActionResult LetterFormat(string Group1, string Button, string MapDataField)
        {
            string basePath = _hostingEnvironment.WebRootPath;
            string contenttype1 = "application/msword";
            string dataPath = basePath + @"/Word/Letter Formatting.doc";
            FileStream fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            if (Group1 == null)
                return View();
            if (Button == "View Template")
            {
                return File(fileStream, contenttype1, "Letter Formatting.doc");
            }
            fileStream.Dispose();
            fileStream = null;
            try
            {
                // Load the template.
                FileStream fileStreamPath = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                WordDocument document = new WordDocument(fileStreamPath, FormatType.Doc);
                fileStreamPath.Dispose();
                fileStreamPath = null;
                //Gets the data table.
                DataTable table = GetDataTable();
                //Checks if data field mapping should be enabled
                if (MapDataField == "MapDataField")
                {
                    //Removes paragraph that contains only empty fields.
                    document.MailMerge.RemoveEmptyParagraphs = true;
                    //To clear the fields with empty value
                    document.MailMerge.ClearFields = true;
                    //Clear the map fields
                    document.MailMerge.MappedFields.Clear();
                    //Update the mapping fields
                    document.MailMerge.MappedFields.Add("Contact Name", "ContactName");
                    document.MailMerge.MappedFields.Add("Company Name", "CompanyName");
                    document.MailMerge.MappedFields.Add("CompanyAddress", "Address");
                    document.MailMerge.MappedFields.Add("Residing City", "City");
                    document.MailMerge.MappedFields.Add("Current Region", "Region");
                    document.MailMerge.MappedFields.Add("Home Country", "Country");
                }
                //Mailmerge can be performed with the input as either DataRow, DataField, DataView, IDataReader 
                //or a set of merge field names and values. Here, one particular row is extraced from the table and used.
                DataRow dr = table.Rows[0];
                //Executes mail merge for the selected record or row.
                document.MailMerge.Execute(dr);
                FormatType type = FormatType.Docx;
                string filename = "LetterFormat.docx";
                string contenttype = "application/vnd.ms-word.document.12";
                #region Document SaveOption
                //Save as .doc format
                if (Group1 == "WordDoc")
                {
                    type = FormatType.Doc;
                    filename = "LetterFormat.doc";
                    contenttype = "application/msword";
                }
                //Save as .xml format
                else if (Group1 == "WordML")
                {
                    type = FormatType.WordML;
                    filename = "LetterFormat.xml";
                    contenttype = "application/msword";
                }
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
        private DataTable GetDataTable()
        {
            //Data source.
            DataSet ds = new DataSet();
            ds.ReadXml(_hostingEnvironment.WebRootPath + @"/Word/Customers.xml");
            DataTable table = ds.Tables[0];
            return table;
        }
    }
}