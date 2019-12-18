#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
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

            if (Request.Form.Files != null && Request.Form.Files.Count!=0)
            {
                // Gets the extension from file.
                string extension = Path.GetExtension(Request.Form.Files[0].FileName).ToLower();
                string output = Path.GetFileNameWithoutExtension(Request.Form.Files[0].FileName);
                
                // Compares extension with supported extensions.
                if (extension == ".doc" || extension == ".docx" || extension == ".dot" || extension == ".dotx" || extension == ".dotm" || extension == ".docm"
                   || extension == ".xml" || extension == ".rtf")
                {
                    Stream stream = new FileStream(Path.GetTempFileName(), FileMode.Create);
                    Request.Form.Files[0].CopyToAsync(stream);
                    try
                    {
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
                        return File(memoryStream, "application/pdf", output + ".pdf");
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = string.Format("The input document could not be processed completely, Could you please email the document to support@syncfusion.com for troubleshooting.");
                    }                    
                }
                else
                {
                    ViewBag.Message = string.Format("Please choose Word format document to convert to PDF");
                }
            }
            else
            {
                ViewBag.Message = string.Format("Browse a Word document and then click the button to convert as a PDF document");
            }
            return View();
        }
    }
}
