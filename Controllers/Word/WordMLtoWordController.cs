#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System.IO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.Word
{
    public partial class WordController : Controller
    {
        #region WordML to Word
        public ActionResult WordMLToWord(string Group1)
        {
            if (Group1 == null)
                return View();
            if (Request.Form.Files != null)
            {

                var extension = Path.GetExtension(Request.Form.Files[0].FileName).ToLower();
                if (extension == ".xml")
                {
                    MemoryStream stream = new MemoryStream();
                    Request.Form.Files[0].CopyTo(stream);
                    WordDocument document = new WordDocument(stream, FormatType.WordML);
                    stream.Dispose();
                    stream = null;
                    FormatType type = FormatType.Docx;
                    string filename = "WordMLToWord.docx";
                    string contenttype = "application/vnd.ms-word.document.12";
                    #region Document SaveOption
                    //Save as .doc format
                    if (Group1 == "WordDoc")
                    {
                        type = FormatType.Doc;
                        filename = "WordMLToWord.doc";
                        contenttype = "application/msword";
                    }
                    //Save as .xml format
                    else if (Group1 == "WordML")
                    {
                        type = FormatType.WordML;
                        filename = "WordMLToWord.xml";
                        contenttype = "application/msword";
                    }
                    #endregion Document SaveOption
                    MemoryStream ms = new MemoryStream();
                    document.Save(ms, type);
                    document.Close();
                    ms.Position = 0;
                    return File(ms, contenttype, filename);
                }
                else
                {
                    ViewBag.Message = string.Format("Please choose WordML document to convert to Word Document");
                }
            }
            else
            {
                ViewBag.Message = string.Format("Browse a WordML document and then click the button to convert as a Word document");
            }

            return View();
        }
        #endregion WordML to Word
    }
}
