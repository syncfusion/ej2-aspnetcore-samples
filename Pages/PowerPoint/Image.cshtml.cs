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

public class Image : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;

    public Image(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }
    [HttpPost]
    public ActionResult OnPost(string button)
    {
        if (button == null)
            return null;
            // return View();
        //Create an instance of PowerPoint.
        IPresentation pptxDoc = Presentation.Create();
        //Add a blank slide to Presentation.
        ISlide firstSlide = pptxDoc.Slides.Add(SlideLayoutType.Blank);

        //Add a title text box to the slide.
        IShape titleShape = firstSlide.Shapes.AddTextBox(55, 23, 853, 72);
        //Set vertical alignment to the text body.
        titleShape.TextBody.VerticalAlignment = VerticalAlignmentType.Bottom;
        //Add a title paragraph.
        IParagraph titleParagraph = titleShape.TextBody.AddParagraph();
        //Set the alignment properties for the paragraph.
        titleParagraph.HorizontalAlignment = HorizontalAlignmentType.Center;
        //Add a text part.
        ITextPart titleTextPart = titleParagraph.AddTextPart("Adventure Works Cycles");
        //Set the font properties for the text part.
        titleTextPart.Font.FontSize = 36;

        //Add a content text box to the slide.
        IShape textbox = firstSlide.Shapes.AddTextBox(66, 132, 543, 350);
        //Add the first paragraph.
        IParagraph paragraph1 = textbox.TextBody.AddParagraph();
        //Set bulleted list type.
        paragraph1.ListFormat.Type = ListType.Bulleted;
        //Set paragraph properties.
        paragraph1.LeftIndent = 22;
        paragraph1.FirstLineIndent = -22;
        paragraph1.LineSpacing = 38;
        paragraph1.SpaceBefore = 10;
        //Add a new text part.
        paragraph1.AddTextPart(
            "Adventure Works Cycles, the fictitious company on which the Adventure Works sample databases are based, is a large, multinational manufacturing company.");

        //Add the second paragraph.
        IParagraph paragraph2 = textbox.TextBody.AddParagraph();
        //Set bulleted list type.
        paragraph2.ListFormat.Type = ListType.Bulleted;
        //Set paragraph properties.
        paragraph2.LeftIndent = 22;
        paragraph2.FirstLineIndent = -22;
        paragraph2.LineSpacing = 38;
        paragraph2.SpaceBefore = 10;
        //Add a new text part.
        paragraph2.AddTextPart(
            "The company manufactures and sells metal and composite bicycles to North American, European, and Asian commercial markets. While its base operation is located in Bothell, Washington, with 290 employees, several regional sales teams are located throughout their market base.");
        string basePath = _hostingEnvironment.WebRootPath;
        //Create an instance for the image as a stream.
        FileStream imageStream =
            new FileStream(basePath + @"/PowerPoint/CycleLogo.jpg", FileMode.Open, FileAccess.Read);
        //Add a picture to the shape collection.
        IPicture picture = firstSlide.Shapes.AddPicture(imageStream, 610, 246, 328, 123);
        //Add alternate text to the picture.
        picture.Description = "Adventure Works Cycles Logo";
        //Apply bounding box size and position.
        picture.Crop.ContainerWidth = 328f;
        picture.Crop.ContainerHeight = 123f;
        picture.Crop.ContainerLeft = 609f;
        picture.Crop.ContainerTop = 246f;
        //Apply cropping size and offsets.
        picture.Crop.Width = 370f;
        picture.Crop.Height = 151f;
        picture.Crop.OffsetX = -4.32f;
        picture.Crop.OffsetY = 1.44f;

        //Add a title-only slide to Presentation.
        ISlide secondSlide = pptxDoc.Slides.Add(SlideLayoutType.TitleOnly);
        //Retrieve the first shape of the slide.
        IShape titleShape2 = secondSlide.Shapes[0] as IShape;
        //Add a title paragraph.
        IParagraph titleParagraph2 = titleShape2.TextBody.AddParagraph();
        //Set the alignment properties for the paragraph.
        titleParagraph2.HorizontalAlignment = HorizontalAlignmentType.Center;
        //Add a text part.
        ITextPart titleTextPart2 = titleParagraph2.AddTextPart("About Adventure Works Cycles");
        //Set the font properties for the text part.
        titleTextPart2.Font.FontName = "Calibri";
        titleTextPart2.Font.FontSize = 40;

        //Get an SVG image as a stream.
        FileStream svgImageStream = new FileStream(basePath + @"/PowerPoint/About.svg", FileMode.Open, FileAccess.Read);
        //Get a fallback image as a stream.
        FileStream fallbackImageStream =
            new FileStream(basePath + @"/PowerPoint/About.png", FileMode.Open, FileAccess.Read);
        //Add the SVG picture to a slide by specifying its size and position.
        IPicture svgPicture = secondSlide.Pictures.AddPicture(svgImageStream, fallbackImageStream, 172, 155, 643, 256);
        //Add alternate text to the picture.
        svgPicture.Description = "About Adventure Works Cycles";

        //Close the image streams.
        imageStream.Close();
        svgImageStream.Close();
        fallbackImageStream.Close();
        MemoryStream ms = new MemoryStream();

        //Saves the presentation to the memory stream.
        pptxDoc.Save(ms);
        //Set the position of the stream to beginning.
        ms.Position = 0;
        //Close the Presentation.
        pptxDoc.Close();
        //Initialize the file stream to download the presentation.
        FileStreamResult fileStreamResult = new FileStreamResult(ms,
            "application/vnd.openxmlformats-officedocument.presentationml.presentation");
        //Set the file name.
        fileStreamResult.FileDownloadName = "Images.pptx";

        return fileStreamResult;
    }
}