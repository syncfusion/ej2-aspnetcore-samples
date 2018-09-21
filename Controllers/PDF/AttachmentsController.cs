using System;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        //
        // GET: /Attachments/

        public ActionResult Attachments()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Attachments(string Browser)
        {
             //Creates a new PDF document.
             PdfDocument doc = new PdfDocument();

             //Add a page
             PdfPage  page = doc.Pages.Add();

             //Set the font
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 18f, PdfFontStyle.Bold);

            //Create new PDF color
            PdfColor orangeColor = new PdfColor(255, 255, 167, 73);

            //Draw the text
            page.Graphics.DrawString("Attachments", font, PdfBrushes.Black, new RectangleF(0, 0, page.GetClientSize().Width, page.GetClientSize().Height), new PdfStringFormat(PdfTextAlignment.Center));

            //Create font
            font = new PdfStandardFont(PdfFontFamily.Helvetica, 10f, PdfFontStyle.Regular);

            page.Graphics.DrawString("This PDF document contains image and text file as attachment.", font, PdfBrushes.Black, new PointF(0, 30));

            font = new PdfStandardFont(PdfFontFamily.Helvetica, 8f, PdfFontStyle.Regular);

            page.Graphics.DrawString("Click to open the attachment:", font, PdfBrushes.Black, new PointF(0, 50));

            page.Graphics.DrawString("Click to open the attachment:", font, PdfBrushes.Black, new PointF(0, 70));

            string basePath = _hostingEnvironment.WebRootPath;
            string dataPath = string.Empty;
            dataPath = basePath + @"/PDF/";

            //Read the file
            FileStream file = new FileStream(dataPath + "Text1.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            //Creates an attachment
            PdfAttachment attachment = new PdfAttachment("Text1.txt",file);

            attachment.ModificationDate = DateTime.Now;

            attachment.Description = "About Syncfusion";

            attachment.MimeType = "application/txt";

            //Adds the attachment to the document
            doc.Attachments.Add(attachment);

            file = new FileStream(dataPath + "Autumn Leaves.jpg", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            
            //Creates an attachment
            attachment = new PdfAttachment("Autumn Leaves.jpg",file);

            attachment.ModificationDate = DateTime.Now;

            attachment.Description = "Autumn Leaves Image";

            attachment.MimeType = "application/jpg";

            doc.Attachments.Add(attachment);

            file = new FileStream(dataPath + "Text2.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            //Creates an attachment
            attachment = new PdfAttachment("Text2.txt",file);

            attachment.ModificationDate = DateTime.Now;

            attachment.Description = "List of Syncfusion Control";

            attachment.MimeType = "application/txt";

            doc.Attachments.Add(attachment);

            //Set document viewerpreference.
            doc.ViewerPreferences.HideWindowUI = false;
            doc.ViewerPreferences.HideMenubar = false;
            doc.ViewerPreferences.HideToolbar = false;
            doc.ViewerPreferences.FitWindow = false;
            doc.ViewerPreferences.DisplayTitle = false;
            doc.ViewerPreferences.PageMode = PdfPageMode.UseAttachments;
			
			//Disable the default appearance.
            doc.Form.SetDefaultAppearance(false);

            //Create pdfbuttonfield.
            PdfButtonField openSpecificationButton = new PdfButtonField(page, "openSpecification");
            openSpecificationButton.Bounds = new RectangleF(105, 50, 62, 10);
            openSpecificationButton.TextAlignment = PdfTextAlignment.Left;
            openSpecificationButton.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 7);
            openSpecificationButton.BorderStyle = PdfBorderStyle.Underline;
            openSpecificationButton.BorderColor = orangeColor;
            openSpecificationButton.BackColor = new PdfColor(255, 255, 255);
            openSpecificationButton.ForeColor = orangeColor;
            openSpecificationButton.Text = "Autumn Leaves.jpg";
            openSpecificationButton.Actions.MouseUp = new PdfJavaScriptAction("this.exportDataObject({ cName: 'Autumn Leaves.jpg', nLaunch: 2 });");
            doc.Form.Fields.Add(openSpecificationButton);

            openSpecificationButton = new PdfButtonField(page, "openSpecification");
            openSpecificationButton.Bounds = new RectangleF(105, 70, 30, 10);
            openSpecificationButton.TextAlignment = PdfTextAlignment.Left;
            openSpecificationButton.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 7);
            openSpecificationButton.BorderStyle = PdfBorderStyle.Underline;
            openSpecificationButton.BorderColor = orangeColor;
            openSpecificationButton.BackColor = new PdfColor(255, 255, 255);
            openSpecificationButton.ForeColor = orangeColor;
            openSpecificationButton.Text = "Text1.txt";
            openSpecificationButton.Actions.MouseUp = new PdfJavaScriptAction("this.exportDataObject({ cName: 'Text1.txt', nLaunch: 2 });");
            doc.Form.Fields.Add(openSpecificationButton);

            //Save the PDF to the MemoryStream
            MemoryStream ms = new MemoryStream();
            doc.Save(ms);

            //If the position is not set to '0' then the PDF will be empty.
            ms.Position = 0;

            //Close the PDF document.
            doc.Close(true);

            //Download the PDF document in the browser.
            FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
            fileStreamResult.FileDownloadName = "Attachments.pdf";
            return fileStreamResult;
        }

    }
}
