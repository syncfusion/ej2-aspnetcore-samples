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
    public class Position
    {
        public string Value { get; set; }
        public List<Position> Positions()
        {
            List<Position> position = new List<Position>();
            position.Add(new Position { Value = "Top Left" });
            position.Add(new Position { Value = "Top Right" });
            position.Add(new Position { Value = "Top Center" });
            position.Add(new Position { Value = "Top Full Width" });
            position.Add(new Position { Value = "Bottom Left" });
            position.Add(new Position { Value = "Bottom Right" });
            position.Add(new Position { Value = "Bottom Center" });
            position.Add(new Position { Value = "Bottom Full Width" });
            return position;
        }
    }

}
