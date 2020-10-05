#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
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

namespace EJ2CoreSampleBrowser.Controllers.DocIO
{
    public partial class DocIOController : Controller
    {
        #region RTF to Doc
        public ActionResult RTFToDoc(string Group1)
        {
           
            if (Group1 == null)
                return View();
            if (Request.Form.Files != null)
            {
                var extension = Path.GetExtension(Request.Form.Files[0].FileName).ToLower();
                string outputFileName = Path.GetFileNameWithoutExtension(Request.Form.Files[0].FileName);
                if (extension == ".rtf")
                {
                    MemoryStream stream = new MemoryStream();
                    Request.Form.Files[0].CopyTo(stream);
                    WordDocument document = new WordDocument(stream, FormatType.Rtf);
                    stream.Dispose();
                    stream = null;

                    FormatType type = FormatType.Docx;
                    string filename = outputFileName +".docx";
                    string contenttype = "application/vnd.ms-word.document.12";
                    #region Document SaveOption
                    //Save as .doc format
                    if (Group1 == "WordDoc")
                    {
                        type = FormatType.Doc;
                        filename = outputFileName + ".doc";
                        contenttype = "application/msword";
                    }
                    //Save as .xml format
                    else if (Group1 == "WordML")
                    {
                        type = FormatType.WordML;
                        filename = outputFileName +".xml";
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
                    ViewBag.Message = string.Format("Please choose RTF document to convert to Word document");
                }
            }
            else
            {
                ViewBag.Message = string.Format("Browse a RTF document and then click the button to convert as a Word document");
            }

            return View();
        }
        #endregion RTF to Doc
    }
}

