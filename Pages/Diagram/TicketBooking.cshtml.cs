#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Diagrams;
using System.Runtime.CompilerServices;

namespace EJ2CoreSampleBrowser.Pages.Diagram
{
    public class SeatBookingModel : PageModel
    {
        public List<DiagramNode> Nodes = new List<DiagramNode>();
        public DiagramConstraints Constraints { get; set; } = DiagramConstraints.Default & ~DiagramConstraints.UndoRedo;

        public void OnGet()
        {
            Nodes.Clear();

            //if (selectedTiming == null) return;

            double currentY = 50; // Starting Y position

            // Executive Tier
            currentY = CreateTierSeats("Executive", 25, currentY, new List<(string row, int seats)>
            {
                    ("A", 18), ("B", 18), ("C", 18), ("D", 18), ("E", 18), ("F", 18), ("G", 16), ("H", 14)
            });

            // Corporate Tier - Fixed seat counts for L and M rows
            currentY += 92; // Tier spacing
            currentY = CreateTierSeats("Corporate", 16, currentY, new List<(string row, int seats)>
            {
                ("I", 16), ("J", 16), ("K", 16), ("L", 14), ("M", 12) // Fixed: L=14, M=12
            });

            // Budget Tier
            currentY += 92; // Tier spacing
            currentY = CreateTierSeats("Budget", 8, currentY, new List<(string row, int seats)>
            {
                ("N", 16), ("O", 16), ("P", 16)
            });

            // Create screen
            currentY += 92; // Space before screen
            CreateScreen(currentY);
        }
        public double CreateTierSeats(string tierName, decimal tierPrice, double startY, List<(string row, int seats)> rowConfig)
        {
            double currentY = startY;

            // Create tier label - centered properly
            CreateTierLabel(tierName, tierPrice, currentY - 50);

            foreach (var (row, seatCount) in rowConfig)
            {
                // Create row label - positioned further left to avoid overlap
                CreateRowLabel(row, currentY);

                // Check if this is a row with reduced seats that needs center alignment
                bool isCenterAligned = (tierName == "Executive" && (row == "G" || row == "H")) ||
                                     (tierName == "Corporate" && (row == "L" || row == "M"));

                if (isCenterAligned)
                {
                    // Center-aligned seating for rows with fewer seats - with proper aisle gap
                    CreateCenterAlignedSeatsWithAisle(row, seatCount, tierPrice, tierName, currentY);
                }
                else
                {
                    // Normal left-right split seating
                    CreateSplitSeats(row, seatCount, tierPrice, tierName, currentY);
                }

                currentY += 48; // 32px height + 16px vertical spacing
            }

            return currentY;
        }
        public void CreateSplitSeats(string row, int seatCount, decimal tierPrice, string tierName, double currentY)
        {
            // Calculate seats per side (split by center aisle)
            int leftSeats = seatCount / 2;
            int rightSeats = seatCount - leftSeats;

            // Calculate the theater center point - updated to 600
            double theaterCenter = 600;
            double seatWidth = 32;
            double seatSpacing = 10;
            double aisleWidth = 82;

            // Calculate left side starting position
            double leftSideWidth = leftSeats * seatWidth + (leftSeats - 1) * seatSpacing;
            double leftStartX = theaterCenter - (aisleWidth / 2) - leftSideWidth;

            // Create left side seats
            for (int j = 1; j <= leftSeats; j++)
            {
                string seatNumber = $"{row}{j}";
                string seatId = $"seat{row}{j}";
                double x = leftStartX + (j - 1) * (seatWidth + seatSpacing);

                CreateSeatNode(seatId, seatNumber, row, j, tierPrice, tierName, x, currentY);
            }

            // Calculate right side starting position
            double rightStartX = theaterCenter + (aisleWidth / 2);

            // Create right side seats
            for (int j = leftSeats + 1; j <= seatCount; j++)
            {
                string seatNumber = $"{row}{j}";
                string seatId = $"seat{row}{j}";
                double x = rightStartX + (j - leftSeats - 1) * (seatWidth + seatSpacing);

                CreateSeatNode(seatId, seatNumber, row, j, tierPrice, tierName, x, currentY);
            }
        }
        public void CreateCenterAlignedSeatsWithAisle(string row, int seatCount, decimal tierPrice, string tierName, double currentY)
        {
            // For center-aligned rows, still maintain the aisle gap
            double seatWidth = 32;
            double seatSpacing = 10;
            double aisleWidth = 82;
            double theaterCenter = 600; // Updated to match the new theater center

            // Calculate seats per side for center-aligned rows
            int leftSeats = seatCount / 2;
            int rightSeats = seatCount - leftSeats;

            // Left side seats - positioned to end at the aisle
            double leftSideWidth = leftSeats * seatWidth + (leftSeats - 1) * seatSpacing;
            double leftStartX = theaterCenter - (aisleWidth / 2) - leftSideWidth;

            for (int j = 1; j <= leftSeats; j++)
            {
                string seatNumber = $"{row}{j}";
                string seatId = $"seat{row}{j}";
                double x = leftStartX + (j - 1) * (seatWidth + seatSpacing);

                CreateSeatNode(seatId, seatNumber, row, j, tierPrice, tierName, x, currentY);
            }

            // Right side seats - positioned to start at the aisle
            double rightStartX = theaterCenter + (aisleWidth / 2);

            for (int j = leftSeats + 1; j <= seatCount; j++)
            {
                string seatNumber = $"{row}{j}";
                string seatId = $"seat{row}{j}";
                double x = rightStartX + (j - leftSeats - 1) * (seatWidth + seatSpacing);

                CreateSeatNode(seatId, seatNumber, row, j, tierPrice, tierName, x, currentY);
            }
        }
        public void CreateSeatNode(string seatId, string seatNumber, string row, int column, decimal tierPrice, string tierName, double x, double y)
        {
            var node = new DiagramNode
            {
                Id = seatId,
                Width = 32,
                Height = 32,
                OffsetX = x,
                OffsetY = y,
                Shape = new
                {
                    cornerRadius = 4
                },
                Style = new NodeStyleNodes()
                {
                    StrokeColor = "#9CA3AF",
                    StrokeWidth = 2
                },
                Annotations = new List<DiagramNodeAnnotation>()   
                {
                    new DiagramNodeAnnotation
                    {
                        Content =  column.ToString(),
                        Style = new DiagramTextStyle { FontSize = 14, Bold = true }
                    }
                 },
                AddInfo = new Dictionary<string, object> {
                    { "SeatNumber", seatNumber },
                    { "Row", row },
                    { "Column", column },
                    { "Price", tierPrice },
                    { "TierCategory", tierName },
                    { "SeatId", seatId },
                    { "Booked", false },
                },
                Constraints = (Syncfusion.EJ2.Diagrams.NodeConstraints.Default | Syncfusion.EJ2.Diagrams.NodeConstraints.Tooltip | Syncfusion.EJ2.Diagrams.NodeConstraints.ReadOnly) & ~Syncfusion.EJ2.Diagrams.NodeConstraints.Select
            };
            Nodes.Add(node);
        }
        public void CreateTierLabel(string tierName, decimal price, double y)
        {
            string labelId = $"tierlabel{tierName}";
            var labelNode = new DiagramNode
            {
                Id = labelId,
                Width = 200,
                Height = 25,
                OffsetX = 585,
                OffsetY = y,
                Shape = new { type = "Text" },
                Annotations = new List<DiagramNodeAnnotation>
                {
                    new DiagramNodeAnnotation
                    {
                        Content = $"{tierName} - ₹{price}",
                        Style = new DiagramTextStyle { FontSize = 16, Bold = true }
                    }
                },
                Constraints = Syncfusion.EJ2.Diagrams.NodeConstraints.ReadOnly
            };
            Nodes.Add(labelNode);
        }
        public void CreateRowLabel(string rowName, double y)
        {
            string labelId = $"rowlabel{rowName}";
            var labelNode = new DiagramNode
            {
                Id = labelId,
                Width = 30,
                Height = 32,
                OffsetX = 80,
                OffsetY = y,
                Shape = new { type = "Text", content = rowName },

                Annotations = new List<DiagramNodeAnnotation>
                {
                    new DiagramNodeAnnotation
                    {
                        Content = rowName,
                        Style = new DiagramTextStyle { FontSize = 14, Bold = true }
                    }
                },
                Constraints = Syncfusion.EJ2.Diagrams.NodeConstraints.ReadOnly
            };
            Nodes.Add(labelNode);
        }

        public void CreateScreen(double y)
        {
            var screenNode = new DiagramNode
            {
                Id = "screen",
                Height = 80,
                Width = 600,
                OffsetX = 580, // Center
                OffsetY = y,
                Shape = new
                {
                    type = "Native",
                    content = "<svg width=\"394\" height=\"56\" viewBox=\"0 0 394 56\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\">\r\n                                    <path d=\"M27.0321 1.62598L2 37.6661C124.157 52.0822 312.899 43.6728 392 37.6661L364.965 1.62598C276.852 11.8374 148.187 11.8374 27.0321 1.62598Z\" stroke=\"#818CF8\" stroke-width=\"2\" stroke-linejoin=\"round\" />\r\n                                    <path d=\"M2 45.666C124.157 60.0821 312.899 51.6727 392 45.666\" stroke=\"#818CF8\" stroke-width=\"4\" stroke-linecap=\"round\" stroke-linejoin=\"round\" />\r\n                                    <path d=\"M27.0321 1.62598L2 37.6661C124.157 52.0822 312.899 43.6728 392 37.6661L364.965 1.62598C276.852 11.8374 148.187 11.8374 27.0321 1.62598Z\" fill=\"#E0E7FF\" />\r\n                                </svg>"
                },

                Annotations = new List<DiagramNodeAnnotation>
                {
                    new DiagramNodeAnnotation
                    {
                        Content = "Screen This Way",
                        Offset = new DiagramPoint(){X = 0.5, Y = 1.5},
                        Style = new DiagramTextStyle { Color = "#818CF8", FontSize = 14 }
                    }
                },
                Constraints = Syncfusion.EJ2.Diagrams.NodeConstraints.ReadOnly
            };
            Nodes.Add(screenNode);
        }

        public class ScreenTiming
        {
            public string ScreenName { get; set; } = "";
            public List<ShowTiming> ShowTimings { get; set; } = new List<ShowTiming>();
        }
        public class ShowTiming
        {
            public int Id { get; set; }
            public string Time { get; set; } = "";
            public string Type { get; set; } = "";
            public string ScreenName { get; set; } = "";
        }
        public class MovieDetails
        {
            public string Title { get; set; } = "";
            public string TheaterName { get; set; } = "";
            public DateTime ShowTime { get; set; }
        }
        public class SeatSelection
        {
            public string Category { get; set; } = "";
            public List<string> SeatNumbers { get; set; } = new List<string>();
            public int TicketCount { get; set; } = 0;
            public decimal Amount { get; set; } = 0.00m;
        }
    }
}
