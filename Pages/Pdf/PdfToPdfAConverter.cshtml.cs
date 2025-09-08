#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf.Parsing;
using SkiaSharp;

namespace EJ2CoreSampleBrowser.Pages.Pdf;

public class PdfToPdfAConverter : PageModel
{
    public string[] data;
    public string lab;
    public void OnGet()
    {
        data = new string[] { "PDF/A-1b",  "PDF/A-2b", "PDF/A-3b" , "PDF/A-4"};
    }

    [HttpPost]
    public ActionResult OnPost(string conformance, string Browser)
    {
        if (Request.Form.Files != null && Request.Form.Files.Count != 0)
        {
            //Load an existing PDF.
            PdfLoadedDocument doc = new PdfLoadedDocument(Request.Form.Files[0].OpenReadStream());
            doc.SubstituteFont += LoadedDocument_SubstituteFont;
            if (conformance == "PDF/A-1b")
            {
                //Create a new document with PDF/A standard.
                doc.ConvertToPDFA(PdfConformanceLevel.Pdf_A1B);
            }
            else if (conformance == "PDF/A-2b")
            {
                //Create a new document with PDF/A standard.
                doc.ConvertToPDFA(PdfConformanceLevel.Pdf_A2B);
            }
            else if (conformance == "PDF/A-3b")
            {
                //Create a new document with PDF/A standard.
                doc.ConvertToPDFA(PdfConformanceLevel.Pdf_A3B);
            }
            else if (conformance == "PDF/A-4")
            {
                //Create a new document with PDF/A standard.
                doc.ConvertToPDFA(PdfConformanceLevel.Pdf_A4);
            }

            //If the position is not set to '0' then the PDF will be empty.
            MemoryStream ms = new MemoryStream();
            doc.Save(ms);
            ms.Position = 0;
            doc.Close(true);
            //Download the PDF document in the browser.
            FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
            fileStreamResult.FileDownloadName = "PDFA.pdf";
            return fileStreamResult;
        }
        else
        {
            lab = "Choose a valid PDF file.";
            data = new string[] { "PDF/A-1b", "PDF/A-2b", "PDF/A-3b", "PDF/A-4" };
            return null;
            // return View();
        }

    }
    private void LoadedDocument_SubstituteFont(object sender, PdfFontEventArgs args)
    {
        //Get the font name
        string fontName = args.FontName.Split(',')[0];

        //Get the font style
        PdfFontStyle fontStyle = args.FontStyle;

        SKFontStyle sKFontStyle = SKFontStyle.Normal;

        if (fontStyle != PdfFontStyle.Regular)
        {
            if (fontStyle == PdfFontStyle.Bold)
            {
                sKFontStyle = SKFontStyle.Bold;
            }
            else if (fontStyle == PdfFontStyle.Italic)
            {
                sKFontStyle = SKFontStyle.Italic;
            }
            else if (fontStyle == (PdfFontStyle.Italic | PdfFontStyle.Bold))
            {
                sKFontStyle = SKFontStyle.BoldItalic;
            }
        }

        SKTypeface typeface = SKTypeface.FromFamilyName(fontName, sKFontStyle);
        SKStreamAsset typeFaceStream = typeface.OpenStream();
        MemoryStream memoryStream = null;
        if (typeFaceStream != null && typeFaceStream.Length > 0)
        {
            //Create fontData from type face stream.
            byte[] fontData = new byte[typeFaceStream.Length - 1];
            typeFaceStream.Read(fontData, typeFaceStream.Length);
            typeFaceStream.Dispose();
            //Create the new memory stream from font data.
            memoryStream = new MemoryStream(fontData);
        }
        //set the font stream to the event args.
        args.FontStream = memoryStream;
    }
}
