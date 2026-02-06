#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using EJ2CoreSampleBrowser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class Animation
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public List<Animation> AnimationOptions()
        {
            List<Animation> animationList = new List<Animation>();
            animationList.Add(new Animation { Name = "Fade zoom", Value = "FadeZoom" });
            animationList.Add(new Animation { Name = "Slide bottom", Value = "SlideBottom" });
            animationList.Add(new Animation { Name = "Slide top", Value = "SlideTop" });
            animationList.Add(new Animation { Name = "Zoom", Value = "Zoom" });
            animationList.Add(new Animation { Name = "Fade", Value = "Fade" });
            return animationList;
        }
    }

}
    

