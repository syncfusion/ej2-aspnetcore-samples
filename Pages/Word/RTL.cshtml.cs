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

public class RTL : PageModel
{
    public void OnGet()
    {

    }
    private readonly IWebHostEnvironment _hostingEnvironment;

    public RTL(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    #region RTL

    public ActionResult OnPost(string Group1)
    {
        if (Group1 == null)
            return null;
            // return View();
        // Creating a new document.
        WordDocument document = new WordDocument();
        document.EnsureMinimal();

        string basePath = _hostingEnvironment.WebRootPath;
        string dataPath = basePath + @"/Word/Arabic.txt";
        // Reading Arabic text from text file.
        StreamReader s = new StreamReader(new FileStream(dataPath, FileMode.Open), System.Text.Encoding.ASCII);
        string text = s.ReadToEnd();
        s.Dispose();
        s = null;

        // Appending Arabic text to the document.
        document.LastParagraph.ParagraphFormat.Bidi = true;
        IWTextRange txtRange = document.LastParagraph.AppendText(text);
        txtRange.CharacterFormat.Bidi = true;

        // Set the RTL text font size.
        txtRange.CharacterFormat.FontSizeBidi = 16;

        FormatType type = FormatType.Docx;
        string filename = "RTL.docx";
        string contenttype = "application/vnd.ms-word.document.12";

        #region Document SaveOption

        //Save as .doc format
        if (Group1 == "WordDoc")
        {
            type = FormatType.Doc;
            filename = "RTL.doc";
            contenttype = "application/msword";
        }
        //Save as .xml format
        else if (Group1 == "WordML")
        {
            type = FormatType.WordML;
            filename = "RTL.xml";
            contenttype = "application/msword";
        }

        #endregion Document SaveOption

        MemoryStream ms = new MemoryStream();
        document.Save(ms, type);
        document.Close();
        ms.Position = 0;
        return File(ms, contenttype, filename);
    }

    #endregion RTL
}