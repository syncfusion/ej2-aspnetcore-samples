#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace EJ2CoreSampleBrowser.Pages.Sankey
{
    public class PrintExportModel : PageModel
    {
        public class SankeyNode
        {
            public string Id { get; set; } = "";
            public string? Color { get; set; }
        }

        public class SankeyLink
        {
            public string SourceId { get; set; } = "";
            public string TargetId { get; set; } = "";
            public double Value { get; set; }
        }

        public List<SankeyNode> Nodes { get; set; } = new();
        public List<SankeyLink> Links { get; set; } = new();

        public void OnGet()
        {
            Nodes = new()
            {
                // Goods Type (Blue - Column 1)
                new SankeyNode { Id = "Books" },
                new SankeyNode { Id = "Clothing" },
                new SankeyNode { Id = "Electronics" },
                new SankeyNode { Id = "Furniture" },
                new SankeyNode { Id = "Jewelry" },
                new SankeyNode { Id = "Toys" },

                // Shipping Method (Teal/Cyan - Column 2)
                new SankeyNode { Id = "Air" },
                new SankeyNode { Id = "Ground" },
                new SankeyNode { Id = "Sea" },

                // Destination Region (Pink/Red - Column 3)
                new SankeyNode { Id = "Asia" },
                new SankeyNode { Id = "Europe" },
                new SankeyNode { Id = "North America" },
                new SankeyNode { Id = "South America" },

                // Delivery Status (Yellow/Orange - Column 4)
                new SankeyNode { Id = "Delayed" },
                new SankeyNode { Id = "Delivered" },
                new SankeyNode { Id = "In Transit" }
            };

            Links = new()
            {
                // Level 1: Goods Type -> Shipping Method
                new SankeyLink { SourceId = "Books",        TargetId = "Air",            Value = 18 },
                new SankeyLink { SourceId = "Books",        TargetId = "Ground",         Value = 12 },
                new SankeyLink { SourceId = "Clothing",     TargetId = "Air",            Value = 25 },
                new SankeyLink { SourceId = "Clothing",     TargetId = "Ground",         Value = 15 },
                new SankeyLink { SourceId = "Clothing",     TargetId = "Sea",            Value = 20 },
                new SankeyLink { SourceId = "Electronics",  TargetId = "Air",            Value = 35 },
                new SankeyLink { SourceId = "Electronics",  TargetId = "Ground",         Value = 22 },
                new SankeyLink { SourceId = "Electronics",  TargetId = "Sea",            Value = 18 },
                new SankeyLink { SourceId = "Furniture",    TargetId = "Ground",         Value = 28 },
                new SankeyLink { SourceId = "Furniture",    TargetId = "Sea",            Value = 25 },
                new SankeyLink { SourceId = "Jewelry",      TargetId = "Air",            Value = 12 },
                new SankeyLink { SourceId = "Jewelry",      TargetId = "Ground",         Value = 8  },
                new SankeyLink { SourceId = "Toys",         TargetId = "Ground",         Value = 15 },
                new SankeyLink { SourceId = "Toys",         TargetId = "Sea",            Value = 22 },

                // Level 2: Shipping Method -> Destination Region
                new SankeyLink { SourceId = "Air",          TargetId = "Asia",           Value = 40 },
                new SankeyLink { SourceId = "Air",          TargetId = "Europe",         Value = 30 },
                new SankeyLink { SourceId = "Air",          TargetId = "North America",  Value = 20 },
                new SankeyLink { SourceId = "Ground",       TargetId = "Europe",         Value = 35 },
                new SankeyLink { SourceId = "Ground",       TargetId = "North America",  Value = 30 },
                new SankeyLink { SourceId = "Ground",       TargetId = "South America",  Value = 15 },
                new SankeyLink { SourceId = "Ground",       TargetId = "Asia",           Value = 20 },
                new SankeyLink { SourceId = "Sea",          TargetId = "Asia",           Value = 25 },
                new SankeyLink { SourceId = "Sea",          TargetId = "Europe",         Value = 15 },
                new SankeyLink { SourceId = "Sea",          TargetId = "North America",  Value = 30 },
                new SankeyLink { SourceId = "Sea",          TargetId = "South America",  Value = 15 },

                // Level 3: Destination Region -> Delivery Status
                new SankeyLink { SourceId = "Asia",         TargetId = "Delayed",        Value = 35 },
                new SankeyLink { SourceId = "Asia",         TargetId = "Delivered",      Value = 40 },
                new SankeyLink { SourceId = "Asia",         TargetId = "In Transit",     Value = 10 },
                new SankeyLink { SourceId = "Europe",       TargetId = "Delivered",      Value = 65 },
                new SankeyLink { SourceId = "Europe",       TargetId = "In Transit",     Value = 15 },
                new SankeyLink { SourceId = "North America",TargetId = "Delivered",      Value = 50 },
                new SankeyLink { SourceId = "North America",TargetId = "In Transit",     Value = 30 },
                new SankeyLink { SourceId = "South America",TargetId = "Delayed",        Value = 10 },
                new SankeyLink { SourceId = "South America",TargetId = "In Transit",     Value = 20 }
            };
        }
    }
}