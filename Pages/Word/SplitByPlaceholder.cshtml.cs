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
using System.Text.RegularExpressions;

namespace EJ2CoreSampleBrowser_NET8.Pages.Word;

public class SplitByPlaceholder : PageModel
{
    public void OnGet()
    {
        
    }
    
    private readonly IWebHostEnvironment _hostingEnvironment;
    public SplitByPlaceholder(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public ActionResult OnPost(string Group1, string Button, string RegexPattern, string IncludePlaceholder)
    {
        if (Group1 == null)
            return null;
            // return View();

        string contenttype1 = "application/vnd.ms-word.document.12";
        Stream fileStream = GetPlaceholderWordDocument();
        if (Button == "View Template")
        {
            return File(fileStream, contenttype1, "SplitByPlaceholder.docx");
        }

        string outputFileName = (Request.Form.Files != null && Request.Form.Files.Count != 0)
            ? Request.Form.Files[0].FileName
            : "SplitByPlaceholder.docx";
        //Create instance of ZipArchive to save the splitted documents.
        ZipArchive zip = new ZipArchive();
        if (fileStream != null)
        {
            try
            {
                //Open an existing Word document.
                using (WordDocument document = new WordDocument(fileStream, FormatType.Docx))
                {
                    // Insert bookmarks at placeholders

                    //Finds all the placeholder text in the Word document.
                    TextSelection[] textSelections = document.FindAll(new Regex(RegexPattern));
                    if (textSelections != null)
                    {
                        //Unique ID for each bookmark.
                        int bkmkId = 1;
                        string bookmarkName = string.Empty;
                        //Collection to hold the inserted bookmarks.
                        List<string> bookmarks = new List<string>();
                        //Iterate each text selection.
                        for (int i = 0; i < textSelections.Length; i++)
                        {
                            #region Insert bookmark start before the placeholder

                            //Get the placeholder as WTextRange.
                            WTextRange textRange = textSelections[i].GetAsOneRange();
                            //Get the index of the placeholder text. 
                            WParagraph startParagraph = textRange.OwnerParagraph;
                            int index = startParagraph.ChildEntities.IndexOf(textRange);
                            bookmarkName = "Bookmark_" + bkmkId;
                            //Add new bookmark to bookmarks collection.
                            bookmarks.Add(bookmarkName);
                            //Create bookmark start.
                            BookmarkStart bkmkStart = new BookmarkStart(document, bookmarkName);
                            //Insert the bookmark start before the start placeholder.
                            startParagraph.ChildEntities.Insert(index, bkmkStart);
                            //Remove the placeholder if the IncludePlaceholder checkbox is disabled.
                            if (IncludePlaceholder != "IncludePlaceholder")
                                textRange.Text = string.Empty;

                            #endregion

                            #region Insert bookmark end after the placeholder

                            i++;
                            //Get the placeholder as WTextRange.
                            textRange = textSelections[i].GetAsOneRange();
                            //Get the index of the placeholder text. 
                            WParagraph endParagraph = textRange.OwnerParagraph;
                            index = endParagraph.ChildEntities.IndexOf(textRange);
                            //Create bookmark end.
                            BookmarkEnd bkmkEnd = new BookmarkEnd(document, bookmarkName);
                            //Insert the bookmark end after the end placeholder.
                            endParagraph.ChildEntities.Insert(index + 1, bkmkEnd);
                            bkmkId++;
                            //Remove the placeholder if the IncludePlaceholder checkbox is disabled.
                            if (IncludePlaceholder != "IncludePlaceholder")
                                textRange.Text = string.Empty;

                            #endregion

                        }

                        // Split bookmark content into separate documents

                        BookmarksNavigator bookmarksNavigator = new BookmarksNavigator(document);
                        int fileIndex = 1;
                        foreach (string bookmark in bookmarks)
                        {
                            MemoryStream memoryStream = new MemoryStream();
                            //Move the virtual cursor to the location before the end of the bookmark.
                            bookmarksNavigator.MoveToBookmark(bookmark);
                            //Get the bookmark content as WordDocumentPart.
                            WordDocumentPart wordDocumentPart = bookmarksNavigator.GetContent();
                            //Save the WordDocumentPart as separate Word document.
                            WordDocument newDocument = wordDocumentPart.GetAsWordDocument();
                            if (Group1 == "WordDocx")
                            {
                                //Save the Word document.
                                newDocument.Save(memoryStream, FormatType.Docx);
                                //Save splitted document to zip.
                                SaveFileToZip(zip, "Document" + fileIndex + ".docx", memoryStream);
                            }
                            else
                            {
                                //Convert Word to PDF.
                                memoryStream = ConvertToPDF(newDocument);
                                //Save splitted document to zip.
                                SaveFileToZip(zip, "Document" + fileIndex + ".pdf", memoryStream);
                            }

                            fileIndex++;
                        }
                    }
                    //If placeholders not in the document, then return the document.
                    else
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
                            memoryStream = ConvertToPDF(document);
                            //Retrun the PDF document.
                            return File(memoryStream, "application/pdf",
                                Path.GetFileNameWithoutExtension(outputFileName) + ".pdf");
                        }
                    }
                    fileStream.Dispose();
                }

                string outpurFileNmae =
                    Group1 == "WordDocx" ? "SplitByPlaceholderDOCX.zip" : "SplitByPlaceholderPDFs.zip";

                //Return the zip file with split documents.
                return GetFinalZip(zip, outpurFileNmae);
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
    private MemoryStream ConvertToPDF(WordDocument newDocument)
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
    private Stream GetPlaceholderWordDocument()
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
            FileStream fileStreamPath =
                new FileStream(_hostingEnvironment.WebRootPath + @"/Word/SplitByPlaceholder.docx", FileMode.Open,
                    FileAccess.Read, FileShare.ReadWrite);
            return fileStreamPath;
        }
    }

    /// <summary>
    /// Saves the given Word document into zip file.
    /// </summary>
    private void SaveFileToZip(ZipArchive zip, string filename, Stream stream)
    {
        stream.Position = 0;
        ZipArchiveItem item =
            new ZipArchiveItem(zip, filename, stream, true, Syncfusion.Compression.FileAttributes.Compressed);
        zip.AddItem(item);
    }

    /// <summary>
    /// Gets the all document as one zip file.
    /// </summary>
    private ActionResult GetFinalZip(ZipArchive zip, string filename)
    {
        MemoryStream stream = new MemoryStream();
        zip.Save(stream, true);
        return File(stream.ToArray(), "application/zip", filename);
    }
}