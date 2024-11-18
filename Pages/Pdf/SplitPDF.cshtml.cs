#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Compression.Zip;

namespace EJ2CoreSampleBrowser.Pages.Pdf;

public class SplitPDF : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public SplitPDF(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public string lab;
    public string Message;
    public int PageCount;
    private string result;

    public ActionResult OnPost(string Browser, string splitOption, int startPageNumber, int endPageNumber,
        int fileCount, int pageNoCount, IFormFile file)
    {
        result = null;
        Stream fileStream = GetSplitPDFDocument(file);
        if (splitOption == "fixedRange")
        {
            if (startPageNumber != 0 && endPageNumber != 0)
            {
                int splitAtPage = startPageNumber;
                int splitAtPage1 = endPageNumber;

                if (splitAtPage <= splitAtPage1)
                {
                    PdfLoadedDocument ldoc = new PdfLoadedDocument(fileStream);
                    int pageCount = ldoc.Pages.Count;
                    PageCount = pageCount;
                    if (splitAtPage1 <= ldoc.Pages.Count && splitAtPage != 0)
                    {
                        //Create pdf split options
                        PdfSplitOptions option = new PdfSplitOptions();

                        //Enable split tags
                        option.SplitTags = true;

                        //Subscribe document split event
                        ldoc.DocumentSplitEvent += DocumentSplitEvent;

                        //Split pdf document by page ranges and split options
                        ldoc.SplitByRanges(new int[,] { { splitAtPage - 1, splitAtPage1 - 1 } }, option);

                        //Close the PDF document.
                        ldoc.Close(true);

                        if (result == null)
                            return null;
                            // return View();

                        //Download the PDF document in the browser.
                        FileStreamResult fileStreamResult =
                            new FileStreamResult(new MemoryStream(Convert.FromBase64String(result)), "application/pdf");
                        fileStreamResult.FileDownloadName = "Split.pdf";
                        return fileStreamResult;
                    }
                    else
                    {
                        int pagecount = ldoc.Pages.Count;
                        lab = "Invalid Page no: The page range should be 1 to " + pagecount;
                    }

                    ldoc.Close(true);
                }
                else
                {
                    PdfLoadedDocument ldoc = new PdfLoadedDocument(fileStream);
                    int pagecount = ldoc.Pages.Count;
                    ldoc.Close(true);
                    lab = "Invalid page range: The page range should be 1 to " + pagecount;
                }
            }
            else
            {
                PdfLoadedDocument ldoc = new PdfLoadedDocument(fileStream);
                int pagecount = ldoc.Pages.Count;
                ldoc.Close(true);
                lab = "Invalid page range: The page range should be 1 to " + pagecount;
            }
        }
        else if (splitOption == "fileCount")
        {
            PdfLoadedDocument ldoc = new PdfLoadedDocument(fileStream);
            int pageCount = ldoc.Pages.Count;
            if (fileCount != 0)
            {
                if (fileCount <= pageCount)
                {
                    // Create PDF split options
                    PdfSplitOptions option = new PdfSplitOptions();

                    option.SplitTags = true;

                    ZipArchive zipArchive = new ZipArchive();

                    int[,] splitRanges = GetPageRanges(pageCount, fileCount);

                    int index = 0;

                    ldoc.DocumentSplitEvent += (object sender, PdfDocumentSplitEventArgs args) =>
                    {
                        MemoryStream stream = new MemoryStream();
                        args.PdfDocumentData.CopyTo(stream);
                        zipArchive.AddItem($"split{splitRanges[index, 0] + 1}-{splitRanges[index, 1] + 1}.pdf", stream,
                            false, (Syncfusion.Compression.FileAttributes)FileAttributes.Normal);
                        index++;
                    };

                    // Split the document by page range and split options
                    ldoc.SplitByRanges(splitRanges, option);

                    // Save the ziparchive in memory stream
                    MemoryStream memoryStream = new MemoryStream();
                    zipArchive.Save(memoryStream, false);

                    // Close the ZipArchive
                    zipArchive.Dispose();

                    // Close the loaded document
                    ldoc.Close(true);
                    return File(memoryStream.ToArray(), "application/zip", "SplitedFiles.zip");
                }
                else
                {
                    lab = "Invalid file count: The file count should be 1 to " + pageCount;
                }
            }
            else
            {
                lab = "Invalid file count: The file count should be 1 to " + pageCount;
            }

            ldoc.Close(true);
        }
        else if (splitOption == "pageCount")
        {
            PdfLoadedDocument ldoc = new PdfLoadedDocument(fileStream);
            int pageCount = ldoc.Pages.Count;
            if (pageNoCount != 0)
            {
                if (pageNoCount <= pageCount)
                {
                    // Create PDF split options
                    PdfSplitOptions option = new PdfSplitOptions();

                    option.SplitTags = true;

                    ZipArchive zipArchive = new ZipArchive();

                    int index = 1;
                    ldoc.DocumentSplitEvent += (object sender, PdfDocumentSplitEventArgs args) =>
                    {
                        MemoryStream stream = new MemoryStream();
                        args.PdfDocumentData.CopyTo(stream);
                        zipArchive.AddItem($"split{index}.pdf", stream, false,
                            (Syncfusion.Compression.FileAttributes)FileAttributes.Normal);
                        index++;
                    };

                    // Split the document by fixed number and split options
                    ldoc.SplitByFixedNumber(pageNoCount, option);

                    // Save the zip archive in memory stream
                    MemoryStream memoryStream = new MemoryStream();
                    zipArchive.Save(memoryStream, false);

                    // Close the ZipArchive.
                    zipArchive.Dispose();

                    // Close the loaded document
                    ldoc.Close(true);

                    return File(memoryStream.ToArray(), "application/zip", "SplitedFiles.zip");
                }
                else
                {
                    lab = "Invalid page count: The page count should be 1 to " + pageCount;
                }
            }
            else
            {
                lab = "Invalid page count: The page count should be 1 to " + pageCount;
            }

            ldoc.Close(true);

        }
        else
        {
            lab = "Enter the page no to split";
        }

        fileStream.Dispose();
        return null;
        // return View();
    }
    int[,] GetPageRanges(int pageCount, int fileCount)
    {
        // Calculate the base number of pages per file and the remaining pages
        int pagesPerFileBase = pageCount / fileCount;
        int remainingPages = pageCount % fileCount;

        // Create an array to store the number of pages for each file
        int[] pagesPerFile = new int[fileCount];

        // Distribute the pages among the files
        for (int i = 0; i < fileCount; i++)
        {
            pagesPerFile[i] = pagesPerFileBase;
            if (remainingPages > 0)
            {
                pagesPerFile[i]++;
                remainingPages--;
            }
        }
        int startPage = 0;
        int endPage = 0;
        int[,] splitRanges = new int[fileCount, 2];

        for (int i = 0; i < fileCount; i++)
        {
            endPage = startPage + pagesPerFile[i] - 1;
            splitRanges[i, 0] = startPage;
            splitRanges[i, 1] = endPage;

            startPage = endPage + 1;
        }
        return splitRanges;
    }
    private void DocumentSplitEvent(object sender, PdfDocumentSplitEventArgs args)
    {
        MemoryStream ms = new MemoryStream();
        args.PdfDocumentData.CopyTo(ms);
        result = Convert.ToBase64String(ms.ToArray());
        ms.Dispose();
    }
    private Stream GetSplitPDFDocument(IFormFile file)
    {
        if (file != null)
        {
            // Gets the extension from file.
            string extension = Path.GetExtension(Request.Form.Files[0].FileName).ToLower();

            // Compares extension with supported extensions.
            if (extension == ".pdf")
            {
                MemoryStream stream = new MemoryStream();
                Request.Form.Files[0].CopyTo(stream);
                return stream;
            }
            else
            {
                Message = string.Format("Please choose a valid PDF document to split");
                return null;
            }
        }
        else
        {
            //Opens an existing document from stream through constructor of `WordDocument` class
            FileStream fileStreamPath = new FileStream(_hostingEnvironment.WebRootPath + @"/PDF/SplitPDF.pdf", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            return fileStreamPath;
        }
    }
}