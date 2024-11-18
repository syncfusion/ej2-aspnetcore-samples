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

public class SlideTransition : PageModel
{
    public void OnGet()
    {

    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public SlideTransition(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }
    [HttpPost]
    public ActionResult OnPost(string button)
    {
        if (button == null)
            return null;
            // return View();
        //Opens the presentation document as stream
        string basePath = _hostingEnvironment.WebRootPath;
        FileStream fileStreamInput =
            new FileStream(basePath + @"/PowerPoint/Transition.pptx", FileMode.Open, FileAccess.Read);
        IPresentation presentation = Presentation.Open(fileStreamInput);
        //PowerPoint instance is Created.

        //Method call to create transition in slides
        CreateTransition(presentation);

        MemoryStream ms = new MemoryStream();

        //Saves the presentation to the memory stream.
        presentation.Save(ms);
        //Set the position of the stream to beginning.
        ms.Position = 0;

        //Initialize the file stream to download the presentation.
        FileStreamResult fileStreamResult = new FileStreamResult(ms,
            "application/vnd.openxmlformats-officedocument.presentationml.presentation");
        //Set the file name.
        fileStreamResult.FileDownloadName = "SlideTransition.pptx";

        return fileStreamResult;
    }

    #region Slide1

    private void CreateTransition(IPresentation presentation)
    {
        //Get the first slide from the presentation
        ISlide slide1 = presentation.Slides[0];

        // Add the 'Wheel' transition effect to the first slide
        slide1.SlideTransition.TransitionEffect = TransitionEffect.Wheel;

        // Get the second slide from the presentation
        ISlide slide2 = presentation.Slides[1];

        // Add the 'Checkerboard' transition effect to the second slide
        slide2.SlideTransition.TransitionEffect = TransitionEffect.Checkerboard;

        // Add the subtype to the transition effect
        slide2.SlideTransition.TransitionEffectOption = TransitionEffectOption.Across;

        // Apply the value to transition mouse on click parameter
        slide2.SlideTransition.TriggerOnClick = true;

        // Get the third slide from the presentation
        ISlide slide3 = presentation.Slides[2];

        // Add the 'Orbit' transition effect for slide
        slide3.SlideTransition.TransitionEffect = TransitionEffect.Orbit;

        // Add the speed for transition
        slide3.SlideTransition.Speed = TransitionSpeed.Fast;

        // Get the fourth slide from the presentation
        ISlide slide4 = presentation.Slides[3];

        // Add the 'Uncover' transition effect to the slide
        slide4.SlideTransition.TransitionEffect = TransitionEffect.Uncover;

        // Apply the value to advance on time for slide
        slide4.SlideTransition.TriggerOnTimeDelay = true;

        // Assign the advance on time value
        slide4.SlideTransition.TimeDelay = 5;

        // Get the fifth slide from the presentation
        ISlide slide5 = presentation.Slides[4];

        // Add the 'PageCurlDouble' transition effect to the slide
        slide5.SlideTransition.TransitionEffect = TransitionEffect.PageCurlDouble;

        // Add the duration value for the transition effect
        slide5.SlideTransition.Duration = 5;
    }
    #endregion
}