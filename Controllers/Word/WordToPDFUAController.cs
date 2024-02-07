#region Copyright Syncfusion Inc. 2001 - 2024
// Copyright Syncfusion Inc. 2001 - 2024. All rights reserved.
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

namespace EJ2CoreSampleBrowser.Controllers.Word
{
    public partial class WordController : Controller
    {
        public IActionResult WordToPDFUA(string button)
        {
            if (button == null)
                return View();
            Stream stream = GetWordDocument();
            if(stream != null)
            {
                try
                {
                    string output = (Request.Form.Files != null && Request.Form.Files.Count != 0) ? Path.GetFileNameWithoutExtension(Request.Form.Files[0].FileName) : "WordtoPDF_Pdf_UA";
                    // Loads document from stream.
                    WordDocument document = new WordDocument(stream, FormatType.Automatic);
                    stream.Dispose();
                    stream = null;
                    // Creates a new instance of DocIORenderer class.
                    DocIORenderer render = new DocIORenderer();
                    //Sets true to preserve document structured tags in the converted PDF document.
                    render.Settings.AutoTag = true;
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
                catch
                {
                    ViewBag.Message = string.Format("The input document could not be processed completely, Could you please email the document to support@syncfusion.com for troubleshooting.");
                }
            }            
            return View();
        }
    }
}
