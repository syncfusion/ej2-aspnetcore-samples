#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;


namespace EJ2CoreSampleBrowser.Helpers
{
    /* Function used to check whether IIS installed, if so then pass URL to Launch OtherProduct*/
    public static class MvcLaunchPageExt
    {
        public static IHttpContextAccessor HttpContextAccessor;
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }
        //public static ServerMode RequestedServer()
        //{
        //    HttpContextAccessor httpContextObj = new HttpContextAccessor();
        //    return String.Equals(System.Diagnostics.Process.GetCurrentProcess().ProcessName, "iisexpress") ? ServerMode.IISExpress : httpContextObj.HttpContext.Response.Headers.Keys.ToArray()[0].ToLower().IndexOf("server") != -1 ? ServerMode.IIS : ServerMode.Other;            
        //}

        //public static ServerMode RequestedServer(this IHtmlHelper helper)
        //{
        //    return RequestedServer();
        //}
        

        public static void IncludeIISUriPrefix(this HtmlHelper helper)
        {
            string uri = @"/sfmvc{0}samplebrowser";

            //WriteTo(helper, string.Format("iisPrefixLink='{0}'", uri));
        }



        //public static void WriteTo(HtmlHelper helper, string value)
        //{
        //    var baseWriter = helper.ViewContext.Writer;            
        //    using (HtmlTextWriter textWriter = new HtmlTextWriter(baseWriter))
        //    {
        //        textWriter.AddAttribute(HtmlTextWriterAttribute.Type, "text/javascript");
        //        textWriter.RenderBeginTag(HtmlTextWriterTag.Script);
        //        textWriter.Write(value);
        //        textWriter.RenderEndTag();
        //    }
        //}
    }
    public enum ServerMode
    {
        IIS,
        IISExpress,
        Other
    }
}
