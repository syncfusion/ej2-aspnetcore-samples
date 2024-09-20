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
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Security;

namespace EJ2CoreSampleBrowser_NET8.Pages.Pdf;

public class Encryption : PageModel
{
    public string[] data;
    public void OnGet()
    {
        List<string> styleList = new List<string>();
        data = new string[] { "Encrypt all contents", "Encrypt all contents except metadata", "Encrypt only attachments [For AES only]" };
    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public Encryption(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }
    public ActionResult OnPost(string InsideBrowser, string encryptionType, string encryptOption)
    {
        PdfDocument document = new PdfDocument();
        PdfPage page = document.Pages.Add();
        PdfGraphics graphics = page.Graphics;

        PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14f, PdfFontStyle.Bold);
        PdfBrush brush = PdfBrushes.Black;
        PdfForm form = document.Form;

        //Document security
        PdfSecurity security = document.Security;

        //Specify key size and encryption algorithm
        if (encryptionType == "40_RC4")
        {
            //use 40 bits key in RC4 mode
            security.KeySize = PdfEncryptionKeySize.Key40Bit;
        }
        else if (encryptionType == "128_RC4")
        {
            //use 128 bits key in RC4 mode
            security.KeySize = PdfEncryptionKeySize.Key128Bit;
            security.Algorithm = PdfEncryptionAlgorithm.RC4;
        }
        else if (encryptionType == "128_AES")
        {
            //use 128 bits key in AES mode
            security.KeySize = PdfEncryptionKeySize.Key128Bit;
            security.Algorithm = PdfEncryptionAlgorithm.AES;
        }
        else if (encryptionType == "256_AES")
        {
            //use 256 bits key in AES mode
            security.KeySize = PdfEncryptionKeySize.Key256Bit;
            security.Algorithm = PdfEncryptionAlgorithm.AES;
        }
        else if (encryptionType == "256_AES_Revision_6")
        {
            security.KeySize = PdfEncryptionKeySize.Key256BitRevision6;
            security.Algorithm = PdfEncryptionAlgorithm.AES;
        }

        //set Encryption options
        if (encryptOption == "Encrypt only attachments [For AES only]")
        {
            string basePath = _hostingEnvironment.WebRootPath;
            string dataPath = basePath + @"/PDF/";

            //Read the file
            FileStream xmlStream = new FileStream(dataPath + "Products.xml", FileMode.Open, FileAccess.Read,
                FileShare.ReadWrite);

            //Creates an attachment
            PdfAttachment attachment = new PdfAttachment("Products.xml", xmlStream);

            attachment.ModificationDate = DateTime.Now;

            attachment.Description = "About Syncfusion";

            attachment.MimeType = "application/txt";

            //Adds the attachment to the document
            document.Attachments.Add(attachment);

            security.EncryptionOptions = PdfEncryptionOptions.EncryptOnlyAttachments;
        }
        else if (encryptOption == "Encrypt all contents except metadata")
            security.EncryptionOptions = PdfEncryptionOptions.EncryptAllContentsExceptMetadata;
        else
            security.EncryptionOptions = PdfEncryptionOptions.EncryptAllContents;

        security.OwnerPassword = "syncfusion";
        security.Permissions = PdfPermissionsFlags.Print | PdfPermissionsFlags.FullQualityPrint;
        security.UserPassword = "password";

        string text = "Security options:\n\n" + String.Format(
            "KeySize: {0}\n\nEncryption Algorithm: {4}\n\nOwner Password: {1}\n\nPermissions: {2}\n\n" +
            "User Password: {3}", security.KeySize, security.OwnerPassword, security.Permissions, security.UserPassword,
            security.Algorithm);
        if (encryptionType == "256_AES_Revision_6")
        {
            text += String.Format("\n\nRevision: {0}", "Revision 6");
        }
        else if (encryptionType == "256_AES")
        {
            text += String.Format("\n\nRevision: {0}", "Revision 5");
        }

        graphics.DrawString("Document is Encrypted with following settings", font, brush, PointF.Empty);
        font = new PdfStandardFont(PdfFontFamily.TimesRoman, 11f, PdfFontStyle.Bold);
        graphics.DrawString(text, font, brush, new PointF(0, 40));

        //Saving the PDF to the MemoryStream
        MemoryStream ms = new MemoryStream();
        document.Save(ms);
        //If the position is not set to '0' then the PDF will be empty.
        ms.Position = 0;

        //Download the PDF document in the browser.
        FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
        fileStreamResult.FileDownloadName = "Secure.pdf";
        return fileStreamResult;
    }
}