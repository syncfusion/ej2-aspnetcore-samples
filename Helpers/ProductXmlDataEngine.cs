using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.AspNetCore.Html;
using System.IO;
using Manoli.Utils.CSharpFormat;
using System.Net;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using EJ2CoreSampleBrowser.Helpers.BrowserClasses;

namespace EJ2CoreSampleBrowser.Helpers.BrowserClasses
{
    internal class ProductXmlDataEngine
    {
        private readonly IHostingEnvironment _appEnvironment;
        public static IHttpContextAccessor HttpContextAccessor;
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }
        public ProductXmlDataEngine()
        {
        }
        public TabType GetTabType(string fileName)
        {

            if (fileName.EndsWith(".aspx") || fileName.EndsWith(".cshtml"))
                return TabType.View;
            else if (fileName.EndsWith(".ascx"))
                return TabType.PartialView;
            else if (fileName.EndsWith(".cs"))
                return TabType.CS;
            else if (fileName.EndsWith(".css"))
                return TabType.CSS;
            else if (fileName.EndsWith(".js"))
                return TabType.JavaScript;
            else if (fileName.EndsWith(".vb"))
                return TabType.VB;
            else if (fileName.EndsWith(".html"))
                return TabType.Description;
            else
                return TabType.XML;

        }

        public string GetSourceTabUrl(IHtmlHelper helper, TabType LoadType)
        {
            HostingEnvironment host = new HostingEnvironment();
            string filePath = "";
            string dynamicUrl = GetDynamicUrl(helper);
            //   bool isRazorEngine = (bool)helper.ViewData["isRazorEngine"];
            if (!(dynamicUrl.Contains("/")))
                dynamicUrl = dynamicUrl + "/";
            string[] StreamSplit = dynamicUrl.Split('/');
            string RazorPath = string.Empty;
            string RazorExten = ".cshtml";
            //if (isRazorEngine)
            //{
            //    RazorPath = "Areas\\Razor\\";
            //    RazorExten = ".cshtml";
            //}


            if (StreamSplit.Length >= 1)
            {

                if (LoadType == TabType.CS)
                {
                    filePath = "Controllers" + @"\" + StreamSplit[0] + @"\" + StreamSplit[1] + "Controller.cs";
                }
                else if (LoadType == TabType.View)
                {
                    if (StreamSplit[1] == "")
                    {

                        //UrlHelper urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
                        //var routeValueDictionary = urlHelper.RequestContext.RouteData.Values;
                        //StreamSplit[1] = (string)routeValueDictionary["action"];
                    }
                    filePath = RazorPath + "Views" + @"\" + StreamSplit[0] + @"\" + StreamSplit[1] + RazorExten;
                }
                else if (LoadType == TabType.Description)
                {
                    filePath = RazorPath + "Views" + @"\" + StreamSplit[0] + @"\" + StreamSplit[1] + ".htm";
                }

            }

            return filePath;
        }

        private static string GetDynamicUrl(IHtmlHelper helper)
        {
            String DynamicUrl = string.Empty;
            HttpContextAccessor httpContextObj = new HttpContextAccessor();
            DynamicUrl = helper.ViewContext.HttpContext.Request.Path;
            if (DynamicUrl.IndexOf("/") == 0)
            {
                DynamicUrl = DynamicUrl.Substring(1, DynamicUrl.Length - 1);
            }
            return DynamicUrl.Replace("Razor", "razor").Replace("razor/", "");
        }
        private static IHostingEnvironment GetPhysicalPath(IHostingEnvironment path)
        {
            return path;
        }

        public IEnumerable<XElement> GetSourceCodeOtherFiles(IHtmlHelper helper)
        {
            string dynamicUrl = GetDynamicUrl(helper);
            //bool isRazorEngine = true;
            string[] StreamSplit = dynamicUrl.Split('/');
            string RazorPath = string.Empty;
            //if (isRazorEngine)
            //    RazorPath = "Areas/Razor/";
            var path = GetPhysicalPath(_appEnvironment);
            DirectoryInfo dir = new DirectoryInfo(_appEnvironment + RazorPath + "Views" + @"\" + StreamSplit[0]);
            FileInfo[] files = dir.GetFiles("OtherFiles.xml", SearchOption.AllDirectories);
            IEnumerable<XElement> sourceCodes = null;
            if (files.Length != 0 && files[0] != null)
            {
                XDocument doc = XDocument.Load(files[0].FullName);
                XElement rootNode = doc.Element("Category");
                sourceCodes = rootNode.Elements().Where(c => c.Attribute("url").Value.ToLower() == @"/" + dynamicUrl).Elements();
            }
            return sourceCodes;
        }

        public string GetTabContent(TabType LoadType, string Path, IHostingEnvironment physicalPath)
        {
            EJ2CoreSampleBrowser.Helpers.BrowserClasses.TagBuilder tabContent = new EJ2CoreSampleBrowser.Helpers.BrowserClasses.TagBuilder("div");
            string Filestream = "";
            CSharpFormat csformat = new CSharpFormat();
            HtmlFormat format = new HtmlFormat();
            JavaScriptFormat jsformat = new JavaScriptFormat();
            VisualBasicFormat vbformat = new VisualBasicFormat();

            switch (LoadType)
            {
                case TabType.Description:
                    Filestream = ReadTabContent(physicalPath.ContentRootPath + "\\" + Path);
                    tabContent.InnerHtml = WebUtility.HtmlDecode(Filestream);
                    break;
                case TabType.PartialView:
                    Filestream = ReadTabContent(physicalPath.ContentRootPath + "\\" + @"\Views" + Path.Replace("/", "\\"));
                    tabContent.InnerHtml = format.FormatCode(Filestream).ToString();
                    break;
                case TabType.View:
                    Filestream = ReadTabContent(physicalPath.ContentRootPath + "\\" + Path);
                    tabContent.InnerHtml = format.FormatCode(Filestream).ToString();
                    break;
                case TabType.VB:
                case TabType.CS:
                    Filestream = ReadTabContent(physicalPath.ContentRootPath + "\\" + Path);
                    tabContent.InnerHtml = csformat.FormatCode(Filestream).ToString();
                    break;
                case TabType.CSS:
                    Filestream = ReadTabContent(physicalPath.ContentRootPath + "\\" + Path);
                    tabContent.InnerHtml = format.FormatCode(Filestream).ToString();
                    break;
                case TabType.XML:
                    Filestream = ReadTabContent(@"/Models" + Path);
                    tabContent.InnerHtml = csformat.FormatCode(Filestream).ToString();
                    break;
                case TabType.JavaScript:
                    Filestream = ReadTabContent(physicalPath.ContentRootPath + "\\" + @"\Scripts" + Path.Replace("/", "\\"));
                    tabContent.InnerHtml = jsformat.FormatCode(Filestream).ToString();
                    break;
                case TabType.Model:
                    Filestream = ReadTabContent(@"/Models" + Path).ToString();
                    tabContent.InnerHtml = csformat.FormatCode(Filestream).ToString();
                    break;
                default:
                    break;
            }

            return tabContent.ToString();
        }

        //public string ReadFileContent(string path)
        //{
        //    string targetPath = VirtualPathUtility.IsAppRelative(path) ? VirtualPathUtility.ToAbsolute(path) : path;

        //    using (Stream file = VirtualPathProvider.OpenFile(targetPath))
        //    {
        //        using (StreamReader reader = new StreamReader(file))
        //        {
        //            return reader.ReadToEnd();
        //        };
        //    };
        //}

        public string ReadTabContent(string path)
        {
            string content = "";
            ReadFileStreams MyStream = new ReadFileStreams();
            List<string> Filestream = new List<string>();
            FileStream data = new FileStream(path, FileMode.Open);
            Filestream = MyStream.GetFileData(data);
            foreach (string m in (IEnumerable<string>)Filestream)
            {
                if (m != null)
                {
                    content += m.ToString();
                }
            }
            return content;
        }
    }
}
