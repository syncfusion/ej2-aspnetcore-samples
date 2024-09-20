#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Syncfusion.Pdf.Parsing;
using EJ2CoreSampleBrowser.Models;
using Syncfusion.Pdf;
using Syncfusion.EJ2.Navigations;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        // GET: /FindText/
        public IActionResult FindText()
        {
            FindTextMessage message = new FindTextMessage();
            message.Message = string.Empty;
            return View("FindText", message);
        }
        private readonly IWebHostEnvironment _hostingEnvironment;
        public PdfController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpPost]
        public IActionResult FindText(string ViewTemplate, string findText, string find)
        {
            if (!string.IsNullOrEmpty(find))
            {
                Stream fileStream = GetSplitPDFDocument();
                PdfLoadedDocument loadedDocument = new PdfLoadedDocument(fileStream);
                Dictionary<int, List<Syncfusion.Drawing.RectangleF>> matchRects = new Dictionary<int, List<Syncfusion.Drawing.RectangleF>>();
                bool matchFound = loadedDocument.FindText(findText, out matchRects);
                FindTextMessage message = new FindTextMessage();
                List<Syncfusion.Drawing.RectangleF> rectCoords = null;
                string findTextResults = null;
                int textCounts = 0;

                if (matchFound)
                {
                    // Iterate through the matchedText bounds dictionary.
                    foreach (KeyValuePair<int, List<Syncfusion.Drawing.RectangleF>> matchedText in matchRects)
                    {
                        int pageIndex = matchedText.Key;
                        rectCoords = matchedText.Value;
                        for (int j = 0; j < rectCoords.Count; j++)
                        {
                            textCounts++;
                            findTextResults += "Occurrence " + textCounts + " is on page " + (pageIndex + 1) + " with the following coordinates: X:" + rectCoords[j].X + "; Y:" + rectCoords[j].Y + "; Width:" + rectCoords[j].Width + "; Height:" + rectCoords[j].Height + Environment.NewLine;

                        }

                    }
                    var text = " The text \"" + findText + "\" appears " + textCounts + " times in this document " + "\n";
                    message.Message = text + findTextResults;

                }
                else
                {
                    ViewBag.Message = "No such word found in in the PDF document";
                }

                return View("FindText", message);

            }
            return View("FindText");
        }

        private Stream GetSplitPDFDocument()
        {
            if (Request.Form.Files != null && Request.Form.Files.Count != 0)
            {
                // Gets the extension from file.
                string extension = Path.GetExtension(Request.Form.Files[0].FileName).ToLower();

                // Compares extension with supported extensions.
                if (extension == ".pdf")
                {
                    MemoryStream stream = new MemoryStream();
                    Request.Form.Files[0].CopyTo(stream);
                    return stream;
                }
                else
                {
                    ViewBag.Message =  string.Format("Please choose a valid PDF document to find the text");
                    return null;
                }
            }
            else
            {
                //Opens an existing document from stream through constructor of `WordDocument` class
                FileStream fileStreamPath = new FileStream(_hostingEnvironment.WebRootPath + @"/PDF/PDF_Succinctly.pdf", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                return fileStreamPath;
            }
        }
    }
}
