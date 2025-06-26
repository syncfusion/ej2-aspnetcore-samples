#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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

public class SplitByBookmark : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public SplitByBookmark(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public ActionResult OnPost(string Group1, string Button, string ExcludeLabelsAndNumbers)
    {
        if (Group1 == null)
            return null;
            // return View();

        string contenttype1 = "application/vnd.ms-word.document.12";
        Stream fileStream = GetBookmarkWordDocument();
        if (Button == "View Template")
        {
            return File(fileStream, contenttype1, "SplitByBookmark.docx");
        }

        string outputFileName = (Request.Form.Files != null && Request.Form.Files.Count != 0)
            ? Request.Form.Files[0].FileName
            : "SplitByBookmark.docx";
        //Create instance of ZipArchive to save the splitted documents.
        ZipArchive zip = new ZipArchive();
        if (fileStream != null)
        {
            try
            {
                //Open an existing Word document.
                using (WordDocument document = new WordDocument(fileStream, FormatType.Docx))
                {
                    //If bookmarks are not in the document, return the input document.
                    if (document.Bookmarks.Count == 0)
                    {
                        MemoryStream memoryStream = new MemoryStream();
                        if (Group1 == "WordDocx")
                        {
                            //Save the Word file.
                            document.Save(memoryStream, FormatType.Docx);
                            //Return the document.
                            return File(memoryStream, contenttype1, outputFileName);
                        }
                        else
                        {
                            //Convert Word to PDF.
                            memoryStream = ConvertWordDocumentToPDF(document);

                            //Retrun the PDF document.
                            return File(memoryStream, "application/pdf",
                                Path.GetFileNameWithoutExtension(outputFileName) + ".pdf");
                        }
                    }
                    else
                    {
                        //Create the bookmark navigator instance to access the bookmark.
                        BookmarksNavigator bookmarksNavigator = new BookmarksNavigator(document);
                        BookmarkCollection bookmarkCollection = document.Bookmarks;
                        //Iterate each bookmark in Word document.
                        foreach (Bookmark bookmark in bookmarkCollection)
                        {
                            MemoryStream memoryStream = new MemoryStream();
                            //Move the virtual cursor to the location before the end of the bookmark.
                            bookmarksNavigator.MoveToBookmark(bookmark.Name);
                            //Get the bookmark content as WordDocumentPart.
                            WordDocumentPart documentPart = bookmarksNavigator.GetContent();
                            //Save the WordDocumentPart as separate Word document
                            WordDocument newDocument = documentPart.GetAsWordDocument();

                            if (Group1 == "WordDocx")
                            {
                                newDocument.Save(memoryStream, FormatType.Docx);
                                //Save splitted document to zip.
                                SaveIntoZip(zip, bookmark.Name + ".docx", memoryStream);
                            }
                            else
                            {
                                //Convert Word to PDF.
                                memoryStream = ConvertWordDocumentToPDF(newDocument);

                                //Save splitted document to zip.
                                SaveIntoZip(zip, bookmark.Name + ".pdf", memoryStream);
                            }
                        }
                    }

                    fileStream.Dispose();
                }

                string outpurFileNmae = Group1 == "WordDocx" ? "SplitByBookmarkDOCX.zip" : "SplitByBookmarkPDFs.zip";

                //Return the zip file with split documents.
                return GetFilesInZipFormat(zip, outpurFileNmae);
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
    private MemoryStream ConvertWordDocumentToPDF(WordDocument newDocument)
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
    private Stream GetBookmarkWordDocument()
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
            FileStream fileStreamPath = new FileStream(_hostingEnvironment.WebRootPath + @"/Word/SplitByBookmark.docx",
                FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            return fileStreamPath;
        }
    }

    /// <summary>
    /// Saves the given Word document into zip file.
    /// </summary>
    private void SaveIntoZip(ZipArchive zip, string filename, Stream stream)
    {
        stream.Position = 0;
        ZipArchiveItem item =
            new ZipArchiveItem(zip, filename, stream, true, Syncfusion.Compression.FileAttributes.Compressed);
        zip.AddItem(item);
    }

    /// <summary>
    /// Gets the all document as one zip file.
    /// </summary>
    private ActionResult GetFilesInZipFormat(ZipArchive zip, string filename)
    {
        MemoryStream stream = new MemoryStream();
        zip.Save(stream, true);
        return File(stream.ToArray(), "application/zip", filename);
    }
}