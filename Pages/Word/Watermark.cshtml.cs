#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser_NET8.Pages.Word;

public class Watermark : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;

    public Watermark(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public ActionResult OnPost(string Group1, string Group2)
    {
        if (Group2 == null)
            return null;
            // return View();
        string basePath = _hostingEnvironment.WebRootPath;
        string dataPath = basePath + @"/Word/Watermark.doc";
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

            FileStream imageStream = new FileStream(basePath + @"/images/Word/Northwind_logo.png", FileMode.Open,
                FileAccess.Read);
            BinaryReader br = new BinaryReader(imageStream);
            byte[] image = br.ReadBytes((int)imageStream.Length);

            //Set the picture.
            picWatermark.LoadPicture(image);
            //Set the properties for the watermark.
            picWatermark.Scaling = 100.0f;
            picWatermark.Washout = false;
        }

        FormatType type = FormatType.Docx;
        string filename = "Watermark.docx";
        string contenttype = "application/vnd.ms-word.document.12";

        #region Document SaveOption

        //Save as .doc format
        if (Group1 == "WordDoc")
        {
            type = FormatType.Doc;
            filename = "Watermark.doc";
            contenttype = "application/msword";
        }
        //Save as .xml format
        else if (Group1 == "WordML")
        {
            type = FormatType.WordML;
            filename = "Watermark.xml";
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