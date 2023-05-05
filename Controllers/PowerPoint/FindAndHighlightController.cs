#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Syncfusion.Presentation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class PowerPointController : Controller
    {
        public ActionResult FindAndHighlight()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindAndHighlight(string button, string Group, string matchCase, string matchWholeWord, string highlightFirst)
        {
            if (button == null)
                return View();
            //Retrieve the current application environment.
            //Open the existing presentation.
            string basePath = _hostingEnvironment.WebRootPath;
            string dataPath = basePath + @"/PowerPoint/Input Template.pptx";
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
                    ITextSelection textSelection = presentation.Find(Group, matchCase == "MatchCase", matchWholeWord == "MatchWholeWord");
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
                    ITextSelection[] textSelections = presentation.FindAll(Group, matchCase == "MatchCase", matchWholeWord == "MatchWholeWord");
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

                MemoryStream ms = new MemoryStream();

                //Saves the presentation to the memory stream.
                presentation.Save(ms);
                //Set the position of the stream to beginning.
                ms.Position = 0;

                //Initialize the file stream to download the presentation.
                FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/vnd.openxmlformats-officedocument.presentationml.presentation");
                //Set the file name.
                fileStreamResult.FileDownloadName = "FindandHighlight.pptx";

                return fileStreamResult;
            }
            catch (Exception)
            { }
            return View();
        }
    }
}