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

namespace EJ2CoreSampleBrowser_NET8.Pages.PowerPoint;

public class EncryptAndDecrypt : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;

    public EncryptAndDecrypt(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }
    [HttpPost]
    public ActionResult OnPost(string button, string Group1, string Group2)
    {
        if (button == null)
            return null;
            // return View();
        string basePath = _hostingEnvironment.WebRootPath;
        FileStream fileStreamInput = new FileStream(basePath + @"/PowerPoint/Syncfusion Presentation.pptx", FileMode.Open, FileAccess.Read);
        if (Group1 == "CreateEncryptDoc")
        {
            IPresentation presentation = Presentation.Open(fileStreamInput);
            presentation.Encrypt("syncfusion");
            MemoryStream ms = new MemoryStream();
            //Saves the presentation to the memory stream.
            presentation.Save(ms);
            //Set the position of the stream to beginning.
            ms.Position = 0;
            return File(ms, "application/vnd.openxmlformats-officedocument.presentationml.presentation", "Encryption.pptx");
        }
        else
        {
            IPresentation presentation = Presentation.Open(fileStreamInput);
            presentation.RemoveEncryption();
            MemoryStream ms = new MemoryStream();
            //Saves the presentation to the memory stream.
            presentation.Save(ms);
            //Set the position of the stream to beginning.
            ms.Position = 0;
            //Initialize the file stream to download the presentation.
            FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/vnd.openxmlformats-officedocument.presentationml.presentation");
            //Set the file name.
            fileStreamResult.FileDownloadName = "Decryption.pptx";
            return fileStreamResult;
        }
    }
}