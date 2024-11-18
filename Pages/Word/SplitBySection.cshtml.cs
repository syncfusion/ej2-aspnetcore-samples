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
using Syncfusion.DocIORenderer;
using Syncfusion.Compression.Zip;
using Syncfusion.Pdf;

namespace EJ2CoreSampleBrowser.Pages.Word;

public class SplitBySection : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public SplitBySection(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public ActionResult OnPost(string Group1, string Button, string ExcludeLabelsAndNumbers)
    {
        if (Group1 == null)
            return null;
            // return View();

        string contenttype1 = "application/vnd.ms-word.document.12";
        Stream fileStream = GetSectionWordDocument();
        if (Button == "View Template")
        {
            return File(fileStream, contenttype1, "SplitBySection.docx");
        }

        //Create instance of ZipArchive to save the splitted documents.
        ZipArchive zip = new ZipArchive();
        if (fileStream != null)
        {
            // try
            // {
                //Open an existing Word document.
                using (WordDocument document = new WordDocument(fileStream, FormatType.Docx))
                {

                    int fileId = 1;

                    //Iterate each section in Word document.
                    foreach (WSection section in document.Sections)
                    {
                        MemoryStream memoryStream = new MemoryStream();
                        //Create new Word document.
                        using (WordDocument newDocument = new WordDocument())
                        {
                            //Clone the section from source document to new document.
                            newDocument.Sections.Add(section.Clone());

                            if (Group1 == "WordDocx")
                            {
                                newDocument.Save(memoryStream, FormatType.Docx);
                                //Save splitted document to zip.
                                SaveDocumentToZip(zip, "Section_" + fileId + ".docx", memoryStream);
                            }
                            else
                            {
                                //Instantiation of DocIORenderer for Word to PDF conversion
                                using (DocIORenderer render = new DocIORenderer())
                                {
                                    //Convert Word document into PDF document
                                    using (PdfDocument pdfDocument = render.ConvertToPDF(newDocument))
                                    {
                                        //Save the PDF file.
                                        pdfDocument.Save(memoryStream);
                                        //Save splitted document to zip.
                                        SaveDocumentToZip(zip, "Section_" + fileId + ".pdf", memoryStream);
                                    }
                                }
                            }

                            fileId++;
                        }
                    }

                    fileStream.Dispose();
                }

                string outpurFileNmae = Group1 == "WordDocx" ? "SplitBySectionDOCX.zip" : "SplitBySectionPDFs.zip";

                //Return the zip file with split documents.
                return GetZipFile(zip, outpurFileNmae);
            // }
            // catch
            // {
            //     var Message =
            //         string.Format(
            //             "The input document could not be processed completely, Could you please email the document to support@syncfusion.com for troubleshooting.");
            // }
        }

        // return View();
        return null;
    }

    private Stream GetSectionWordDocument()
    {
        if (Request.Form.Files != null && Request.Form.Files.Count != 0)
        {
            // Gets the extension from file.
            string extension = Path.GetExtension(Request.Form.Files[0].FileName).ToLower();

            // Compares extension with supported extensions.
            if (extension == ".doc" || extension == ".docx" || extension == ".dot" || extension == ".dotx" ||
                extension == ".dotm" || extension == ".docm"
                || extension == ".xml" || extension == ".rtf")
            {
                MemoryStream stream = new MemoryStream();
                Request.Form.Files[0].CopyTo(stream);
                return stream;
            }
            else
            {
                var Message = string.Format("Please choose Word format document to split the Word document");
                return null;
            }
        }
        else
        {
            //Opens an existing document from stream through constructor of `WordDocument` class
            FileStream fileStreamPath = new FileStream(_hostingEnvironment.WebRootPath + @"/Word/SplitBySection.docx",
                FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            return fileStreamPath;
        }
    }

    /// <summary>
    /// Saves the given Word document into zip file.
    /// </summary>
    private void SaveDocumentToZip(ZipArchive zip, string filename, Stream stream)
    {
        stream.Position = 0;
        ZipArchiveItem item =
            new ZipArchiveItem(zip, filename, stream, true, Syncfusion.Compression.FileAttributes.Compressed);
        zip.AddItem(item);
    }

    /// <summary>
    /// Gets the all document as one zip file.
    /// </summary>
    private ActionResult GetZipFile(ZipArchive zip, string filename)
    {
        MemoryStream stream = new MemoryStream();
        zip.Save(stream, true);
        return File(stream.ToArray(), "application/zip", filename);
    }
}