#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Syncfusion.Presentation;
using Microsoft.AspNetCore.Hosting;
using Syncfusion.OfficeChart;
using Syncfusion.Drawing;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class PowerPointController : Controller
    {
        public IActionResult WriteProtection()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriteProtection(string Browser, string Password)
        {
            string basePath = _hostingEnvironment.WebRootPath;
            FileStream fileStreamInput = new FileStream(basePath + @"/PowerPoint/Syncfusion Presentation.pptx", FileMode.Open, FileAccess.Read);
            //Open a existing PowerPoint presentation.
            IPresentation presentation = Presentation.Open(fileStreamInput);

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
}
