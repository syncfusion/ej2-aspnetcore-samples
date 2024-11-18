#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Presentation;

namespace EJ2CoreSampleBrowser.Pages.PowerPoint;

public class HeaderAndFooter : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;

    public HeaderAndFooter(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }
    [HttpPost]
    public ActionResult OnPost(string button)
    {
        if (button == null)
            return null;
            // return View();
        //Opens the presentation document as stream
        string basePath = _hostingEnvironment.WebRootPath;
        FileStream fileStreamInput =
            new FileStream(basePath + @"/PowerPoint/HeaderFooter.pptx", FileMode.Open, FileAccess.Read);
        IPresentation presentation = Presentation.Open(fileStreamInput);

        //Add footers into all the PowerPoint slides.
        foreach (ISlide slide in presentation.Slides)
        {
            //Enable a date and time footer in slide.
            slide.HeadersFooters.DateAndTime.Visible = true;
            //Enable a footer in slide.
            slide.HeadersFooters.Footer.Visible = true;
            //Sets the footer text.
            slide.HeadersFooters.Footer.Text = "Footer";
            //Enable a slide number footer in slide.
            slide.HeadersFooters.SlideNumber.Visible = true;
        }

        //Add header into first slide notes page.
        //Add a notes slide to the slide.
        INotesSlide notesSlide = presentation.Slides[0].AddNotesSlide();
        //Enable a header in notes slide.
        notesSlide.HeadersFooters.Header.Visible = true;
        //Sets the header text.
        notesSlide.HeadersFooters.Header.Text = "Header";

        MemoryStream ms = new MemoryStream();

        //Saves the presentation to the memory stream.
        presentation.Save(ms);
        //Set the position of the stream to beginning.
        ms.Position = 0;

        //Initialize the file stream to download the presentation.
        FileStreamResult fileStreamResult = new FileStreamResult(ms,
            "application/vnd.openxmlformats-officedocument.presentationml.presentation");
        //Set the file name.
        fileStreamResult.FileDownloadName = "HeaderFooter.pptx";

        return fileStreamResult;
    }
}