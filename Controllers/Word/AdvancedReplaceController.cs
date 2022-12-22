#region Copyright Syncfusion Inc. 2001 - 2022
// Copyright Syncfusion Inc. 2001 - 2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Microsoft.AspNetCore.Mvc;
using System.IO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.Word
{
    public partial class WordController : Controller
    {
        #region AdvancedReplace
        public ActionResult AdvancedReplace(string Group1, string Button)
        {
            if (Group1 == null)
                return View();
            try
            {
                string basePath = _hostingEnvironment.WebRootPath;
                string dataPathTemp = basePath + @"/Word/SourceTemplate1.doc";
                string dataPathTemplate = basePath + @"/Word/SourceTemplate2.doc";
                string dataPathMaster = basePath + @"/Word/MasterTemplate.doc";
                string contenttype1 = "application/msword";
                //Load Template document stream.
                FileStream fileStream = new FileStream(dataPathMaster, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                if (Button == "View Template")
                {
                    return File(fileStream, contenttype1, "MasterTemplate.doc");
                }
                fileStream.Dispose();
                fileStream = null;

                //Creating new documents.
                WordDocument docSource1 = new WordDocument();
                WordDocument docSource2 = new WordDocument();
                WordDocument docMaster = new WordDocument();
                //Load Templates.
                fileStream = new FileStream(dataPathTemp, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                docSource1.Open(fileStream, FormatType.Doc);
                fileStream.Dispose();
                fileStream = null;
                fileStream = new FileStream(dataPathTemplate, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                docSource2.Open(fileStream, FormatType.Doc);
                fileStream.Dispose();
                fileStream = null;
                fileStream = new FileStream(dataPathMaster, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                docMaster.Open(fileStream, FormatType.Doc);
                fileStream.Dispose();
                fileStream = null;
                //Search for a string and store in TextSelection
                //The TextSelection copies a text segment with formatting.
                TextSelection selection1 = docSource1.Find("PlaceHolder text is replaced with this formatted animated text", false, false);
                //Get the text segment to replace the tex across multiple paragraphs
                TextBodyPart replacePart = new TextBodyPart(docSource2);
                foreach (TextBodyItem bodyItem in docSource2.LastSection.Body.ChildEntities)
                    replacePart.BodyItems.Add(bodyItem.Clone());
                //Replacing the placeholder inside Master Template with matches found while
                //search the two template documents. 
                docMaster.Replace("PlaceHolder1", selection1, true, true, true);
                docMaster.ReplaceSingleLine((new System.Text.RegularExpressions.Regex("PlaceHolder2Start:Suppliers/Vendors of Northwind." +
                "Customers of Northwind.Employee details of Northwind traders.The product information.The inventory details.The shippers." +
                "PO transactions i.e Purchase Order transactions.Sales Order transaction.Inventory transactions.Invoices.PlaceHolder2End")), replacePart);

                FormatType type = FormatType.Docx;
                string filename = "AdvancedReplace.docx";
                string contenttype = "application/vnd.ms-word.document.12";
                #region Document SaveOption
                //Save as .doc format
                if (Group1 == "WordDoc")
                {
                    type = FormatType.Doc;
                    filename = "AdvancedReplace.doc";
                    contenttype = "application/msword";
                }
                //Save as .xml format
                else if (Group1 == "WordML")
                {
                    type = FormatType.WordML;
                    filename = "AdvancedReplace.xml";
                    contenttype = "application/msword";
                }
                #endregion Document SaveOption
                MemoryStream ms = new MemoryStream();
                docMaster.Save(ms, type);
                docMaster.Close();
                ms.Position = 0;
                return File(ms, contenttype, filename);
            }
            catch (Exception)
            {
            }
            return View();
        }
        #endregion
    }
}
