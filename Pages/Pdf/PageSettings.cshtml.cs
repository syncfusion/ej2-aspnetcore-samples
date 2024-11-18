#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

namespace EJ2CoreSampleBrowser.Pages.Pdf;

public class PageSettings : PageModel
{
    public void OnGet()
    {
        
    }

    public ActionResult OnPost(string InsideBrowser, string pageDetails, string ApplyTransition)
    {
        // Create a new document class object.
        PdfDocument doc = new PdfDocument();

        //Set the document viewer preferences.
        doc.ViewerPreferences.HideToolbar = true;
        doc.ViewerPreferences.PageMode = PdfPageMode.FullScreen;

        //Get the page details
        List<PdfPageDetails> pageDetailsList = GetPageDetails(pageDetails);

        //Create PdfPen.
        PdfPen pen = new PdfPen(Syncfusion.Drawing.Color.Black);
        pen.Width = 6f;

        for (int i = 0; i < pageDetailsList.Count; i++)
        {
            //Add a new section to the PDF document.
            PdfSection section = doc.Sections.Add();

            PdfPageDetails pgDetails = pageDetailsList[i];

            //Set the section page settings.
            section.PageSettings.Size = pgDetails.PageSize;
            section.PageSettings.Rotate = pgDetails.RotateAngle;
            section.PageSettings.Orientation = pgDetails.PageOrientation;
            section.PageSettings.Margins.All = pgDetails.Margin;

            //Add a new page to the section.
            PdfPage page = section.Pages.Add();

            if (ApplyTransition != null)
            {
                //Create page label
                PdfPageLabel label = new PdfPageLabel();
                label.Prefix = "Sec" + i + "-";
                section.PageLabel = label;
                section.Pages[0].Graphics.SetTransparency(0.35f);
                section.PageSettings.Transition.PageDuration = 1;
                section.PageSettings.Transition.Duration = 1;
                section.PageSettings.Transition.Style = PdfTransitionStyle.Box;
            }

            //Create a brush
            PdfSolidBrush brush = new PdfSolidBrush(Color.Black);
            brush.Color = new PdfColor(Syncfusion.Drawing.Color.LightGreen);

            //Create a Rectangle
            PdfRectangle rect = new PdfRectangle(0, 0, page.GetClientSize().Width, page.GetClientSize().Height);
            rect.Brush = brush;
            rect.Draw(page.Graphics);
            //Draw the line.
            page.Graphics.DrawLine(pen, 0, 100, 300, 100);
        }

        //Set the font
        PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 16f);
        PdfSolidBrush fieldBrush = new PdfSolidBrush(Color.Black);

        //Draw page template
        PdfPageTemplateElement templateElement = new PdfPageTemplateElement(400, 400);
        //Create page number field.
        PdfPageNumberField pageNumber = new PdfPageNumberField(font, fieldBrush);
        //Create page count field.
        PdfPageCountField count = new PdfPageCountField(font, fieldBrush);
        //Add the fields in composite fields.
        PdfCompositeField compositeField =
            new PdfCompositeField(font, fieldBrush, "Page {0} of {1}", pageNumber, count);
        compositeField.Bounds = templateElement.Bounds;
        //Draw the composite field in template.
        compositeField.Draw(templateElement.Graphics, new PointF(230, 200));

        //Add the template to the document stamps.
        doc.Template.Stamps.Add(templateElement);
        templateElement.Background = true;

        //Save the PDF to the MemoryStream
        MemoryStream ms = new MemoryStream();

        doc.Save(ms);

        //If the position is not set to '0' then the PDF will be empty.
        ms.Position = 0;

        //Close the PDF document.
        doc.Close(true);

        //Download the PDF document in the browser.
        FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
        fileStreamResult.FileDownloadName = "PageSettings.pdf";
        return fileStreamResult;
    }
    private List<PdfPageDetails> GetPageDetails(string pageDetails)
    {
        List<PdfPageDetails> pageDetailsList = new List<PdfPageDetails>();
        if (string.IsNullOrEmpty(pageDetails))
        {
            pageDetailsList.Add(new PdfPageDetails());
        }
        else
        {
            string[] words = pageDetails.Split(';');
            foreach (string word in words)
            {
                if (word != string.Empty)
                {
                    string[] pageDetail = word.Split(',');

                    SizeF pageSize = GetPageSize(pageDetail[0]);
                    PdfPageOrientation pageOrientation = pageDetail[1] == "Portrait" ? PdfPageOrientation.Portrait : PdfPageOrientation.Landscape;
                    float margin = GetMargin(pageDetail[2]);
                    PdfPageRotateAngle rotateAngle = GetRotationAngle(pageDetail[3]);                       
                    pageDetailsList.Add(new PdfPageDetails(pageOrientation, pageSize, margin, rotateAngle));
                }
            }
        }
        return pageDetailsList;
    }
    private SizeF GetPageSize(string size)
    {
        switch (size)
        {
            case "Letter":
                return PdfPageSize.Letter;
            case "Legal":
                return PdfPageSize.Legal;
            case "A3":
                return PdfPageSize.A3;
            case "A4":
                return PdfPageSize.A4;
            case "A5":
                return PdfPageSize.A5;
            case "B4":
                return PdfPageSize.B4;
            case "B5":
                return PdfPageSize.B5;
            default:
                return PdfPageSize.A4;
        }
    }
    private float GetMargin(string margin)
    {
        switch (margin)
        {
            case "Small":
                return 20;
            case "Large":
                return 40;
            default:
                return 0;
        }
    }
    private PdfPageRotateAngle GetRotationAngle(string rotate)
    {
        switch (rotate)
        {
            case "90":
                return PdfPageRotateAngle.RotateAngle90;
            case "180":
                return PdfPageRotateAngle.RotateAngle180;
            case "270":
                return PdfPageRotateAngle.RotateAngle270;
            default:
                return PdfPageRotateAngle.RotateAngle0;
        }
    }
}
internal class PdfPageDetails
{
    public PdfPageOrientation PageOrientation { get; set; }
    public SizeF PageSize { get; set; }
    public float Margin { get; set; }
    public PdfPageRotateAngle RotateAngle { get; set; }

    public PdfPageDetails()
    {
        PageOrientation = PdfPageOrientation.Portrait;
        PageSize = PdfPageSize.A4;
        Margin = 40;
        RotateAngle = PdfPageRotateAngle.RotateAngle0;
    }
    public PdfPageDetails(PdfPageOrientation pageOrientation, SizeF pageSize, float margin, PdfPageRotateAngle pdfPageRotate)
    {
        PageOrientation = pageOrientation;
        PageSize = pageSize;
        Margin = margin;
        RotateAngle = pdfPageRotate;
    }
}