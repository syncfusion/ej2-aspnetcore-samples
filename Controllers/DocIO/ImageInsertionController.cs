#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
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

namespace EJ2CoreSampleBrowser.Controllers.DocIO
{
    public partial class DocIOController : Controller
    {
        string dataPath2;
        #region ImageInsertion
        public ActionResult ImageInsertion(string Group1)
        {
            if (Group1 == null)
                return View();
            //Create a new document
            WordDocument document = new WordDocument();
            //Adding a new section to the document.
            IWSection section = document.AddSection();
            //Adding a paragraph to the section
            IWParagraph paragraph = section.AddParagraph();        
            //Writing text.
            paragraph.AppendText("This sample demonstrates how to insert Vector and Scalar images inside a document.");
            //Adding a new paragraph
            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            string basePath = _hostingEnvironment.WebRootPath;
            FileStream imageStream = new FileStream(basePath + @"/images/DocIO/yahoo.gif", FileMode.Open, FileAccess.Read);
            //Inserting .gif .
            WPicture picture = (WPicture)paragraph.AppendPicture(imageStream);
            //Adding Image caption
            picture.AddCaption("Yahoo [.gif Image]", CaptionNumberingFormat.Roman, CaptionPosition.AboveImage);

            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            imageStream = new FileStream(basePath + @"/images/DocIO/Reports.bmp", FileMode.Open, FileAccess.Read);
            //Inserting .bmp
            picture = (WPicture)paragraph.AppendPicture(imageStream);
            //Adding Image caption
            picture.AddCaption("Reports [.bmp Image]", CaptionNumberingFormat.Roman, CaptionPosition.AboveImage);

            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            imageStream = new FileStream(basePath + @"/images/DocIO/google.png", FileMode.Open, FileAccess.Read);
            //Inserting .png 
            picture = (WPicture)paragraph.AppendPicture(imageStream);
            //Adding Image caption
            picture.AddCaption("Google [.png Image]", CaptionNumberingFormat.Roman, CaptionPosition.AboveImage);

            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            imageStream = new FileStream(basePath + @"/images/DocIO/Square.tif", FileMode.Open, FileAccess.Read);
            //Inserting .tif 
            picture = (WPicture)paragraph.AppendPicture(imageStream);
            //Adding Image caption
            picture.AddCaption("Square [.tif Image]", CaptionNumberingFormat.Roman, CaptionPosition.AboveImage);

            //Adding a new paragraph.
            paragraph = section.AddParagraph();
            //Setting Alignment for the image.
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            imageStream = new FileStream(basePath + @"/images/DocIO/Ess chart.emf", FileMode.Open, FileAccess.Read);
            //Inserting .wmf Image to the document.
            WPicture mImage = (WPicture)paragraph.AppendPicture(imageStream);
            //Scaling Image
            mImage.HeightScale = 50f;
            mImage.WidthScale = 50f;

            //Adding Image caption
            mImage.AddCaption("Chart Vector Image", CaptionNumberingFormat.Roman, CaptionPosition.AboveImage);

            FormatType type = FormatType.Docx;
            string filename = "Sample.docx";
            string contenttype = "application/vnd.ms-word.document.12";
            #region Document SaveOption
            //Save as .doc format
            if (Group1 == "WordDoc")
            {
                type = FormatType.Doc;
                filename = "Sample.doc";
                contenttype = "application/msword";
            }
            //Save as .xml format
            else if (Group1 == "WordML")
            {
                type = FormatType.WordML;
                filename = "Sample.xml";
                contenttype = "application/msword";
            }
            #endregion Document SaveOption
            MemoryStream ms = new MemoryStream();
            document.Save(ms, type);
            document.Close();
            ms.Position = 0;
            return File(ms, contenttype, filename);
        }
        #endregion ImageInsertion
    }
}