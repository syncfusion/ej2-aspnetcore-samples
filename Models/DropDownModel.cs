#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace EJ2CoreSampleBrowser_NET6.Models
{
    public class DropDownModel
    {
        public object scrollLimits()
        {

            List<object> scrollLimits = new List<object>();

            scrollLimits.Add(new

            {

                text = "Infinity",

                value = "Infinity"

            });

            scrollLimits.Add(new

            {

                text = "Diagram",

                value = "Diagram"

            });

            scrollLimits.Add(new

            {

                text = "Limited",

                value = "Limited"

            });

            return scrollLimits;

        }
    }
}
