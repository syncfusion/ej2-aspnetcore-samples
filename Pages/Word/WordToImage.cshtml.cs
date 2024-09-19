#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using Syncfusion.DocIORenderer;
using Syncfusion.Compression.Zip;

namespace EJ2CoreSampleBrowser_NET8.Pages.Word;

public class WordToImage : PageModel
{
    
    public void OnGet()
    {
        
    }
    public string Message { get; set; }
    private readonly IWebHostEnvironment _hostingEnvironment;

    public WordToImage(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public IActionResult OnPost(string option, string button, string from, string to)
    {
        if (button == null)
            return null;
            // return View();
        Stream stream = GetWordDocumentForImageConversion();
        if (stream != null)
        {
            try
            {
                string output = (Request.Form.Files != null && Request.Form.Files.Count != 0)
                    ? Path.GetFileNameWithoutExtension(Request.Form.Files[0].FileName)
                    : "WordtoImage";

                //Loads document from stream.
                using (WordDocument document = new WordDocument(stream, FormatType.Automatic))
                {
                    stream.Dispose();
                    stream = null;

                    //Creates a new instance of DocIORenderer class.
                    using (DocIORenderer render = new DocIORenderer())
                    {
                        if (option == "FirstPage")
                        {
                            //Converts the first page of Word document to image.
                            MemoryStream imageStream =
                                (MemoryStream)document.RenderAsImages(0, Syncfusion.DocIO.ExportImageFormat.Jpeg);
                            imageStream.Position = 0;
                            return File(imageStream, "image/jpeg", output + "_Page1.jpeg");
                        }
                        else
                        {
                            //Initialize ZipArchive to zip the image files.
                            ZipArchive zip = new ZipArchive();
                            string zipFileName;
                            Stream[] imageStreams;

                            if (option == "SpecificPages")
                            {
                                int firstPage = int.Parse(from);
                                int lastPage = int.Parse(to);
                                int pageCount = document.BuiltinDocumentProperties.PageCount;

                                if (firstPage <= lastPage && firstPage <= pageCount && firstPage > 0)
                                {
                                    int numberOfPages = lastPage - firstPage + 1;

                                    //Converts specific page range of Word document to images.
                                    imageStreams = document.RenderAsImages(firstPage - 1, numberOfPages);

                                    zipFileName = output + "_Pages" + firstPage + "To" + lastPage + ".zip";
                                    return SaveImagesToZip(zip, output, firstPage, imageStreams, zipFileName);
                                }
                                else
                                {
                                    Message = string.Format("Please enter a valid range of pages.");
                                }
                            }
                            else
                            {
                                //Converts all pages in Word document to images.
                                imageStreams = document.RenderAsImages();

                                zipFileName = output + "_Images.zip";
                                return SaveImagesToZip(zip, output, 1, imageStreams, zipFileName);
                            }
                        }
                    }
                }
            }
            catch
            {
                Message =
                    string.Format(
                        "The input document could not be processed completely, Could you please email the document to support@syncfusion.com for troubleshooting.");
            }
        }

        return null;
        // return View();
    }

    /// <summary>
    /// Gets Word document for Image Conversion
    /// </summary>
    /// <returns></returns>
    private Stream GetWordDocumentForImageConversion()
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
                Message = string.Format("Please choose Word format document to convert to Image");
                return null;
            }
        }
        else
        {
            //Opens an existing document from stream through constructor of `WordDocument` class
            FileStream fileStreamPath = new FileStream(_hostingEnvironment.WebRootPath + @"/Word/WordtoImage.docx",
                FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            return fileStreamPath;
        }
    }

    /// <summary>
    /// Save the images to zip file
    /// </summary>
    /// <returns></returns>
    private ActionResult SaveImagesToZip(ZipArchive zip, string output, int firstPage, Stream[] imageStreams,
        string zipFileName)
    {
        foreach (Stream imageStream in imageStreams)
        {
            string filename = output + "_Page" + firstPage + ".jpeg";
            imageStream.Position = 0;
            ZipArchiveItem item = new ZipArchiveItem(zip, filename, imageStream, true,
                Syncfusion.Compression.FileAttributes.Compressed);
            zip.AddItem(item);
            firstPage++;
        }

        MemoryStream stream = new MemoryStream();
        zip.Save(stream, true);
        return File(stream.ToArray(), "application/zip", zipFileName);
    }
}