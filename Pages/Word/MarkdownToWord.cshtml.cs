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
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;

namespace EJ2CoreSampleBrowser.Pages.Word;

public class MarkdownToWord : PageModel
{
    public void OnGet()
    {
        
    }
    public string Message { get; set; }
    private readonly IWebHostEnvironment _hostingEnvironment;

    public MarkdownToWord(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public ActionResult OnPost(string Group1)
    {
        if (Group1 == null)
            return null;
            // return View();
        Stream stream = GetMarkdownDocument();
        if (stream != null)
        {
            try
            {
                string output = (Request.Form.Files != null && Request.Form.Files.Count != 0)
                    ? Path.GetFileNameWithoutExtension(Request.Form.Files[0].FileName)
                    : "MarkdownToWord";
                WordDocument document = new WordDocument(stream, FormatType.Markdown);
                stream.Dispose();
                stream = null;
                FormatType type = FormatType.Docx;
                string filename = output + ".docx";
                string contenttype = "application/vnd.ms-word.document.12";

                #region Document SaveOption

                //Save as Html format
                if (Group1 == "HTML")
                {
                    type = FormatType.Html;
                    filename = output + ".html";
                    contenttype = "text/html";
                }
                //Save as PDF format
                else if (Group1 == "PDF")
                {
                    filename = output + ".pdf";
                    contenttype = "application/pdf";
                    // Creates a new instance of DocIORenderer class.
                    DocIORenderer render = new DocIORenderer();
                    // Converts Word document into PDF document.
                    PdfDocument pdf = render.ConvertToPDF(document);
                    MemoryStream memoryStream = new MemoryStream();
                    // Save the PDF document.
                    pdf.Save(memoryStream);
                    render.Dispose();
                    pdf.Close();
                    document.Close();
                    memoryStream.Position = 0;
                    return File(memoryStream, contenttype, filename);
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
        // return View();
    }
    private Stream GetMarkdownDocument()
    {
        if (Request.Form.Files != null && Request.Form.Files.Count != 0)
        {
            // Gets the extension from file.
            string extension = Path.GetExtension(Request.Form.Files[0].FileName).ToLower();

            // Compares extension with supported extensions.
            if (extension == ".md")
            {
                MemoryStream stream = new MemoryStream();
                Request.Form.Files[0].CopyTo(stream);
                return stream;
            }
            else
            {
                Message = string.Format("Please choose Markdown format document to convert to Word or PDF");
                return null;
            }
        }
        else
        {
            //Opens an existing document from stream through constructor of `WordDocument` class
            FileStream fileStreamPath = new FileStream(_hostingEnvironment.WebRootPath + @"/Word/MarkdownToWord.md", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            return fileStreamPath;
        }
    }
}