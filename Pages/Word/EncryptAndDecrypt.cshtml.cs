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

namespace EJ2CoreSampleBrowser.Pages.Word;

public class EncryptAndDecrypt : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public EncryptAndDecrypt(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public ActionResult OnPost(string Group1, string Group2)
    {
        if (Group1 == null)
            return null;
            // return View();
        WordDocument document = null;
        if (Group1 == "CreateEncryptDoc")
        {
            document = new WordDocument();

            document.EnsureMinimal();

            // Getting last section of the document.
            IWSection section = document.LastSection;

            // Adding a paragraph to the section.
            IWParagraph paragraph = section.AddParagraph();

            // Writing text
            IWTextRange text = paragraph.AppendText("This document was encrypted with password");
            text.CharacterFormat.FontSize = 16f;
            text.CharacterFormat.FontName = "Bitstream Vera Serif";

            // Encrypt the document by giving password
            document.EncryptDocument("syncfusion");
        }
        else
        {
            // Open an existing template document.
            string basePath = _hostingEnvironment.WebRootPath;
            string dataPath = basePath + @"/Word/Security Settings.docx";
            FileStream fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            document = new WordDocument(fileStream, FormatType.Docx, "syncfusion");

            // Getting last section of the document.
            IWSection section = document.LastSection;

            // Adding a paragraph to the section.
            IWParagraph paragraph = section.AddParagraph();

            // Writing text
            IWTextRange text = paragraph.AppendText("\nDemo For Document Decryption with Essential DocIO");
            text.CharacterFormat.FontSize = 16f;
            text.CharacterFormat.FontName = "Bitstream Vera Serif";

            text = paragraph.AppendText("\nThis document is Decrypted");
            text.CharacterFormat.FontSize = 16f;
            text.CharacterFormat.FontName = "Bitstream Vera Serif";
        }

        #region Document SaveOption

        FormatType type = FormatType.Docx;
        string filename = "EncryptAndDecrypt.docx";
        string contenttype = "application/vnd.ms-word.document.12";
        //Save as .doc format

        #endregion Document SaveOption

        MemoryStream ms = new MemoryStream();
        document.Save(ms, type);
        document.Close();
        ms.Position = 0;
        return File(ms, contenttype, filename);
    }
}