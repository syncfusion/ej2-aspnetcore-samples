#region Copyright Syncfusion Inc. 2001 - 2024
// Copyright Syncfusion Inc. 2001 - 2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.IO;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.Word
{
    public partial class WordController : Controller
    {
        #region Word to Markdown
        public ActionResult WordToMarkdown(string button)
        {
            if (button == null)
                return View();
            Stream stream = GetWordDocumentForConversion();
            if (stream != null)
            {
                try
                {
                    string output = (Request.Form.Files != null && Request.Form.Files.Count != 0) ? Path.GetFileNameWithoutExtension(Request.Form.Files[0].FileName) : "WordtoMD";
                    WordDocument document = new WordDocument(stream, FormatType.Automatic);
                    #region Document SaveOption
                    //Save as .md format
                    FormatType type = FormatType.Markdown;
                    string contenttype = "application/msword";

                    #endregion Document SaveOption
                    MemoryStream ms = new MemoryStream();
                    document.Save(ms, type);
                    document.Close();
                    ms.Position = 0;
                    return File(ms, contenttype, output + ".md");

                }
                catch
                {
                    ViewBag.Message = string.Format("The input document could not be processed completely, Could you please email the document to support@syncfusion.com for troubleshooting.");
                }
            }
            return View();
        }
        private Stream GetWordDocumentForConversion()
        {
            if (Request.Form.Files != null && Request.Form.Files.Count != 0)
            {
                // Gets the extension from file.
                string extension = Path.GetExtension(Request.Form.Files[0].FileName).ToLower();

                // Compares extension with supported extensions.
                if (extension == ".doc" || extension == ".docx" || extension == ".dot" || extension == ".dotx" || extension == ".dotm" || extension == ".docm"
                   || extension == ".xml" || extension == ".rtf")
                {
                    MemoryStream stream = new MemoryStream();
                    Request.Form.Files[0].CopyTo(stream);
                    return stream;
                }
                else
                {
                    ViewBag.Message = string.Format("Please choose Word format document to convert to Markdown");
                    return null;
                }
            }
            else
            {
                //Opens an existing document from stream through constructor of `WordDocument` class
                FileStream fileStreamPath = new FileStream(_hostingEnvironment.WebRootPath + @"/Word/WordtoMD.docx", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                return fileStreamPath;
            }
        }
        #endregion Word to Markdown
    }
}