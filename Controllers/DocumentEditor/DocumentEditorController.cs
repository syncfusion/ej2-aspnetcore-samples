using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Syncfusion.EJ2.DocumentEditor;
using Microsoft.AspNetCore.Cors;
using WDocument = Syncfusion.DocIO.DLS.WordDocument;
using WFormatType = Syncfusion.DocIO.FormatType;

namespace EJ2CoreSampleBrowser.Controllers.DocumentEditor
{
    [Route("api/[controller]")]
    public class DocumentEditorController : Controller
    {
        [AcceptVerbs("Post")]
        [HttpPost]
        [Route("Import")]
        public string Import(IFormCollection data)
        {

            Stream stream = new MemoryStream();
            string type = "docx";
            if (data.Files.Count == 0)
                return null;
            IFormFile file = data.Files[0];
            int index = file.FileName.LastIndexOf('.');
            type = index > -1 && index < file.FileName.Length - 1 ? file.FileName.Substring(index + 1) : "";
            file.CopyTo(stream);
            stream.Position = 0;

            WordDocument document = WordDocument.Load(stream, GetFormatType(type.ToLower()));
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(document);
            document.Dispose();
            return json;
        }
        internal static FormatType GetFormatType(string format)
        {
            if (string.IsNullOrEmpty(format))
                throw new NotSupportedException("EJ2 Document editor does not support this file format.");
            switch (format.ToLower())
            {
                case "dotx":
                case "docx":
                case "docm":
                case "dotm":
                    return FormatType.Docx;
                case "dot":
                case "doc":
                    return FormatType.Doc;
                case "rtf":
                    return FormatType.Rtf;
                case "txt":
                    return FormatType.Txt;
                case "xml":
                    return FormatType.WordML;
                default:
                    throw new NotSupportedException("EJ2 Document editor does not support this file format.");
            }
        }

        internal WDocument GetDocument(IFormCollection data)
        {
            Stream stream = new MemoryStream();
            if (data.Files.Count == 0)
                return null;
            IFormFile file = data.Files[0];

            file.CopyTo(stream);
            stream.Position = 0;

            WDocument document = new WDocument(stream, WFormatType.Docx);
            stream.Dispose();
            return document;
        }
    }
}