#region Copyright Syncfusion Inc. 2001 - 2022
// Copyright Syncfusion Inc. 2001 - 2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        public IActionResult WordToPDF(string button)
        {
            if (button == null)
                return View();
            Stream stream = GetWordDocument();
            if (stream != null)
            {
                    try
                    {
                        string output = (Request.Form.Files != null && Request.Form.Files.Count != 0) ? Path.GetFileNameWithoutExtension(Request.Form.Files[0].FileName) : "WordtoPDF";
                        // Loads document from stream.
                        WordDocument document = new WordDocument(stream, FormatType.Automatic);
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
                        return File(memoryStream, "application/pdf",  output + ".pdf");
                    }
                catch
                {
                    ViewBag.Message = string.Format("The input document could not be processed completely, Could you please email the document to support@syncfusion.com for troubleshooting.");
                }
            }
            return View();
        }
        private Stream GetWordDocument()
        {
            if (Request.Form.Files != null && Request.Form.Files.Count != 0)
            {
                // Gets the extension from file.
                string extension = Path.GetExtension(Request.Form.Files[0].FileName).ToLower();

                // Compares extension with supported extensions.
                if (extension == ".doc" || extension == ".docx" || extension == ".dot" || extension == ".dotx" || extension == ".dotm" || extension == ".docm"
                   || extension == ".xml" || extension == ".rtf")
                {
                    MemoryStream stream = new MemoryStream();
                    Request.Form.Files[0].CopyTo(stream);
                    return stream;
                }
                else
                {
                    ViewBag.Message = string.Format("Please choose Word format document to convert to PDF");
                    return null;
                }
            }
            else
            {
                //Opens an existing document from stream through constructor of `WordDocument` class
                FileStream fileStreamPath = new FileStream(_hostingEnvironment.WebRootPath + @"/DocIO/WordtoPDF.docx", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                return fileStreamPath;
            }
        }
    }
}
