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
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class PdfDocumentList
    {
        public PdfDocumentList()
        {

        }
        public PdfDocumentList(string FileName, string File, string author)
        {
            this.FileName = FileName;
            this.File = File;
            this.Author = author;
        }
        public static List<PdfDocumentList> GetAllRecords()
        {
            List<PdfDocumentList> fileData = new List<PdfDocumentList>();

            fileData.Add(new PdfDocumentList("Pdf Succinctly.pdf", "https://cdn.syncfusion.com/content/pdf/pdf-succinctly.pdf", "Ryan Hodson"));
            fileData.Add(new PdfDocumentList("Hive Succinctly.pdf", "https://cdn.syncfusion.com/content/pdf/hive-succinctly.pdf", "Elton Stoneman"));
            fileData.Add(new PdfDocumentList("GIS Succinctly.pdf", "https://cdn.syncfusion.com/content/pdf/gis-succinctly.pdf", "Peter Shaw"));
            fileData.Add(new PdfDocumentList("JavaScript Succinctly.pdf", "https://cdn.syncfusion.com/content/pdf/Javascript-succinctly.pdf", "Cody Lindley"));
            fileData.Add(new PdfDocumentList("HTTP Succinctly.pdf", "https://cdn.syncfusion.com/content/pdf/http-succinctly.pdf", "Scott Allen"));

            return fileData;
        }
        public string FileName { get; set; }
        public string File { get; set; }
        public string Author { get; set; }
    }
}
