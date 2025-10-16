#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Charts;
using Syncfusion.EJ2.Diagrams;
using System.Text;
using Position = Syncfusion.EJ2.Popups.Position;

namespace EJ2CoreSampleBrowser.Pages.Diagram
{
    public class HistoryTimelineModel : PageModel
    {
        public List<DiagramNode> Nodes { get; set; }
        public List<DiagramConnector> Connectors { get; set; }
        public DiagramConstraints Constraints { get; set; } = DiagramConstraints.Default & ~(DiagramConstraints.UndoRedo | DiagramConstraints.PanY);
        public List<TimelineEvent> TimelineEvents { get; set; } = new List<TimelineEvent>();
        public static DiagramSelector Selector { get; set; }
        public List<DiagramUserHandle> Userhandles { get; set; }
        public void OnGet()
        {
            TimelineEvents = new List<TimelineEvent>
            {
                new TimelineEvent { Year = "1969", Title = "ARPANET", Description = "ARPANET, the precursor to the Internet, is created by the U.S. Department of Defense's Advanced Research Projects Agency (ARPA).", Icon = "sf-icon-arpanet" },
                new TimelineEvent { Year = "1983", Title = "Birth of the Internet", Description = "ARPANET switches to TCP/IP, marking the official birth of the Internet.", Icon = "sf-icon-birth-internet" },
               new TimelineEvent { Year = "1991", Title = "Internet Goes Public", Description = "The World Wide Web is released to the public, making the Internet accessible to a broader audience.", Icon = "sf-icon-internet-public" },
               new TimelineEvent { Year = "1993", Title = "First Web Browser", Description = "The first web browser, Mosaic, is released, making it easier for people to access the World Wide Web.", Icon = "sf-icon-first-web-browser" },
               new TimelineEvent { Year = "1995", Title = "Commercialization of the Internet", Description = "The U.S. government lifts restrictions on commercial use of the Internet, leading to the rise of commercial websites and e-commerce.", Icon = "sf-icon-commercialization" },
               new TimelineEvent { Year = "1998", Title = "Google Founded", Description = "Google is founded by Larry Page and Sergey Brin, revolutionizing how people search for information online.", Icon = "sf-icon-google-found" },
               new TimelineEvent { Year = "2004", Title = "Social Media Boom", Description = "Facebook is launched, marking the beginning of the social media era.", Icon = "sf-icon-social-media" },
               new TimelineEvent { Year = "2005", Title = "YouTube Launched", Description = "YouTube is launched, becoming a major platform for sharing and viewing video content.", Icon = "sf-icon-youtube" },
               new TimelineEvent { Year = "2007", Title = "iPhone Released", Description = "Apple releases the first iPhone, transforming mobile internet usage and leading to the proliferation of mobile apps.", Icon = "sf-icon-i-phone" },
               new TimelineEvent { Year = "2010", Title = "Cloud Computing", Description = "Cloud computing becomes mainstream, allowing for more flexible and scalable internet services.", Icon = "sf-icon-cloud-computing" },
               new TimelineEvent { Year = "2014", Title = "Internet of Things (IoT)", Description = "The Internet of Things (IoT) gains significant traction, connecting everyday devices to the internet.", Icon = "sf-icon-internet-of-things" },
               new TimelineEvent { Year = "2020", Title = "Remote Work", Description = "The COVID-19 pandemic accelerates the adoption of remote work, online education, and digital communication.", Icon = "sf-icon-remote-work" },
               new TimelineEvent { Year = "2021", Title = "5G Rollout", Description = "The global rollout of 5G networks begins, promising significantly faster internet speeds and lower latency.", Icon = "sf-icon-5g-network" },
               new TimelineEvent { Year = "2022", Title = "Metaverse Development", Description = "Major technology companies begin to invest heavily in the development of the metaverse, virtual and augmented reality spaces.", Icon = "sf-icon-metaverse" },
               new TimelineEvent { Year = "2023", Title = "Quantum Internet", Description = "Continued research and development in quantum computing and quantum internet technology aim to revolutionize data security and processing speeds.", Icon = "sf-icon-quantum-internet" },
               new TimelineEvent { Year = "2025", Title = "IoT Pervasiveness", Description = "The Internet of Things becomes more pervasive, with smart devices deeply integrated into daily life and industry.", Icon = "sf-icon-iot-pervasiveness" },
               new TimelineEvent { Year = "2030", Title = "Autonomous Vehicles", Description = "The widespread adoption of autonomous vehicles becomes more common, relying heavily on the internet for communication, navigation, and updates.", Icon = "sf-icon-autonomous-vehicle" },
               new TimelineEvent { Year = "2035", Title = "Advanced AI Integration", Description = "Advanced AI systems are fully integrated into internet services, offering more personalized and efficient user experiences.", Icon = "sf-icon-advance-ai" }
            };

            CreateTimelineNodes();
            CreateTimelineConnectors();
            InitializeUserHandles();
        }
        private const double StartX = 100;
        private const double StartY = 100;
        private const double NodeSpacing = 200;
        private const double AlternateOffset = 200;
        private const double BaseLine = 300;

        private readonly string[] EventColors = 
        {
            "#FEC200", "#43C94C", "#3D95F6", "#FF3343", "#CDDE1F",
            "#00897B", "#7F38CD", "#FF2667", "#00BCD7", "#F47B10",
            "#576ADE", "#91521B"
        };

        private void CreateTimelineNodes()
        {
            Nodes = new List<DiagramNode>();
            // Create main timeline line
            var timelineLine = new DiagramNode()
            {
                Id = "timeline_line",
                OffsetX = (TimelineEvents.Count * NodeSpacing) / 2,
                OffsetY = BaseLine,
                Width = TimelineEvents.Count * NodeSpacing,
                Height = 10,
            };
            timelineLine.Shape = new
            {
                type = "HTML",
                content = GetHtmlTemplate(timelineLine)
            };
            Nodes.Add(timelineLine);

            // Create timeline event Nodes
            for (int index = 0; index < TimelineEvents.Count; index++)
            {
                var eventItem = TimelineEvents[index];
                var colorIndex = index % EventColors.Length;
                var nodeColor = EventColors[colorIndex];
                var isOdd = (index + 1) % 2 != 0;
                var x = StartX + (index * NodeSpacing);
                var y = isOdd ? StartY : BaseLine + AlternateOffset;

                // Timeline Event Node
                var timelineNode = new DiagramNode()
                {
                    Id = $"timeline_{index}",
                    OffsetX = x,
                    OffsetY = y,
                    Width = 130,
                    Height = 100,
                    Constraints = (NodeConstraints.Default & ~NodeConstraints.Drag) | NodeConstraints.Tooltip | NodeConstraints.ReadOnly,
                    Style = new NodeStyleNodes { Fill = "none" },
                    Tooltip = new DiagramDiagramTooltip
                    {
                        Content = $"{eventItem.Year}: {eventItem.Description}",
                        Position = isOdd ? Position.TopCenter : Position.BottomCenter,
                        RelativeMode = TooltipRelativeMode.Object
                    },
                    AddInfo = new Dictionary<string, object>
                    {
                        {"Year", eventItem.Year},
                        {"Title", eventItem.Title},
                        {"Description", eventItem.Description}
                    }
                };
                timelineNode.Shape = new
                {
                    type = "HTML",
                    content = GetHtmlTemplate(timelineNode)
                };

                // Timeline Year Marker Node
                var yearMarker = new DiagramNode()
                {
                    Id = $"marker_{index}",
                    OffsetX = x,
                    OffsetY = BaseLine,
                    Width = 170,
                    Height = 50,
                    Constraints = (NodeConstraints.Default | NodeConstraints.ReadOnly) & ~NodeConstraints.Drag,
                    AddInfo = new Dictionary<string, object>
                    {
                        {"eventIndex", index}
                    }
                };
                yearMarker.Shape = new
                {
                    type = "HTML",
                    content = GetHtmlTemplate(yearMarker)
                };
                Nodes.Add(timelineNode);
                Nodes.Add(yearMarker);
            }
        }

        private void CreateTimelineConnectors()
        {
            Connectors = new List<DiagramConnector>();
            for (int index = 0; index < TimelineEvents.Count; index++)
            {
                var colorIndex = index % EventColors.Length;
                var strokeColor = EventColors[colorIndex];
                var connector = new DiagramConnector()
                {
                    Id = $"connector_{index}",
                    SourceID = $"timeline_{index}",
                    TargetID = $"marker_{index}",
                    Constraints = ConnectorConstraints.None,
                    Style = new DiagramStrokeStyle
                    {
                        StrokeColor = strokeColor,
                        StrokeWidth = 2
                    },
                };
                Connectors.Add(connector);
            }
        }

        public string GetHtmlTemplate(DiagramNode node)
        {
            if (node.Id.Contains("timeline_line"))
            {
                var sb = new StringBuilder();
                sb.Append("<div class=\"timeline-line\">");
                for (int i = 0; i < TimelineEvents.Count; i++)
                {
                    var colorIndex = i % EventColors.Length;
                    var segmentColor = EventColors[colorIndex];
                    sb.Append($"<div class=\"timeline-segment\" style=\"background-color: {segmentColor};\"></div>");
                }
                sb.Append("</div>");
                return sb.ToString();
            }
            else if (node.Id.StartsWith("timeline_"))
            {
                var eventIndex = GetEventIndexFromNode(node);
                if (eventIndex >= 0 && eventIndex < TimelineEvents.Count)
                {
                    var eventItem = TimelineEvents[eventIndex];
                    var colorIndex = eventIndex % EventColors.Length;
                    var nodeColor = EventColors[colorIndex];

                    if (!string.IsNullOrEmpty(eventItem.ImageUrl))
                    {
                        return $"<div class=\"timeline-event-node\" style=\"background-color: {nodeColor};\">" +
                               $"<div class=\"timeline-event-icon\">" +
                               $"<img src=\"{eventItem.ImageUrl}\" alt=\"Event Image\" style=\"max-width: 100%; max-height: 60px; border-radius: 3px;\" />" +
                               "</div>" +
                               $"<div class=\"timeline-event-title\"><strong>{eventItem.Title}</strong></div>" +
                               "</div>";
                    }
                    else
                    {
                        return $"<div class=\"timeline-event-node\" style=\"background-color: {nodeColor};\">" +
                               $"<div class=\"timeline-event-icon {eventItem.Icon}\"></div>" +
                               $"<div class=\"timeline-event-title\"><strong>{eventItem.Title}</strong></div>" +
                               "</div>";
                    }
                }
            }
            else if (node.Id.StartsWith("marker_"))
            {
                var eventIndex = GetEventIndexFromNode(node);
                if (eventIndex >= 0 && eventIndex < TimelineEvents.Count)
                {
                    var eventItem = TimelineEvents[eventIndex];
                    return "<div class=\"timeline-year-marker\">" +
                           "<div class=\"timeline-year-circle\">" +
                           $"{eventItem.Year}" +
                           "</div>" +
                           "</div>";
                }
            }

            return string.Empty; // Return an empty string if no match
        }

        private void InitializeUserHandles()
        {
            Userhandles = new List<DiagramUserHandle>()
            {
                new DiagramUserHandle
                {
                    Id = "NewEvent",
                    Name = "NewEvent",
                    PathData = "M256 80c0-17.7-14.3-32-32-32s-32 14.3-32 32V224H48c-17.7 0-32 14.3-32 32s14.3 32 32 32H192V432c0 17.7 14.3 32 32 32s32-14.3 32-32V288H400c17.7 0 32-14.3 32-32s-14.3-32-32-32H256V80z",
                    Offset = 0.5,
                    Side = Side.Right,
                    Visible = true,
                    Margin = new DiagramMargin { Right = 10 },
                    Tooltip = new  { Content = "Add Event",}
                },
                new DiagramUserHandle
                {
                    Id = "EditEvent",
                    Name = "EditEvent",
                    PathData = "M410.3 231l11.3-11.3-33.9-33.9-62.1-62.1L291.7 89.8l-11.3 11.3-22.6 22.6L58.6 322.9c-10.4 10.4-18 23.3-22.2 37.4L1 480.7c-2.5 8.4-.2 17.5 6.1 23.7s15.3 8.5 23.7 6.1l120.3-35.4c14.1-4.2 27-11.8 37.4-22.2L387.7 253.7 410.3 231zM160 399.4l-9.1 22.7c-4 3.1-8.5 5.4-13.3 6.9L59.4 452l23-78.1c1.4-4.9 3.8-9.4 6.9-13.3l22.7-9.1v32c0 8.8 7.2 16 16 16h32zM362.7 18.7L348.3 33.2 325.7 55.8 314.3 67.1l33.9 33.9 62.1 62.1 33.9 33.9 11.3-11.3 22.6-22.6 14.5-14.5c25-25 25-65.5 0-90.5L453.3 18.7c-25-25-65.5-25-90.5 0zm-47.4 168l-144 144c-6.2 6.2-16.4 6.2-22.6 0s-6.2-16.4 0-22.6l144-144c6.2-6.2 16.4-6.2 22.6 0s6.2 16.4 0 22.6z",
                    Offset = 0.5,
                    Side = Side.Bottom,
                    Visible = true,
                    Margin = new DiagramMargin { Bottom = 10 },
                    Tooltip = new { Content = "Edit Event",}
                }
            };
            Selector = new DiagramSelector();
            Selector.Constraints = SelectorConstraints.UserHandle;
            Selector.UserHandles = Userhandles;
        }

        // Helper methods for template rendering
        private Dictionary<string, object>? GetTimelineNodeData(DiagramNode node)
        {
            var eventIndex = GetEventIndexFromNode(node);
            if (eventIndex >= 0 && eventIndex < TimelineEvents.Count)
            {
                var eventItem = TimelineEvents[eventIndex];
                return new Dictionary<string, object>
                {
                    {"EventIndex", eventIndex},
                    {"Year", eventItem.Year},
                    {"Title", eventItem.Title},
                    {"Description", eventItem.Description},
                    {"Icon", eventItem.Icon}
                };
            }
            return null;
        }

        // Modified method to accept Node parameter instead of nodeId
        private int GetEventIndexFromNode(DiagramNode node)
        {
            if (node == null)
                return -1;

            // First try parsing index from the node ID
            string nodeId = node.Id;
            if (nodeId.StartsWith("timeline_") || nodeId.StartsWith("marker_"))
            {
                var parts = nodeId.Split('_');
                if (parts.Length > 1 && int.TryParse(parts[1], out int index))
                {
                    return index;
                }
            }

            // If parsing failed, check if node has Year in AddInfo
            if (node.AddInfo != null && ((Dictionary<string, object>)node.AddInfo).ContainsKey("Year"))
            {
                string year = ((Dictionary<string, object>)node.AddInfo)["Year"]?.ToString();
                if (!string.IsNullOrEmpty(year))
                {
                    // Find the index of the timeline event with matching year
                    return TimelineEvents.FindIndex(e => e.Year == year);
                }
            }

            // If we have EventIndex directly in AddInfo, use that
            if (node.AddInfo != null && ((Dictionary<string, object>)node.AddInfo).ContainsKey("EventIndex"))
            {
                if (((Dictionary<string, object>)node.AddInfo)["EventIndex"] is int eventIndex)
                {
                    return eventIndex;
                }
            }

            return -1;
        }

        public class TimelineEvent
        {
            public string Year { get; set; } = "";
            public string Title { get; set; } = "";
            public string Description { get; set; } = "";
            public string Icon { get; set; } = "";
            public string ImageUrl { get; set; } = "";
        }
        public class ButtonModel
        {
            public string content { get; set; }
            public bool isPrimary { get; set; }
            public string cssClass { get; set; }
        }
    }
}
