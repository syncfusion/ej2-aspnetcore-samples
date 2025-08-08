#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class ColorsData
    {
        public string Color { get; set; }
        public string Code { get; set; }
        public List<ColorsData> GetColorsData()
        {
            List<ColorsData> color = new List<ColorsData>();
            color.Add( new ColorsData { Color= "Chocolate", Code = "#75523C" });
            color.Add( new ColorsData { Color= "CadetBlue", Code = "#3B8289" });
            color.Add( new ColorsData { Color= "DarkOrange", Code = "#FF843D" });
            color.Add( new ColorsData { Color= "DarkRed", Code = "#CA3832" });
            color.Add( new ColorsData { Color= "Fuchsia", Code = "#D44FA3" });
            color.Add( new ColorsData { Color= "HotPink", Code = "#F23F82" });
            color.Add( new ColorsData { Color= "Indigo", Code = "#2F5D81" });
            color.Add( new ColorsData { Color= "LimeGreen", Code = "#4CD242" });
            color.Add( new ColorsData { Color= "OrangeRed", Code = "#FE2A00" });
            color.Add( new ColorsData { Color = "Tomato", Code = "#FF745C" });
            return color;
        }
    }
}
