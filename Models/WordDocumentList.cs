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
    public class WordDocumentList
    {
        public WordDocumentList()
        {

        }
        public WordDocumentList(string FileName, string author)
        {
            this.FileName = FileName;
            this.Author = author;
        }
        public static List<WordDocumentList> GetAllRecords()
        {
            List<WordDocumentList> fileData = new List<WordDocumentList>();

            fileData.Add(new WordDocumentList("Getting Started.docx", "Ryan Hodson"));
            fileData.Add(new WordDocumentList("Character Formatting.docx", "Elton Stoneman"));
            fileData.Add(new WordDocumentList("Paragraph Formatting.docx", "Peter Shaw"));
            fileData.Add(new WordDocumentList("Styles.docx", "Cody Lindley"));
            fileData.Add(new WordDocumentList("Web layout.docx", "Scott Allen"));

            return fileData;
        }
        public string FileName { get; set; }
        public string Author { get; set; }
    }
}
