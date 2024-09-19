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

namespace EJ2CoreSampleBrowser_NET8.Pages.Word;

public class SplitByHeading : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public SplitByHeading(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public ActionResult OnPost(string Group1, string Button, string ExcludeLabelsAndNumbers)
    {
        if (Group1 == null)
            return null;
            // return View();

        string contenttype1 = "application/vnd.ms-word.document.12";
        Stream fileStream = GetHeadingWordDocument();
        if (Button == "View Template")
        {
            return File(fileStream, contenttype1, "SplitByHeading.docx");
        }

        string outputFileName = (Request.Form.Files != null && Request.Form.Files.Count != 0)
            ? Request.Form.Files[0].FileName
            : "SplitByHeading.docxx";
        //Create instance of ZipArchive to save the splitted documents.
        ZipArchive zip = new ZipArchive();
        if (fileStream != null)
        {
            try
            {
                //Open an existing Word document.
                using (WordDocument document = new WordDocument(fileStream, FormatType.Docx))
                {
                    MemoryStream memoryStream = null;
                    WordDocument newDocument = null;
                    WSection newSection = null;
                    int headingIndex = 0;
                    //Iterate each section in the Word document.
                    foreach (WSection section in document.Sections)
                    {
                        // Clone the section and add into new document.
                        if (newDocument != null)
                            newSection = AddSection(newDocument, section);
                        //Iterate each child entity in the Word document.
                        foreach (TextBodyItem item in section.Body.ChildEntities)
                        {
                            //If item is paragraph, then check for heading style and split.
                            //else, add the item into new document.
                            if (item is WParagraph)
                            {
                                WParagraph paragraph = item as WParagraph;
                                //If paragraph has Heading 1 style, then save the traversed content as separate document.
                                //And create new document for new heading content.
                                if (paragraph.StyleName == "Heading 1")
                                {
                                    if (newDocument != null)
                                    {
                                        //Save document to the zip file.
                                        SaveDocumentsToZip(newDocument, zip, Group1, headingIndex);
                                        headingIndex++;
                                    }

                                    //Create new document for new heading content.
                                    newDocument = new WordDocument();
                                    newSection = AddSection(newDocument, section);
                                    AddEntity(newSection, paragraph);
                                }
                                else if (newDocument != null)
                                    AddEntity(newSection, paragraph);
                            }
                            else
                                AddEntity(newSection, item);
                        }
                    }

                    //If heading is not fount in the input document, then return the document.
                    if (newDocument == null && headingIndex == 0)
                    {
                        MemoryStream documentStream = new MemoryStream();
                        if (Group1 == "WordDocx")
                        {
                            //Save the Word file.
                            document.Save(documentStream, FormatType.Docx);
                            //Return the document.
                            return File(documentStream, contenttype1, outputFileName);
                        }
                        else
                        {
                            //Convert Word to PDF.
                            documentStream = ConvertWordToPDF(document);
                            //Retrun the PDF document.
                            return File(documentStream, "application/pdf",
                                Path.GetFileNameWithoutExtension(outputFileName) + ".pdf");
                        }
                    }

                    //Save the remaining content as separate document.
                    if (newDocument != null)
                        //Save document to the zip file.
                        SaveDocumentsToZip(newDocument, zip, Group1, headingIndex);
                    fileStream.Dispose();
                }

                string outpurFileNmae = Group1 == "WordDocx" ? "SplitByHeadingDOCX.zip" : "SplitByHeadingPDFs.zip";

                //Return the zip file with split documents.
                return GetZippedFile(zip, outpurFileNmae);
            }
            catch
            {
                var Message =
                    string.Format(
                        "The input document could not be processed completely, Could you please email the document to support@syncfusion.com for troubleshooting.");
            }
        }

        return null;
        // return View();
    }

    /// <summary>
    /// Convert given Word document to PDF.
    /// </summary>
    private MemoryStream ConvertWordToPDF(WordDocument newDocument)
    {
        MemoryStream memoryStream = new MemoryStream();
        //Instantiation of DocIORenderer for Word to PDF conversion
        using (DocIORenderer render = new DocIORenderer())
        {
            //Convert Word document into PDF document
            using (PdfDocument pdfDocument = render.ConvertToPDF(newDocument))
            {
                //Save the PDF file.
                pdfDocument.Save(memoryStream);
                memoryStream.Position = 0;
                return memoryStream;
            }
        }
    }

    /// <summary>
    /// Get the input Word document.
    /// </summary>
    private Stream GetHeadingWordDocument()
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
            FileStream fileStreamPath = new FileStream(_hostingEnvironment.WebRootPath + @"/Word/SplitByHeading.docx",
                FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            return fileStreamPath;
        }
    }

    /// <summary>
    /// Clone the entity from source document and add to new document's body collection.
    /// </summary>
    private void AddEntity(WSection? newSection, Entity entity)
    {
        newSection.Body.ChildEntities.Add(entity.Clone());
    }

    /// <summary>
    /// Clone the section from source document and add to new document.
    /// </summary>
    private WSection? AddSection(WordDocument newDocument, WSection section)
    {
        WSection newSection = section.Clone();
        newSection.Body.ChildEntities.Clear();
        newSection.HeadersFooters.FirstPageHeader.ChildEntities.Clear();
        newSection.HeadersFooters.FirstPageFooter.ChildEntities.Clear();
        newSection.HeadersFooters.OddFooter.ChildEntities.Clear();
        newSection.HeadersFooters.OddHeader.ChildEntities.Clear();
        newSection.HeadersFooters.EvenFooter.ChildEntities.Clear();
        newSection.HeadersFooters.EvenHeader.ChildEntities.Clear();
        newDocument.Sections.Add(newSection);
        return newSection;
    }

    /// <summary>
    ///Saves documents to the zip file.
    /// </summary>
    private void SaveDocumentsToZip(WordDocument wordDocument, ZipArchive zip, string group, int headingIndex)
    {
        MemoryStream memoryStream = new MemoryStream();
        if (group == "WordDocx")
        {
            wordDocument.Save(memoryStream, FormatType.Docx);
            //Save splitted document to zip.
            SaveWordIntoZip(zip, "Document" + (headingIndex + 1) + ".docx", memoryStream);
        }
        else
        {
            //Convert Word to PDF.
            memoryStream = ConvertWordToPDF(wordDocument);

            //Save splitted document to zip.
            SaveWordIntoZip(zip, "Document" + (headingIndex + 1) + ".pdf", memoryStream);
        }
    }

    /// <summary>
    /// Saves the given Word document into zip file.
    /// </summary>
    private void SaveWordIntoZip(ZipArchive zip, string filename, Stream stream)
    {
        stream.Position = 0;
        ZipArchiveItem item =
            new ZipArchiveItem(zip, filename, stream, true, Syncfusion.Compression.FileAttributes.Compressed);
        zip.AddItem(item);
    }

    /// <summary>
    /// Gets the all document as one zip file.
    /// </summary>
    private ActionResult GetZippedFile(ZipArchive zip, string filename)
    {
        MemoryStream stream = new MemoryStream();
        zip.Save(stream, true);
        return File(stream.ToArray(), "application/zip", filename);
    }
}