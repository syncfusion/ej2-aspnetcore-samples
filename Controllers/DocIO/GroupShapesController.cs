#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Microsoft.AspNetCore.Mvc;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using System.IO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.DocIO
{
    public partial class DocIOController : Controller
    {
        #region GroupShapes
        public ActionResult GroupShapes(string Group1)
        {
            if (Group1 == null)
                return View();

            //Creates a new Word document 
            WordDocument document = new WordDocument();
            //Adds new section to the document
            IWSection section = document.AddSection();
            //Sets page setup options
            section.PageSetup.Orientation = PageOrientation.Landscape;
            section.PageSetup.Margins.All = 72;
            section.PageSetup.PageSize = new SizeF(792f, 612f);
            //Adds new paragraph to the section
            WParagraph paragraph = section.AddParagraph() as WParagraph;
            //Creates new group shape
            GroupShape groupShape = new GroupShape(document);
            //Adds group shape to the paragraph.
            paragraph.ChildEntities.Add(groupShape);

            //Create a RoundedRectangle shape with "Management" text
            CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(324f, 107.7f, 144f, 45f), 0, false, false, Color.FromArgb(50, 48, 142), "Management", groupShape, document);

            //Create a BentUpArrow shape to connect with "Development" shape
            CreateChildShape(AutoShapeType.BentUpArrow, new RectangleF(177.75f, 176.25f, 210f, 50f), 180, false, false, Color.White, null, groupShape, document);

            //Create a BentUpArrow shape to connect with "Sales" shape
            CreateChildShape(AutoShapeType.BentUpArrow, new RectangleF(403.5f, 175.5f, 210f, 50f), 180, true, false, Color.White, null, groupShape, document);

            //Create a DownArrow shape to connect with "Production" shape
            CreateChildShape(AutoShapeType.DownArrow, new RectangleF(381f, 153f, 29.25f, 72.5f), 0, false, false, Color.White, null, groupShape, document);

            //Create a RoundedRectangle shape with "Development" text
            CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(135f, 226.45f, 110f, 40f), 0, false, false, Color.FromArgb(104, 57, 157), "Development", groupShape, document);

            //Create a RoundedRectangle shape with "Production" text
            CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(341f, 226.5f, 110f, 40f), 0, false, false, Color.FromArgb(149, 50, 118), "Production", groupShape, document);

            //Create a RoundedRectangle shape with "Sales" text
            CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(546.75f, 226.5f, 110f, 40f), 0, false, false, Color.FromArgb(179, 63, 62), "Sales", groupShape, document);

            //Create a DownArrow shape to connect with "Software" and "Hardware" shape
            CreateChildShape(AutoShapeType.DownArrow, new RectangleF(177f, 265.5f, 25.5f, 20.25f), 0, false, false, Color.White, null, groupShape, document);

            //Create a DownArrow shape to connect with "Series" and "Parts" shape
            CreateChildShape(AutoShapeType.DownArrow, new RectangleF(383.25f, 265.5f, 25.5f, 20.25f), 0, false, false, Color.White, null, groupShape, document);

            //Create a DownArrow shape to connect with "North" and "South" shape            
            CreateChildShape(AutoShapeType.DownArrow, new RectangleF(588.75f, 266.25f, 25.5f, 20.25f), 0, false, false, Color.White, null, groupShape, document);

            //Create a BentUpArrow shape to connect with "Software" shape
            CreateChildShape(AutoShapeType.BentUpArrow, new RectangleF(129.5f, 286.5f, 60f, 33f), 180, false, false, Color.White, null, groupShape, document);

            //Create a BentUpArrow shape to connect with "Hardware" shape
            CreateChildShape(AutoShapeType.BentUpArrow, new RectangleF(190.5f, 286.5f, 60f, 33f), 180, true, false, Color.White, null, groupShape, document);

            //Create a BentUpArrow shape to connect with "Series" shape
            CreateChildShape(AutoShapeType.BentUpArrow, new RectangleF(336f, 287.25f, 60f, 33f), 180, false, false, Color.White, null, groupShape, document);

            //Create a BentUpArrow shape to connect with "Parts" shape
            CreateChildShape(AutoShapeType.BentUpArrow, new RectangleF(397f, 287.25f, 60f, 33f), 180, true, false, Color.White, null, groupShape, document);

            //Create a BentUpArrow shape to connect with "North" shape
            CreateChildShape(AutoShapeType.BentUpArrow, new RectangleF(541.5f, 288f, 60f, 33f), 180, false, false, Color.White, null, groupShape, document);

            //Create a BentUpArrow shape to connect with "South" shape
            CreateChildShape(AutoShapeType.BentUpArrow, new RectangleF(602.5f, 288f, 60f, 33f), 180, true, false, Color.White, null, groupShape, document);

            //Create a RoundedRectangle shape with "Software" text
            CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(93f, 320.25f, 90f, 40f), 0, false, false, Color.FromArgb(23, 187, 189), "Software", groupShape, document);

            //Create a RoundedRectangle shape with "Hardware" text
            CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(197.2f, 320.25f, 90f, 40f), 0, false, false, Color.FromArgb(24, 159, 106), "Hardware", groupShape, document);

            //Create a RoundedRectangle shape with "Series" text
            CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(299.25f, 320.25f, 90f, 40f), 0, false, false, Color.FromArgb(23, 187, 189), "Series", groupShape, document);

            //Create a RoundedRectangle shape with "Parts" text
            CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(404.2f, 320.25f, 90f, 40f), 0, false, false, Color.FromArgb(24, 159, 106), "Parts", groupShape, document);

            //Create a RoundedRectangle shape with "North" text
            CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(505.5f, 321.75f, 90f, 40f), 0, false, false, Color.FromArgb(23, 187, 189), "North", groupShape, document);

            //Create a RoundedRectangle shape with "South" text
            CreateChildShape(AutoShapeType.RoundedRectangle, new RectangleF(609.7f, 321.75f, 90f, 40f), 0, false, false, Color.FromArgb(24, 159, 106), "South", groupShape, document);

            string filename = "";
            string contenttype = "";
            MemoryStream ms = new MemoryStream();
            #region Document SaveOption
            //Save as .docx format
            if (Group1 == "WordDocx")
            {
                filename = "Sample.docx";
                contenttype = "application/vnd.ms-word.document.12";
                document.Save(ms, FormatType.Docx);
            }
            //Save as .xml format           
            else if (Group1 == "WordML")
            {
                filename = "Sample.xml";
                contenttype = "application/msword";
                document.Save(ms, FormatType.WordML);
            }
            //Save as .pdf format
            else if (Group1 == "Pdf")
            {
                filename = "Sample.pdf";
                contenttype = "application/pdf";
                DocIORenderer renderer = new DocIORenderer();
                PdfDocument pdfDoc = renderer.ConvertToPDF(document);
                pdfDoc.Save(ms);
                pdfDoc.Close();
            }
            #endregion Document SaveOption
            document.Close();
            ms.Position = 0;
            return File(ms, contenttype, filename);
        }

        /// <summary>
        /// Create a child shape with its specified properties and add into specified group shape
        /// </summary>
        /// <param name="autoShapeType">Represent the AutoShapeType of child shape</param>
        /// <param name="bounds">Represent the bounds of child shape to be placed</param>
        /// <param name="rotation">Represent the rotation of child shape</param>
        /// <param name="flipH">Represent the horizontal flip of child shape</param>
        /// <param name="flipV">Represent the vertical flip of child shape</param>
        /// <param name="fillColor">Represent the fill color of child shape</param>
        /// <param name="text">Represent the text that to be append in child shape</param>
        /// <param name="groupShape">Represent the group shape to add a child shape</param>
        /// <param name="wordDocument">Represent the Word document instance</param>
        private static void CreateChildShape(AutoShapeType autoShapeType, RectangleF bounds, float rotation, bool flipH, bool flipV, Color fillColor, string text, GroupShape groupShape, WordDocument wordDocument)
        {
            //Creates new shape to add into group
            Shape shape = new Shape(wordDocument, autoShapeType);
            //Sets height and width for shape
            shape.Height = bounds.Height;
            shape.Width = bounds.Width;
            //Sets horizontal and vertical position
            shape.HorizontalPosition = bounds.X;
            shape.VerticalPosition = bounds.Y;
            //Set rotation and flipH for the shape
            if (rotation != 0)
                shape.Rotation = rotation;
            if (flipH)
                shape.FlipHorizontal = true;
            if (flipV)
                shape.FlipVertical = true;
            //Applies fill color for shape
            if (fillColor != Color.White)
            {
                shape.FillFormat.Fill = true;
                shape.FillFormat.Color = fillColor;
            }
            //Set wrapping style for shape
            shape.WrapFormat.TextWrappingStyle = TextWrappingStyle.InFrontOfText;
            //Sets horizontal and vertical origin
            shape.HorizontalOrigin = HorizontalOrigin.Page;
            shape.VerticalOrigin = VerticalOrigin.Page;
            //Sets no line to RoundedRectangle shapes
            if (autoShapeType == AutoShapeType.RoundedRectangle)
                shape.LineFormat.Line = false;
            //Add paragraph for the shape textbody
            if (text != null)
            {
                IWParagraph paragraph = shape.TextBody.AddParagraph();
                //Set required textbody alignments
                shape.TextFrame.TextVerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                //Set required paragraph alignments
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                IWTextRange textRange = paragraph.AppendText(text);
                //Applies a required text formatting's
                textRange.CharacterFormat.FontName = "Calibri";
                textRange.CharacterFormat.FontSize = 15;
                textRange.CharacterFormat.TextColor = Color.White;
                textRange.CharacterFormat.Bold = true;
                textRange.CharacterFormat.Italic = true;
            }
            //Adds the specified shape to group shape
            groupShape.Add(shape);
        }

        #endregion
    }
}
