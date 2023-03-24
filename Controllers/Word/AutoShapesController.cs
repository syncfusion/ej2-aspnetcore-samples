#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Microsoft.AspNetCore.Mvc;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using System.IO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.Word
{
    public partial class WordController : Controller
    {
        #region AutoShapes
        public ActionResult AutoShapes(string Group1)
        {
            if (Group1 == null)
                return View();

            //Initialize Word document
            WordDocument doc = new WordDocument();
            //Ensure Minimum
            doc.EnsureMinimal();
            //Append AutoShape
            Shape shape = doc.LastParagraph.AppendShape(AutoShapeType.RoundedRectangle, 130, 45);
            //Set horizontal alignment
            shape.HorizontalAlignment = ShapeHorizontalAlignment.Center;
            //Set horizontal origin
            shape.HorizontalOrigin = HorizontalOrigin.Page;
            //Set vertical origin
            shape.VerticalOrigin = VerticalOrigin.Page;
            //Set vertical position
            shape.VerticalPosition = 50;
            //Set AllowOverlap to true for overlapping shapes
            shape.WrapFormat.AllowOverlap = true;
            //Set Fill Color
            shape.FillFormat.Color = Syncfusion.Drawing.Color.Blue;
            //Set Content vertical alignment
            shape.TextFrame.TextVerticalAlignment = VerticalAlignment.Middle;
            //Add Texbody contents to Shape
            IWParagraph para = shape.TextBody.AddParagraph();
            para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            para.AppendText("Requirement").ApplyCharacterFormat(new WCharacterFormat(doc) { Bold = true, TextColor = Syncfusion.Drawing.Color.White, FontSize = 12, FontName = "Verdana" });

            shape = doc.LastParagraph.AppendShape(AutoShapeType.DownArrow, 45, 45);
            shape.HorizontalAlignment = ShapeHorizontalAlignment.Center;
            shape.HorizontalOrigin = HorizontalOrigin.Page;
            shape.VerticalOrigin = VerticalOrigin.Page;
            shape.VerticalPosition = 95;
            shape.WrapFormat.AllowOverlap = true;

            shape = doc.LastParagraph.AppendShape(AutoShapeType.RoundedRectangle, 130, 45);
            shape.HorizontalAlignment = ShapeHorizontalAlignment.Center;
            shape.HorizontalOrigin = HorizontalOrigin.Page;
            shape.VerticalOrigin = VerticalOrigin.Page;
            shape.VerticalPosition = 140;
            shape.WrapFormat.AllowOverlap = true;
            shape.FillFormat.Color = Syncfusion.Drawing.Color.Orange;
            shape.TextFrame.TextVerticalAlignment = VerticalAlignment.Middle;
            para = shape.TextBody.AddParagraph();
            para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            para.AppendText("Design").ApplyCharacterFormat(new WCharacterFormat(doc) { Bold = true, TextColor = Syncfusion.Drawing.Color.White, FontSize = 12, FontName = "Verdana" });

            shape = doc.LastParagraph.AppendShape(AutoShapeType.DownArrow, 45, 45);
            shape.HorizontalAlignment = ShapeHorizontalAlignment.Center;
            shape.HorizontalOrigin = HorizontalOrigin.Page;
            shape.VerticalOrigin = VerticalOrigin.Page;
            shape.VerticalPosition = 185;
            shape.WrapFormat.AllowOverlap = true;

            shape = doc.LastParagraph.AppendShape(AutoShapeType.RoundedRectangle, 130, 45);
            shape.HorizontalAlignment = ShapeHorizontalAlignment.Center;
            shape.HorizontalOrigin = HorizontalOrigin.Page;
            shape.VerticalOrigin = VerticalOrigin.Page;
            shape.VerticalPosition = 230;
            shape.WrapFormat.AllowOverlap = true;
            shape.FillFormat.Color = Syncfusion.Drawing.Color.Blue;
            shape.TextFrame.TextVerticalAlignment = VerticalAlignment.Middle;
            para = shape.TextBody.AddParagraph();
            para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            para.AppendText("Execution").ApplyCharacterFormat(new WCharacterFormat(doc) { Bold = true, TextColor = Syncfusion.Drawing.Color.White, FontSize = 12, FontName = "Verdana" });

            shape = doc.LastParagraph.AppendShape(AutoShapeType.DownArrow, 45, 45);
            shape.HorizontalAlignment = ShapeHorizontalAlignment.Center;
            shape.HorizontalOrigin = HorizontalOrigin.Page;
            shape.VerticalOrigin = VerticalOrigin.Page;
            shape.VerticalPosition = 275;
            shape.WrapFormat.AllowOverlap = true;

            shape = doc.LastParagraph.AppendShape(AutoShapeType.RoundedRectangle, 130, 45);
            shape.HorizontalAlignment = ShapeHorizontalAlignment.Center;
            shape.HorizontalOrigin = HorizontalOrigin.Page;
            shape.VerticalOrigin = VerticalOrigin.Page;
            shape.VerticalPosition = 320;
            shape.WrapFormat.AllowOverlap = true;
            shape.FillFormat.Color = Syncfusion.Drawing.Color.Violet;
            shape.TextFrame.TextVerticalAlignment = VerticalAlignment.Middle;
            para = shape.TextBody.AddParagraph();
            para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            para.AppendText("Testing").ApplyCharacterFormat(new WCharacterFormat(doc) { Bold = true, TextColor = Syncfusion.Drawing.Color.White, FontSize = 12, FontName = "Verdana" });

            shape = doc.LastParagraph.AppendShape(AutoShapeType.DownArrow, 45, 45);
            shape.HorizontalAlignment = ShapeHorizontalAlignment.Center;
            shape.HorizontalOrigin = HorizontalOrigin.Page;
            shape.VerticalOrigin = VerticalOrigin.Page;
            shape.VerticalPosition = 365;
            shape.WrapFormat.AllowOverlap = true;

            shape = doc.LastParagraph.AppendShape(AutoShapeType.RoundedRectangle, 130, 45);
            shape.HorizontalAlignment = ShapeHorizontalAlignment.Center;
            shape.HorizontalOrigin = HorizontalOrigin.Page;
            shape.VerticalOrigin = VerticalOrigin.Page;
            shape.VerticalPosition = 410;
            shape.WrapFormat.AllowOverlap = true;
            shape.FillFormat.Color = Syncfusion.Drawing.Color.PaleVioletRed;
            shape.TextFrame.TextVerticalAlignment = VerticalAlignment.Middle;
            para = shape.TextBody.AddParagraph();
            para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            para.AppendText("Release").ApplyCharacterFormat(new WCharacterFormat(doc) { Bold = true, TextColor = Syncfusion.Drawing.Color.White, FontSize = 12, FontName = "Verdana" });

            
            string filename = "";
            string contenttype = "";
            MemoryStream ms = new MemoryStream();
            #region Document SaveOption
            //Save as .docx format
            if (Group1 == "WordDocx")
            {
                filename = "AutoShapes.docx";
                contenttype = "application/vnd.ms-word.document.12";
                doc.Save(ms, FormatType.Docx);
            }
            //Save as .xml format           
            else if (Group1 == "WordML")
            {
                filename = "AutoShapes.xml";
                contenttype = "application/msword";
                doc.Save(ms, FormatType.WordML);
            }
            //Save as .pdf format
            else if (Group1 == "Pdf")
            {
                filename = "AutoShapes.pdf";
                contenttype = "application/pdf";
                DocIORenderer renderer = new DocIORenderer();
                PdfDocument pdfDoc = renderer.ConvertToPDF(doc);
                pdfDoc.Save(ms);
                pdfDoc.Close();
            }
            #endregion Document SaveOption
            doc.Close();
            ms.Position = 0;
            return File(ms, contenttype, filename);
        }
        #endregion
    }
}
