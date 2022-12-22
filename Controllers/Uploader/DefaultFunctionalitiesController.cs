#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http.Features;

namespace EJ2CoreSampleBrowser.Controllers.TextBoxes
{
    public partial class UploaderController : Controller
    {
        private IWebHostEnvironment hostingEnv;
        public UploaderController(IWebHostEnvironment env)
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
        public IActionResult DefaultFunctionalities()
        {
            return View();
        }
    }
}