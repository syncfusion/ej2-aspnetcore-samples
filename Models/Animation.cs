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
    

