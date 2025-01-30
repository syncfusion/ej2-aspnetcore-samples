#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Presentation;

namespace EJ2CoreSampleBrowser.Pages.PowerPoint;

public class OLEObject : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;

    public OLEObject(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }
    [HttpPost]
    public ActionResult OnPost(string button)
    {
        if (button == null)
            return null;
            // return View();
        string basePath = _hostingEnvironment.WebRootPath;
        if (button.Trim() == "Create Presentation")
        {
            //New Instance of PowerPoint is Created.[Equivalent to launching MS PowerPoint with no slides].
            IPresentation presentation = Presentation.Create();

            ISlide slide = presentation.Slides.Add(SlideLayoutType.TitleOnly);

            IShape titleShape = slide.Shapes[0] as IShape;
            titleShape.Left = 0.65 * 72;
            titleShape.Top = 0.24 * 72;
            titleShape.Width = 11.5 * 72;
            titleShape.Height = 1.45 * 72;
            titleShape.TextBody.AddParagraph("Ole Object");
            titleShape.TextBody.Paragraphs[0].Font.Bold = true;
            titleShape.TextBody.Paragraphs[0].HorizontalAlignment = HorizontalAlignmentType.Left;

            IShape heading = slide.Shapes.AddTextBox(0.84 * 72, 1.65 * 72, 2.23 * 72, 0.51 * 72);
            heading.Left = 3.2 * 72;
            heading.Top = 1.51 * 72;
            heading.Width = 1.86 * 72;
            heading.Height = 0.71 * 72;
            heading.TextBody.AddParagraph("MS Word Object");
            heading.TextBody.Paragraphs[0].Font.Italic = true;
            heading.TextBody.Paragraphs[0].Font.Bold = true;
            heading.TextBody.Paragraphs[0].Font.FontSize = 18;

            string mswordPath = basePath + @"/PowerPoint/OleTemplate.docx";
            //Get the word document as stream
            Stream wordStream = new FileStream(mswordPath, FileMode.Open);
            string imagePath = basePath + @"/PowerPoint/OlePicture.png";
            //Image to be displayed, This can be any image
            Stream imageStream = new FileStream(imagePath, FileMode.Open);

            IOleObject oleObject = slide.Shapes.AddOleObject(imageStream, "Word.Document.12", wordStream);
            //Set size and position of the ole object
            oleObject.Left = 4.53 * 72;
            oleObject.Top = 0.79 * 72;
            oleObject.Width = 4.26 * 72;
            oleObject.Height = 5.92 * 72;

            MemoryStream ms = new MemoryStream();

            //Saves the presentation to the memory stream.
            presentation.Save(ms);
            //Set the position of the stream to beginning.
            ms.Position = 0;
            //Dispose the streams.
            wordStream.Dispose();
            imageStream.Dispose();
            return File(ms, "application/vnd.openxmlformats-officedocument.presentationml.presentation",
                "InsertOLEObject.pptx");
        }
        else
        {
            FileStream fileStreamInput = new FileStream(basePath + @"/PowerPoint/EmbeddedOleObject.pptx", FileMode.Open,
                FileAccess.Read);
            IPresentation pptxDoc = Presentation.Open(fileStreamInput);
            //New Instance of PowerPoint is Created.[Equivalent to launching MS PowerPoint with no slides].

            //Gets the first slide of the Presentation
            ISlide slide = pptxDoc.Slides[0];
            //Gets the Ole Object of the slide
            IOleObject oleObject = slide.Shapes[2] as IOleObject;
            //Gets the file data of embedded Ole Object.
            byte[] array = oleObject.ObjectData;
            //Gets the file Name of OLE Object
            string outputFile = oleObject.FileName;

            MemoryStream ms = new MemoryStream(array);

            //Initialize the file stream to download the presentation.
            FileStreamResult fileStreamResult = new FileStreamResult(ms,
                "application/vnd.openxmlformats-officedocument.presentationml.presentation");
            //Set the file name.
            fileStreamResult.FileDownloadName = outputFile;

            return fileStreamResult;
        }
    }
}