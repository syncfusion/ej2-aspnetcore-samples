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

namespace EJ2CoreSampleBrowser.Pages.Word;

public class DOCtoODT : PageModel
{
    public void OnGet()
    {
        
    }

    public string Message { get; set; }

    public ActionResult OnPost(string button)
    {
        if (button == null)
            return null;
            // return View();
        if (Request.Form.Files != null)
        {
            var extension = Path.GetExtension(Request.Form.Files[0].FileName).ToLower();
            if (extension == ".doc" || extension == ".docx" || extension == ".dot" || extension == ".dotx" ||
                extension == ".dotm" || extension == ".docm"
                || extension == ".xml" || extension == ".rtf")
            {
                MemoryStream stream = new MemoryStream();
                Request.Form.Files[0].CopyTo(stream);
                WordDocument document = new WordDocument(stream, FormatType.Automatic);
                stream.Dispose();
                stream = null;
                //Convert word document into ODT document
                try
                {
                    #region Document SaveOption

                    //Save as .odt format
                    FormatType type = FormatType.Odt;
                    string filename = "WordToODT.odt";
                    string contenttype = "application/msword";

                    #endregion Document SaveOption

                    MemoryStream ms = new MemoryStream();
                    document.Save(ms, type);
                    document.Close();
                    ms.Position = 0;
                    return File(ms, contenttype, filename);
                }
                catch (Exception)
                {
                }
                finally
                {

                }
            }
            else
            {
                Message = string.Format("Please choose Word format document to convert to ODT");
            }
        }
        else
        {
            Message =
                string.Format("Browse a Word document and then click the button to convert as a ODT document");
        }

        return null;
        // return View();
    }
}