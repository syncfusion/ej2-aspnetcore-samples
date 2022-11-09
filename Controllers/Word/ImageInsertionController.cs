#region Copyright Syncfusion Inc. 2001-2022
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Reflection;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.Word
{
    public partial class WordController : Controller
    {
        #region ImageInsertion
        public ActionResult ImageInsertion(string Group1)
        {
            if (Group1 == null)
                return View();
            //Create a new document
            WordDocument document = new WordDocument();
            //Adding a new section to the document.
            IWSection section = document.AddSection();
            section.PageSetup.Margins.All = 72;
            //Adding a paragraph to the section
            IWParagraph paragraph = section.AddParagraph();        
            //Writing text.
            paragraph.AppendText("This sample demonstrates how to insert Vector and Scalar images inside a document.");
            //Adding a new paragraph
            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            string basePath = _hostingEnvironment.WebRootPath;
            FileStream imageStream = new FileStream(basePath + @"/images/Word/yahoo.gif", FileMode.Open, FileAccess.Read);
            //Inserting .gif .
            WPicture picture = (WPicture)paragraph.AppendPicture(imageStream);
            //Adding Image caption
            picture.AddCaption("Figure", CaptionNumberingFormat.Roman, CaptionPosition.AfterImage);
            ApplyFormattingForCaption(document.LastParagraph);

            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            imageStream = new FileStream(basePath + @"/images/Word/Reports.bmp", FileMode.Open, FileAccess.Read);
            //Inserting .bmp
            picture = (WPicture)paragraph.AppendPicture(imageStream);
            //Adding Image caption
            picture.AddCaption("Figure", CaptionNumberingFormat.Roman, CaptionPosition.AfterImage);
            ApplyFormattingForCaption(document.LastParagraph);

            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            imageStream = new FileStream(basePath + @"/images/Word/google.png", FileMode.Open, FileAccess.Read);
            //Inserting .png 
            picture = (WPicture)paragraph.AppendPicture(imageStream);
            //Adding Image caption
            picture.AddCaption("Figure", CaptionNumberingFormat.Roman, CaptionPosition.AfterImage);
            ApplyFormattingForCaption(document.LastParagraph);

            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            imageStream = new FileStream(basePath + @"/images/Word/Square.tif", FileMode.Open, FileAccess.Read);
            //Inserting .tif 
            picture = (WPicture)paragraph.AppendPicture(imageStream);
            //Adding Image caption
            picture.AddCaption("Figure", CaptionNumberingFormat.Roman, CaptionPosition.AfterImage);
            ApplyFormattingForCaption(document.LastParagraph);

            //Adding a new paragraph.
            paragraph = section.AddParagraph();
            //Setting Alignment for the image.
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            imageStream = new FileStream(basePath + @"/images/Word/Ess chart.emf", FileMode.Open, FileAccess.Read);
            //Inserting .wmf Image to the document.
            WPicture mImage = (WPicture)paragraph.AppendPicture(imageStream);
            //Scaling Image
            mImage.HeightScale = 50f;
            mImage.WidthScale = 50f;

            //Adding Image caption
            mImage.AddCaption("Figure", CaptionNumberingFormat.Roman, CaptionPosition.AfterImage);
            ApplyFormattingForCaption(document.LastParagraph);

            //Updates the fields in Word document
            document.UpdateDocumentFields();

            FormatType type = FormatType.Docx;
            string filename = "Image Insertion.docx";
            string contenttype = "application/vnd.ms-word.document.12";
            #region Document SaveOption
            //Save as .doc format
            if (Group1 == "WordDoc")
            {
                type = FormatType.Doc;
                filename = "Image Insertion.doc";
                contenttype = "application/msword";
            }
            //Save as .xml format
            else if (Group1 == "WordML")
            {
                type = FormatType.WordML;
                filename = "Image Insertion.xml";
                contenttype = "application/msword";
            }
            #endregion Document SaveOption
            MemoryStream ms = new MemoryStream();
            document.Save(ms, type);
            document.Close();
            ms.Position = 0;
            return File(ms, contenttype, filename);
        }
        /// <summary>
        /// Apply formattings for image caption paragraph
        /// </summary>
        private void ApplyFormattingForCaption(WParagraph paragraph)
        {
            //Align the caption
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            //Sets after spacing
            paragraph.ParagraphFormat.AfterSpacing = 1.5f;
            //Sets before spacing
            paragraph.ParagraphFormat.BeforeSpacing = 1.5f;
        }
        #endregion ImageInsertion
    }
}