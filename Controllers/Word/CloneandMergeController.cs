#region Copyright Syncfusion Inc. 2001-2022
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.IO;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.Word
{
    public partial class WordController : Controller
    {
        #region Clone and Merge
        public ActionResult CloneandMerge(string Group1, string Group2, string ImportOptions)
        {
            if (Group1 == null)
                return View();
            if (Group2 == null)
                return View();
            string basePath = _hostingEnvironment.WebRootPath;
            string dataPath = basePath + @"/Word/Adventure.docx";
            string dataPathTemp = basePath + @"/Word/Northwind.docx";
            // Opens a source document.
            WordDocument document = new WordDocument();
            FileStream fileStream = new FileStream(dataPathTemp, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            document.Open(fileStream, FormatType.Docx);
            fileStream.Dispose();
            fileStream = null;
            if (Group2 == "UseImportcontents")
            {
                fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                document.ImportContent(new WordDocument(fileStream, FormatType.Doc), GetImportOption(ImportOptions));
                fileStream.Dispose();
                fileStream = null;
            }
            else
            {
                //Specifies the import option for the cloning the contents.
                document.ImportOptions = GetImportOption(ImportOptions);
                // Read the source template document
                WordDocument destinationDocument = new WordDocument();
                fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                destinationDocument.Open(fileStream, FormatType.Doc);
                fileStream.Dispose();
                fileStream = null;
                // Enumerate all the sections from the source document.
                foreach (IWSection sec in destinationDocument.Sections)
                {
                    // Cloning all the sections one by one and merging it to the destination document.
                    document.Sections.Add(sec.Clone());
                    // Setting section break code to be the same as the template.
                    document.LastSection.BreakCode = sec.BreakCode;
                }
            }
            FormatType type = FormatType.Docx;
            string filename = "CloneAndMerge.docx";
            string contenttype = "application/vnd.ms-word.document.12";
            #region Document SaveOption
            //Save as .doc format
            if (Group1 == "WordDoc")
            {
                type = FormatType.Doc;
                filename = "CloneAndMerge.doc";
                contenttype = "application/msword";
            }
            else if (Group1 == "WordML")
            {
                type = FormatType.WordML;
                filename = "CloneAndMerge.xml";
                contenttype = "application/msword";
            }
            #endregion Document SaveOption
            MemoryStream ms = new MemoryStream();
            document.Save(ms, type);
            document.Close();
            ms.Position = 0;
            return File(ms, contenttype, filename);
        }
        /// <summary>
        /// Returns the ImportOption.
        /// </summary>      
        private ImportOptions GetImportOption(string value)
        {
            switch (value)
            {
                case "0":
                    return ImportOptions.KeepSourceFormatting;
                case "1":
                    return ImportOptions.MergeFormatting;
                case "2":
                    return ImportOptions.KeepTextOnly;
                case "3":
                    return ImportOptions.UseDestinationStyles;
                case "4":
                    return ImportOptions.ListContinueNumbering;
                case "5":
                    return ImportOptions.ListRestartNumbering;
            }
            return ImportOptions.UseDestinationStyles;
        }
        #endregion Clone and Merge
    }
}