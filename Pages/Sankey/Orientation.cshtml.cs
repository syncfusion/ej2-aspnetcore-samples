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
    public class OrientationModel : PageModel
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
                // Sources (top to bottom)
                new SankeyNode { Id = "Transportation" },
                new SankeyNode { Id = "Industry" },
                new SankeyNode { Id = "Commercial" },
                new SankeyNode { Id = "Residential" },
                new SankeyNode { Id = "Agriculture" },

                // Middle sub-processes
                new SankeyNode { Id = "Road (Cars/Trucks)" },
                new SankeyNode { Id = "Aviation & Other Transport" },
                new SankeyNode { Id = "Direct Emissions" },
                new SankeyNode { Id = "Indirect Electricity Use" },

                // Final sink
                new SankeyNode { Id = "Atmosphere (Gross Emissions)" }
            };

            Links = new()
            {
                // Transportation flows
                new SankeyLink { SourceId = "Transportation", TargetId = "Road (Cars/Trucks)", Value = 1482 },
                new SankeyLink { SourceId = "Transportation", TargetId = "Aviation & Other Transport", Value = 326 },

                // Industry flows
                new SankeyLink { SourceId = "Industry", TargetId = "Direct Emissions", Value = 1416 },
                new SankeyLink { SourceId = "Industry", TargetId = "Indirect Electricity Use", Value = 457 },

                // Commercial & Residential → mostly indirect electricity
                new SankeyLink { SourceId = "Commercial", TargetId = "Indirect Electricity Use", Value = 600 },
                new SankeyLink { SourceId = "Residential", TargetId = "Indirect Electricity Use", Value = 500 },

                // Agriculture → direct emissions
                new SankeyLink { SourceId = "Agriculture", TargetId = "Direct Emissions", Value = 664 },

                // Middle → Atmosphere
                new SankeyLink { SourceId = "Road (Cars/Trucks)", TargetId = "Atmosphere (Gross Emissions)", Value = 1482 },
                new SankeyLink { SourceId = "Aviation & Other Transport", TargetId = "Atmosphere (Gross Emissions)", Value = 326 },
                new SankeyLink { SourceId = "Direct Emissions", TargetId = "Atmosphere (Gross Emissions)", Value = 2080 },
                new SankeyLink { SourceId = "Indirect Electricity Use", TargetId = "Atmosphere (Gross Emissions)", Value = 1557 }
            };
        }
    }
}