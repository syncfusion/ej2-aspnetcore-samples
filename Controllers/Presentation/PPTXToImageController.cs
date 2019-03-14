#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Syncfusion.Presentation;
using Microsoft.AspNetCore.Hosting;
using Syncfusion.PresentationRenderer;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class PresentationController : Controller
    {
        public IActionResult PPTXToImage()
        {
            return View();
        }
    
        [HttpPost]
        public ActionResult PPTXToImage(string Browser, string view)
        {
            string basePath = _hostingEnvironment.WebRootPath;
			if (view.Trim() == "INPUT TEMPLATE")
		    {
		    
            FileStream fileStreamInput = new FileStream(basePath + @"/Presentation/Template.pptx", FileMode.Open, FileAccess.Read);
            IPresentation presentation = Presentation.Open(fileStreamInput);
			MemoryStream ms = new MemoryStream();

            //Saves the presentation to the memory stream.
            presentation.Save(ms);
            //Set the position of the stream to beginning.
            ms.Position = 0;
			return File(ms, "application/vnd.openxmlformats-officedocument.presentationml.presentation","InputTemplate.pptx");
		    }
			else
			{
            FileStream fileStreamInput = new FileStream(basePath + @"/Presentation/Template.pptx", FileMode.Open, FileAccess.Read);
			//Open the existing PowerPoint  presentation.
			IPresentation presentation = Presentation.Open(fileStreamInput);

            //Initialize PresentationRenderer to perform image conversion.
            presentation.PresentationRenderer = new PresentationRenderer();

            //Convert PowerPoint slide to image stream.
            Stream stream = presentation.Slides[0].ConvertToImage(ExportImageFormat.Jpeg);

            //Reset the stream position
            stream.Position = 0;           

            //Close the PowerPoint Presentation.
            presentation.Close();

            //Initialize the file stream to download the converted image.
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "image/jpeg");
            //Set the file name.
            fileStreamResult.FileDownloadName = "Slide1.jpg";

            return fileStreamResult;
			}
        }
    }
}
