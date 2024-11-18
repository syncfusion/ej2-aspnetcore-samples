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

public class ModifyAnimation : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public ModifyAnimation(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }
    public ActionResult OnPost(string button)
    {
        if (button == null)
            return null;
            // return View();
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
            ModifyAnimations(presentation);

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

    private void ModifyAnimations(IPresentation presentation)
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
