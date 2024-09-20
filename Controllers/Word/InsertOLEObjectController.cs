#region Copyright Syncfusion Inc. 2001 - 2024
// Copyright Syncfusion Inc. 2001 - 2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.IO;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.Word
{  
    public partial class WordController : Controller
    {
        #region InsertOLEObject
        public ActionResult InsertOLEObject(string Group1)
        {
            if (Group1 == null)
                return View();

            //Data folder path is resolved from requested page physical path.
            string basePath = _hostingEnvironment.WebRootPath;
            string dataPath = basePath + @"/Word/OleTemplate.doc";
            FileStream fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            WordDocument oleSource;
            if (Group1 == ".doc")
               //Open an existing word document                 
                oleSource = new WordDocument(fileStream, FormatType.Doc);                                
            
            else
                //Open an existing word document 
                oleSource = new WordDocument(fileStream, FormatType.Doc);
            fileStream.Dispose();
            fileStream = null;
            WordDocument dest = new WordDocument();
            dest.EnsureMinimal();

            // Get OLE object from source document
            WOleObject oleObject = oleSource.LastParagraph.Items[0] as WOleObject;

            WPicture pic = oleObject.OlePicture.Clone() as WPicture;
            dest.LastParagraph.AppendText("OLE Object Demo");
            dest.LastParagraph.ApplyStyle(BuiltinStyle.Heading1);
            dest.LastParagraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;

            dest.Sections[0].AddParagraph();
            dest.LastParagraph.AppendText("Adobe PDF object Inserted");
            dest.LastParagraph.ApplyStyle(BuiltinStyle.Heading2);

            dest.Sections[0].AddParagraph();
            // AppendOLE object to the destination document
            dest.LastParagraph.AppendOleObject(oleObject.Container, pic, OleLinkType.Embed);

            FormatType type = FormatType.Docx;
            string filename = "InsertOLEObject.docx";
            string contenttype = "application/vnd.ms-word.document.12";
            #region Document SaveOption
            //Save as .doc format
            if (Group1 == "WordDoc")
            {
                type = FormatType.Doc;
                filename = "InsertOLEObject.doc";
                contenttype = "application/msword";
            }
            //Save as .xml format
            else if (Group1 == "WordML")
            {
                type = FormatType.WordML;
                filename = "InsertOLEObject.xml";
                contenttype = "application/msword";
            }
            #endregion Document SaveOption
            MemoryStream ms = new MemoryStream();
            dest.Save(ms, type);
            dest.Close();
            ms.Position = 0;
            return File(ms, contenttype, filename);
        }
        #endregion InsertOLEObject
    }
}