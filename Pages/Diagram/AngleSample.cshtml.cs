#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using EJ2CoreSampleBrowser.Pages.Diagram;
using EJ2CoreSampleBrowser_NET6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using Syncfusion.EJ2.Diagrams;       
using System.ComponentModel;

namespace EJ2CoreSampleBrowser.Pages.Diagram
{
    public class AngleSampleModel : PageModel
    {
        public List<DiagramNode> Nodes { get; set; }
        public List<DiagramConnector> Connectors { get; set; }
        public SelectorConstraints Constraints = SelectorConstraints.All & ~(SelectorConstraints.ResizeAll | SelectorConstraints.ToolTip);
        public DiagramBackground Background;
        public int CurrentAngle = 303;
        public double Efficiency = 78;
        public string SelectedLocation = "New York";
        public DateTime SelectedDateTime = DateTime.Now;
        public double SunElevation = 0;
        public double SunAzimuth = 0;
        public double OptimalTilt = 0;
        public double SolarIrradiance = 0;
        public double IncidenceAngle = 0;
        public int IntPanelAngleDeg = 0;

        public void OnGet()
        {
            InitializeDiagram();

        }

        // Helper methods to create nodes/connectors
        private DiagramNode CreateTextNode(string id, double width, double height, double offsetX, double offsetY, string content, DiagramTextStyle textStyle, string? color = null)
        {
            return new DiagramNode()
            {
                Id = id,
                Width = width,
                Height = height,
                OffsetX = offsetX,
                OffsetY = offsetY,
                Shape = new { type = "text" },
                BackgroundColor = "none",
                BorderColor = "none",
                Annotations = new List<DiagramNodeAnnotation>
                {
                    new DiagramNodeAnnotation
                    {
                        Content = content,
                        Style = textStyle
                    }
                },
                Style = new NodeStyleNodes()
                {
                    Color = color ?? textStyle.Color,
                    Fill = "none",
                    StrokeColor = "none",
                    FontFamily = textStyle.FontFamily,
                    FontSize = textStyle.FontSize,
                    Bold = textStyle.Bold,
                    TextAlign = textStyle.TextAlign
                }
            };
        }

        private DiagramNode CreateNativeNode(string id, double width, double height, double offsetX, double offsetY, string templateId)
        {
            return new DiagramNode()
            {
                Id = id,
                Width = width,
                Height = height,
                OffsetX = offsetX,
                OffsetY = offsetY,
                Shape = new { type = "Native", content = GetNodeTemplate(templateId, "Native") },
                BackgroundColor = "none",
                Style = new NodeStyleNodes() { Fill = "none", StrokeColor = "none" }
            };
        }

        private DiagramNode CreateImageNode(string id, double width, double height, double offsetX, double offsetY, string source, double? rotateAngle = null, NodeConstraints? constraints = null, double? pivotX = null, double? pivotY = null)
        {
            var node = new DiagramNode()
            {
                Id = id,
                Width = width,
                Height = height,
                OffsetX = offsetX,
                OffsetY = offsetY,
                Shape = new { type = "Image", source },
                BackgroundColor = "none",
                Style = new NodeStyleNodes() { Fill = "none", StrokeColor = "none" }
            };
            if (rotateAngle.HasValue) node.RotateAngle = rotateAngle.Value;
            if (constraints.HasValue) node.Constraints = constraints.Value;
            if (pivotX.HasValue && pivotY.HasValue) node.Pivot = new DiagramPoint() { X = pivotX.Value, Y = pivotY.Value };
            return node;
        }

        private DiagramNode CreateEllipseNode(string id, double width, double height, double offsetX, double offsetY, string fill, string strokeColor, double strokeWidth)
        {
            return new DiagramNode()
            {
                Id = id,
                Width = width,
                Height = height,
                OffsetX = offsetX,
                OffsetY = offsetY,
                Shape = new { type = "Basic", shape = "Ellipse" },
                BackgroundColor = "none",
                Style = new NodeStyleNodes() { Fill = fill, StrokeColor = strokeColor, StrokeWidth = strokeWidth }
            };
        }

        private DiagramNode CreateHtmlNode(string id, double width, double height, double offsetX, double offsetY)
        {
            return new DiagramNode()
            {
                Id = id,
                Width = width,
                Height = height,
                OffsetX = offsetX,
                OffsetY = offsetY,
                Shape = new { type = "HTML" },
                BackgroundColor = "none",
                Style = new NodeStyleNodes() { Fill = "none", StrokeColor = "none" }
            };
        }

        private DiagramNode CreateRectNode(string id, double width, double height, double offsetX, double offsetY, string fill, string strokeColor, double strokeWidth)
        {
            return new DiagramNode()
            {
                Id = id,
                Width = width,
                Height = height,
                OffsetX = offsetX,
                OffsetY = offsetY,
                Shape = new { type = "Basic", shape = "Rectangle" },
                Style = new NodeStyleNodes() { Fill = fill, StrokeColor = strokeColor, StrokeWidth = strokeWidth }
            };
        }

        private DiagramConnector CreateConnectorBezier(string id, double spx, double spy, double tpx, double tpy, string strokeColor, double strokeWidth, string dash, double opacity)
        {
            return new DiagramConnector()
            {
                Id = id,
                ZIndex = 1,
                Constraints = ConnectorConstraints.None,
                SourcePoint = new DiagramPoint() { X = spx, Y = spy },
                TargetPoint = new DiagramPoint() { X = tpx, Y = tpy },
                Type = Syncfusion.EJ2.Diagrams.Segments.Bezier,
                Style = new DiagramStrokeStyle() { StrokeColor = strokeColor, StrokeWidth = strokeWidth, StrokeDashArray = dash, Opacity = opacity },
                SourceDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None },
                TargetDecorator = new DiagramDecorator() { Shape = DecoratorShapes.None }
            };
        }

        public void InitializeDiagram()
        {
            Nodes = new List<DiagramNode>();
            Connectors = new List<DiagramConnector>();

            // Title
            var title = CreateTextNode(
                id: "title",
                width: 450, height: 80, offsetX: 485, offsetY: 135,
                content: "SMART SOLAR PANEL TILT SYSTEM",
                textStyle: new DiagramTextStyle { FontSize = 26, Bold = true, FontFamily = "Segoe UI", Color = "#2c3e50", TextAlign = TextAlign.Center, TextWrapping = TextWrap.NoWrap },
                color: "#2c3e50"
            );

            // Sun path connector
            var sunPath = CreateConnectorBezier(
                id: "sunPath",
                spx: 221, spy: 422, tpx: 731, tpy: 422,
                strokeColor: "#3498db", strokeWidth: 3, dash: "10,5", opacity: 0.8
            );

            // Sun nodes
            var eastSun = CreateNativeNode("eastSun", 60, 60, 221, 422, "eastSun");
            var centerSun = CreateNativeNode("centerSun", 60, 60, 483, 293, "centerSun");
            var westSun = CreateNativeNode("westSun", 60, 45, 731, 422, "westSun");

            // Labels
            var eastLabel = CreateTextNode(
                id: "eastLabel",
                width: 60, height: 30, offsetX: 238, offsetY: 365,
                content: "EAST",
                textStyle: new DiagramTextStyle { FontSize = 14, Bold = true, Color = "#34495e", FontFamily = "Segoe UI" },
                color: "#34495e"
            );
            var westLabel = CreateTextNode(
                id: "westLabel",
                width: 60, height: 30, offsetX: 725, offsetY: 365,
                content: "WEST",
                textStyle: new DiagramTextStyle { FontSize = 14, Bold = true, Color = "#34495e", FontFamily = "Segoe UI" },
                color: "#34495e"
            );

            // Ground line
            var groundLine = CreateRectNode("groundLine", 500, 5, 489, 657, "#2E485F", "#2E485F", 2);

            // Support structure
            var supportPost = CreateImageNode("supportPost", 215, 185, 465, 565, "../images/Diagram/angle/PanelSupport.png");

            // Solar panel (main interactive element)
            var solarPanelFrame = CreateImageNode(
                id: "solarPanelFrame", width: 260, height: 50, offsetX: 478.25, offsetY: 485,
                source: "../images/Diagram/angle/SolarPanel.png",
                rotateAngle: CurrentAngle,
                constraints: (NodeConstraints.Default & ~NodeConstraints.Drag) | NodeConstraints.ReadOnly,
                pivotX: 0.5, pivotY: 0.8
            );

            // Pivot point
            var pivotPoint = CreateEllipseNode("pivotPoint", 16, 16, 478.5, 488, "#FF5F1F", "#2E485F", 1);

            // HTML panels
            var locationNode = CreateHtmlNode("location", 300, 150, 1130, 100);
            var efficiencyNode = CreateHtmlNode("efficiency", 300, 350, 1130, 383);
            var angleNode = CreateHtmlNode("angle", 300, 185, 1130, 680);

            // Add nodes/connectors
            Nodes.Add(locationNode);
            Nodes.Add(efficiencyNode);
            Nodes.Add(angleNode);
            Nodes.Add(title);
            Nodes.Add(eastSun);
            Nodes.Add(centerSun);
            Nodes.Add(westSun);
            Nodes.Add(eastLabel);
            Nodes.Add(westLabel);
            Nodes.Add(groundLine);
            Nodes.Add(supportPost);
            Nodes.Add(solarPanelFrame);
            Nodes.Add(pivotPoint);
            Connectors.Add(sunPath);

            Background = new DiagramBackground()
            {
                Source = "../images/Diagram/background.png",
                Scale = Scale.Meet
            };
        }

      
        public string GetNodeTemplate(string nodeId, string? nodeShapeType = null)
        {
            switch (nodeId)
            {

                case "centerSun":
                    if (nodeShapeType == "Native")
                        return GetCenterSunSvg();
                    break;

                case "eastSun":
                    if (nodeShapeType == "Native")
                        return GetEastSunSvg();
                    break;

                case "westSun":
                    if (nodeShapeType == "Native")
                        return GetWestSunSvg();
                    break;

                default:
                    return string.Empty;
            }

            return string.Empty;
        }

        public string GetCenterSunSvg()
        {
            return @"
    <svg width=""76"" height=""76"" viewBox=""0 0 76 76"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">
        <g filter=""url(#filter0_d_1423_96)"">
            <circle cx=""37.9998"" cy=""38"" r=""17.2727"" fill=""url(#paint0_radial_1423_96)"" />
        </g>
        <g filter=""url(#filter1_d_1423_96)"">
            <path fill-rule=""evenodd"" clip-rule=""evenodd"" d=""M38.0001 6.33331C36.4102 6.33331 35.1213 7.62219 35.1213 9.2121V14.9697C35.1213 16.5596 36.4102 17.8485 38.0001 17.8485C39.59 17.8485 40.8788 16.5596 40.8788 14.9697V9.2121C40.8788 7.62219 39.59 6.33331 38.0001 6.33331ZM60.3915 15.6082C59.2672 14.484 57.4445 14.484 56.3202 15.6082L52.249 19.6794C51.1248 20.8037 51.1248 22.6264 52.249 23.7507C53.3733 24.8749 55.196 24.8749 56.3203 23.7507L60.3915 19.6794C61.5157 18.5552 61.5157 16.7325 60.3915 15.6082ZM66.7877 35.1212C68.3776 35.1212 69.6665 36.41 69.6665 38C69.6665 39.5899 68.3776 40.8787 66.7877 40.8787H61.0301C59.4402 40.8787 58.1513 39.5899 58.1513 38C58.1513 36.41 59.4402 35.1212 61.0301 35.1212H66.7877ZM15.6077 15.6083C14.4834 16.7326 14.4834 18.5553 15.6077 19.6796L19.6789 23.7508C20.8031 24.875 22.6259 24.875 23.7501 23.7508C24.8744 22.6265 24.8744 20.8038 23.7501 19.6796L19.6789 15.6083C18.5547 14.4841 16.7319 14.4841 15.6077 15.6083ZM35.1213 61.0302C35.1213 59.4403 36.4102 58.1514 38.0001 58.1514C39.59 58.1514 40.8788 59.4403 40.8788 61.0302V66.7878C40.8788 68.3777 39.59 69.6666 38.0001 69.6666C36.4102 69.6666 35.1213 68.3777 35.1213 66.7878V61.0302ZM23.7511 52.2492C22.6269 51.125 20.8041 51.125 19.6799 52.2492L15.6087 56.3204C14.4844 57.4447 14.4844 59.2674 15.6087 60.3917C16.7329 61.5159 18.5557 61.5159 19.6799 60.3917L23.7511 56.3204C24.8754 55.1962 24.8754 53.3735 23.7511 52.2492ZM14.9696 35.1212C16.5595 35.1212 17.8484 36.41 17.8484 38C17.8484 39.5899 16.5595 40.8787 14.9696 40.8787H9.21204C7.62213 40.8787 6.33325 39.5899 6.33325 38C6.33325 36.41 7.62213 35.1212 9.21204 35.1212H14.9696ZM52.2491 52.2492C51.1248 53.3734 51.1248 55.1962 52.2491 56.3204L56.3203 60.3916C57.4445 61.5159 59.2673 61.5159 60.3915 60.3916C61.5157 59.2674 61.5157 57.4447 60.3915 56.3204L56.3203 52.2492C55.196 51.125 53.3733 51.125 52.2491 52.2492Z"" fill=""url(#paint1_linear_1423_96)"" />
        </g>
        <defs>
            <filter id=""filter0_d_1423_96"" x=""16.9271"" y=""16.9272"" width=""42.9899"" height=""42.9899"" filterUnits=""userSpaceOnUse"" color-interpolation-filters=""sRGB"">
                <feFlood flood-opacity=""0"" result=""BackgroundImageFix"" />
                <feColorMatrix in=""SourceAlpha"" type=""matrix"" values=""0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 127 0"" result=""hardAlpha"" />
                <feOffset dx=""0.422222"" dy=""0.422222"" />
                <feGaussianBlur stdDeviation=""2.11111"" />
                <feComposite in2=""hardAlpha"" operator=""out"" />
                <feColorMatrix type=""matrix"" values=""0 0 0 0 0 0 0 0 0 0.156863 0 0 0 0 0.305882 0 0 0 0.25 0"" />
                <feBlend mode=""normal"" in2=""BackgroundImageFix"" result=""effect1_dropShadow_1423_96"" />
                <feBlend mode=""normal"" in=""SourceGraphic"" in2=""effect1_dropShadow_1423_96"" result=""shape"" />
            </filter>
            <filter id=""filter1_d_1423_96"" x=""2.53325"" y=""2.53331"" width=""71.7777"" height=""71.7777"" filterUnits=""userSpaceOnUse"" color-interpolation-filters=""sRGB"">
                <feFlood flood-opacity=""0"" result=""BackgroundImageFix"" />
                <feColorMatrix in=""SourceAlpha"" type=""matrix"" values=""0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 127 0"" result=""hardAlpha"" />
                <feOffset dx=""0.422222"" dy=""0.422222"" />
                <feGaussianBlur stdDeviation=""2.11111"" />
                <feComposite in2=""hardAlpha"" operator=""out"" />
                <feColorMatrix type=""matrix"" values=""0 0 0 0 0 0 0 0 0 0.156863 0 0 0 0 0.305882 0 0 0 0.25 0"" />
                <feBlend mode=""normal"" in2=""BackgroundImageFix"" result=""effect1_dropShadow_1423_96"" />
                <feBlend mode=""normal"" in=""SourceGraphic"" in2=""effect1_dropShadow_1423_96"" result=""shape"" />
            </filter>
            <radialGradient id=""paint0_radial_1423_96"" cx=""0"" cy=""0"" r=""1"" gradientUnits=""userSpaceOnUse"" gradientTransform=""translate(41.9506 27.1674) rotate(180) scale(32.7949)"">
                <stop stop-color=""#FFF4C3"" />
                <stop offset=""0.16"" stop-color=""#FFE036"" />
                <stop offset=""1"" stop-color=""#FA761C"" />
            </radialGradient>
            <linearGradient id=""paint1_linear_1423_96"" x1=""66.8754"" y1=""5.38557"" x2=""10.5535"" y2=""67.6553"" gradientUnits=""userSpaceOnUse"">
                <stop stop-color=""#FFBA24"" />
                <stop offset=""1"" stop-color=""#FF5500"" />
            </linearGradient>
        </defs>
    </svg>";
        }

        public string GetEastSunSvg()
        {
            return @"
    <svg width=""76"" height=""76"" viewBox=""0 0 76 76"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">
<g clip-path=""url(#clip0_7964_371)"">
<g filter=""url(#filter0_d_7964_371)"">
<path d=""M14.9707 35.1214C16.5606 35.1214 17.8496 36.4104 17.8496 38.0003C17.8494 39.59 16.5605 40.8792 14.9707 40.8792H9.21289C7.62318 40.8791 6.33416 39.59 6.33398 38.0003C6.33398 36.4105 7.62307 35.1215 9.21289 35.1214H14.9707ZM66.7881 35.1214C68.3778 35.1216 69.666 36.4105 69.666 38.0003C69.6658 39.5899 68.3777 40.879 66.7881 40.8792H61.0303C59.4405 40.8792 58.1515 39.5901 58.1514 38.0003C58.1514 36.4104 59.4404 35.1214 61.0303 35.1214H66.7881ZM15.6074 15.6087C16.7317 14.4845 18.5545 14.4845 19.6787 15.6087L23.75 19.68C24.8737 20.8041 24.8737 22.6262 23.75 23.7503C22.6259 24.8744 20.803 24.8751 19.6787 23.7513L15.6074 19.68C14.4832 18.5558 14.4832 16.7329 15.6074 15.6087ZM56.3203 15.6087C57.4445 14.4845 59.2674 14.4845 60.3916 15.6087C61.5158 16.7329 61.5158 18.5558 60.3916 19.68L56.3203 23.7513C55.1962 24.8749 53.3741 24.8749 52.25 23.7513C51.1258 22.627 51.1258 20.8042 52.25 19.68L56.3203 15.6087ZM38.001 6.33331C39.5907 6.33352 40.8789 7.62244 40.8789 9.21222V14.97C40.8787 16.5597 39.5906 17.8487 38.001 17.8489C36.4112 17.8489 35.1222 16.5598 35.1221 14.97V9.21222C35.1221 7.62231 36.4111 6.33331 38.001 6.33331Z"" fill=""url(#paint0_linear_7964_371)"" />
</g>
<g filter=""url(#filter1_d_7964_371)"">
<path d=""M56.9995 63.3337C58.1653 63.3337 59.1106 64.2783 59.1108 65.444C59.1108 66.61 58.1654 67.5554 56.9995 67.5554H23.2222C22.0562 67.5554 21.1108 66.61 21.1108 65.444C21.1111 64.2783 22.0564 63.3337 23.2222 63.3337H56.9995ZM37.9995 50.6667C39.1654 50.6667 40.1108 51.6121 40.1108 52.778C40.1107 53.9438 39.1654 54.8893 37.9995 54.8893H4.22217C3.05631 54.8893 2.11097 53.9438 2.11084 52.778C2.11084 51.6121 3.05623 50.6667 4.22217 50.6667H37.9995ZM71.7778 50.6667C72.9437 50.6668 73.8892 51.6122 73.8892 52.778C73.889 53.9438 72.9436 54.8892 71.7778 54.8893H46.4438C45.2782 54.8891 44.3336 53.9437 44.3335 52.778C44.3335 51.6122 45.2781 50.6669 46.4438 50.6667H71.7778Z"" fill=""url(#paint1_radial_7964_371)"" />
</g>
<g filter=""url(#filter2_d_7964_371)"">
<path d=""M38 20.7271C47.5394 20.7271 55.2733 28.4602 55.2734 37.9996C55.2734 39.4562 55.0924 40.8709 54.7529 42.2222H21.248C20.9085 40.8709 20.7275 39.4562 20.7275 37.9996C20.7277 28.4603 28.4607 20.7273 38 20.7271Z"" fill=""url(#paint2_radial_7964_371)"" />
</g>
</g>
<defs>
<filter id=""filter0_d_7964_371"" x=""2.53398"" y=""2.53331"" width=""71.7765"" height=""42.9903"" filterUnits=""userSpaceOnUse"" color-interpolation-filters=""sRGB"">
<feFlood flood-opacity=""0"" result=""BackgroundImageFix"" />
<feColorMatrix in=""SourceAlpha"" type=""matrix"" values=""0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 127 0"" result=""hardAlpha"" />
<feOffset dx=""0.422222"" dy=""0.422222"" />
<feGaussianBlur stdDeviation=""2.11111"" />
<feComposite in2=""hardAlpha"" operator=""out"" />
<feColorMatrix type=""matrix"" values=""0 0 0 0 0 0 0 0 0 0.156863 0 0 0 0 0.305882 0 0 0 0.25 0"" />
<feBlend mode=""normal"" in2=""BackgroundImageFix"" result=""effect1_dropShadow_7964_371"" />
<feBlend mode=""normal"" in=""SourceGraphic"" in2=""effect1_dropShadow_7964_371"" result=""shape"" />
</filter>
<filter id=""filter1_d_7964_371"" x=""-1.68916"" y=""46.8667"" width=""80.2228"" height=""25.3331"" filterUnits=""userSpaceOnUse"" color-interpolation-filters=""sRGB"">
<feFlood flood-opacity=""0"" result=""BackgroundImageFix"" />
<feColorMatrix in=""SourceAlpha"" type=""matrix"" values=""0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 127 0"" result=""hardAlpha"" />
<feOffset dx=""0.422222"" dy=""0.422222"" />
<feGaussianBlur stdDeviation=""2.11111"" />
<feComposite in2=""hardAlpha"" operator=""out"" />
<feColorMatrix type=""matrix"" values=""0 0 0 0 0 0 0 0 0 0.156863 0 0 0 0 0.305882 0 0 0 0.25 0"" />
<feBlend mode=""normal"" in2=""BackgroundImageFix"" result=""effect1_dropShadow_7964_371"" />
<feBlend mode=""normal"" in=""SourceGraphic"" in2=""effect1_dropShadow_7964_371"" result=""shape"" />
</filter>
<filter id=""filter2_d_7964_371"" x=""16.9275"" y=""16.9271"" width=""42.9903"" height=""29.9396"" filterUnits=""userSpaceOnUse"" color-interpolation-filters=""sRGB"">
<feFlood flood-opacity=""0"" result=""BackgroundImageFix"" />
<feColorMatrix in=""SourceAlpha"" type=""matrix"" values=""0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 127 0"" result=""hardAlpha"" />
<feOffset dx=""0.422222"" dy=""0.422222"" />
<feGaussianBlur stdDeviation=""2.11111"" />
<feComposite in2=""hardAlpha"" operator=""out"" />
<feColorMatrix type=""matrix"" values=""0 0 0 0 0 0 0 0 0 0.156863 0 0 0 0 0.305882 0 0 0 0.25 0"" />
<feBlend mode=""normal"" in2=""BackgroundImageFix"" result=""effect1_dropShadow_7964_371"" />
<feBlend mode=""normal"" in=""SourceGraphic"" in2=""effect1_dropShadow_7964_371"" result=""shape"" />
</filter>
<linearGradient id=""paint0_linear_7964_371"" x1=""66.875"" y1=""5.81636"" x2=""42.3723"" y2=""55.4803"" gradientUnits=""userSpaceOnUse"">
<stop stop-color=""#FFBA24"" />
<stop offset=""1"" stop-color=""#FF5500"" />
</linearGradient>
<radialGradient id=""paint1_radial_7964_371"" cx=""0"" cy=""0"" r=""1"" gradientUnits=""userSpaceOnUse"" gradientTransform=""translate(49.6112 64.3887) rotate(-168.69) scale(48.441 24.199)"">
<stop stop-color=""#FFBA24"" />
<stop offset=""1"" stop-color=""#FF5500"" />
</radialGradient>
<radialGradient id=""paint2_radial_7964_371"" cx=""0"" cy=""0"" r=""1"" gradientUnits=""userSpaceOnUse"" gradientTransform=""translate(41.9513 27.1673) rotate(180) scale(32.7953 32.7951)"">
<stop stop-color=""#FFF4C3"" />
<stop offset=""0.16"" stop-color=""#FFE036"" />
<stop offset=""1"" stop-color=""#FA761C"" />
</radialGradient>
<clipPath id=""clip0_7964_371"">
<rect width=""76"" height=""76"" fill=""white"" />
</clipPath>
</defs>
</svg>";
        }

        public string GetWestSunSvg()
        {
            return @"
    <svg width=""76"" height=""76"" viewBox=""0 0 76 76"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">
<g clip-path=""url(#clip0_7964_385)"">
<g filter=""url(#filter0_d_7964_385)"">
<path d=""M56.9998 61.2225C58.1655 61.2225 59.1108 62.1672 59.1111 63.3329C59.1111 64.4988 58.1657 65.4442 56.9998 65.4442H23.2224C22.0565 65.4442 21.1111 64.4988 21.1111 63.3329C21.1113 62.1672 22.0566 61.2225 23.2224 61.2225H56.9998ZM37.9998 48.5555C39.1657 48.5555 40.1111 49.5009 40.1111 50.6669C40.111 51.8327 39.1656 52.7782 37.9998 52.7782H4.22241C3.05655 52.7782 2.11119 51.8327 2.11108 50.6669C2.11108 49.5009 3.05648 48.5555 4.22241 48.5555H37.9998ZM71.7781 48.5555C72.9438 48.5557 73.8884 49.5011 73.8884 50.6669C73.8883 51.8326 72.9438 52.778 71.7781 52.7782H48.5554C47.3896 52.7782 46.4442 51.8327 46.4441 50.6669C46.4441 49.501 47.3895 48.5556 48.5554 48.5555H71.7781Z"" fill=""url(#paint0_radial_7964_385)"" />
</g>
<g filter=""url(#filter1_d_7964_385)"">
<path d=""M37.7803 8.17151C51.8926 8.17156 63.333 19.6119 63.333 33.7242C63.333 35.8791 63.0648 37.9713 62.5625 39.9703H12.998C12.4958 37.9713 12.2275 35.8791 12.2275 33.7242C12.2275 19.6119 23.6679 8.17151 37.7803 8.17151Z"" fill=""url(#paint1_radial_7964_385)"" />
</g>
</g>
<defs>
<filter id=""filter0_d_7964_385"" x=""-1.68892"" y=""44.7555"" width=""80.2218"" height=""25.3331"" filterUnits=""userSpaceOnUse"" color-interpolation-filters=""sRGB"">
<feFlood flood-opacity=""0"" result=""BackgroundImageFix"" />
<feColorMatrix in=""SourceAlpha"" type=""matrix"" values=""0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 127 0"" result=""hardAlpha"" />
<feOffset dx=""0.422222"" dy=""0.422222"" />
<feGaussianBlur stdDeviation=""2.11111"" />
<feComposite in2=""hardAlpha"" operator=""out"" />
<feColorMatrix type=""matrix"" values=""0 0 0 0 0 0 0 0 0 0.156863 0 0 0 0 0.305882 0 0 0 0.25 0"" />
<feBlend mode=""normal"" in2=""BackgroundImageFix"" result=""effect1_dropShadow_7964_385"" />
<feBlend mode=""normal"" in=""SourceGraphic"" in2=""effect1_dropShadow_7964_385"" result=""shape"" />
</filter>
<filter id=""filter1_d_7964_385"" x=""8.42754"" y=""4.37151"" width=""59.5499"" height=""40.2433"" filterUnits=""userSpaceOnUse"" color-interpolation-filters=""sRGB"">
<feFlood flood-opacity=""0"" result=""BackgroundImageFix"" />
<feColorMatrix in=""SourceAlpha"" type=""matrix"" values=""0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 127 0"" result=""hardAlpha"" />
<feOffset dx=""0.422222"" dy=""0.422222"" />
<feGaussianBlur stdDeviation=""2.11111"" />
<feComposite in2=""hardAlpha"" operator=""out"" />
<feColorMatrix type=""matrix"" values=""0 0 0 0 0 0 0 0 0 0.156863 0 0 0 0 0.305882 0 0 0 0.25 0"" />
<feBlend mode=""normal"" in2=""BackgroundImageFix"" result=""effect1_dropShadow_7964_385"" />
<feBlend mode=""normal"" in=""SourceGraphic"" in2=""effect1_dropShadow_7964_385"" result=""shape"" />
</filter>
<radialGradient id=""paint0_radial_7964_385"" cx=""0"" cy=""0"" r=""1"" gradientUnits=""userSpaceOnUse"" gradientTransform=""translate(39.8314 62.2776) rotate(-165.864) scale(38.8982 23.931)"">
<stop stop-color=""#FFBA24"" />
<stop offset=""1"" stop-color=""#FF5500"" />
</radialGradient>
<radialGradient id=""paint1_radial_7964_385"" cx=""0"" cy=""0"" r=""1"" gradientUnits=""userSpaceOnUse"" gradientTransform=""translate(46.0737 36.9531) rotate(-153.435) scale(41.1658 41.1657)"">
<stop stop-color=""#FFF4C3"" />
<stop offset=""0.28125"" stop-color=""#FFE036"" />
<stop offset=""0.598958"" stop-color=""#FA761C"" />
</radialGradient>
<clipPath id=""clip0_7964_385"">
<rect width=""76"" height=""76"" fill=""white"" />
</clipPath>
</defs>
</svg>";
        }


        public List<LocationData> locations = new List<LocationData>
        {
            // US Cities

            new LocationData { Name = "New York", Latitude = 40.7128, Longitude = -74.0060, Angle = 45 },
            new LocationData { Name = "Los Angeles", Latitude = 34.0522, Longitude = -118.2437, Angle = 67 },
            new LocationData { Name = "Chicago", Latitude = 41.8781, Longitude = -87.6298, Angle = 90 },
            new LocationData { Name = "Houston", Latitude = 29.7604, Longitude = -95.3698, Angle = 112 },
            new LocationData { Name = "Phoenix", Latitude = 33.4484, Longitude = -112.0740, Angle = 135 },

        };

        public class LocationData
        {
            public string? Name { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public int Angle { get; set; }
        }

    }
}
