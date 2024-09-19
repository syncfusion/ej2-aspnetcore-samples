#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

namespace EJ2CoreSampleBrowser_NET8.Pages.Pdf;

public class OverlayDocuments : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public OverlayDocuments(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }
    [HttpPost]
    public ActionResult OnPost(string InsideBrowser)
    {
        string basePath = _hostingEnvironment.WebRootPath;
        string dataPath = string.Empty;
        dataPath = basePath + @"/PDF/";

        string dataPath1 = dataPath + "BorderTemplate.pdf";
        string dataPath2 = dataPath + "SourceTemplate.pdf";

        Stream stream1 = new FileStream(dataPath2, FileMode.Open, FileAccess.Read);
        FileStream file = new FileStream(dataPath1, FileMode.Open, FileAccess.Read, FileShare.Read);
        PdfLoadedDocument ldDoc1 = new PdfLoadedDocument(file);
        PdfLoadedDocument ldDoc2 = new PdfLoadedDocument(stream1);
        PdfDocument doc = new PdfDocument();

        for (int i = 0, count = ldDoc2.Pages.Count; i < count; ++i)
        {
            PdfPage page = doc.Pages.Add();
            PdfGraphics g = page.Graphics;

            PdfPageBase lpage = ldDoc2.Pages[i];
            PdfTemplate template = lpage.CreateTemplate();

            g.DrawPdfTemplate(template, PointF.Empty, page.GetClientSize());

            lpage = ldDoc1.Pages[0];
            template = lpage.CreateTemplate();

            g.DrawPdfTemplate(template, PointF.Empty, page.GetClientSize());
        }
        MemoryStream stream = new MemoryStream();

        //Save the PDF document
        doc.Save(stream);

        stream.Position = 0;

        //Close the PDF document
        doc.Close(true);

        //Download the PDF document in the browser.
        FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
        fileStreamResult.FileDownloadName = "Overlay.pdf";
        return fileStreamResult;
    }
}