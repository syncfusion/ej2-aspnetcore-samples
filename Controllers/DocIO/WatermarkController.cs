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
        public ActionResult Watermark(string Group1, string Group2)
        {
            if (Group2 == null)
                return View();
            string basePath = _hostingEnvironment.WebRootPath;          
            string dataPath = basePath + @"/DocIO/Watermark.doc";
            //Open an existing word document 
            FileStream fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);                        
            WordDocument doc = new WordDocument(fileStream, FormatType.Doc);
            fileStream.Dispose();
            fileStream = null;

            if (Group2 != "Picture")
            {
                //Add text watermark.
                TextWatermark textWatermark = new TextWatermark("Demo", "Arial", 160, 160);
                doc.Watermark = textWatermark;

                //Set the color for the watermark text.
                textWatermark.Color = Syncfusion.Drawing.Color.Gray;

                //Set the size.
                textWatermark.Size = 120;
            }
            else
            {
                //Add Picture watermark to the word document.
                PictureWatermark picWatermark = new PictureWatermark();
                doc.Watermark = picWatermark;

                FileStream imageStream = new FileStream(basePath + @"/images/DocIO/Northwind_logo.png", FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(imageStream);
                byte[] image = br.ReadBytes((int)imageStream.Length);

                //Set the picture.
                picWatermark.LoadPicture(image);
                //Set the properties for the watermark.
                picWatermark.Scaling = 100.0f;
                picWatermark.Washout = false;
            }
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
                doc.Save(ms, type);
                doc.Close();
                ms.Position = 0;
                return File(ms, contenttype, filename);
               
        }
    }
}
