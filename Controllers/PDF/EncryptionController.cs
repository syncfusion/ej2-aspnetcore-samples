using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Security;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {        
        
        public ActionResult Encryption()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Encryption(string InsideBrowser, string encryptionType)
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

            security.OwnerPassword = "syncfusion";
            security.Permissions = PdfPermissionsFlags.Print | PdfPermissionsFlags.FullQualityPrint;
            security.UserPassword = "password";

            string text = "Security options:\n\n" + String.Format("KeySize: {0}\n\nEncryption Algorithm: {4}\n\nOwner Password: {1}\n\nPermissions: {2}\n\n" +
                "UserPassword: {3}", security.KeySize, security.OwnerPassword, security.Permissions, security.UserPassword, security.Algorithm);
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
}
