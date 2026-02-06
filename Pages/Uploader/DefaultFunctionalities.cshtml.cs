#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
namespace EJ2CoreSampleBrowser.Pages.Uploader;

public class DefaultFunctionalities : PageModel
{
    private IWebHostEnvironment hostingEnv;
    public DefaultFunctionalities(IWebHostEnvironment env)
    {
        this.hostingEnv = env;
    }
    [AcceptVerbs("Post")]
    public IActionResult Save(IList<IFormFile> UploadFiles)
    {
        try
        {
            foreach (var file in UploadFiles)
            {
                if (UploadFiles != null)
                {
                    var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    filename = hostingEnv.WebRootPath + $@"\{filename}";
                    if (!System.IO.File.Exists(filename))
                    {
                        //using (FileStream fs = System.IO.File.Create(filename))
                        //{
                        //    file.CopyTo(fs);
                        //    fs.Flush(); 
                        //}
                    }
                    else
                    {
                        Response.Clear();
                        Response.StatusCode = 204;
                        Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File already exists.";
                    }
                }
            }
        }
        catch (Exception e)
        {
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.StatusCode = 204;
            Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "No Content";
            Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
        }
        return Content("");
    }
    [AcceptVerbs("Post")]
    public IActionResult Remove(string UploadFiles)
    {
        try
        {
            var fileName = UploadFiles;
            var filePath = Path.Combine(hostingEnv.WebRootPath);
            var fileSavePath = filePath + "\\" + fileName;
            if (!System.IO.File.Exists(fileSavePath))
            {
                System.IO.File.Delete(fileSavePath);
            }  
        }
        catch (Exception e)
        {
            Response.Clear();
            Response.StatusCode = 200;
            Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File removed successfully";
            Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
        }
        return Content("");
    }
    public void OnGet()
    {
        
    }
}