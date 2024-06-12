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
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {        
        //
        // GET: /FormFilling/

        public ActionResult FormFilling()
        {

            UserRegisterationModel user = new UserRegisterationModel();
            user.Name = "John Milton";
            user.Gender = "Male";
            user.StateDropdown = "Alabama";
            user.DateOfBirth = new DateTime(2012, 05, 12);
            user.EmailID = "john.milton@example.com";
            user.Newsletter = false;
            user.States = GetStates();
            return View(user);
        }

        [HttpPost]
        public ActionResult FormFilling(string viewTemplate, string fillForm, string fillAndFlatten, UserRegisterationModel user)
        {
            string basePath = _hostingEnvironment.WebRootPath;
            string dataPath = string.Empty;
            dataPath = basePath + @"/PDF/";
            if (!string.IsNullOrEmpty(viewTemplate))
            {
                //Read the file
                FileStream file = new FileStream(dataPath + "FormFillingDocument.pdf", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

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
            else if (!string.IsNullOrEmpty(fillForm) || !string.IsNullOrEmpty(fillAndFlatten))
            {
                //Read the file
                FileStream file = new FileStream(dataPath + "FormFillingDocument.pdf", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                //Load the template document
                PdfLoadedDocument doc = new PdfLoadedDocument(file);

                PdfLoadedForm form = doc.Form;

                if (user.Name != null)
                {
                    //Load the textbox field
                    PdfLoadedTextBoxField? nameText = form.Fields["name"] as PdfLoadedTextBoxField;

                    //Fill the text box
                    nameText!.Text = user.Name;
                }

                //Get the Radio button field
                PdfLoadedRadioButtonListField? genderRadio = form.Fields["gender"] as PdfLoadedRadioButtonListField;

                switch (user.Gender)
                {
                    case "Male":
                        genderRadio!.SelectedIndex = 0;
                        break;
                    case "Female":
                        genderRadio!.SelectedIndex = 2;
                        break;
                    case "Unspecified":
                        genderRadio!.SelectedIndex = 1;
                        break;
                }

                //Load the textbox field
                PdfLoadedTextBoxField? dobText = form.Fields["dob"] as PdfLoadedTextBoxField;

                //Fill the text box
                dobText!.Text = user.DateOfBirth.Date.ToString("dd MMMM yyyy");

                if (user.EmailID != null)
                {
                    //Load the textbox field
                    PdfLoadedTextBoxField? emailText = form.Fields["email"] as PdfLoadedTextBoxField;

                    //Fill the text box
                    emailText!.Text = user.EmailID;
                }

                //Load the combo box field
                PdfLoadedComboBoxField? countryCombo = form.Fields["state"] as PdfLoadedComboBoxField;

                countryCombo!.SelectedValue = user.StateDropdown;

                //Get the Checkbox field
                PdfLoadedCheckBoxField? newsCheck = form.Fields["newsletter"] as PdfLoadedCheckBoxField;

                if (user.Newsletter)
                    newsCheck!.Checked = true;

                //Disable the default appearance.
                doc.Form.SetDefaultAppearance(false);

                if (!string.IsNullOrEmpty(fillAndFlatten))
                {
                    //Flatten the form fields.
                    doc.Form.Flatten = true;
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
        private List<SelectListItem> GetStates()
        {
            return new List<SelectListItem>
            {
            new SelectListItem { Value = "Alabama",  Text = "Alabama" },
            new SelectListItem { Value = "Alaska", Text = "Alaska" },
            new SelectListItem { Value = "Arizona", Text = "Arizona" },
            new SelectListItem { Value = "Arkansas", Text = "Arkansas" },
            new SelectListItem { Value = "California", Text = "California" },
            new SelectListItem { Value = "Colorado", Text = "Colorado" },
            new SelectListItem { Value = "Connecticut", Text = "Connecticut" },
            new SelectListItem { Value = "Delaware", Text = "Delaware" },
            new SelectListItem { Value = "Florida", Text = "Florida" },
            new SelectListItem { Value = "Georgia", Text = "Georgia" },
            new SelectListItem { Value = "Hawaii", Text = "Hawaii" },
            new SelectListItem { Value = "Idaho", Text = "Idaho" },
            new SelectListItem { Value = "Illinois", Text = "Illinois" },
            new SelectListItem { Value = "Indiana", Text = "Indiana" },
            new SelectListItem { Value = "Iowa", Text = "Iowa" },
            new SelectListItem { Value = "Kansas", Text = "Kansas" },
            new SelectListItem { Value = "Kentucky", Text = "Kentucky" },
            new SelectListItem { Value = "Louisiana", Text = "Louisiana" },
            new SelectListItem { Value = "Maine", Text = "Maine" },
            new SelectListItem { Value = "Maryland", Text = "Maryland" },
            new SelectListItem { Value = "Massachusetts", Text = "Massachusetts" },
            new SelectListItem { Value = "Michigan", Text = "Michigan" },
            new SelectListItem { Value = "Minnesota", Text = "Minnesota" },
            new SelectListItem { Value = "Mississippi", Text = "Mississippi" },
            new SelectListItem { Value = "Missouri", Text = "Missouri" },
            new SelectListItem { Value = "Montana", Text = "Montana" },
            new SelectListItem { Value = "Nebraska", Text = "Nebraska" },
            new SelectListItem { Value = "Nevada", Text = "Nevada" },
            new SelectListItem { Value = "New Jersey", Text = "New Jersey" },
            new SelectListItem { Value = "New Mexico", Text = "New Mexico" },
            new SelectListItem { Value = "New York", Text = "New York" },
            new SelectListItem { Value = "North Carolina", Text = "North Carolina" },
            new SelectListItem { Value = "North Dakota", Text = "North Dakota" },
            new SelectListItem { Value = "Ohio", Text = "Ohio" },
            new SelectListItem { Value = "Oklahoma", Text = "Oklahoma" },
            new SelectListItem { Value = "Oregon", Text = "Oregon" },
            new SelectListItem { Value = "Pennsylvania", Text = "Pennsylvania" },
            new SelectListItem { Value = "South Carolina", Text = "South Carolina" },
            new SelectListItem { Value = "South Dakota", Text = "South Dakota" },
            new SelectListItem { Value = "Tennessee", Text = "Tennessee" },
            new SelectListItem { Value = "Texas", Text = "Texas" },
            new SelectListItem { Value = "Utah", Text = "Utah" },
            new SelectListItem { Value = "Vermont", Text = "Vermont" },
            new SelectListItem { Value = "Virginia", Text = "Virginia" },
            new SelectListItem { Value = "Washington", Text = "Washington" },
            new SelectListItem { Value = "West Virginia", Text = "West Virginia" },
            new SelectListItem { Value = "Wisconsin", Text = "Wisconsin" },
            new SelectListItem { Value = "Wyoming", Text = "Wyoming" }
        };
        }
    }
}
