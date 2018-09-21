#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Drawing;
using System.Text.RegularExpressions;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.Pdf;
using Microsoft.AspNetCore.Mvc;
using System.IO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.DocIO
{
    public partial class DocIOController : Controller
    {
        public ActionResult FindandHighlight(string Group1, string Button, string Group2)
        {
            if (Group1 == null)
                return View();
            string basePath = _hostingEnvironment.WebRootPath;
            string dataPath = basePath + @"/DocIO/Adventure.docx";
            string contenttype1 = "application/vnd.ms-word.document.12";
            FileStream fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            if (Button == "View Template")
                return File(fileStream, contenttype1, "Adventure.docx");
            try
            {                         
                //Load template document
                WordDocument doc = new WordDocument(fileStream,FormatType.Docx);
                fileStream.Dispose();
                fileStream = null;
                //Get the pattern for regular expression
                Regex regex = new Regex(Group2);
                //Find the first occurrence of the text in the Word document.
                TextSelection text = doc.Find(regex);
                //Set the highlight color for the text.
                text.GetAsOneRange().CharacterFormat.HighlightColor = Syncfusion.Drawing.Color.Green;
                try
                {
                    FormatType type = FormatType.Docx;
                    string filename = "Sample.docx";
                    string contenttype = "application/vnd.ms-word.document.12";
                    #region Document SaveOption
                    //Save as .doc format
                    if (Group1 == "WordDoc")
                    {
                        type = FormatType.Doc;
                        filename = "Sample.doc";
                        contenttype = "application/msword";
                    }
                    //Save as .xml format
                    else if (Group1 == "WordML")
                    {
                        type = FormatType.WordML;
                        filename = "Sample.xml";
                        contenttype = "application/msword";
                    }
                    #endregion Document SaveOption
                    MemoryStream ms = new MemoryStream();
                    doc.Save(ms, type);
                    doc.Close();
                    ms.Position = 0;
                    return File(ms, contenttype, filename);
                }
                catch (Exception)
                { }
            }
            catch (Exception)
            { }
            return View();
        }
    }
}
