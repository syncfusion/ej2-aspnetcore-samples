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
using Syncfusion.PresentationRenderer;
using Syncfusion.Pdf;

namespace EJ2CoreSampleBrowser_NET8.Pages.PowerPoint;

public class FindAndHighlight : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;

    public FindAndHighlight(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }
    [HttpPost]
    public ActionResult OnPost(string button, string Group, string Group1, string matchCase,
        string matchWholeWord, string highlightFirst)
    {
        if (button == null)
            return null;
            // return View();
        //Retrieve the current application environment.
        //Open the existing presentation.
        string basePath = _hostingEnvironment.WebRootPath;
        string dataPath = basePath + @"/PowerPoint/FindAndHighlightInput.pptx";
        string contenttype = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
        FileStream fileStreamInput = new FileStream(dataPath, FileMode.Open, FileAccess.Read);
        if (button == "View Input Template")
            return File(fileStreamInput, contenttype, "Input Template.pptx");

        try
        {
            IPresentation presentation = Presentation.Open(fileStreamInput);
            fileStreamInput.Dispose();
            fileStreamInput = null;
            //Highlight only the first occurrence of the text
            if (highlightFirst == "HighlightFirst")
            {
                //Finds the first occurrence of a particular text
                ITextSelection textSelection =
                    presentation.Find(Group, matchCase == "MatchCase", matchWholeWord == "MatchWholeWord");
                if (textSelection != null)
                {
                    //Gets the found text containing text parts
                    foreach (ITextPart textPart in textSelection.GetTextParts())
                    {
                        //Sets highlight color
                        textPart.Font.HighlightColor = ColorObject.Yellow;
                    }
                }
            }
            else
            {
                //Finds all the occurrences of a particular text
                ITextSelection[] textSelections =
                    presentation.FindAll(Group, matchCase == "MatchCase", matchWholeWord == "MatchWholeWord");
                if (textSelections != null)
                {
                    foreach (ITextSelection textSelection in textSelections)
                    {
                        //Gets the found text containing text parts
                        foreach (ITextPart textPart in textSelection.GetTextParts())
                        {
                            //Sets highlight color
                            textPart.Font.HighlightColor = ColorObject.Yellow;
                        }
                    }
                }
            }

            string filename = "";
            MemoryStream ms = new MemoryStream();
            if (Group1 == "PPTX")
            {
                filename = "FindandHighlight.pptx";
                contenttype = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                //Saves the presentation to the memory stream.
                presentation.Save(ms);
            }
            else
            {
                filename = "FindandHighlight.pdf";
                contenttype = "application/pdf";
                // Create new instance for PresentationToPdfConverterSettings
                PresentationToPdfConverterSettings settings = new PresentationToPdfConverterSettings();
                //Convert the PowerPoint document to PDF document.
                using (PdfDocument pdfDocument = PresentationToPdfConverter.Convert(presentation, settings))
                    //Save the converted PDF document to Memory stream.
                    pdfDocument.Save(ms);
            }

            //Set the position of the stream to beginning.
            ms.Position = 0;
            //Close the PowerPoint Presentation.
            presentation.Close();
            //Initialize the file stream to download the presentation or PDF.
            FileStreamResult fileStreamResult = new FileStreamResult(ms, contenttype);
            //Set the file name.
            fileStreamResult.FileDownloadName = filename;
            return fileStreamResult;
        }
        catch (Exception)
        {
        }

        return null;
        // return View();
    }
}