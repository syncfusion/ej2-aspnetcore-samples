#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Diagrams;
using Syncfusion.EJ2.Layouts;
using System.Xml.Linq;

namespace EJ2CoreSampleBrowser.Pages.Diagram;

public class PeriodicTableModel : PageModel
{
    public List<DiagramNode> Nodes { get; set; }
    public List<DiagramConnector> Connectors { get; set; }
    public DiagramConstraints Constraints { get; set; } = DiagramConstraints.Default & ~DiagramConstraints.UndoRedo;
    public List<FontFamily> Font { get; set; }
    public List<TemplateList> TemplateList { get; set; }
    public DiagramSelector DiagramSelector { get; set; }
    List<DiagramNode> legendNodes = new List<DiagramNode>();
    public const double CellWidth = 60;
    public const double CellHeight = 60;
    public const double CellSpacing = 10;
    public const double StartX = 50;
    public const double StartY = 50;
    Dictionary<string, string> CategoryColors = new Dictionary<string, string>
{
    { "alkali-metals", "#006AC7" },
    { "alkaline-earth-metals", "#08970E" },
    { "transition-metals", "#F08000" },
    { "other-metals", "#B75A09" },
    { "metalloids", "#95B506" },
    { "non-metals", "#DE2362" },
    { "halogens", "#DE2723" },
    { "noble-gases", "#0B98A9" },
    { "lanthanides", "#5C1FA8" },
    { "actinides", "#8C04A1" }
};

    public void OnGet()
    {
        DiagramSelector = new DiagramSelector()
        {
            Constraints = SelectorConstraints.None,
        };
        Nodes = new List<DiagramNode>();
        Connectors = new List<DiagramConnector>();
        InitPeriodicTable();

    }
    public void InitPeriodicTable()
    {
       

        // Add element Nodes
        foreach (var element in periodicTableData)
        {
            Nodes.Add(CreateElementNode(element));
        }

        // Add legend Nodes
        CreateLegendNodes();

        // Add period and group labels
        CreateRowsColumns();

        // Add block labels
        CreateBlockNodesAndConnectors();

        // Add title node
        double cellWidth = 60;
        double cellSpacing = 10;
        double startX = 50;
        double startY = 50;

        Nodes.Add(new DiagramNode
        {
            Id = "title",
            OffsetX = startX + 9 * (cellWidth + cellSpacing),
            OffsetY = startY - 100,
            Constraints = NodeConstraints.None,
            Shape = new { type = "Text",content = "Periodic Table of Elements" },
            Style = new DiagramTextStyle
            {
                FontSize = 24,
                Color = "#212121",
                FontFamily = "Roboto",
                Bold = true
            }
        });
    }

    public DiagramNode CreateElementNode(Element element)
    {
        var position = CalculatePosition(element.Period, element.Group, element.Block == "f");
        var fillColor = CategoryColors[element.Category];
        var id = element.AtomicNumber?.ToString() ?? Guid.NewGuid().ToString();

        var annotations = new List<DiagramNodeAnnotation>
    {
        // Atomic number (top-left)
        new DiagramNodeAnnotation
        {
            Id="annot",
            Content = element.AtomicNumber?.ToString() ?? "",
            Offset = new DiagramPoint { X = 0.15, Y = 0.2 },
            Style = new DiagramTextStyle
            {
                FontSize = 11,
                FontFamily = "Roboto",
                Color = "#FFFFFF"
            }
        },
        //Symbol (center)
        new DiagramNodeAnnotation
        {
             Id="anno2",
            Content = element.Symbol,
            Offset = new DiagramPoint { X = 0.5, Y = 0.5 },
            Style = new DiagramTextStyle
            {
                FontSize = 16,
                FontFamily = "Roboto",
                Color = "#FFFFFF",
                Bold = true
            }
        },
        // Name (bottom)
        new DiagramNodeAnnotation
        {
             Id="anno3",
            Content = element.Name,
            Offset = new DiagramPoint { X = 0.5, Y = 0.85 },
            Style = new DiagramTextStyle
            {
                FontSize = 11,
                FontFamily = "Roboto",
                Color = "#FFFFFF",
                TextOverflow = TextOverflow.Ellipsis,
                TextWrapping = TextWrap.NoWrap
            }
        },
        // // Atomic mass (top-right, hidden)
        new DiagramNodeAnnotation
        {
             Id="anno4",
            Content = element.AtomicMass?.ToString() ?? "",
            Offset = new DiagramPoint { X = 0.75, Y = 0.2 },
            Style = new DiagramTextStyle
            {
                FontSize = 11,
                FontFamily = "Roboto",
                Color = "#FFFFFF"
            },
            Visibility = false
        }
    };

        return new DiagramNode
        {
            Id = $"element_{id}",
            OffsetX = position.X + CellWidth / 2,
            OffsetY = position.Y + CellHeight / 2,
            Width = CellWidth,
            Height = CellHeight,
            Shape = new { type = "Basic", shape = "Rectangle", cornerRadius = 5 },
            Annotations = annotations,

            Constraints = (NodeConstraints.Default | NodeConstraints.ReadOnly) & ~NodeConstraints.Select,
            Style = new NodeStyleNodes
            {
               Fill=fillColor,
            },
            AddInfo = new Dictionary<string, string>
        {
            //{ "AtomicMass", element.AtomicMass.ToString() },
             { "Name", element.Name.ToString() },
              { "Period", element.Period.ToString() },
                 { "Symbol", element.Symbol.ToString() },
                      { "Group", element.Group.ToString() },
                        //{ "AtomicNumber", element.AtomicNumber.ToString() },
                          { "Category", element.Category.ToString() },
                          //{ "Block", element.Block.ToString() }
        }
        };
    }

    public void CreateLegendNodes()
    {
        var legendData = new List<(string Category, string Label)>
    {
        ("alkali-metals", "Alkali metals"),
        ("alkaline-earth-metals", "Alkaline earth metals"),
        ("transition-metals", "Transition metals"),
        ("other-metals", "Other metals"),
        ("metalloids", "Metalloids"),
        ("non-metals", "Non-metals"),
        ("halogens", "Halogens"),
        ("noble-gases", "Noble gases"),
        ("lanthanides", "Lanthanides"),
        ("actinides", "Actinides")
    };

        var legendNodes = new List<DiagramNode>();

        double cellWidth = 60;
        double cellSpacing = 10;
        double startX = 50;
        double startY = 50;

        double tableWidth = 19 * (cellWidth + cellSpacing);
        double tableCenterX = startX + tableWidth / 2;

        double legendItemWidth = 170;
        double legendItemHeight = 20;
        double legendSpacing = 10;
        int legendRowItems = 5;

        double totalLegendWidth = legendRowItems * legendItemWidth + (legendRowItems - 1) * legendSpacing;
        double legendStartY = startY + 10 * (cellWidth + cellSpacing) + 20;
        double legendStartX = tableCenterX - totalLegendWidth / 2;

        for (int index = 0; index < legendData.Count; index++)
        {
            var (category, label) = legendData[index];
            var fillColor = CategoryColors[legendData[index].Category];

            int row = (index / legendRowItems);
            int col = index % legendRowItems;

            double x = legendStartX + col * (legendItemWidth + legendSpacing);
            double y = legendStartY + row * (legendItemHeight + legendSpacing);

            // Color indicator node
            Nodes.Add(new DiagramNode
            {
                Id = $"legend_color_{index}",
                OffsetX = x + 10,
                OffsetY = y + legendItemHeight / 2,
                Width = 20,
                Height = 20,
                Constraints = NodeConstraints.None,
                Shape = new { type = "Basic", shape = "Ellipse" },
                Style = new NodeStyleNodes
                {
                      Fill= fillColor,
                    StrokeColor = "#444444",
                    StrokeWidth = 1
                }
            });

            // Label node
            Nodes.Add(new DiagramNode
            {
                Id = $"legend_label_{index}",
                OffsetX = x + 90,
                OffsetY = y + legendItemHeight / 2,
                Width = 140,
                Height = legendItemHeight,
                Constraints = NodeConstraints.None,
                Shape = new { type = "Text", content = label },
                Style = new DiagramTextStyle
                {
                    Fill = "transparent",
                    FontSize = 14,
                    FontFamily = "Roboto",
                    Color = "#212121"
                }
            });
        }
    }
    public void CreateRowsColumns()
    {

        double cellWidth = 60;
        double cellHeight = 60;
        double cellSpacing = 10;
        double startX = 50;
        double startY = 50;

        // "PERIOD" label (rotated)
        Nodes.Add(new DiagramNode
        {
            Id = "PERIOD",
            OffsetX = startX - (cellWidth + cellSpacing) / 2 - 10,
            OffsetY = startY + (cellHeight + cellSpacing) / 2 - 30,
            RotateAngle = 270,
            Constraints = NodeConstraints.None,
            Shape = new { type = "Text", content = "PERIOD" },
            Style = new DiagramTextStyle
            {
                Fill = "transparent",
                FontFamily = "Roboto",
                Bold = true
            }
        });

        // "GROUP" label
        Nodes.Add(new DiagramNode
        {
            Id = "GROUP",
            OffsetX = startX,
            OffsetY = startY - (cellHeight + cellSpacing) / 2 - 30,
            Constraints = NodeConstraints.None,
            Shape = new { type = "Text", content = "GROUP" },
            Style = new DiagramTextStyle
            {
                Fill = "transparent",
                FontFamily = "Roboto",
                Bold = true
            }
        });

        // Period numbers (rows)
        for (int period = 0; period < 7; period++)
        {
            Nodes.Add(new DiagramNode
            {
                Id = $"PERIOD_{period}",
                OffsetX = startX - (cellWidth + cellSpacing) / 3,
                OffsetY = startY + period * (cellHeight + cellSpacing) + cellHeight / 2,
                Width = cellWidth / 3,
                Height = cellHeight,
                Shape = new { type = "Text", content = (period + 1).ToString() },
                Style = new DiagramTextStyle
                {
                    FontSize = 14,
                    Color = "#424242",
                    Fill = period % 2 == 0 ? "#dfe6f3" : "#fbfcff",
                    FontFamily = "Roboto"
                },
                BorderWidth = 1,
                BorderColor = "#d0d7e2",
                Constraints = NodeConstraints.Select | NodeConstraints.PointerEvents,
                AddInfo = new Dictionary<string, object>
            {
                { "label", "PERIOD" },
                { "cellValue", period + 1 }
            }
            });
        }

        // Group numbers (columns)
        for (int group = 0; group < 18; group++)
        {
            Nodes.Add(new DiagramNode
            {
                Id = $"GROUP_{group}",
                OffsetX = startX + group * (cellWidth + cellSpacing) + cellWidth / 2,
                OffsetY = startY - (cellHeight + cellSpacing) / 2 - 10,
                Width = cellWidth,
                Height = cellHeight / 3,
                Shape = new { type = "Text", content = (group + 1).ToString() },
                Style = new DiagramTextStyle
                {
                    FontSize = 14,
                    Color = "#424242",
                    Fill = group % 2 == 0 ? "#dfe6f3" : "#fbfcff",
                    FontFamily = "Roboto"
                },
                BorderWidth = 1,
                BorderColor = "#d0d7e2",
                Constraints = NodeConstraints.Select | NodeConstraints.PointerEvents|NodeConstraints.ReadOnly,
                AddInfo = new Dictionary<string, object>
            {
                { "label", "GROUP" },
                { "cellValue", group + 1 }
            }
            });
        }
    }
    public void CreateBlockNodesAndConnectors()
    {
        double cellWidth = 60;
        double cellHeight = 60;
        double cellSpacing = 10;
        double startX = 50;
        double startY = 50;



        Nodes.Add(new DiagramNode
        {
            Id = "p_block",
            OffsetX = startX + 15 * (cellWidth + cellSpacing) - 5,
            OffsetY = startY - 19,
            Width = 70,
            Height = 15,
            Constraints = NodeConstraints.None,
            Shape = new { type = "Text", content = "P Block" },
            Style = new DiagramTextStyle { Fill = "transparent", Color = "#555555", Bold = true, FontSize = 16 },
            Ports = new List<DiagramPort>
            {
                new DiagramPort { Id = "port1", Offset = new DiagramPoint { X = 0, Y = 0.5 } },
                new DiagramPort { Id = "port2", Offset = new DiagramPoint { X = 1, Y = 0.5 } }
            }
        });
        Nodes.Add(new DiagramNode
        {
            Id = "s_block",
            OffsetX = startX + (cellWidth + cellSpacing) - 5,
            OffsetY = startY - 19,
            Width = 70,
            Height = 15,
            Constraints = NodeConstraints.None,
            Shape = new { type = "Text", content = "S Block" },
            Style = new DiagramTextStyle { Fill = "transparent", Color = "#555555", Bold = true, FontSize = 16 },
            Ports = new List<DiagramPort>
            {
                new DiagramPort { Id = "port1", Offset = new DiagramPoint { X = 0, Y = 0.5 } },
                new DiagramPort { Id= "port2", Offset = new DiagramPoint { X = 1, Y = 0.5 } }
            }
        });
        Nodes.Add(new DiagramNode
        {
            Id = "d_block",
            OffsetX = startX + 7 * (cellWidth + cellSpacing) - 5,
            OffsetY = startY + 3 * (cellHeight + cellSpacing) - 19,
            Width = 70,
            Height = 15,
            Constraints = NodeConstraints.None,
            Shape = new { type = "Text", content = "D Block" },
            Style = new DiagramTextStyle { Fill = "transparent", Color = "#555555", Bold = true, FontSize = 16 },
            Ports = new List<DiagramPort>
            {
                new DiagramPort { Id= "port1", Offset = new DiagramPoint { X = 0, Y = 0.5 } },
                new DiagramPort { Id = "port2", Offset = new DiagramPoint { X = 1, Y = 0.5 } }
            }
        });
        Nodes.Add(new DiagramNode
        {
            Id = "f_block",
            OffsetX = startX + 2 * (cellWidth + cellSpacing) - 25,
            OffsetY = startY + 8.5 * (cellHeight + cellSpacing) - 10,
            Width = 70,
            Height = 15,
            RotateAngle = 270,
            Constraints = NodeConstraints.None,
            Shape = new { type = "Text", content = "F Block" },
            Style = new DiagramTextStyle { Fill = "transparent", Color = "#555555", Bold = true, FontSize = 16 },
            Ports = new List<DiagramPort>
            {
                new DiagramPort { Id= "port1", Offset = new DiagramPoint { X = 0, Y = 0.5 } },
                new DiagramPort { Id= "port2", Offset = new DiagramPoint { X = 1, Y = 0.5 } }
            }
        });


        Connectors = new List<DiagramConnector>()
        {
            new DiagramConnector
            {
                SourceID = "p_block", SourcePortID = "port1",
                    Type=Segments.Orthogonal,
                TargetPoint = new DiagramPoint { X = startX + 12 * (cellWidth + cellSpacing), Y = startY - 9 },
             
                Segments = new List<DiagramSegment>() { new DiagramSegment() { Type = "Orthogonal", Length = 170, Direction = "Left" } },

            },
            new DiagramConnector
            {
                SourceID = "p_block", SourcePortID = "port2",
                    Type=Segments.Orthogonal,
                TargetPoint = new DiagramPoint { X = startX + 17 * (cellWidth + cellSpacing) + cellWidth, Y = startY - 9 },
                Segments = new List<DiagramSegment>() { new DiagramSegment() { Type = "Orthogonal", Length = 170, Direction = "Right" } },

            },
            new DiagramConnector
            {
                SourceID = "s_block", SourcePortID = "port1",
                    Type=Segments.Orthogonal,
                TargetPoint = new DiagramPoint { X = startX, Y = startY - 9 },
                Segments = new List<DiagramSegment>() { new DiagramSegment() { Type = "Orthogonal", Length = 30, Direction = "Left" } },
            },
            new DiagramConnector
            {
                SourceID = "s_block", SourcePortID = "port2",
                    Type=Segments.Orthogonal,
                TargetPoint = new DiagramPoint { X = startX + 1 * (cellWidth + cellSpacing) + cellWidth, Y = startY - 9 },
                Segments = new List<DiagramSegment>() { new DiagramSegment() { Type = "Orthogonal", Length = 30, Direction = "Right" } },
            },
            new DiagramConnector
            {
                SourceID = "d_block", SourcePortID = "port1",
                TargetPoint = new DiagramPoint { X = startX + 2 * (cellWidth + cellSpacing), Y = startY + 3 * (cellHeight + cellSpacing) - 9 },
                Segments = new List<DiagramSegment>() { new DiagramSegment() { Type = "Orthogonal", Length = 310, Direction = "Left" } },
            },
            new DiagramConnector
            {
                SourceID = "d_block", SourcePortID = "port2",
                    Type=Segments.Orthogonal,
                TargetPoint = new DiagramPoint { X = startX + 11 * (cellWidth + cellSpacing) + cellWidth, Y = startY + 3 * (cellHeight + cellSpacing) - 9 },
                Segments = new List<DiagramSegment>() { new DiagramSegment() { Type = "Orthogonal", Length = 310, Direction = "Right" } },
            },
            new DiagramConnector
            {
                SourceID = "f_block", SourcePortID = "port1",
                TargetPoint = new DiagramPoint { X = startX + 2 * (cellWidth + cellSpacing) - 10, Y = 700 },
                Segments = new List<DiagramSegment>() { new DiagramSegment() { Type = "Orthogonal", Length = 30, Direction = "Bottom" } },
            },
            new DiagramConnector
            {
                SourceID = "f_block", SourcePortID = "port2",
                Type=Segments.Orthogonal,
                TargetPoint = new DiagramPoint { X = startX + 2 * (cellWidth + cellSpacing) - 10, Y = 570 },
                Segments = new List<DiagramSegment>() { new DiagramSegment() { Type = "Orthogonal", Length = 30, Direction = "Top" } },
            }
        };
    }

    public class Element
    {
        public int? AtomicNumber { get; set; }
        public double? AtomicMass { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public int Period { get; set; }
        public int Group { get; set; }
        public string Category { get; set; }
        public string? Block { get; set; }
    }





    List<Element> periodicTableData = new List<Element>
{
    // Period 1
    new Element { AtomicNumber = 1, Symbol = "H", Name = "Hydrogen", Period = 1, Group = 1, Category = "non-metals", AtomicMass = 1.008 },
    new Element { AtomicNumber = 2, Symbol = "He", Name = "Helium", Period = 1, Group = 18, Category = "noble-gases", AtomicMass = 4.0026 },

    // Period 2
    new Element { AtomicNumber = 3, Symbol = "Li", Name = "Lithium", Period = 2, Group = 1, Category = "alkali-metals", AtomicMass = 6.94 },
    new Element { AtomicNumber = 4, Symbol = "Be", Name = "Beryllium", Period = 2, Group = 2, Category = "alkaline-earth-metals", AtomicMass = 9.0122 },
    new Element { AtomicNumber = 5, Symbol = "B", Name = "Boron", Period = 2, Group = 13, Category = "metalloids", AtomicMass = 10.81 },
    new Element { AtomicNumber = 6, Symbol = "C", Name = "Carbon", Period = 2, Group = 14, Category = "non-metals", AtomicMass = 12.011 },
    new Element { AtomicNumber = 7, Symbol = "N", Name = "Nitrogen", Period = 2, Group = 15, Category = "non-metals", AtomicMass = 14.007 },
    new Element { AtomicNumber = 8, Symbol = "O", Name = "Oxygen", Period = 2, Group = 16, Category = "non-metals", AtomicMass = 15.999 },
    new Element { AtomicNumber = 9, Symbol = "F", Name = "Fluorine", Period = 2, Group = 17, Category = "halogens", AtomicMass = 18.998 },
    new Element { AtomicNumber = 10, Symbol = "Ne", Name = "Neon", Period = 2, Group = 18, Category = "noble-gases", AtomicMass = 20.18 },

    // Period 3
    new Element { AtomicNumber = 11, Symbol = "Na", Name = "Sodium", Period = 3, Group = 1, Category = "alkali-metals", AtomicMass = 22.99 },
    new Element { AtomicNumber = 12, Symbol = "Mg", Name = "Magnesium", Period = 3, Group = 2, Category = "alkaline-earth-metals", AtomicMass = 24.305 },
    new Element { AtomicNumber = 13, Symbol = "Al", Name = "Aluminum", Period = 3, Group = 13, Category = "other-metals", AtomicMass = 26.982 },
    new Element { AtomicNumber = 14, Symbol = "Si", Name = "Silicon", Period = 3, Group = 14, Category = "metalloids", AtomicMass = 28.085 },
    new Element { AtomicNumber = 15, Symbol = "P", Name = "Phosphorus", Period = 3, Group = 15, Category = "non-metals", AtomicMass = 30.974 },
    new Element { AtomicNumber = 16, Symbol = "S", Name = "Sulfur", Period = 3, Group = 16, Category = "non-metals", AtomicMass = 32.06 },
    new Element { AtomicNumber = 17, Symbol = "Cl", Name = "Chlorine", Period = 3, Group = 17, Category = "halogens", AtomicMass = 35.45 },
    new Element { AtomicNumber = 18, Symbol = "Ar", Name = "Argon", Period = 3, Group = 18, Category = "noble-gases", AtomicMass = 39.948 },

        // Period 4
    new Element { AtomicNumber = 19, Symbol = "K", Name = "Potassium", Period = 4, Group = 1, Category = "alkali-metals", AtomicMass = 39.098 },
    new Element { AtomicNumber = 20, Symbol = "Ca", Name = "Calcium", Period = 4, Group = 2, Category = "alkaline-earth-metals", AtomicMass = 40.078 },
    new Element { AtomicNumber = 21, Symbol = "Sc", Name = "Scandium", Period = 4, Group = 3, Category = "transition-metals", AtomicMass = 44.956 },
    new Element { AtomicNumber = 22, Symbol = "Ti", Name = "Titanium", Period = 4, Group = 4, Category = "transition-metals", AtomicMass = 47.867 },
    new Element { AtomicNumber = 23, Symbol = "V", Name = "Vanadium", Period = 4, Group = 5, Category = "transition-metals", AtomicMass = 50.942 },
    new Element { AtomicNumber = 24, Symbol = "Cr", Name = "Chromium", Period = 4, Group = 6, Category = "transition-metals", AtomicMass = 51.996 },
    new Element { AtomicNumber = 25, Symbol = "Mn", Name = "Manganese", Period = 4, Group = 7, Category = "transition-metals", AtomicMass = 54.938 },
    new Element { AtomicNumber = 26, Symbol = "Fe", Name = "Iron", Period = 4, Group = 8, Category = "transition-metals", AtomicMass = 55.845 },
    new Element { AtomicNumber = 27, Symbol = "Co", Name = "Cobalt", Period = 4, Group = 9, Category = "transition-metals", AtomicMass = 58.933 },
    new Element { AtomicNumber = 28, Symbol = "Ni", Name = "Nickel", Period = 4, Group = 10, Category = "transition-metals", AtomicMass = 58.693 },
    new Element { AtomicNumber = 29, Symbol = "Cu", Name = "Copper", Period = 4, Group = 11, Category = "transition-metals", AtomicMass = 63.546 },
    new Element { AtomicNumber = 30, Symbol = "Zn", Name = "Zinc", Period = 4, Group = 12, Category = "transition-metals", AtomicMass = 65.38 },
    new Element { AtomicNumber = 31, Symbol = "Ga", Name = "Gallium", Period = 4, Group = 13, Category = "other-metals", AtomicMass = 69.723 },
    new Element { AtomicNumber = 32, Symbol = "Ge", Name = "Germanium", Period = 4, Group = 14, Category = "metalloids", AtomicMass = 72.63 },
    new Element { AtomicNumber = 33, Symbol = "As", Name = "Arsenic", Period = 4, Group = 15, Category = "metalloids", AtomicMass = 74.922 },
    new Element { AtomicNumber = 34, Symbol = "Se", Name = "Selenium", Period = 4, Group = 16, Category = "non-metals", AtomicMass = 78.971 },
    new Element { AtomicNumber = 35, Symbol = "Br", Name = "Bromine", Period = 4, Group = 17, Category = "halogens", AtomicMass = 79.904 },
    new Element { AtomicNumber = 36, Symbol = "Kr", Name = "Krypton", Period = 4, Group = 18, Category = "noble-gases", AtomicMass = 83.798 },

    // // Period 5
    new Element { AtomicNumber = 37, Symbol = "Rb", Name = "Rubidium", Period = 5, Group = 1, Category = "alkali-metals", AtomicMass = 85.468 },
     new Element { AtomicNumber = 38, Symbol = "Sr", Name = "Strontium", Period = 5, Group = 2, Category = "alkaline-earth-metals", AtomicMass = 87.62 },
    new Element { AtomicNumber = 39, Symbol = "Y", Name = "Yttrium", Period = 5, Group = 3, Category = "transition-metals", AtomicMass = 88.906 },
    new Element { AtomicNumber = 40, Symbol = "Zr", Name = "Zirconium", Period = 5, Group = 4, Category = "transition-metals", AtomicMass = 91.224 },
    new Element { AtomicNumber = 41, Symbol = "Nb", Name = "Niobium", Period = 5, Group = 5, Category = "transition-metals", AtomicMass = 92.906 },
    new Element { AtomicNumber = 42, Symbol = "Mo", Name = "Molybdenum", Period = 5, Group = 6, Category = "transition-metals", AtomicMass = 95.95 },
    new Element { AtomicNumber = 43, Symbol = "Tc", Name = "Technetium", Period = 5, Group = 7, Category = "transition-metals", AtomicMass = 98.0 },
    new Element { AtomicNumber = 44, Symbol = "Ru", Name = "Ruthenium", Period = 5, Group = 8, Category = "transition-metals", AtomicMass = 101.07 },
    new Element { AtomicNumber = 45, Symbol = "Rh", Name = "Rhodium", Period = 5, Group = 9, Category = "transition-metals", AtomicMass = 102.91 },
    new Element { AtomicNumber = 46, Symbol = "Pd", Name = "Palladium", Period = 5, Group = 10, Category = "transition-metals", AtomicMass = 106.42 },
    new Element { AtomicNumber = 47, Symbol = "Ag", Name = "Silver", Period = 5, Group = 11, Category = "transition-metals", AtomicMass = 107.87 },
    new Element { AtomicNumber = 48, Symbol = "Cd", Name = "Cadmium", Period = 5, Group = 12, Category = "transition-metals", AtomicMass = 112.41 },
    new Element { AtomicNumber = 49, Symbol = "In", Name = "Indium", Period = 5, Group = 13, Category = "other-metals", AtomicMass = 114.82 },
    new Element { AtomicNumber = 50, Symbol = "Sn", Name = "Tin", Period = 5, Group = 14, Category = "other-metals", AtomicMass = 118.71 },
    new Element { AtomicNumber = 51, Symbol = "Sb", Name = "Antimony", Period = 5, Group = 15, Category = "metalloids", AtomicMass = 121.76 },
    new Element { AtomicNumber = 52, Symbol = "Te", Name = "Tellurium", Period = 5, Group = 16, Category = "metalloids", AtomicMass = 127.6 },
    new Element { AtomicNumber = 53, Symbol = "I", Name = "Iodine", Period = 5, Group = 17, Category = "halogens", AtomicMass = 126.9 },
    new Element { AtomicNumber = 54, Symbol = "Xe", Name = "Xenon", Period = 5, Group = 18, Category = "noble-gases", AtomicMass = 131.29 },

        // Period 6
    new Element { AtomicNumber = 55, Symbol = "Cs", Name = "Cesium", Period = 6, Group = 1, Category = "alkali-metals", AtomicMass = 132.91},
    new Element { AtomicNumber = 56, Symbol = "Ba", Name = "Barium", Period = 6, Group = 2, Category = "alkaline-earth-metals", AtomicMass = 137.33 },
    new Element { Symbol = "57-71", Name = "Lanthanides", Period = 6, Group = 3, Category = "lanthanides"},
    new Element { AtomicNumber = 72, Symbol = "Hf", Name = "Hafnium", Period = 6, Group = 4, Category = "transition-metals", AtomicMass = 178.49},
    new Element { AtomicNumber = 73, Symbol = "Ta", Name = "Tantalum", Period = 6, Group = 5, Category = "transition-metals", AtomicMass = 180.95 },
    new Element { AtomicNumber = 74, Symbol = "W", Name = "Tungsten", Period = 6, Group = 6, Category = "transition-metals", AtomicMass = 183.84},
    new Element { AtomicNumber = 75, Symbol = "Re", Name = "Rhenium", Period = 6, Group = 7, Category = "transition-metals", AtomicMass = 186.21 },
    new Element { AtomicNumber = 76, Symbol = "Os", Name = "Osmium", Period = 6, Group = 8, Category = "transition-metals", AtomicMass = 190.23 },
    new Element { AtomicNumber = 77, Symbol = "Ir", Name = "Iridium", Period = 6, Group = 9, Category = "transition-metals", AtomicMass = 192.22 },
    new Element { AtomicNumber = 78, Symbol = "Pt", Name = "Platinum", Period = 6, Group = 10, Category = "transition-metals", AtomicMass = 195.08 },
    new Element { AtomicNumber = 79, Symbol = "Au", Name = "Gold", Period = 6, Group = 11, Category = "transition-metals", AtomicMass = 196.97 },
    new Element { AtomicNumber = 80, Symbol = "Hg", Name = "Mercury", Period = 6, Group = 12, Category = "transition-metals", AtomicMass = 200.59},
    new Element { AtomicNumber = 81, Symbol = "Tl", Name = "Thallium", Period = 6, Group = 13, Category = "other-metals", AtomicMass = 204.38 },
    new Element { AtomicNumber = 82, Symbol = "Pb", Name = "Lead", Period = 6, Group = 14, Category = "other-metals", AtomicMass = 207.2 },
    new Element { AtomicNumber = 83, Symbol = "Bi", Name = "Bismuth", Period = 6, Group = 15, Category = "other-metals", AtomicMass = 208.98},
    new Element { AtomicNumber = 84, Symbol = "Po", Name = "Polonium", Period = 6, Group = 16, Category = "metalloids", AtomicMass = 209.0 },
    new Element { AtomicNumber = 85, Symbol = "At", Name = "Astatine", Period = 6, Group = 17, Category = "halogens", AtomicMass = 210.0},
    new Element { AtomicNumber = 86, Symbol = "Rn", Name = "Radon", Period = 6, Group = 18, Category = "noble-gases", AtomicMass = 222.0 },
    // Period 7
    new Element { AtomicNumber = 87, Symbol = "Fr", Name = "Francium", Period = 7, Group = 1, Category = "alkali-metals", AtomicMass = 223.0 },
    new Element { AtomicNumber = 88, Symbol = "Ra", Name = "Radium", Period = 7, Group = 2, Category = "alkaline-earth-metals", AtomicMass = 226.0},
    new Element { Symbol = "89-103", Name = "Actinides", Period = 7, Group = 3, Category = "actinides" },
    new Element { AtomicNumber = 104, Symbol = "Rf", Name = "Rutherfordium", Period = 7, Group = 4, Category = "transition-metals", AtomicMass = 267.0 },
    new Element { AtomicNumber = 105, Symbol = "Db", Name = "Dubnium", Period = 7, Group = 5, Category = "transition-metals", AtomicMass = 270.0 },
    new Element { AtomicNumber = 106, Symbol = "Sg", Name = "Seaborgium", Period = 7, Group = 6, Category = "transition-metals", AtomicMass = 271.0},
    new Element { AtomicNumber = 107, Symbol = "Bh", Name = "Bohrium", Period = 7, Group = 7, Category = "transition-metals", AtomicMass = 270.0 },
    new Element { AtomicNumber = 108, Symbol = "Hs", Name = "Hassium", Period = 7, Group = 8, Category = "transition-metals", AtomicMass = 277.0 },
    new Element { AtomicNumber = 109, Symbol = "Mt", Name = "Meitnerium", Period = 7, Group = 9, Category = "transition-metals", AtomicMass = 276.0 },
    new Element { AtomicNumber = 110, Symbol = "Ds", Name = "Darmstadtium", Period = 7, Group = 10, Category = "transition-metals", AtomicMass = 281.0 },
    new Element { AtomicNumber = 111, Symbol = "Rg", Name = "Roentgenium", Period = 7, Group = 11, Category = "transition-metals", AtomicMass = 282.0 },
    new Element { AtomicNumber = 112, Symbol = "Cn", Name = "Copernicium", Period = 7, Group = 12, Category = "transition-metals", AtomicMass = 285.0 },
    new Element { AtomicNumber = 113, Symbol = "Nh", Name = "Nihonium", Period = 7, Group = 13, Category = "other-metals", AtomicMass = 286.0},
    new Element { AtomicNumber = 114, Symbol = "Fl", Name = "Flerovium", Period = 7, Group = 14, Category = "other-metals", AtomicMass = 289.0 },
    new Element { AtomicNumber = 115, Symbol = "Mc", Name = "Moscovium", Period = 7, Group = 15, Category = "other-metals", AtomicMass = 290.0 },
    new Element { AtomicNumber = 116, Symbol = "Lv", Name = "Livermorium", Period = 7, Group = 16, Category = "other-metals", AtomicMass = 293.0 },
    new Element { AtomicNumber = 117, Symbol = "Ts", Name = "Tennessine", Period = 7, Group = 17, Category = "halogens", AtomicMass = 294.0 },
    new Element { AtomicNumber = 118, Symbol = "Og", Name = "Oganesson", Period = 7, Group = 18, Category = "noble-gases", AtomicMass = 294.0 },

        // Lanthanides (Period 6, f-block)
    new Element { AtomicNumber = 57, Symbol = "La", Name = "Lanthanum", Period = 6, Group = 3, Category = "lanthanides", AtomicMass = 138.91, Block = "f" },
    new Element { AtomicNumber = 58, Symbol = "Ce", Name = "Cerium", Period = 6, Group = 4, Category = "lanthanides", AtomicMass = 140.12, Block = "f" },
    new Element { AtomicNumber = 59, Symbol = "Pr", Name = "Praseodymium", Period = 6, Group = 5, Category = "lanthanides", AtomicMass = 140.91, Block = "f" },
    new Element { AtomicNumber = 60, Symbol = "Nd", Name = "Neodymium", Period = 6, Group = 6, Category = "lanthanides", AtomicMass = 144.24, Block = "f" },
    new Element { AtomicNumber = 61, Symbol = "Pm", Name = "Promethium", Period = 6, Group = 7, Category = "lanthanides", AtomicMass = 145.0, Block = "f" },
    new Element { AtomicNumber = 62, Symbol = "Sm", Name = "Samarium", Period = 6, Group = 8, Category = "lanthanides", AtomicMass = 150.36, Block = "f" },
    new Element { AtomicNumber = 63, Symbol = "Eu", Name = "Europium", Period = 6, Group = 9, Category = "lanthanides", AtomicMass = 151.96, Block = "f" },
    new Element { AtomicNumber = 64, Symbol = "Gd", Name = "Gadolinium", Period = 6, Group = 10, Category = "lanthanides", AtomicMass = 157.25, Block = "f" },
    new Element { AtomicNumber = 65, Symbol = "Tb", Name = "Terbium", Period = 6, Group = 11, Category = "lanthanides", AtomicMass = 158.93, Block = "f" },
    new Element { AtomicNumber = 66, Symbol = "Dy", Name = "Dysprosium", Period = 6, Group = 12, Category = "lanthanides", AtomicMass = 162.5, Block = "f" },
    new Element { AtomicNumber = 67, Symbol = "Ho", Name = "Holmium", Period = 6, Group = 13, Category = "lanthanides", AtomicMass = 164.93, Block = "f" },
    new Element { AtomicNumber = 68, Symbol = "Er", Name = "Erbium", Period = 6, Group = 14, Category = "lanthanides", AtomicMass = 167.26, Block = "f" },
    new Element { AtomicNumber = 69, Symbol = "Tm", Name = "Thulium", Period = 6, Group = 15, Category = "lanthanides", AtomicMass = 168.93, Block = "f" },
    new Element { AtomicNumber = 70, Symbol = "Yb", Name = "Ytterbium", Period = 6, Group = 16, Category = "lanthanides", AtomicMass = 173.05, Block = "f" },
    new Element { AtomicNumber = 71, Symbol = "Lu", Name = "Lutetium", Period = 6, Group = 17, Category = "lanthanides", AtomicMass = 174.97, Block = "f" },
    // Actinides (Period 7, f-block)
    new Element { AtomicNumber = 89, Symbol = "Ac", Name = "Actinium", Period = 7, Group = 3, Category = "actinides", AtomicMass = 227.0, Block = "f" },
    new Element { AtomicNumber = 90, Symbol = "Th", Name = "Thorium", Period = 7, Group = 4, Category = "actinides", AtomicMass = 232.04, Block = "f" },
    new Element { AtomicNumber = 91, Symbol = "Pa", Name = "Protactinium", Period = 7, Group = 5, Category = "actinides", AtomicMass = 231.04, Block = "f" },
    new Element { AtomicNumber = 92, Symbol = "U", Name = "Uranium", Period = 7, Group = 6, Category = "actinides", AtomicMass = 238.03, Block = "f" },
    new Element { AtomicNumber = 93, Symbol = "Np", Name = "Neptunium", Period = 7, Group = 7, Category = "actinides", AtomicMass = 237.0, Block = "f" },
    new Element { AtomicNumber = 94, Symbol = "Pu", Name = "Plutonium", Period = 7, Group = 8, Category = "actinides", AtomicMass = 244.0, Block = "f" },
    new Element { AtomicNumber = 95, Symbol = "Am", Name = "Americium", Period = 7, Group = 9, Category = "actinides", AtomicMass = 243.0, Block = "f" },
    new Element { AtomicNumber = 96, Symbol = "Cm", Name = "Curium", Period = 7, Group = 10, Category = "actinides", AtomicMass = 247.0, Block = "f" },
    new Element { AtomicNumber = 97, Symbol = "Bk", Name = "Berkelium", Period = 7, Group = 11, Category = "actinides", AtomicMass = 247.0, Block = "f" },
    new Element { AtomicNumber = 98, Symbol = "Cf", Name = "Californium", Period = 7, Group = 12, Category = "actinides", AtomicMass = 251.0, Block = "f" },
    new Element { AtomicNumber = 99, Symbol = "Es", Name = "Einsteinium", Period = 7, Group = 13, Category = "actinides", AtomicMass = 252.0, Block = "f" },
    new Element { AtomicNumber = 100, Symbol = "Fm", Name = "Fermium", Period = 7, Group = 14, Category = "actinides", AtomicMass = 257.0, Block = "f" },
    new Element { AtomicNumber = 101, Symbol = "Md", Name = "Mendelevium", Period = 7, Group = 15, Category = "actinides", AtomicMass = 258.0, Block = "f" },
    new Element { AtomicNumber = 102, Symbol = "No", Name = "Nobelium", Period = 7, Group = 16, Category = "actinides", AtomicMass = 259.0, Block = "f" },
    new Element { AtomicNumber = 103, Symbol = "Lr", Name = "Lawrencium", Period = 7, Group = 17, Category = "actinides", AtomicMass = 262.0, Block = "f" }



};





    public DiagramPoint CalculatePosition(int period, int group, bool fBlock)
    {
        double x = StartX + (group - 1) * (CellWidth + CellSpacing);
        double y = StartY + (period - 1) * (CellHeight + CellSpacing);

        if (fBlock)
        {
            y += (2 * (CellHeight + CellSpacing)) + CellHeight / 2;
        }

        return new DiagramPoint { X = x, Y = y };
    }



}

