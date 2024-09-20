#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser_NET8.Pages.Toast;

public class API : PageModel
{
    public List<dropData> easingData = new List<dropData>();
    public List<dropData> directionData = new List<dropData>();
    public List<dropData> animationData = new List<dropData>();
    public void OnGet()
    {
        easingData.Add(new dropData { Id = "ease", Value = "Ease" });
        easingData.Add(new dropData { Id = "linear", Value = "Linear" });
        
        directionData.Add(new dropData { Id = "Rtl", Value = "Right to Left" });
        directionData.Add(new dropData { Id = "Ltr", Value = "Left to Right" });
        
        animationData.Add(new dropData { Id = "SlideBottomIn", Value = "Slide Bottom In" });
        animationData.Add(new dropData { Id = "FadeIn", Value = "Fade In" });
        animationData.Add(new dropData { Id = "FadeZoomIn", Value = "Fade Zoom In" });
        animationData.Add(new dropData { Id = "FadeZoomOut", Value = "Fade Zoom Out" });
        animationData.Add(new dropData { Id = "FlipLeftDownIn", Value = "Flip Left Down In" });
        animationData.Add(new dropData { Id = "FlipLeftDownOut", Value = "Flip Left Down Out" });
        animationData.Add(new dropData { Id = "FlipLeftUpIn", Value = "Flip Left Up In" });
        animationData.Add(new dropData { Id = "FlipLeftUpOut", Value = "Flip Left Up Out" });
        animationData.Add(new dropData { Id = "FlipRightDownIn", Value = "Flip Right Down In" });
        animationData.Add(new dropData { Id = "FlipRightDownOut", Value = "Flip Right Down Out" });
        animationData.Add(new dropData { Id = "FlipRightUpIn", Value = "Flip Right Up In" });
        animationData.Add(new dropData { Id = "FlipRightUpOut", Value = "Flip Right Up Out" });
        animationData.Add(new dropData { Id = "SlideBottomOut", Value = "Slide Bottom Out" });
        animationData.Add(new dropData { Id = "SlideLeftIn", Value = "Slide Left In" });
        animationData.Add(new dropData { Id = "SlideLeftOut", Value = "Slide Left Out" });
        animationData.Add(new dropData { Id = "SlideRightIn", Value = "Slide Right In" });
        animationData.Add(new dropData { Id = "SlideRightOut", Value = "Slide Right Out" });
        animationData.Add(new dropData { Id = "SlideTopIn", Value = "Slide Top In" });
        animationData.Add(new dropData { Id = "SlideTopOut", Value = "Slide Top Out" });
        animationData.Add(new dropData { Id = "ZoomIn", Value = "Zoom In" });
        animationData.Add(new dropData { Id = "ZoomOut", Value = "Zoom Out" });
    }
}
public class dropData
{
    public string Id { get; set; }
    public string Value { get; set; }

}