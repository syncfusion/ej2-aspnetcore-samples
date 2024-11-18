#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Presentation;
using Syncfusion.PresentationRenderer;
using Syncfusion.Compression.Zip;
using Syncfusion.Office;

namespace EJ2CoreSampleBrowser.Pages.PowerPoint;

public class PPTXToImage : PageModel
{
    public void OnGet()
    {
        
    }

    public string Message { get; set; }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public PPTXToImage(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }
    public ActionResult OnPost(string option, string button, string from, string to)
    {
        if (button == null)
            return null;
            // return View();
        Stream stream = GetPPTXDocumentForImageConversion();
        if (stream != null)
        {
            try
            {
                string output = (Request.Form.Files != null && Request.Form.Files.Count != 0)
                    ? Path.GetFileNameWithoutExtension(Request.Form.Files[0].FileName)
                    : "PresentationtoImage";

                //Open the existing PowerPoint  presentation.
                using (IPresentation presentation = Presentation.Open(stream))
                {
                    //Initialize PresentationRenderer to perform image conversion.
                    presentation.PresentationRenderer = new PresentationRenderer();

                    //Add a custom fallback font collection for Presentation.
                    AddFallbackFonts(presentation);

                    if (option == "FirstSlide")
                    {
                        //Converts the first slide of PowerPoint document to image.
                        Stream imageStream = presentation.Slides[0].ConvertToImage(ExportImageFormat.Jpeg);
                        imageStream.Position = 0;
                        return File(imageStream, "image/jpeg", output + "_Slide1.jpeg");
                    }
                    else
                    {
                        //Initialize ZipArchive to zip the image files.
                        ZipArchive zip = new ZipArchive();
                        string zipFileName;
                        Stream[] imageStreams;

                        if (option == "SpecificSlides")
                        {
                            int firstSlide = int.Parse(from);
                            int lastSlide = int.Parse(to);
                            int totalSlides = presentation.Slides.Count;

                            if (firstSlide <= lastSlide && firstSlide <= totalSlides && firstSlide > 0)
                            {
                                imageStreams = lastSlide <= totalSlides
                                    ? new Stream[lastSlide - firstSlide + 1]
                                    : new Stream[totalSlides - firstSlide + 1];

                                int i = 0;
                                for (int currentSlide = firstSlide - 1;
                                     currentSlide < totalSlides && currentSlide < lastSlide;
                                     currentSlide++)
                                {
                                    //Converts specific slide range of PowerPoint document to images.
                                    imageStreams[i] = presentation.Slides[currentSlide]
                                        .ConvertToImage(ExportImageFormat.Jpeg);
                                    i++;
                                }

                                zipFileName = output + "_Slides" + firstSlide + "To" + lastSlide + ".zip";
                                return SaveImagesToZip(zip, output, firstSlide, imageStreams, zipFileName);
                            }
                            else
                            {
                                Message = string.Format("Please enter a valid range of slides.");
                                return null;
                                // return View();
                            }
                        }
                        else
                        {
                            //Converts all slides in PowerPoint document to images.
                            imageStreams = presentation.RenderAsImages(ExportImageFormat.Jpeg);

                            zipFileName = output + "_Images.zip";
                            return SaveImagesToZip(zip, output, 1, imageStreams, zipFileName);
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
    /// Add a custom fallback font collection for IPresentation.
    /// </summary>
    /// <param name="presentation">Represent a presentation to add.</param>
    private void AddFallbackFonts(IPresentation presentation)
    {
        //Add customized fallback font names.

        // Arabic
        presentation.FontSettings.FallbackFonts.Add(new FallbackFont(0x0600, 0x06ff, "Arial"));
        // Hebrew
        presentation.FontSettings.FallbackFonts.Add(new FallbackFont(0x0590, 0x05ff, "Arial, David"));
        // Hindi
        presentation.FontSettings.FallbackFonts.Add(new FallbackFont(0x0900, 0x097F, "Mangal"));
        // Chinese
        presentation.FontSettings.FallbackFonts.Add(new FallbackFont(0x4E00, 0x9FFF, "DengXian"));
        // Japanese
        presentation.FontSettings.FallbackFonts.Add(new FallbackFont(0x3040, 0x309F, "MS Mincho"));
        // Korean
        presentation.FontSettings.FallbackFonts.Add(new FallbackFont(0xAC00, 0xD7A3, "Malgun Gothic"));
    }
    /// <summary>
    /// Gets Word document for Image Conversion
    /// </summary>
    /// <returns></returns>
    private Stream GetPPTXDocumentForImageConversion()
    {
        if (Request.Form.Files != null && Request.Form.Files.Count != 0)
        {
            // Gets the extension from file.
            string extension = Path.GetExtension(Request.Form.Files[0].FileName).ToLower();

            // Compares extension with supported extensions.
            if (extension == ".pptx")
            {
                MemoryStream stream = new MemoryStream();
                Request.Form.Files[0].CopyTo(stream);
                return stream;
            }
            else
            {
                Message = string.Format("Please choose PPTX format document to convert to Image");
                return null;
            }
        }
        else
        {
            //Opens an existing document from stream through `IPresentation` class
            FileStream fileStreamPath = new FileStream(_hostingEnvironment.WebRootPath + @"/PowerPoint/Template.pptx", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            return fileStreamPath;
        }
    }
    /// <summary>
    /// Save the images to zip file
    /// </summary>
    /// <returns></returns>
    private ActionResult SaveImagesToZip(ZipArchive zip, string output, int firstSlide, Stream[] imageStreams, string zipFileName)
    {
        foreach (Stream imageStream in imageStreams)
        {
            string filename = output + "_Slide" + firstSlide + ".jpeg";
            imageStream.Position = 0;
            ZipArchiveItem item = new ZipArchiveItem(zip, filename, imageStream, true, Syncfusion.Compression.FileAttributes.Compressed);
            zip.AddItem(item);
            firstSlide++;
        }

        MemoryStream stream = new MemoryStream();
        zip.Save(stream, true);
        return File(stream.ToArray(), "application/zip", zipFileName);
    }
}