#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Microsoft.AspNetCore.Mvc;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.Office;
using System;
using System.IO;
using Syncfusion.DocIORenderer;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.Word
{
    public partial class WordController : Controller
    {	
        public IActionResult LaTeX(string LaTeX, string Button, string Group1)
        {
            if (Button == null)
                return View();
            string basePath = _hostingEnvironment.WebRootPath;
            string dataPath = basePath + @"/Word/Create Equation.docx";
            string contenttype = "application/vnd.ms-word.document.12";
            // Load Template document stream.
            FileStream fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            // Creates an empty Word document instance.          
            WordDocument document = new WordDocument();
            // Opens template document.
            document.Open(fileStream, FormatType.Docx);
            fileStream.Dispose();
            fileStream = null;

            //Get the last section in the document
            WSection section = document.LastSection;
            //Set page margins
            section.PageSetup.Margins.All = 72;
            //Add new paragraph to the section
            IWParagraph paragraph = section.AddParagraph();

            //Append text to paragraph
            IWTextRange textRange = paragraph.AppendText("Mathematical equation");
            textRange.CharacterFormat.FontSize = 28;
            paragraph.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
            paragraph.ParagraphFormat.AfterSpacing = 12;

            //Add new paragraph to the section.
            paragraph = section.AddParagraph();

            //Append mathematical equation using LaTeX.
            if (!string.IsNullOrEmpty(LaTeX))
                paragraph.AppendMath(LaTeX);

            string filename = "";
            MemoryStream ms = new MemoryStream();
            #region Document SaveOption
            if (Group1 == "WordDocx")
            {
                filename = "LaTeXToMath.docx";
                contenttype = "application/msword";
                document.Save(ms, FormatType.Docx);
            }
            else
            {
                filename = "LaTeXToMath.pdf";
                contenttype = "application/pdf";
                DocIORenderer renderer = new DocIORenderer();
                renderer.ConvertToPDF(document).Save(ms);
            }
            #endregion Document SaveOption
            document.Close();			
            ms.Position = 0;
            return File(ms, contenttype, filename);
        }
    }
}
