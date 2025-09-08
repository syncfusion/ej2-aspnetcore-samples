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

public class TXTtoWord : PageModel
{
    public void OnGet()
    {
        
    }
    public string Message { get; set; }
    private readonly IWebHostEnvironment _hostingEnvironment;

    public TXTtoWord(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public ActionResult OnPost(string Group1)
    {

        if (Group1 == null)
            return null;
		Stream stream = GetTextFile();
		if (stream != null)
        {
            try
            {
                string output = (Request.Form.Files != null && Request.Form.Files.Count != 0)
                    ? Path.GetFileNameWithoutExtension(Request.Form.Files[0].FileName)
                    : "TXTToWord";
                WordDocument document = new WordDocument(stream, FormatType.Txt);
                stream.Dispose();
                stream = null;
                FormatType type = FormatType.Docx;
                string filename = output + ".docx";
                string contenttype = "application/vnd.ms-word.document.12";

                #region Document SaveOption

                //Save as .doc format
                if (Group1 == "WordDoc")
                {
                    type = FormatType.Doc;
                    filename = output + ".doc";
                    contenttype = "application/msword";
                }
                //Save as .xml format
                else if (Group1 == "WordML")
                {
                    type = FormatType.WordML;
                    filename = output + ".xml";
                    contenttype = "application/msword";
                }

                #endregion Document SaveOption

                MemoryStream ms = new MemoryStream();
                document.Save(ms, type);
                document.Close();
                ms.Position = 0;
                return File(ms, contenttype, filename);
            }
            catch
            {
                Message =
                    string.Format(
                        "The input document could not be processed completely, Could you please email the document to support@syncfusion.com for troubleshooting.");
            }
        }
		
        return null;
    }
	/// <summary>
    /// Gets Text file for Word conversion
    /// </summary>
    /// <returns></returns>
	 private Stream GetTextFile()
    {
        if (Request.Form.Files != null && Request.Form.Files.Count != 0)
        {
            // Gets the extension from file.
            string extension = Path.GetExtension(Request.Form.Files[0].FileName).ToLower();

            // Compares extension with supported extensions.
            if (extension == ".txt")
            {
                MemoryStream stream = new MemoryStream();
                Request.Form.Files[0].CopyTo(stream);
                return stream;
            }
            else
            {
                Message = string.Format("Please choose text file to convert to Word document");
                return null;
            }
        }
        else
        {
            //Opens an existing document from stream through constructor of `WordDocument` class
            FileStream fileStreamPath = new FileStream(_hostingEnvironment.WebRootPath + @"/Word/TXTToWord.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            return fileStreamPath;
        }
    }
}
