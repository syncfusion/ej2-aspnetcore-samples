#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser_NET8.Pages.Word;

public class WordMLToWord : PageModel
{
    public void OnGet()
    {
        
    }

    public string Message { get; set; }

    public ActionResult OnPost(string Group1)
    {
        if (Group1 == null)
            return null;
            // return View();
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
                Message = string.Format("Please choose WordML document to convert to Word Document");
            }
        }
        else
        {
            Message =
                string.Format("Browse a WordML document and then click the button to convert as a Word document");
        }

        return null;
        // return View();
    }
}