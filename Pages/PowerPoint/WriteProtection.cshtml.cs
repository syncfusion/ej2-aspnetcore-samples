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

public class WriteProtection : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;

    public WriteProtection(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }
    [HttpPost]
    public ActionResult OnPost(string button, string Password)
    {
        if (button == null)
            return null;
            // return View();
        string basePath = _hostingEnvironment.WebRootPath;
        //Open a existing PowerPoint presentation.
        IPresentation presentation = Presentation.Open(basePath + @"/PowerPoint/Syncfusion Presentation.pptx");

        if (Password == null)
            Password = string.Empty;

        //Set the write protection for presentation instance
        presentation.SetWriteProtection(Password);

        MemoryStream ms = new MemoryStream();

        //Initialize the file stream to download the presentation.
        FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/vnd.openxmlformats-officedocument.presentationml.presentation");
        //Set the file name.
        fileStreamResult.FileDownloadName = "ProtectedPresentation.pptx";

        //Saves the presentation to the memory stream.
        presentation.Save(ms);
        //Set the position of the stream to beginning.
        ms.Position = 0;

        return fileStreamResult;
    }
}