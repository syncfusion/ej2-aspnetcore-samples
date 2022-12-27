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
        public ActionResult FindAndReplace()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindAndReplace(string button, string matchCase, string matchWholeWord,
            string findText, string replaceText, string replaceFirst)
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
                //Replaces only the first occurrence of the text
                if (replaceFirst == "ReplaceFirst")
                {
                    //Finds the first occurrence of a particular text
                    ITextSelection textSelection = presentation.Find(findText, matchCase == "MatchCase", matchWholeWord == "MatchWholeWord");
                    if (textSelection != null)
                    {
                    //Gets the found text as single text part
                    ITextPart textPart = textSelection.GetAsOneTextPart();
                    //Replace the text
                    textPart.Text = replaceText;
                    }
                }
                else
                {
                    //Finds all the occurrences of a particular text
                    ITextSelection[] textSelections = presentation.FindAll(findText, matchCase == "MatchCase", matchWholeWord == "MatchWholeWord");
                    if (textSelections != null)
                    {
                    foreach (ITextSelection textSelection in textSelections)
                    {
                        //Gets the found text as single text part
                        ITextPart textPart = textSelection.GetAsOneTextPart();
                        //Replace the text
                        textPart.Text = replaceText;
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
                fileStreamResult.FileDownloadName = "FindandReplace.pptx";

                return fileStreamResult;
            }
            catch (Exception)
            { }
            return View();
        }
    }
}