#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System.IO;

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        //
        // GET: /FormFilling/

        public ActionResult FormFilling()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FormFilling(string submit1, string submit, string InsideBrowser,string flatten)
        {
            if (submit1 == "View Template")
            {
                string basePath = _hostingEnvironment.WebRootPath;
                string dataPath = string.Empty;
                dataPath = basePath + @"/PDF/";

                //Read the file
                FileStream file = new FileStream(dataPath + "Form.pdf", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                
                //Load the template document
                PdfLoadedDocument doc = new PdfLoadedDocument(file);

                //Save the PDF to the MemoryStream
                MemoryStream ms = new MemoryStream();
                doc.Save(ms);

                //If the position is not set to '0' then the PDF will be empty.
                ms.Position = 0;

                //Close the PDF document.
                doc.Close(true);

                //Download the PDF document in the browser.
                FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
                fileStreamResult.FileDownloadName = "template.pdf";
                return fileStreamResult;
            }
            else if (submit == "Fill Form")
            {
                string basePath = _hostingEnvironment.WebRootPath;
                string dataPath = string.Empty;
                dataPath = basePath + @"/PDF/";

                //Read the file
                FileStream file = new FileStream(dataPath + "Form.pdf", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                //Load the template document
                PdfLoadedDocument doc = new PdfLoadedDocument(file);

                PdfLoadedForm form = doc.Form;

                // fill the fields from the first page
                (form.Fields["f1-1"] as PdfLoadedTextBoxField).Text = "1";
                (form.Fields["f1-2"] as PdfLoadedTextBoxField).Text = "1";
                (form.Fields["f1-3"] as PdfLoadedTextBoxField).Text = "1";
                (form.Fields["f1-4"] as PdfLoadedTextBoxField).Text = "3";
                (form.Fields["f1-5"] as PdfLoadedTextBoxField).Text = "1";
                (form.Fields["f1-6"] as PdfLoadedTextBoxField).Text = "1";
                (form.Fields["f1-7"] as PdfLoadedTextBoxField).Text = "22";
                (form.Fields["f1-8"] as PdfLoadedTextBoxField).Text = "30";
                (form.Fields["f1-9"] as PdfLoadedTextBoxField).Text = "John";
                (form.Fields["f1-10"] as PdfLoadedTextBoxField).Text = "Doe";
                (form.Fields["f1-11"] as PdfLoadedTextBoxField).Text = "3233 Spring Rd.";
                (form.Fields["f1-12"] as PdfLoadedTextBoxField).Text = "Atlanta, GA 30339";
                (form.Fields["f1-13"] as PdfLoadedTextBoxField).Text = "332";
                (form.Fields["f1-14"] as PdfLoadedTextBoxField).Text = "43";
                (form.Fields["f1-15"] as PdfLoadedTextBoxField).Text = "4556";
                (form.Fields["f1-16"] as PdfLoadedTextBoxField).Text = "3";
                (form.Fields["f1-17"] as PdfLoadedTextBoxField).Text = "2000";
                (form.Fields["f1-18"] as PdfLoadedTextBoxField).Text = "Exempt";
                (form.Fields["f1-19"] as PdfLoadedTextBoxField).Text = "Syncfusion, Inc";
                (form.Fields["f1-20"] as PdfLoadedTextBoxField).Text = "200";
                (form.Fields["f1-21"] as PdfLoadedTextBoxField).Text = "22";
                (form.Fields["f1-22"] as PdfLoadedTextBoxField).Text = "56654";
                (form.Fields["c1-1[0]"] as PdfLoadedCheckBoxField).Items[0].Checked = true;
                (form.Fields["c1-1[1]"] as PdfLoadedCheckBoxField).Items[0].Checked = true;

                // fill the fields from the second page
                (form.Fields["f2-1"] as PdfLoadedTextBoxField).Text = "3200";
                (form.Fields["f2-2"] as PdfLoadedTextBoxField).Text = "4850";
                (form.Fields["f2-3"] as PdfLoadedTextBoxField).Text = "0";
                (form.Fields["f2-4"] as PdfLoadedTextBoxField).Text = "500";
                (form.Fields["f2-5"] as PdfLoadedTextBoxField).Text = "500";
                (form.Fields["f2-6"] as PdfLoadedTextBoxField).Text = "800";
                (form.Fields["f2-7"] as PdfLoadedTextBoxField).Text = "0";
                (form.Fields["f2-8"] as PdfLoadedTextBoxField).Text = "0";
                (form.Fields["f2-9"] as PdfLoadedTextBoxField).Text = "3";
                (form.Fields["f2-10"] as PdfLoadedTextBoxField).Text = "3";
                (form.Fields["f2-11"] as PdfLoadedTextBoxField).Text = "3";
                (form.Fields["f2-12"] as PdfLoadedTextBoxField).Text = "2";
                (form.Fields["f2-13"] as PdfLoadedTextBoxField).Text = "3";
                (form.Fields["f2-14"] as PdfLoadedTextBoxField).Text = "3";
                (form.Fields["f2-15"] as PdfLoadedTextBoxField).Text = "2";
                (form.Fields["f2-16"] as PdfLoadedTextBoxField).Text = "1";
                (form.Fields["f2-17"] as PdfLoadedTextBoxField).Text = "200";
                (form.Fields["f2-18"] as PdfLoadedTextBoxField).Text = "600";
                (form.Fields["f2-19"] as PdfLoadedTextBoxField).Text = "250";

                if (flatten == "From Flatten")
                { 
                   doc.Form.Flatten=true;
                }

                //Save the PDF to the MemoryStream
                MemoryStream ms = new MemoryStream();
                doc.Save(ms);

                //If the position is not set to '0' then the PDF will be empty.
                ms.Position = 0;

                //Close the PDF document.
                doc.Close(true);

                //Download the PDF document in the browser.
                FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
                fileStreamResult.FileDownloadName = "Form.pdf";
                return fileStreamResult;
            }
            return View();
        }

    }
}
