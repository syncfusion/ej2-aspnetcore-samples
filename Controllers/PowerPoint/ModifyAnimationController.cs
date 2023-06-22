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

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class PowerPointController : Controller
    {
        public IActionResult ModifyAnimation()
        {
            return View();
        }
    
        [HttpPost]
        public ActionResult ModifyAnimation(string button)
        {
            if (button == null)
                return View();
            string basePath = _hostingEnvironment.WebRootPath;
            if (button.Trim() == "Input Template")
		    {
		    
            FileStream fileStreamInput = new FileStream(basePath + @"/PowerPoint/ShapeWithAnimation.pptx", FileMode.Open, FileAccess.Read);
            IPresentation presentation = Presentation.Open(fileStreamInput);
			MemoryStream ms = new MemoryStream();

            //Saves the presentation to the memory stream.
            presentation.Save(ms);
            //Set the position of the stream to beginning.
            ms.Position = 0;
			return File(ms, "application/vnd.openxmlformats-officedocument.presentationml.presentation","ShapeWithAnimation.pptx");
		    }
		else
		{
            FileStream fileStreamInput = new FileStream(basePath + @"/PowerPoint/ShapeWithAnimation.pptx", FileMode.Open, FileAccess.Read);
            IPresentation presentation = Presentation.Open(fileStreamInput);
            //New Instance of PowerPoint is Created.[Equivalent to launching MS PowerPoint with no slides].

            //Modify the existing animation
            ModifyAnimation(presentation);

            MemoryStream ms = new MemoryStream();

            //Saves the presentation to the memory stream.
            presentation.Save(ms);
            //Set the position of the stream to beginning.
            ms.Position = 0;

            //Initialize the file stream to download the presentation.
            FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/vnd.openxmlformats-officedocument.presentationml.presentation");
            //Set the file name.
            fileStreamResult.FileDownloadName = "ModifyAnimation.pptx";

            return fileStreamResult;
        }
		}

        #region Modify Animation

        private void ModifyAnimation(IPresentation presentation)
        {
            //Retrieves the slide instance
            ISlide slide = presentation.Slides[0];
            //Retrieves the slide main sequence
            ISequence sequence = slide.Timeline.MainSequence;
            //Retrieves the existing animation effect from the main sequence
            IEffect loopEffect = sequence[0];
            //Change the type of the existing animation effect
            loopEffect.Type = EffectType.Bounce;
        }
        #endregion
    }
}
