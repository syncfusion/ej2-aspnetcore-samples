#region Copyright
// Copyright Syncfusion Inc. 2001 - 2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.Pdf;
using Microsoft.AspNetCore.Mvc;
using System.IO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.Word
{
    public partial class WordController : Controller
    {
        public ActionResult SimpleReplace(string Group1, string Button, string MatchCase, string MatchWholeWord,
            string FindText, string ReplaceText, string ReplaceFirst)
        {
            if (Group1 == null)
                return View();
            string basePath = _hostingEnvironment.WebRootPath;
            string dataPath1 = basePath + @"/Word/Adventure.docx";
            string contenttype1 = "application/vnd.ms-word.document.12";
            FileStream fileStream = new FileStream(dataPath1, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            if (Button == "View Template")
                return File(fileStream, contenttype1, "Adventure.docx");
            fileStream.Dispose();
            fileStream = null;

            try
            {
                string dataPath2 = basePath + @"/Word/Adventure.docx";
                FileStream fileStream1 = new FileStream(dataPath2, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                //Load template document
                WordDocument doc = new WordDocument(fileStream1,FormatType.Docx);
                fileStream1.Dispose();
                fileStream1 = null;

                //Replaces only the first occurrence of the text
                if (ReplaceFirst == "ReplaceFirst")
                    doc.ReplaceFirst = true;

                //Replace the text that matches the case and whole word
                doc.Replace(FindText, ReplaceText, MatchCase == "MatchCase", MatchWholeWord == "MatchWholeWord");

                try
                {
                    FormatType type = FormatType.Docx;
                    string filename = "SimpleReplace.docx";
                    string contenttype = "application/vnd.ms-word.document.12";
                    #region Document SaveOption
                    //Save as .doc format
                    if (Group1 == "WordDoc")
                    {
                        type = FormatType.Doc;
                        filename = "SimpleReplace.doc";
                        contenttype = "application/msword";
                    }
                    //Save as .xml format
                    else if (Group1 == "WordML")
                    {
                        type = FormatType.WordML;
                        filename = "SimpleReplace.xml";
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
