#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
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

namespace EJ2CoreSampleBrowser.Controllers.Word
{
    public partial class WordController : Controller
    {
        public IActionResult WordToImage(string button)
        {
            if (button == null)
                return View();
            Stream stream = GetWordDocumentForImageConversion();
            if(stream != null)
            {
                try
                {
                    string output = (Request.Form.Files != null && Request.Form.Files.Count != 0) ? Path.GetFileNameWithoutExtension(Request.Form.Files[0].FileName) : "WordtoImage";
                    // Loads document from stream.
                    WordDocument document = new WordDocument(stream, FormatType.Automatic);
                    stream.Dispose();
                    stream = null;
                    // Creates a new instance of DocIORenderer class.
                    DocIORenderer render = new DocIORenderer();
                    //Converts the first page of word document to image
                    MemoryStream imageStream = (MemoryStream)document.RenderAsImages(0, Syncfusion.DocIO.ExportImageFormat.Jpeg);
                    render.Dispose();
                    document.Close();
                    imageStream.Position = 0;
                    return File(imageStream, "image/jpeg", output + "_Page1.jpeg");
                }
                catch
                {
                    ViewBag.Message = string.Format("The input document could not be processed completely, Could you please email the document to support@syncfusion.com for troubleshooting.");
                }
            }            
            return View();
        }
        /// <summary>
        /// Gets Word document for Image Conversion
        /// </summary>
        /// <returns></returns>
        private Stream GetWordDocumentForImageConversion()
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
                    ViewBag.Message = string.Format("Please choose Word format document to convert to Image");
                    return null;
                }
            }
            else
            {
                //Opens an existing document from stream through constructor of `WordDocument` class
                FileStream fileStreamPath = new FileStream(_hostingEnvironment.WebRootPath + @"/Word/WordtoImage.docx", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                return fileStreamPath;
            }
        }
    }
}
