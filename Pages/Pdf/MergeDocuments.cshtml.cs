#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

namespace EJ2CoreSampleBrowser.Pages.Pdf;

public class MergeDocuments : PageModel
{
    public void OnGet()
    {
        // ViewData["Error"] = "";
    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public MergeDocuments(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }
    [HttpPost]
    public ActionResult OnPost(string InsideBrowser, string OptimizeResources, string MergeAccessibilityTags)
    {
        string basePath = _hostingEnvironment.WebRootPath;
        string dataPath = string.Empty;
        dataPath = basePath + @"/PDF/";

        //Read the file
        FileStream file1 = new FileStream(dataPath + "HTTP Succinctly.pdf", FileMode.Open, FileAccess.Read,
            FileShare.ReadWrite);
        FileStream file2 = new FileStream(dataPath + "HTTP Succinctly.pdf", FileMode.Open, FileAccess.Read,
            FileShare.ReadWrite);

        //Load the documents as streams
        PdfLoadedDocument doc1 = new PdfLoadedDocument(file1);
        PdfLoadedDocument doc2 = new PdfLoadedDocument(file2);

        object[] dobj = { doc1, doc2 };
        PdfDocument doc = new PdfDocument();

        PdfMergeOptions mergeOption = new PdfMergeOptions();


        if (MergeAccessibilityTags == "MergeAccessibilityTags" || OptimizeResources == "OptimizeResources")
        {
            mergeOption.MergeAccessibilityTags = !string.IsNullOrEmpty(MergeAccessibilityTags) ? true : false;
            mergeOption.OptimizeResources = !string.IsNullOrEmpty(OptimizeResources) ? true : false;
            PdfDocument.Merge(doc, mergeOption, dobj);
        }
        else
        {
            PdfDocument.Merge(doc, dobj);
        }

        MemoryStream stream = new MemoryStream();

        //Save the PDF document
        doc.Save(stream);

        stream.Position = 0;

        //Close the PDF document
        doc.Close(true);
        doc1.Close(true);
        doc2.Close(true);

        //Download the PDF document in the browser.
        FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
        fileStreamResult.FileDownloadName = "MergedPDF.pdf";
        return fileStreamResult;
    }
}