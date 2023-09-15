#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
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

namespace EJ2CoreSampleBrowser.Controllers.Word
{
    public partial class WordController : Controller
    {

        public ActionResult CompareDocuments(string Compare, string DetectFormat)
        {
            if (Compare == null)
            {
                return View();
            }
            string basePath = _hostingEnvironment.WebRootPath;
            //Loads the original template document.
            string dataPathField = basePath + @"/Word/OriginalDocument.docx";
            using (FileStream originalDocumentStream = new FileStream(dataPathField, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (WordDocument originalDocument = new WordDocument(originalDocumentStream, FormatType.Docx))
                {
                    //Loads the revised template document.
                    dataPathField = basePath + @"/Word/RevisedDocument.docx";
                    using (FileStream revisedDocumentStream = new FileStream(dataPathField, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (WordDocument revisedDocument = new WordDocument(revisedDocumentStream, FormatType.Docx))
                        {
                            if (DetectFormat == "DetectFormat")
                            {
                                //Compares the original document with revised document
                                originalDocument.Compare(revisedDocument, "Nancy Davolio", DateTime.Now.AddDays(-1));
                            }
                            else
                            {
                                //Disable the flag to ignore the formatting changes while comparing the documents
                                ComparisonOptions comparisonOptions = new ComparisonOptions();
                                comparisonOptions.DetectFormatChanges = false;
                                originalDocument.Compare(revisedDocument, "Nancy Davolio", DateTime.Now.AddDays(-1), comparisonOptions);
                            }
                            FormatType type = FormatType.Docx;
                            string filename = "CompareDocuments.docx";
                            string contenttype = "application/vnd.ms-word.document.12";

                            MemoryStream ms = new MemoryStream();
                            originalDocument.Save(ms, type);
                            ms.Position = 0;
                            return File(ms, contenttype, filename);
                        }
                    }   
                }
            }
        }
    }

    
}
