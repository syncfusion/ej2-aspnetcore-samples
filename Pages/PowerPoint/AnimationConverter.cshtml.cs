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

namespace EJ2CoreSampleBrowser.Pages.PowerPoint;

public class AnimationConverter : PageModel
{
    public int ImagesCount;
    public string FileName;
    public string Message;
    [HttpPost]
    public void OnGet()
    {
        ImagesCount = 0;
        ConvertToImage();
    }
    public ActionResult OnPost(string button, string view)
    {
        ImagesCount = 0;
        if (button == null)
            return null;
            // return View();
        ConvertToImage();
        return null;
        // return View();
    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public AnimationConverter(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }
    /// <summary>
    /// Converts the PowerPoint Presentation slides to image streams based on entrance animation effects.
    /// </summary>
    private void ConvertToImage()
    {
        string basePath = _hostingEnvironment.WebRootPath;
        DirectoryInfo imagesFolder = new DirectoryInfo(_hostingEnvironment.WebRootPath + @"/PowerPoint/images/");
        //Creates image folder.
        if (!imagesFolder.Exists)
        {
            imagesFolder.Create();
        }
        else
        {
            //Deletes existing image files.
            FileInfo[] getFiles = imagesFolder.GetFiles();
            foreach (FileInfo file in getFiles)
            {
                if (file.Exists)
                    file.Delete();
            }
        }

        //Gets the PowerPoint Presentation.
        Stream fileStream = GetAnimationPresentation();

        if (fileStream != null)
        {
            //Opens a PowerPoint Presentation.
            IPresentation pptxDoc = Presentation.Open(fileStream);
            //Initialize the PresentationAnimationConverter to perform slide to image conversion based on animation order.
            using (PresentationAnimationConverter animationConverter = new PresentationAnimationConverter())
            {
                int i = 0;
                foreach (ISlide slide in pptxDoc.Slides)
                {
                    //Convert the PowerPoint slide to a series of images based on entrance animation effects.
                    Stream[] imageStreams = animationConverter.Convert(slide, ExportImageFormat.Jpeg);

                    //Save the image stream.
                    foreach (Stream stream in imageStreams)
                    {
                        i++;
                        //Reset the stream position.
                        stream.Position = 0;

                        string imageName = _hostingEnvironment.WebRootPath + @"/PowerPoint/images/image" + i + ".jpg";
                        //Create the output image file stream.
                        using (FileStream fileStreamOutput = System.IO.File.Create(imageName))
                        {
                            //Copy the converted image stream into created output stream.
                            stream.CopyTo(fileStreamOutput);
                        }
                    }
                }
            }

            ImagesCount = imagesFolder.GetFiles().Length;
        }
    }
    /// <summary>
    /// This method will returns the Input Presentation document or the Default Template Presentation document as Stream
    /// </summary>
    private Stream GetAnimationPresentation()
    {
        if (Request.ContentType != null && Request.Form.Files != null && Request.Form.Files.Count != 0)
        {
            // Gets the extension from file.
            string extension = Path.GetExtension(Request.Form.Files[0].FileName).ToLower();

            // Compares extension with supported extensions.
            if (extension == ".pptx")
            {
                MemoryStream stream = new MemoryStream();
                Request.Form.Files[0].CopyTo(stream);
                FileName = Request.Form.Files[0].FileName;
                return stream;
            }
            else
            {
                Message = string.Format("Please choose PowerPoint Presentation document (PPTX) to convert as Image");
                return null;
            }
        }
        else
        {
            string path = _hostingEnvironment.WebRootPath + @"/PowerPoint/AnimationConverter.pptx";
            //Opens an existing document from stream
            FileStream fileStreamPath = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            FileName = Path.GetFileName(path);
            return fileStreamPath;
        }
    }
}