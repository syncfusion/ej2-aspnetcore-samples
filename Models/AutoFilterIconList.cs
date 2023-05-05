#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web;

namespace EJ2CoreSampleBrowser.Models
{
    public class AutoFilterIconList
    {
    }

    public class icons
    {
        public string iconId { get; set; }
        public string image { get; set; }
        public static List<icons> GetSymbols()
        {
            List<icons> iconList = new List<icons>();
            iconList.Add(new icons { iconId = "1", image = "CF_IS_RedCrossSymbol" });
            iconList.Add(new icons { iconId = "2", image = "CF_IS_YellowExclamationSymbol" });
            iconList.Add(new icons { iconId = "3", image = "CF_IS_GreenCheckSymbol" });
            iconList.Add(new icons { iconId = "NoIcon", image = "NoIcon" });
            return iconList;
        }
        public static List<icons> GetRating()
        {
            List<icons> iconList = new List<icons>();
            iconList.Add(new icons { iconId = "1", image = "CF_IS_SignalWithOneFillBar" });
            iconList.Add(new icons { iconId = "2", image = "CF_IS_SignalWithTwoFillBars" });
            iconList.Add(new icons { iconId = "3", image = "CF_IS_SignalWithThreeFillBars" });
            iconList.Add(new icons { iconId = "4", image = "CF_IS_SignalWithFourFillBars" });
            iconList.Add(new icons { iconId = "NoIcon", image = "NoIcon" });
            return iconList;
        }
        public static List<icons> GetArrows()
        {
            List<icons> iconList = new List<icons>();
            iconList.Add(new icons { iconId = "1", image = "CF_IS_RedDownArrow" });
            iconList.Add(new icons { iconId = "2", image = "CF_IS_YellowDownInclineArrow" });
            iconList.Add(new icons { iconId = "3", image = "CF_IS_YellowSideArrow" });
            iconList.Add(new icons { iconId = "4", image = "CF_IS_YellowUpInclineArrow" });
            iconList.Add(new icons { iconId = "5", image = "CF_IS_GreenUpArrow" });
            iconList.Add(new icons { iconId = "NoIcon", image = "NoIcon" });
            return iconList;
        }
    }
}