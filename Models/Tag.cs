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
    public class Tag
    {
        public string ID { get; set; }
        public string Text { get; set; }
        public bool State { get; set; }
        public List<Tag> TagDataList()
        {
            List<Tag> tag = new List<Tag>();
            tag.Add(new Tag() { ID = "Item1", Text = "Add to KB", State= false });
            tag.Add(new Tag() { ID = "Item2", Text = "Crisis", State= false });
            tag.Add(new Tag() { ID = "Item3", Text = "Enhancement", State= true });
            tag.Add(new Tag() { ID = "Item4", Text = "Presale", State= false });
            tag.Add(new Tag() { ID = "Item5", Text = "Needs Approval", State= false });
            tag.Add(new Tag() { ID = "Item6", Text = "Approved", State= true });
            tag.Add(new Tag() { ID = "Item7", Text = "Internal Issue", State= true });
            tag.Add(new Tag() { ID = "Item8", Text = "Breaking Issue", State= false });
            tag.Add(new Tag() { ID = "Item9", Text = "New Feature", State= true });
            tag.Add(new Tag() { ID = "Item10", Text = "New Component", State= false });
            tag.Add(new Tag() { ID = "Item11", Text = "Mobile Issue", State= false });

            return tag;
        }
    }

}
