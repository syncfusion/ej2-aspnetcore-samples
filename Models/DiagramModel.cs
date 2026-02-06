#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace EJ2CoreSampleBrowser.Models
{
    // Lightweight rectangle model to avoid external DiagramRect dependency
    public class DiagramRect
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
    public class DiagramData
    {
        public string DiagramId { get; set; } = string.Empty;
        public string Data { get; set; } = string.Empty;
        public long Version { get; set; } = 1;
    }
    public class DiagramUpdateMessage
    {
        [JsonPropertyName("sourceConnectionId")]
        public string SourceConnectionId { get; set; } = string.Empty;
        [JsonPropertyName("modifiedElements")]
        public List<string>? ModifiedElementIds { get; set; }
        [JsonPropertyName("version")]
        public long Version { get; set; }
    }
    public class DiagramUser
    {
        public string ConnectionId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
    public sealed class SelectionEvent
    {
        public string ConnectionId { get; set; } = default!;
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public List<string> ElementIds { get; set; } = new();
        public long TimestampUnixMs { get; set; }
        public SelectorBounds? SelectorBounds { get; set; }
    }
    public class SelectorBounds
    {
        public EJ2CoreSampleBrowser.Models.DiagramRect? Bounds { get; set; }
        public double RotationAngle { get; set; }
    }
}