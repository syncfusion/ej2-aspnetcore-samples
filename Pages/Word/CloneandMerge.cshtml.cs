#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Pages.Word;

public class CloneandMerge : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public CloneandMerge(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public ActionResult OnPost(string Group1, string Group2, string ImportOptions)
    {
        if (Group1 == null)
            return null;
            // return View();
        if (Group2 == null)
            return null;
            // return View();
        string basePath = _hostingEnvironment.WebRootPath;
        string dataPath = basePath + @"/Word/Adventure.docx";
        string dataPathTemp = basePath + @"/Word/Northwind.docx";
        // Opens a source document.
        WordDocument document = new WordDocument();
        document.Open(dataPathTemp, FormatType.Docx);
        if (Group2 == "UseImportcontents")
        {
            document.ImportContent(new WordDocument(dataPath, FormatType.Doc), GetImportOption(ImportOptions));
        }
        else
        {
            //Specifies the import option for the cloning the contents.
            document.ImportOptions = GetImportOption(ImportOptions);
            // Read the source template document
            WordDocument destinationDocument = new WordDocument();
            destinationDocument.Open(dataPath, FormatType.Doc);
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
}