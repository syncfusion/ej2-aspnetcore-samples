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
using System.Text.RegularExpressions;

namespace EJ2CoreSampleBrowser.Pages.PowerPoint;

public class FindAndReplace : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;

    public FindAndReplace(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }
    [HttpPost]
    public ActionResult OnPost(string button, string matchCase, string matchWholeWord,
        string findText, string findTextUsingRegex, string findUsing, string replaceText, string replaceFirst)
    {
        if (button == null)
            return null;
            // return View();
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
                ITextSelection textSelection = null;
                if (findUsing == "0")
                {
                    //Finds the first occurrence of a particular text
                    textSelection = presentation.Find(findText, matchCase == "MatchCase",
                        matchWholeWord == "MatchWholeWord");
                }
                else
                {
                    Regex regex = new Regex(findTextUsingRegex);
                    //Finds the first occurrence of a particular text
                    textSelection = presentation.Find(regex);
                }

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
                ITextSelection[] textSelections = null;
                if (findUsing == "0")
                {
                    //Finds the first occurrence of a particular text
                    textSelections = presentation.FindAll(findText, matchCase == "MatchCase",
                        matchWholeWord == "MatchWholeWord");
                }
                else
                {
                    Regex regex = new Regex(findTextUsingRegex);
                    //Finds the first occurrence of a particular text
                    textSelections = presentation.FindAll(regex);
                }

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
            FileStreamResult fileStreamResult = new FileStreamResult(ms,
                "application/vnd.openxmlformats-officedocument.presentationml.presentation");
            //Set the file name.
            fileStreamResult.FileDownloadName = "FindandReplace.pptx";

            return fileStreamResult;
        }
        catch (Exception)
        {
        }

        return null;
        // return View();
    }
}