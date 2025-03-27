#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf.Xfa;

namespace EJ2CoreSampleBrowser.Pages.Pdf;

public class XFAFormFilling : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public XFAFormFilling(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }
    [HttpPost]
    public ActionResult OnPost(string submit1, string submit, string Browser)
    {
        string basePath = _hostingEnvironment.WebRootPath;
        string dataPath = string.Empty;
        dataPath = basePath + @"/PDF/";


        if (submit1 == "View Template")
        {
            Stream file2 = new FileStream(dataPath + "xfaTemplate.pdf", FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStreamResult fileStreamResult = new FileStreamResult(file2, "application/pdf");
            fileStreamResult.FileDownloadName = "XFAFormTemplate.pdf";
            return fileStreamResult;
        }
        else
        {
            //Read the file
            FileStream file1 = new FileStream(dataPath + "xfaTemplate.pdf", FileMode.Open, FileAccess.Read,
                FileShare.ReadWrite);

            //Load the existing XFA document.
            PdfLoadedXfaDocument ldoc = new PdfLoadedXfaDocument(file1);

            //Loaded the existing XFA form.
            PdfLoadedXfaForm lform = ldoc.XfaForm;

            //Fill the XFA form fields.
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields
                ["title[0]"] as PdfLoadedXfaComboBoxField).SelectedIndex = 0;
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields
                ["fn[0]"] as PdfLoadedXfaTextBoxField).Text = "Simons";
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields
                ["ln[0]"] as PdfLoadedXfaTextBoxField).Text = "Bistro";
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields
                ["dob[0]"] as PdfLoadedXfaDateTimeField).Value = new DateTime(1989, 5, 21);
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields
                ["company[0]"] as PdfLoadedXfaTextBoxField).Text = "XYZ Pvt Ltd";
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields
                ["jt[0]"] as PdfLoadedXfaTextBoxField).Text = "Developer";
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields
                    ["jd[0]"] as PdfLoadedXfaTextBoxField).Text =
                "Develop and maintain components and applications for the web, desktop and mobile platforms. \nWork with some of the best UI/UX designers in the world to craft Stunning user interfaces. \nRegular appraisals to ensure quick growth if you deliver on the job.";
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields
                ["st[0]"] as PdfLoadedXfaTextBoxField).Text = "Vinbaeltet 34";
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields
                ["ad1[0]"] as PdfLoadedXfaTextBoxField).Text = "Kobenhaven";
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields
                ["city[0]"] as PdfLoadedXfaTextBoxField).Text = "Denmark";
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields
                ["state[0]"] as PdfLoadedXfaComboBoxField).SelectedIndex = 1;
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields
                ["zip[0]"] as PdfLoadedXfaNumericField).NumericValue = 24534;
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields
                ["country[0]"] as PdfLoadedXfaTextBoxField).Text = "US";
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields
                ["em[0]"] as PdfLoadedXfaTextBoxField).Text = "simonsbistro@outlook.com";
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields
                ["phone[0]"] as PdfLoadedXfaNumericField).NumericValue = 8765456789;
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields
                ["sdn[0]"] as PdfLoadedXfaListBoxField).SelectedItems = new string[] { "Vegan", "Diary Free" };
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields
                ["san[0]"] as PdfLoadedXfaListBoxField).SelectedIndex = 0;
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields
                ["email[0]"] as PdfLoadedXfaCheckBoxField).IsChecked = true;
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields
                ["phone[1]"] as PdfLoadedXfaCheckBoxField).IsChecked = true;
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields
                ["group1[0]"] as PdfLoadedXfaRadioButtonGroup).Fields[1].IsChecked = true;

            //Saving the PDF to the MemoryStream
            MemoryStream ms = new MemoryStream();
            ldoc.Save(ms);
            //If the position is not set to '0' then the PDF will be empty.
            ms.Position = 0;

            //Close the document
            ldoc.Close();

            //Download the PDF document in the browser.
            FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
            fileStreamResult.FileDownloadName = "XFAFormFill.pdf";
            return fileStreamResult;
        }
    }
}