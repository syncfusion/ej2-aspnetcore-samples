using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System.IO;
using EJ2CoreSampleBrowser.Models;
using System.Text;

namespace EJ2CoreSampleBrowser.Controllers.PDF
{
    public partial class PdfController : Controller
    {
        public ActionResult FindPDFCorruption()
        {

            FindPDFCorruptionMessage message = new FindPDFCorruptionMessage();
            message.Message = string.Empty;
            return View("FindPDFCorruption", message);
        }

        [HttpPost]
        public ActionResult FindPDFCorruption(string FindCorruption)
        {
            string dataPath = _hostingEnvironment.WebRootPath + @"/PDF/";
            FindPDFCorruptionMessage message = new FindPDFCorruptionMessage();
            
            //Read the certificate file.
            FileStream pdfFile = new FileStream(dataPath + @"CorruptedDocument.pdf", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            //Create a new instance for the PDF analyzer.
            PdfDocumentAnalyzer analyzer = new PdfDocumentAnalyzer(pdfFile);

            //Get the syntax errors.
            SyntaxAnalyzerResult result = analyzer.AnalyzeSyntax();

            //Check whether the document is corrupted or not.
            if (result.IsCorrupted)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine("The PDF document is corrupted.");
                int count = 1;
                foreach (PdfException exception in result.Errors)
                {
                    builder.AppendLine(count++.ToString() + ": " + exception.Message);
                }
                message.Message = builder.ToString();
            }

            return View("FindPDFCorruption",message);
        }

    }
}
