#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
using Syncfusion.EJ2.Charts;
using Syncfusion.EJ2.Diagrams;
using System.ComponentModel;
using Position = Syncfusion.EJ2.Popups.Position;

namespace EJ2CoreSampleBrowser.Pages.Diagram
{
    public class TournamentResultModel : PageModel
    {
        public List<DiagramNode> Nodes { get; set; }
        public List<DiagramConnector> Connectors { get; set; }
        public DiagramConstraints Constraints { get; set; } = DiagramConstraints.Default & ~DiagramConstraints.UndoRedo;

        public class TournamentMatch
        {
            public string Id { get; set; }
            public string Team1 { get; set; }
            public int? Score1 { get; set; }
            public string Team2 { get; set; }
            public int? Score2 { get; set; }
            public string Winner { get; set; }
            public string MatchType { get; set; }
            public string? ShootoutTeam1 { get; set; }
            public string? ShootoutTeam2 { get; set; }
            public string? Year { get; set; }

            public TournamentMatch(string id, string team1, int? score1, string team2, int? score2, string winner, string matchType, string shootoutTeam1 = null, string shootoutTeam2 = null, string year = null)
            {
                Id = id;
                Team1 = team1;
                Score1 = score1;
                Team2 = team2;
                Score2 = score2;
                Winner = winner;
                MatchType = matchType;
                ShootoutTeam1 = shootoutTeam1;
                ShootoutTeam2 = shootoutTeam2;
                Year = year;
            }
        }

        private List<TournamentMatch> TournamentData = new List<TournamentMatch>()
        {
            new TournamentMatch("round16_1", "BAYERN MUNCHEN", 3, "LAZIO", 1, "BAYERN MUNCHEN", "round16"),
            new TournamentMatch("round16_2", "ARSENAL", 1, "PORTO", 1, "ARSENAL", "round16", "4", "2"),
            new TournamentMatch("round16_3", "COPENHAGEN", 2, "MANCHESTER CITY", 6, "MANCHESTER CITY", "round16"),
            new TournamentMatch("round16_4", "LEIPZIG", 1, "REAL MADRID", 2, "REAL MADRID", "round16"),
            new TournamentMatch("round16_5", "BORUSSIA DORTMUND", 3, "PSV EINDHOVEN", 1, "BORUSSIA DORTMUND", "round16"),
            new TournamentMatch("round16_6", "ATLETICO MADRID", 2, "INTER MILAN", 2, "ATLETICO MADRID", "round16", "3", "2"),
            new TournamentMatch("round16_7", "REAL SOCIEDAD", 1, "PARIS SAINT-GERMAIN", 4, "PARIS SAINT-GERMAIN", "round16"),
            new TournamentMatch("round16_8", "BARCELONA", 4, "NAPOLI", 2, "BARCELONA", "round16"),
            new TournamentMatch("quarter1", "BAYERN MUNCHEN", 3, "ARSENAL", 2, "BAYERN MUNCHEN", "quarterfinal"),
            new TournamentMatch("quarter2", "MANCHESTER CITY", 4, "REAL MADRID", 4, "REAL MADRID", "quarterfinal", "3", "4"),
            new TournamentMatch("quarter3", "BORUSSIA DORTMUND", 5, "ATLETICO MADRID", 4, "BORUSSIA DORTMUND", "quarterfinal"),
            new TournamentMatch("quarter4", "BARCELONA", 4, "PARIS SAINT-GERMAIN", 6, "PARIS SAINT-GERMAIN", "quarterfinal"),
            new TournamentMatch("semi1", "BAYERN MUNCHEN", 3, "REAL MADRID", 4, "REAL MADRID", "semifinal"),
            new TournamentMatch("semi2", "PARIS SAINT-GERMAIN", 0, "BORUSSIA DORTMUND", 2, "BORUSSIA DORTMUND", "semifinal"),
            new TournamentMatch("final", "REAL MADRID", 2, "BORUSSIA DORTMUND", 0, "REAL MADRID", "final"),
            new TournamentMatch("champion", "REAL MADRID", 2, "BORUSSIA DORTMUND", 0, "REAL MADRID", "champion", null, null, "2023-24")
        };
        private TournamentMatch GetTournamentData(string nodeId)
        {
            return TournamentData.FirstOrDefault(item => item.Id == nodeId) ?? new TournamentMatch(nodeId, "TBD", null, "TBD", null, "", "TBD");
        }

        public int angleTiltAmountForRound16ToQuarter = 60;
        public int angleTiltAmountForQuarterToSemi = 130;

        // Node Sizes
        public int championNodeWidth = 280;
        public int championNodeHeight = 200;
        public int tournamentNodeWidth = 180;
        public int tournamentNodeHeight = 100;

        // Offsets
        public int finalNodeOffsetX;
        public int championNodeOffsetY;

        // Other offsets (if needed elsewhere)
        public int offsetXIncreaseAmount;
        public int leftRound16NodesOffsetX;
        public int leftQuarterFinalNodesOffsetX;
        public int leftSemiFinalNodesOffsetX;
        public int rightSemiFinalNodesOffsetX;
        public int rightQuarterFinalNodesOffsetX;
        public int rightRound16NodesOffsetX;

        public int offsetYIncreaseAmount;
        public int round16TopOffsetY;
        public int round16UpperMiddleOffsetY;
        public int round16LowerMiddleOffsetY;
        public int round16BottomOffsetY;
        public int quarterFinalTopOffsetY;
        public int quarterFinalBottomOffsetY;
        public int semiFinalOffsetY;
        public int finalNodeOffsetY;
        public Animation tooltipAnimation { get; set; }
        public Enum position { get; set; }

        public void OnGet()
        {
            InitializePosition(); // Make sure offsets are set before using them
            CreateNodes();
            CreateConnectors();
            tooltipAnimation = new Animation()
            {
                open = new Open() { effect = "FadeZoomIn", delay = 100 },
                close = new Open() { effect = "FadeZoomOut", delay = 100 },
            };

            position = Position.TopLeft;
        }

        public void InitializePosition()
        {
            offsetXIncreaseAmount = 280;
            leftRound16NodesOffsetX = offsetXIncreaseAmount;
            leftQuarterFinalNodesOffsetX = leftRound16NodesOffsetX + offsetXIncreaseAmount;
            leftSemiFinalNodesOffsetX = leftQuarterFinalNodesOffsetX + offsetXIncreaseAmount;
            finalNodeOffsetX = leftSemiFinalNodesOffsetX + offsetXIncreaseAmount;
            rightSemiFinalNodesOffsetX = finalNodeOffsetX + offsetXIncreaseAmount;
            rightQuarterFinalNodesOffsetX = rightSemiFinalNodesOffsetX + offsetXIncreaseAmount;
            rightRound16NodesOffsetX = rightQuarterFinalNodesOffsetX + offsetXIncreaseAmount;

            offsetYIncreaseAmount = 190;
            round16TopOffsetY = offsetYIncreaseAmount;
            round16UpperMiddleOffsetY = round16TopOffsetY + offsetYIncreaseAmount;
            round16LowerMiddleOffsetY = round16UpperMiddleOffsetY + offsetYIncreaseAmount;
            round16BottomOffsetY = round16LowerMiddleOffsetY + offsetYIncreaseAmount;

            quarterFinalTopOffsetY = (round16TopOffsetY + round16UpperMiddleOffsetY) / 2;
            quarterFinalBottomOffsetY = (round16LowerMiddleOffsetY + round16BottomOffsetY) / 2;

            semiFinalOffsetY = (quarterFinalTopOffsetY + quarterFinalBottomOffsetY) / 2;
            finalNodeOffsetY = semiFinalOffsetY;
            championNodeOffsetY = finalNodeOffsetY - 350;
        }

        private void CreateNodes()
        {
            Nodes = new List<DiagramNode>();
            // Champion node
            var championNode = new DiagramNode
            {
                Id = "champion",
                OffsetX = finalNodeOffsetX,
                OffsetY = championNodeOffsetY,
                Width = championNodeWidth,
                Height = championNodeHeight,
                Shape = new
                {
                    type = "HTML",
                    content = GetNodeTemplate(GetTournamentData("champion"))
                }
            };
            Nodes.Add(championNode);

            // Final node (with tooltip)
            var finalNode = new DiagramNode
            {
                Id = "final",
                OffsetX = finalNodeOffsetX,
                OffsetY = finalNodeOffsetY,
                Width = tournamentNodeWidth,
                Height = tournamentNodeHeight,
                Data = CreateTooltipContent(GetTournamentData("final")),
                Shape = new
                {
                    type = "HTML",
                    content = GetNodeTemplate(GetTournamentData("final"))
                },
                Tooltip = new DiagramDiagramTooltip
                {
                    Position = Position.TopCenter,
                    RelativeMode = TooltipRelativeMode.Object
                },
                Constraints = Syncfusion.EJ2.Diagrams.NodeConstraints.Default | Syncfusion.EJ2.Diagrams.NodeConstraints.Tooltip
            };
            Nodes.Add(finalNode);

            // Semi-Final Node 1
            var semi1Node = new DiagramNode
            {
                Id = "semi1",
                OffsetX = leftSemiFinalNodesOffsetX,
                OffsetY = semiFinalOffsetY,
                Width = tournamentNodeWidth,
                Height = tournamentNodeHeight,
                Data = CreateTooltipContent(GetTournamentData("semi1")),
                Shape = new
                {
                    type = "HTML",
                    content = GetNodeTemplate(GetTournamentData("semi1"))
                },
                Tooltip = new DiagramDiagramTooltip
                {
                    Position = Position.TopCenter,
                    RelativeMode = TooltipRelativeMode.Object,
                },
                Constraints = Syncfusion.EJ2.Diagrams.NodeConstraints.Default | Syncfusion.EJ2.Diagrams.NodeConstraints.Tooltip
            };
            Nodes.Add(semi1Node);

            // Semi-Final Node 2
            var semi2Node = new DiagramNode
            {
                Id = "semi2",
                OffsetX = rightSemiFinalNodesOffsetX,
                OffsetY = semiFinalOffsetY,
                Width = tournamentNodeWidth,
                Height = tournamentNodeHeight,
                Data = CreateTooltipContent(GetTournamentData("semi2")),
                Shape = new
                {
                    type = "HTML",
                    content = GetNodeTemplate(GetTournamentData("semi2"))
                },
                Tooltip = new DiagramDiagramTooltip
                {
                    Position = Position.TopCenter,
                    RelativeMode = TooltipRelativeMode.Object
                },
                Constraints = Syncfusion.EJ2.Diagrams.NodeConstraints.Default | Syncfusion.EJ2.Diagrams.NodeConstraints.Tooltip
            };
            Nodes.Add(semi2Node);

            // QuarterFinal Node 1
            var quarter1Node = new DiagramNode
            {
                Id = "quarter1",
                OffsetX = leftQuarterFinalNodesOffsetX,
                OffsetY = quarterFinalTopOffsetY,
                Width = tournamentNodeWidth,
                Height = tournamentNodeHeight,
                Data = CreateTooltipContent(GetTournamentData("quarter1")),
                Shape = new
                {
                    type = "HTML",
                    content = GetNodeTemplate(GetTournamentData("quarter1"))
                },
                Tooltip = new DiagramDiagramTooltip
                {
                    Position = Position.RightCenter,
                    RelativeMode = TooltipRelativeMode.Object
                },
                Constraints = Syncfusion.EJ2.Diagrams.NodeConstraints.Default | Syncfusion.EJ2.Diagrams.NodeConstraints.Tooltip
            };
            Nodes.Add(quarter1Node);

            var quarter2Node = new DiagramNode
            {
                Id = "quarter2",
                OffsetX = leftQuarterFinalNodesOffsetX,
                OffsetY = quarterFinalBottomOffsetY,
                Width = tournamentNodeWidth,
                Height = tournamentNodeHeight,
                Data = CreateTooltipContent(GetTournamentData("quarter2")),
                Shape = new
                {
                    type = "HTML",
                    content = GetNodeTemplate(GetTournamentData("quarter2"))
                },
                Tooltip = new DiagramDiagramTooltip
                {
                    Position = Position.RightCenter,
                    RelativeMode = TooltipRelativeMode.Object
                },
                Constraints = Syncfusion.EJ2.Diagrams.NodeConstraints.Default
                 | Syncfusion.EJ2.Diagrams.NodeConstraints.Tooltip
            };
            Nodes.Add(quarter2Node);

            // quarter3
            var quarter3Node = new DiagramNode
            {
                Id = "quarter3",
                OffsetX = rightQuarterFinalNodesOffsetX,
                OffsetY = quarterFinalTopOffsetY,
                Width = tournamentNodeWidth,
                Height = tournamentNodeHeight,
                Data = CreateTooltipContent(GetTournamentData("quarter3")),
                Shape = new
                {
                    type = "HTML",
                    content = GetNodeTemplate(GetTournamentData("quarter3"))
                },
                Tooltip = new DiagramDiagramTooltip
                {
                    Position = Position.LeftCenter,
                    RelativeMode = TooltipRelativeMode.Object
                },
                Constraints = Syncfusion.EJ2.Diagrams.NodeConstraints.Default
                             | Syncfusion.EJ2.Diagrams.NodeConstraints.Tooltip
            };
            Nodes.Add(quarter3Node);

            // quarter4
            var quarter4Node = new DiagramNode
            {
                Id = "quarter4",
                OffsetX = rightQuarterFinalNodesOffsetX,
                OffsetY = quarterFinalBottomOffsetY,
                Width = tournamentNodeWidth,
                Height = tournamentNodeHeight,
                Data = CreateTooltipContent(GetTournamentData("quarter4")),
                Shape = new
                {
                    type = "HTML",
                    content = GetNodeTemplate(GetTournamentData("quarter4"))
                },
                Tooltip = new DiagramDiagramTooltip
                {
                    Position = Position.LeftCenter,
                    RelativeMode = TooltipRelativeMode.Object
                },
                Constraints = Syncfusion.EJ2.Diagrams.NodeConstraints.Default
                             | Syncfusion.EJ2.Diagrams.NodeConstraints.Tooltip
            };
            Nodes.Add(quarter4Node);

            // round16_1
            var round16_1 = new DiagramNode
            {
                Id = "round16_1",
                OffsetX = leftRound16NodesOffsetX,
                OffsetY = round16TopOffsetY,
                Width = tournamentNodeWidth,
                Height = tournamentNodeHeight,
                Data = CreateTooltipContent(GetTournamentData("round16_1")),
                Shape = new
                {
                    type = "HTML",
                    content = GetNodeTemplate(GetTournamentData("round16_1"))
                },
                Tooltip = new DiagramDiagramTooltip
                {
                    Position = Position.RightCenter,
                    RelativeMode = TooltipRelativeMode.Object
                },
                Constraints = Syncfusion.EJ2.Diagrams.NodeConstraints.Default
                             | Syncfusion.EJ2.Diagrams.NodeConstraints.Tooltip
            };
            Nodes.Add(round16_1);

            // round16_2
            var round16_2 = new DiagramNode
            {
                Id = "round16_2",
                OffsetX = leftRound16NodesOffsetX,
                OffsetY = round16UpperMiddleOffsetY,
                Width = tournamentNodeWidth,
                Height = tournamentNodeHeight,
                Data = CreateTooltipContent(GetTournamentData("round16_2")),
                Shape = new
                {
                    type = "HTML",
                    content = GetNodeTemplate(GetTournamentData("round16_2"))
                },
                Tooltip = new DiagramDiagramTooltip
                {
                    Position = Position.RightCenter,
                    RelativeMode = TooltipRelativeMode.Object
                },
                Constraints = Syncfusion.EJ2.Diagrams.NodeConstraints.Default
                             | Syncfusion.EJ2.Diagrams.NodeConstraints.Tooltip
            };
            Nodes.Add(round16_2);

            // round16_3
            var round16_3 = new DiagramNode
            {
                Id = "round16_3",
                OffsetX = leftRound16NodesOffsetX,
                OffsetY = round16LowerMiddleOffsetY,
                Width = tournamentNodeWidth,
                Height = tournamentNodeHeight,
                Data = CreateTooltipContent(GetTournamentData("round16_3")),
                Shape = new
                {
                    type = "HTML",
                    content = GetNodeTemplate(GetTournamentData("round16_3"))
                },
                Tooltip = new DiagramDiagramTooltip
                {
                    Position = Position.RightCenter,
                    RelativeMode = TooltipRelativeMode.Object
                },
                Constraints = Syncfusion.EJ2.Diagrams.NodeConstraints.Default |
                             Syncfusion.EJ2.Diagrams.NodeConstraints.Tooltip
            };
            Nodes.Add(round16_3);

            // round16_4
            var round16_4 = new DiagramNode
            {
                Id = "round16_4",
                OffsetX = leftRound16NodesOffsetX,
                OffsetY = round16BottomOffsetY,
                Width = tournamentNodeWidth,
                Height = tournamentNodeHeight,
                Data = CreateTooltipContent(GetTournamentData("round16_4")),
                Shape = new
                {
                    type = "HTML",
                    content = GetNodeTemplate(GetTournamentData("round16_4"))
                },
                Tooltip = new DiagramDiagramTooltip
                {
                    Position = Position.RightCenter,
                    RelativeMode = TooltipRelativeMode.Object
                },
                Constraints = Syncfusion.EJ2.Diagrams.NodeConstraints.Default |
                             Syncfusion.EJ2.Diagrams.NodeConstraints.Tooltip
            };
            Nodes.Add(round16_4);

            // round16_5
            var round16_5 = new DiagramNode
            {
                Id = "round16_5",
                OffsetX = rightRound16NodesOffsetX,
                OffsetY = round16TopOffsetY,
                Width = tournamentNodeWidth,
                Height = tournamentNodeHeight,
                Data = CreateTooltipContent(GetTournamentData("round16_5")),
                Shape = new
                {
                    type = "HTML",
                    content = GetNodeTemplate(GetTournamentData("round16_5"))
                },
                Tooltip = new DiagramDiagramTooltip
                {
                    Position = Position.LeftCenter,
                    RelativeMode = TooltipRelativeMode.Object
                },
                Constraints = Syncfusion.EJ2.Diagrams.NodeConstraints.Default |
                             Syncfusion.EJ2.Diagrams.NodeConstraints.Tooltip
            };
            Nodes.Add(round16_5);

            // round16_6
            var round16_6 = new DiagramNode
            {
                Id = "round16_6",
                OffsetX = rightRound16NodesOffsetX,
                OffsetY = round16UpperMiddleOffsetY,
                Width = tournamentNodeWidth,
                Height = tournamentNodeHeight,
                Data = CreateTooltipContent(GetTournamentData("round16_6")),
                Shape = new
                {
                    type = "HTML",
                    content = GetNodeTemplate(GetTournamentData("round16_6"))
                },
                Tooltip = new DiagramDiagramTooltip
                {
                    Position = Position.LeftCenter,
                    RelativeMode = TooltipRelativeMode.Object
                },
                Constraints = Syncfusion.EJ2.Diagrams.NodeConstraints.Default |
                             Syncfusion.EJ2.Diagrams.NodeConstraints.Tooltip
            };
            Nodes.Add(round16_6);

            // round16_7
            var round16_7 = new DiagramNode
            {
                Id = "round16_7",
                OffsetX = rightRound16NodesOffsetX,
                OffsetY = round16LowerMiddleOffsetY,
                Width = tournamentNodeWidth,
                Height = tournamentNodeHeight,
                Data = CreateTooltipContent(GetTournamentData("round16_7")),
                Shape = new
                {
                    type = "HTML",
                    content = GetNodeTemplate(GetTournamentData("round16_7"))
                },
                Tooltip = new DiagramDiagramTooltip
                {
                    Position = Position.LeftCenter,
                    RelativeMode = TooltipRelativeMode.Object
                },
                Constraints = Syncfusion.EJ2.Diagrams.NodeConstraints.Default |
                             Syncfusion.EJ2.Diagrams.NodeConstraints.Tooltip
            };
            Nodes.Add(round16_7);

            var round16_8 = new DiagramNode
            {
                Id = "round16_8",
                OffsetX = rightRound16NodesOffsetX,
                OffsetY = round16BottomOffsetY,
                Width = tournamentNodeWidth,
                Height = tournamentNodeHeight,
                Data = CreateTooltipContent(GetTournamentData("round16_8")),
                Shape = new
                {
                    type = "HTML",
                    content = GetNodeTemplate(GetTournamentData("round16_8"))
                },
                Tooltip = new DiagramDiagramTooltip
                {                          
                    Position = Position.LeftCenter,
                    RelativeMode = TooltipRelativeMode.Object
                },
                Constraints = Syncfusion.EJ2.Diagrams.NodeConstraints.Default
                | Syncfusion.EJ2.Diagrams.NodeConstraints.Tooltip
            };
            Nodes.Add(round16_8);
        }

        private void CreateConnectors()
        {
            #region Connectors
            Connectors = new List<DiagramConnector>();
            DiagramConnector champ1 = new DiagramConnector()
            {
                Id = "champ1",
                SourceID = "final",
                TargetID = "champion",
                Type = Segments.Straight, 
                SourceDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None},
                TargetDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None},
            };
            Connectors.Add(champ1);
            DiagramConnector final1 = new DiagramConnector()
            {
                Id = "final1",
                SourceID = "semi1",
                TargetID = "final",
                Type = Segments.Straight,
                SourceDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },
                TargetDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },
            };
            Connectors.Add(final1);

            DiagramConnector final2 = new DiagramConnector()
            {
                Id = "final2",
                SourceID = "semi2",
                TargetID = "final",
                Type = Segments.Straight,
                SourceDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },
                TargetDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },
            };
            Connectors.Add(final2);
            DiagramConnector semi1_1 = new DiagramConnector()
            {
                Id = "semi1_1",
                SourceID = "quarter1",
                TargetID = "semi1",
                AddInfo = new Dictionary<string, int>()
                {
                    {"x", leftSemiFinalNodesOffsetX - angleTiltAmountForQuarterToSemi},
                    {"y", quarterFinalTopOffsetY}
                },
                SourceDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },
                TargetDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },
            };
            Connectors.Add(semi1_1);

            DiagramConnector semi1_2 = new DiagramConnector()
            {
                Id = "semi1_2",
                SourceID = "quarter2",
                TargetID = "semi1",
                AddInfo = new Dictionary<string, int>()
                {
                    {"x", leftSemiFinalNodesOffsetX - angleTiltAmountForQuarterToSemi},
                    {"y", quarterFinalBottomOffsetY}
                },
                SourceDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },
                TargetDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },
            };
            Connectors.Add(semi1_2);

            DiagramConnector semi2_1 = new DiagramConnector()
            {
                Id = "semi2_1",
                SourceID = "quarter3",
                TargetID = "semi2",
                AddInfo = new Dictionary<string, int>()
                {
                    {"x", rightSemiFinalNodesOffsetX + angleTiltAmountForQuarterToSemi},
                    {"y", quarterFinalTopOffsetY}
                },
                SourceDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },
                TargetDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },

            };
            Connectors.Add(semi2_1);

            DiagramConnector semi2_2 = new DiagramConnector()
            {
                Id = "semi2_2",
                SourceID = "quarter4",
                TargetID = "semi2",
                AddInfo = new Dictionary<string, int>()
                {
                    {"x", rightSemiFinalNodesOffsetX + angleTiltAmountForQuarterToSemi},
                    {"y", quarterFinalBottomOffsetY}
                },
                SourceDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },
                TargetDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },
            };
            Connectors.Add(semi2_2);


            // Add these Connectors to your CreateConnectors() method, after the existing Connectors:

            // Round 16 to Quarter Finals Connectors
            DiagramConnector quarter1_1 = new DiagramConnector()
            {
                Id = "quarter1_1",
                SourceID = "round16_1",
                TargetID = "quarter1",
                AddInfo = new Dictionary<string, int>()
                {
                    {"x", leftQuarterFinalNodesOffsetX - angleTiltAmountForRound16ToQuarter},
                    {"y", round16TopOffsetY}
                },
                SourceDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },
                TargetDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },
            };
            Connectors.Add(quarter1_1);

            DiagramConnector quarter1_2 = new DiagramConnector()
            {
                Id = "quarter1_2",
                SourceID = "round16_2",
                TargetID = "quarter1",
                AddInfo = new Dictionary<string, int>()
                {
                    {"x", leftQuarterFinalNodesOffsetX - angleTiltAmountForRound16ToQuarter},
                    {"y", round16UpperMiddleOffsetY}
                },
                SourceDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },
                TargetDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },

            };
            Connectors.Add(quarter1_2);

            DiagramConnector quarter2_1 = new DiagramConnector()
            {
                Id = "quarter2_1",
                SourceID = "round16_3",
                TargetID = "quarter2",
                AddInfo = new Dictionary<string, int>()
                {
                    {"x", leftQuarterFinalNodesOffsetX - angleTiltAmountForRound16ToQuarter},
                    {"y", round16LowerMiddleOffsetY}
                },
                SourceDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },
                TargetDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },

            };
            Connectors.Add(quarter2_1);

            DiagramConnector quarter2_2 = new DiagramConnector()
            {
                Id = "quarter2_2",
                SourceID = "round16_4",
                TargetID = "quarter2",
                AddInfo = new Dictionary<string, int>()
                {
                    {"x", leftQuarterFinalNodesOffsetX - angleTiltAmountForRound16ToQuarter},
                    {"y", round16BottomOffsetY}
                },
                SourceDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },
                TargetDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },

            };
            Connectors.Add(quarter2_2);

            DiagramConnector quarter3_1 = new DiagramConnector()
            {
                Id = "quarter3_1",
                SourceID = "round16_5",
                TargetID = "quarter3",
                AddInfo = new Dictionary<string, int>()
                {
                    {"x", rightQuarterFinalNodesOffsetX + angleTiltAmountForRound16ToQuarter},
                    {"y", round16TopOffsetY}
                },
                SourceDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },
                TargetDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },

            };
            Connectors.Add(quarter3_1);

            DiagramConnector quarter3_2 = new DiagramConnector()
            {
                Id = "quarter3_2",
                SourceID = "round16_6",
                TargetID = "quarter3",
                AddInfo = new Dictionary<string, int>()
                {
                    {"x", rightQuarterFinalNodesOffsetX + angleTiltAmountForRound16ToQuarter},
                    {"y", round16UpperMiddleOffsetY}
                },
                SourceDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },
                TargetDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },

            };
            Connectors.Add(quarter3_2);

            DiagramConnector quarter4_1 = new DiagramConnector()
            {
                Id = "quarter4_1",
                SourceID = "round16_7",
                TargetID = "quarter4",
                AddInfo = new Dictionary<string, int>()
                {
                    {"x", rightQuarterFinalNodesOffsetX + angleTiltAmountForRound16ToQuarter},
                    {"y", round16LowerMiddleOffsetY}
                },
                SourceDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },
                TargetDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },

            };
            Connectors.Add(quarter4_1);

            DiagramConnector quarter4_2 = new DiagramConnector()
            {
                Id = "quarter4_2",
                SourceID = "round16_8",
                TargetID = "quarter4",
                AddInfo = new Dictionary<string, int>()
                {
                    {"x", rightQuarterFinalNodesOffsetX + angleTiltAmountForRound16ToQuarter},
                    {"y", round16BottomOffsetY}
                },
                SourceDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },
                TargetDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },

            };
            Connectors.Add(quarter4_2);
            #endregion
        }

        public string CreateTooltipContent(TournamentMatch data)
        {
            // Format match type display text
            var matchTypeDisplay =
                data.MatchType == "round16" ? "ROUND OF 16" :
                data.MatchType == "quarterfinal" ? "QUARTER-FINAL" :
                data.MatchType == "semifinal" ? "SEMI-FINAL" :
                data.MatchType == "final" ? "FINAL" :
                data.MatchType == "champion" ? "CHAMPION" : data.MatchType?.ToUpper() ?? "";

            // Penalty shootout display
            var hasShootout = !string.IsNullOrEmpty(data.ShootoutTeam1) && !string.IsNullOrEmpty(data.ShootoutTeam2);
            var shootoutDisplay = hasShootout
                ? $"<div style=\"font-size: 11px; color: #87CEEB; margin-top: 8px; text-align: center;\"><span style='color: #FFD700;'>Penalty Shootout:</span> {data.ShootoutTeam1} - {data.ShootoutTeam2}</div>"
                : string.Empty;

            // Winner styling
            var team1WinnerStyle = data.Winner == data.Team1 ? "color: #FFD700; font-weight: bold;" : "";
            var team2WinnerStyle = data.Winner == data.Team2 ? "color: #FFD700; font-weight: bold;" : "";

            var html = $@"
                        <div style='
                            background: linear-gradient(135deg, #001122 0%, #003366 100%);
                            border-radius: 12px; padding: 16px; color: white;
                            font-family: Verdana, sans-serif; min-width: 300px; max-width: 380px;
                            box-shadow: 0 10px 30px rgba(0,0,0,0.5); position: relative; z-index: 1000; text-align: center;'>
                            <div style='font-size: 11px; font-weight: bold; color: #FFD700; margin-bottom: 6px; letter-spacing: 1px;'>UEFA CHAMPIONS LEAGUE</div>
                            <div style='font-size: 10px; color: #87CEEB; margin-bottom: 12px; font-weight: 600;'>{matchTypeDisplay}</div>
                            <div style='background: rgba(255,255,255,0.1); border-radius: 8px; padding: 12px; margin-bottom: 10px;'>
                                <div style='display: flex; justify-content: space-between; align-items: center; margin-bottom: 8px;'>
                                    <div style='flex: 1; text-align: left;'><div style='font-size: 14px; font-weight: bold; {team1WinnerStyle}'>{data.Team1}</div></div>
                                    <div style='font-size: 20px; font-weight: bold; color: #fff; margin: 0 15px;'>{data.Score1}</div>
                                </div>
                                <div style='text-align: center; margin: 8px 0;'>
                                    <div style='height: 1px; background: linear-gradient(90deg, transparent, #FFD700, transparent);'></div>
                                    <div style='font-size: 10px; color: #87CEEB; margin: 4px 0;'>VS</div>
                                    <div style='height: 1px; background: linear-gradient(90deg, transparent, #FFD700, transparent);'></div>
                                </div>
                                <div style='display: flex; justify-content: space-between; align-items: center;'>
                                    <div style='flex: 1; text-align: left;'><div style='font-size: 14px; font-weight: bold; {team2WinnerStyle}'>{data.Team2}</div></div>
                                    <div style='font-size: 20px; font-weight: bold; color: #fff; margin: 0 15px;'>{data.Score2}</div>
                                </div>
                                {shootoutDisplay}
                            </div>
                            <div style='background: linear-gradient(135deg, #FFD700 0%, #FFA500 100%); color: #001122; padding: 8px 12px; border-radius: 6px; font-weight: bold; font-size: 12px;'>
                                WINNER: {data.Winner}
                            </div>
                        </div>
                        ";
            return html;
        }
        public string GetNodeTemplate(TournamentMatch data)
        {
            // Champion Node Template
            if (data.MatchType == "champion")
            {
                return $@"
                    <div class=""tournament-node champion-node"">
                        <div class=""champion-container"">
                            <div class=""champion-badge""><div class=""champion-trophy"">🏆</div></div>
                            <div class=""champion-title"">CHAMPION</div>
                            <div class=""champion-team"">{(data.Winner ?? "TBD")}</div>
                            <div class=""champion-year"">{(data.Year ?? "2024")}</div>
                        </div>
                    </div>";
            }

            // Winner classes for styling
            var team1Class = data.Winner == data.Team1 ? "winner" : "";
            var team2Class = data.Winner == data.Team2 ? "winner" : "";

            // Round display name
            string roundDisplayName = data.MatchType switch
            {
                "round16" => "ROUND OF 16",
                "quarterfinal" => "QUARTER-FINAL",
                "semifinal" => "SEMI-FINAL",
                "final" => "FINAL",
                _ => "MATCH"
            };

            // Match node template with flip card structure
            return $@"
                <div class=""tournament-node {data.MatchType}-node"">
                    <div class=""flip-card"">
                        <div class=""flip-card-inner"">
                            <div class=""flip-card-front"">
                                <div style=""height: 100%; display: flex; align-items: center; justify-content: center; background: linear-gradient(135deg, rgba(0, 51, 102, 0.9) 0%, rgba(0, 68, 136, 0.9) 100%);"">
                                    <div style=""text-align: center; color: #cbe5feff; font-weight: 600; font-size: 16px; letter-spacing: 2px; text-shadow: 0 2px 4px rgba(0, 14, 87, 0.7);"">
                                        {roundDisplayName}
                                    </div>
                                </div>
                            </div>
                            <div class=""flip-card-back"">
                                <div class=""team-section {team1Class}"">
                                    <span class=""team-name"">{(data.Team1 ?? "TBD")}</span>
                                    <span class=""team-score score-right"">{(data.Score1?.ToString() ?? "")}</span>
                                </div>
                                <div class=""team-section {team2Class}"">
                                    <span class=""team-name"">{(data.Team2 ?? "TBD")}</span>
                                    <span class=""team-score score-right"">{(data.Score2?.ToString() ?? "")}</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>";
        }


    }
}
