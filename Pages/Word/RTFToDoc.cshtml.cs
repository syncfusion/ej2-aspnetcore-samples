#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace EJ2CoreSampleBrowser.Pages.Word;

public class RTFToDoc : PageModel
{
    public void OnGet()
    {
        
    }
    public string Message { get; set; }
    private readonly IWebHostEnvironment _hostingEnvironment;

    public RTFToDoc(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public ActionResult OnPost(string Group1)
    {

        if (Group1 == null)
            return null;
            // return View();
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
                string filename = outputFileName + ".docx";
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
                    filename = outputFileName + ".xml";
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
                Message = string.Format("Please choose RTF document to convert to Word document");
            }
        }
        else
        {
            Message =
                string.Format("Browse a RTF document and then click the button to convert as a Word document");
        }

        return null;
        // return View();
    }
}