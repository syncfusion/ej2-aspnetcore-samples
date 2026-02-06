#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Charts;
using Syncfusion.EJ2.Diagrams;
using Syncfusion.EJ2.Popups;

using System.Collections.Generic;
using Position = Syncfusion.EJ2.Popups.Position;

namespace EJ2CoreSampleBrowser.Pages.Diagram
{
    public class NeuralNetworkModel : PageModel
    {
        public List<DiagramNode> Nodes { get; set; }
        public List<DiagramConnector> Connectors { get; set; }
        public DiagramConstraints Constraints { get; set; } = DiagramConstraints.Default & ~DiagramConstraints.UndoRedo;

        public async Task OnGet()
        {
            await CreateLayerLabels();
            await CreateNeurons();
            await CreateConnections();
        }

        // Neural network configuration
        private readonly int[] LayerSizes = { 3, 5, 4, 2 }; // Input, Hidden1, Hidden2, Output
        private readonly string[] LayerNames = { "Input Layer", "Hidden Layer 1", "Hidden Layer 2", "Output Layer" };
        private readonly string[] LayerColors = { "#0087EA", "#FE871F", "#7925E5", "#04AE45" };
        private readonly string[] NodeLabels = {
            "Feature 1,Feature 2,Feature 3", // Input layer
            "H1-1,H1-2,H1-3,H1-4,H1-5", // Hidden layer 1
            "H2-1,H2-2,H2-3,H2-4", // Hidden layer 2
            "Output 1,Output 2" // Output layer
        };
        private bool ShowWeights = true;

        private async Task CreateLayerLabels()
        {
            double startX = 100;
            double labelY = 50;
            double layerSpacing = 250;
            Nodes = new List<DiagramNode>();
            for (int i = 0; i < LayerNames.Length; i++)
            {
                var labelNode = new DiagramNode()
                {
                    Id = $"label_{i}",
                    OffsetX = startX + (i * layerSpacing),
                    OffsetY = labelY,
                    Width = 150,
                    Height = 30,
                    Style = new NodeStyleNodes()
                    {
                        Fill = "transparent",
                        StrokeColor = "transparent"
                    },
                    BorderColor = "transparent",
                    
                    Annotations = new List<DiagramNodeAnnotation>()
                    {
                        new DiagramNodeAnnotation
                        {
                            Content = LayerNames[i],  
                            Width = 150, 
                            Height = 50,
                            Style = new DiagramTextStyle { FontSize = 14, Color="#2c3e50", Bold = true },
                               //Set an template for Node annotation
                            Template = GetAnnotationHtml($"label_{i}", LayerNames[i], GetLayerColor(LayerNames[i])),
                        }
                    },                      
                    Constraints = NodeConstraints.Default & ~NodeConstraints.Select
                };
                Nodes.Add(labelNode);
            }
        }
        private string GetAnnotationHtml(string id, string content, string color)
        {
            // Generate unique HTML ID if needed
            string htmlId = id + "label_";

            return $@"
                    <div id=""{htmlId}"" style=""height: 100%; width: 100%; display: flex; justify-content: center; align-items: center; color: black; border-radius: 10px"">
                        <div style=""height: 10px; width: 10px; border-radius: 5px; background: {color}; margin-right: 10px""></div>
                        <span>{content}</span>
                    </div>
                    ";
        }
        private async Task CreateNeurons()
        {
            double startX = 100;
            double startY = 120;
            double layerSpacing = 250;
            double neuronSpacing = 100;
            for (int layerIndex = 0; layerIndex < LayerSizes.Length; layerIndex++)
            {
                int neuronsInLayer = LayerSizes[layerIndex];
                string[] labels = NodeLabels[layerIndex].Split(',');

                // Calculate starting Y position to center neurons vertically
                double layerStartY = startY + ((5 - neuronsInLayer) * neuronSpacing / 2);

                for (int neuronIndex = 0; neuronIndex < neuronsInLayer; neuronIndex++)
                {
                    var neuron = new DiagramNode()
                    {
                        Id = $"neuron_{layerIndex}_{neuronIndex}",
                        OffsetX = startX + (layerIndex * layerSpacing),
                        OffsetY = layerStartY + (neuronIndex * neuronSpacing),
                        Width = 75,
                        Height = 75,
                        Shape = new { type = "Basic", shape = "Ellipse", cornerRadius = 10 },
                        Style = new NodeStyleNodes()
                        {
                            Fill = LayerColors[layerIndex],
                            StrokeColor = GetStrokeColor(layerIndex),
                            StrokeWidth = 2
                        },
                        Annotations = new List<DiagramNodeAnnotation>()
                        {
                            new DiagramNodeAnnotation
                            {
                                Content = labels[neuronIndex],
                                Width = 150,
                                Height = 50,
                                Style = new DiagramTextStyle { FontSize = 12, Color="White", Bold = true },
                            }
                        },
                        Constraints = (NodeConstraints.Default & ~NodeConstraints.Select) | NodeConstraints.Tooltip,
                        AddInfo = new Dictionary<string, object>()
                        {
                            {"Layer", LayerNames[layerIndex]},
                            {"Neuron", labels[neuronIndex]}
                        },
                        
                    };
                    neuron.Tooltip = new DiagramDiagramTooltip
                    {
                        Position = Position.TopCenter,
                        RelativeMode = TooltipRelativeMode.Object,
                        Content = GetNodeTooltipContent("🧠 Neuron Information", (Dictionary<string, object>)neuron.AddInfo)
                    };
                    Nodes.Add(neuron);
                }
            }
        }
        private string GetNodeTooltipContent(string title, Dictionary<string, object> addInfo)
        {
            // Safely extract data from addInfo
            string layer = addInfo != null && addInfo.TryGetValue("Layer", out var l) ? l?.ToString() : "";
            string neuron = addInfo != null && addInfo.TryGetValue("Neuron", out var n) ? n?.ToString() : "";

            // Compose HTML
            return $@"
        <div style='padding:8px 12px;border-radius:6px;font-family:""Segoe UI"",sans-serif;'>
            <div style='font-weight:bold;font-size:13px;margin-bottom:4px;'>
                {title}
            </div>
            <hr style='margin:0'/>
            <div style='font-size:13px;margin-bottom:2px;'>
                <span style='font-weight:bold;'>Layer:</span> <span>{layer}</span>
            </div>
            <div style='font-size:13px;'>
                <span style='font-weight:bold;'>Neuron:</span> <span>{neuron}</span>
            </div>
        </div>";
        }

        private async Task CreateConnections()
        {
            Random random = new Random(42); // Fixed seed for consistent results
            Connectors = new List<DiagramConnector>();
            for (int layerIndex = 0; layerIndex < LayerSizes.Length - 1; layerIndex++)
            {
                int currentLayerSize = LayerSizes[layerIndex];
                int nextLayerSize = LayerSizes[layerIndex + 1];

                for (int currentNeuron = 0; currentNeuron < currentLayerSize; currentNeuron++)
                {
                    for (int nextNeuron = 0; nextNeuron < nextLayerSize; nextNeuron++)
                    {
                        string sourceId = $"neuron_{layerIndex}_{currentNeuron}";
                        string targetId = $"neuron_{layerIndex + 1}_{nextNeuron}";

                        // Generate random weight for demonstration
                        double weight = Math.Round((random.NextDouble() * 2 - 1), 2);

                        var connector = new DiagramConnector()
                        {
                            Id = $"conn_{layerIndex}_{currentNeuron}_{nextNeuron}",
                            SourceID = sourceId,
                            TargetID = targetId,
                            Type = Segments.Straight,
                            Constraints = (ConnectorConstraints.Default & ~ConnectorConstraints.Select) | ConnectorConstraints.Tooltip,
                            Style = new DiagramStrokeStyle()
                            {
                                StrokeColor = GetConnectionColor(weight),
                                StrokeWidth = GetConnectionWidth(Math.Abs(weight)),
                                Opacity = 0.7
                            },
                            TargetDecorator = new DiagramDecorator()
                            {
                                Shape = DecoratorShapes.Arrow,
                                Style = new DiagramShapeStyle()
                                {
                                    Fill = GetConnectionColor(weight),
                                    StrokeColor = GetConnectionColor(weight)
                                }
                            },
                            Annotations = ShowWeights ? new List<DiagramConnectorAnnotation>(){new DiagramConnectorAnnotation()
                            {
                                Content = weight.ToString(),
                                Style = new DiagramTextStyle()
                                {
                                    FontSize = 13,
                                    Color = "#495057",
                                    Fill = "white"
                                }
                            } } : new List<DiagramConnectorAnnotation>() { new DiagramConnectorAnnotation() },
                           
                            AddInfo = new Dictionary<string, object>()
                            {
                                {"Weight", weight},
                                {"sourceId", sourceId},
                                {"targetId", targetId},
                            }
                        };
                        connector.Tooltip = new DiagramDiagramTooltip
                        {
                            Position = Position.TopCenter,
                            RelativeMode = TooltipRelativeMode.Object,
                            Content = GetConnectorTooltipContent((Dictionary<string, object>)connector.AddInfo)
                        };
                        Connectors.Add(connector);
                    }
                }
            }
        }

        private string GetConnectorTooltipContent(Dictionary<string, object> addInfo)
        {
            // Default/fallbacks
            string weightHtml = "";
            string fromHtml = "";
            string toHtml = "";

            if (addInfo != null)
            {
                // Weight
                if (addInfo.TryGetValue("Weight", out var weightObj) && double.TryParse(weightObj?.ToString(), out double weight))
                {
                    string weightColor = weight >= 0 ? "#2ecc71" : "#e74c3c";
                    weightHtml = $@"
                <div style='font-size: 13px; margin-bottom: 2px;'>
                    <span style=' font-weight: bold;'>Weight:</span>
                    <span style='color: {weightColor}; font-weight: bold;'>{weight}</span>
                </div>";
                }
                // Source
                if (addInfo.TryGetValue("sourceId", out var sourceObj) && !string.IsNullOrEmpty(sourceObj?.ToString()))
                {
                    fromHtml = $@"
                <div style='font-size: 13px; margin-bottom: 1px;'>
                    <span style='font-weight: bold;'>From:</span>
                    <span >{sourceObj}</span>
                </div>";
                }
                // Target
                if (addInfo.TryGetValue("targetId", out var targetObj) && !string.IsNullOrEmpty(targetObj?.ToString()))
                {
                    toHtml = $@"
                <div style='font-size: 13px;'>
                    <span style='font-weight: bold;'>To:</span>
                    <span >{targetObj}</span>
                </div>";
                }
            }

            // Final assembly
            return $@"
<div style='padding: 8px 12px; border-radius: 6px; font-family: ""Segoe UI"", sans-serif; width: 100%; height: 100%'>
    <div style='font-weight: bold; font-size: 13px; margin-bottom: 4px;'>
        🔗 Connection Details
    </div>
    <hr />
    {weightHtml}
    {fromHtml}
    {toHtml}
</div>";
        }

        private string GetStrokeColor(int layerIndex)
        {
            string[] strokeColors = { "#0087EA", "#FE871F", "#7925E5", "#04AE45" };
            return strokeColors[layerIndex];
        }

        private string GetConnectionColor(double weight)
        {
            // Positive weights in blue, negative in red
            return weight >= 0 ? "#2196f3" : "#f44336";
        }

        private double GetConnectionWidth(double absWeight)
        {
            // Width based on weight magnitude (1-3 pixels)
            return Math.Max(1, Math.Min(3, absWeight * 3));
        }


        public string GetLayerColor(string layerName)
        {
            var layerMap = new Dictionary<string, string>
        {
            { "Input Layer", "#0087EA" },
            { "Hidden Layer 1", "#FE871F" },
            { "Hidden Layer 2", "#7925E5" },
            { "Output Layer", "#04AE45" }
        };

            return layerMap.TryGetValue(layerName, out var color) ? color : "#000000"; // Default to 
        }
    }
}
