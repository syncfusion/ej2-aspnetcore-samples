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
    public class DefaultModel : PageModel
    {
        public class SankeyNode
        {
            public string Id { get; set; } = "";
            public string? Color { get; set; }
            public double? Offset { get; set; }   // added to support vertical offset
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
                new SankeyNode { Id = "Electricity Generation", Offset = -120 },

                new SankeyNode { Id = "Residential", Offset = 38 },
                new SankeyNode { Id = "Commercial", Offset = 36 },
                new SankeyNode { Id = "Industrial", Offset = 34 },
                new SankeyNode { Id = "Transportation", Offset = 32 },

                new SankeyNode { Id = "Rejected Energy", Offset = -40 },
                new SankeyNode { Id = "Energy Services" },

                // Sources
                new SankeyNode { Id = "Solar" },
                new SankeyNode { Id = "Nuclear" },
                new SankeyNode { Id = "Wind" },
                new SankeyNode { Id = "Geothermal" },
                new SankeyNode { Id = "Natural Gas" },
                new SankeyNode { Id = "Coal" },
                new SankeyNode { Id = "Biomass" },
                new SankeyNode { Id = "Petroleum", Offset = -10 }
            };

            Links = new()
            {
                // Generation inputs
                new SankeyLink { SourceId = "Solar",        TargetId = "Electricity Generation", Value = 454 },
                new SankeyLink { SourceId = "Nuclear",      TargetId = "Electricity Generation", Value = 185 },
                new SankeyLink { SourceId = "Wind",         TargetId = "Electricity Generation", Value = 47.8 },
                new SankeyLink { SourceId = "Geothermal",   TargetId = "Electricity Generation", Value = 40 },
                new SankeyLink { SourceId = "Natural Gas",  TargetId = "Electricity Generation", Value = 800 },
                new SankeyLink { SourceId = "Coal",         TargetId = "Electricity Generation", Value = 28.7 },
                new SankeyLink { SourceId = "Biomass",      TargetId = "Electricity Generation", Value = 50 },

                // To Residential
                new SankeyLink { SourceId = "Electricity Generation", TargetId = "Residential", Value = 182 },
                new SankeyLink { SourceId = "Natural Gas",            TargetId = "Residential", Value = 400 },
                new SankeyLink { SourceId = "Petroleum",              TargetId = "Residential", Value = 50 },

                // To Commercial
                new SankeyLink { SourceId = "Electricity Generation", TargetId = "Commercial", Value = 351 },
                new SankeyLink { SourceId = "Natural Gas",            TargetId = "Commercial", Value = 300 },

                // To Industrial
                new SankeyLink { SourceId = "Electricity Generation", TargetId = "Industrial", Value = 641 },
                new SankeyLink { SourceId = "Natural Gas",            TargetId = "Industrial", Value = 786 },
                new SankeyLink { SourceId = "Biomass",                TargetId = "Industrial", Value = 563 },
                new SankeyLink { SourceId = "Petroleum",              TargetId = "Industrial", Value = 300 },

                // To Transportation
                new SankeyLink { SourceId = "Electricity Generation", TargetId = "Transportation", Value = 20 },
                new SankeyLink { SourceId = "Natural Gas",            TargetId = "Transportation", Value = 51 },
                new SankeyLink { SourceId = "Biomass",                TargetId = "Transportation", Value = 71 },
                new SankeyLink { SourceId = "Petroleum",              TargetId = "Transportation", Value = 2486 },

                // Sectors → Rejected Energy
                new SankeyLink { SourceId = "Residential",   TargetId = "Rejected Energy", Value = 432 },
                new SankeyLink { SourceId = "Commercial",    TargetId = "Rejected Energy", Value = 351 },
                new SankeyLink { SourceId = "Industrial",    TargetId = "Rejected Energy", Value = 972 },
                new SankeyLink { SourceId = "Transportation",TargetId = "Rejected Energy", Value = 1920 },

                // Sectors → Energy Services
                new SankeyLink { SourceId = "Residential",   TargetId = "Energy Services", Value = 200 },
                new SankeyLink { SourceId = "Commercial",    TargetId = "Energy Services", Value = 300 },
                new SankeyLink { SourceId = "Industrial",    TargetId = "Energy Services", Value = 755 },
                new SankeyLink { SourceId = "Transportation",TargetId = "Energy Services", Value = 637 }
            };
        }
    }
}