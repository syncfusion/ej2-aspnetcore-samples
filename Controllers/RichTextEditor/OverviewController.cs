#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class RichtextEditorController : Controller
    {
        public IActionResult Overview()
        {
            string hostUrl = "https://services.syncfusion.com/aspnet/production/";
            ViewBag.rteValue = "<h1>Welcome to the Syncfusion Rich Text Editor</h1><p>The Rich Text Editor, a WYSIWYG (what you see is what you get) editor, is a user interface that allows you to create, edit, and format rich text content. You can try out a demo of this editor here.</p><h2>Do you know the key features of the editor?</h2><ul> <li>Basic features include headings, block quotes, numbered lists, bullet lists, and support to insert images, tables, audio, and video.</li> <li>Inline styles include <b>bold</b>, <em>italic</em>, <span style=\"text-decoration: underline\">underline</span>, <span style=\"text-decoration: line-through\">strikethrough</span>, <a class=\"e-rte-anchor\" href=\"https://ej2.syncfusion.com/aspnetcore/richtexteditor/overview#/material3\" title=\"https://ej2aspnetmvc.azurewebsites.net/aspnetmvc/richtexteditor/overview#/material3\">hyperlinks</a>, 😀 and more.</li> <li>The toolbar has multi-row, expandable, and scrollable modes. The Editor supports an inline toolbar, a floating toolbar, and custom toolbar items.</li> <li>Integration with Syncfusion Mention control lets users tag other users. To learn more, check out the <a class=\"e-rte-anchor\" href=\"https://ej2.syncfusion.com/aspnetcore/documentation/rich-text-editor/mention-integration\" title=\"Mention Documentation\">documentation</a> and <a class=\"e-rte-anchor\" href=\"https://ej2.syncfusion.com/aspnetcore/richtexteditor/mentionintegration#/material3\" title=\"Mention Demos\">demos</a>.</li> <li><b>Paste from MS Word</b> - helps to reduce the effort while converting the Microsoft Word content to HTML format with format and styles. To learn more, check out the documentation <a class=\"e-rte-anchor\" href=\"https://ej2.syncfusion.com/aspnetcore/documentation/rich-text-editor/paste-cleanup\" title=\"Paste from MS Word Documentation\">here</a>.</li> <li>Other features: placeholder text, character count, form validation, enter key configuration, resizable editor, IFrame rendering, tooltip, source code view, RTL mode, persistence, HTML Sanitizer, autosave, and <a class=\"e-rte-anchor\" href=\"https://help.syncfusion.com/cr/aspnetcore-js2/syncfusion.ej2.richtexteditor.richtexteditor.html\" title=\"Rich Text Editor API\">more</a>.</li></ul><blockquote><p><em>Easily access Audio, Image, Link, Video, and Table operations through the quick toolbar by right-clicking on the corresponding element with your mouse.</em></p></blockquote><h2>Unlock the Power of Tables</h2><p>A table can be created in the editor using either a keyboard shortcut or the toolbar. With the quick toolbar, you can perform table cell insert, delete, split, and merge operations. You can style the table cells using background colours and borders.</p><table class=\"e-rte-table\" style=\"width: 100%; min-width: 0px; height: 151px\"> <thead style=\"height: 16.5563%\"> <tr style=\"height: 16.5563%\"> <th style=\"width: 12.1813%\"><span>S No</span><br></th> <th style=\"width: 23.2295%\"><span>Name</span><br></th> <th style=\"width: 9.91501%\"><span>Age</span><br></th> <th style=\"width: 15.5807%\"><span>Gender</span><br></th> <th style=\"width: 17.9887%\"><span>Occupation</span><br></th> <th style=\"width: 21.1048%\">Mode of Transport</th> </tr> </thead> <tbody> <tr style=\"height: 16.5563%\"> <td style=\"width: 12.1813%\">1</td> <td style=\"width: 23.2295%\">Selma Rose</td> <td style=\"width: 9.91501%\">30</td> <td style=\"width: 15.5807%\">Female</td> <td style=\"width: 17.9887%\"><span>Engineer</span><br></td> <td style=\"width: 21.1048%\"><span style=\"font-size: 14pt\">🚴</span></td> </tr> <tr style=\"height: 16.5563%\"> <td style=\"width: 12.1813%\">2</td> <td style=\"width: 23.2295%\"><span>Robert</span><br></td> <td style=\"width: 9.91501%\">28</td> <td style=\"width: 15.5807%\">Male</td> <td style=\"width: 17.9887%\"><span>Graphic Designer</span></td> <td style=\"width: 21.1048%\"><span style=\"font-size: 14pt\">🚗</span></td> </tr> <tr style=\"height: 16.5563%\"> <td style=\"width: 12.1813%\">3</td> <td style=\"width: 23.2295%\"><span>William</span><br></td> <td style=\"width: 9.91501%\">35</td> <td style=\"width: 15.5807%\">Male</td> <td style=\"width: 17.9887%\">Teacher</td> <td style=\"width: 21.1048%\"><span style=\"font-size: 14pt\">🚗</span></td> </tr> <tr style=\"height: 16.5563%\"> <td style=\"width: 12.1813%\">4</td> <td style=\"width: 23.2295%\"><span>Laura Grace</span><br></td> <td style=\"width: 9.91501%\">42</td> <td style=\"width: 15.5807%\">Female</td> <td style=\"width: 17.9887%\">Doctor</td> <td style=\"width: 21.1048%\"><span style=\"font-size: 14pt\">🚌</span></td> </tr> <tr style=\"height: 16.5563%\"> <td style=\"width: 12.1813%\">5</td><td style=\"width: 23.2295%\"><span>Andrew James</span><br></td><td style=\"width: 9.91501%\">45</td><td style=\"width: 15.5807%\">Male</td><td style=\"width: 17.9887%\">Lawyer</td><td style=\"width: 21.1048%\"><span style=\"font-size: 14pt\">🚕</span></td></tr></tbody></table><h2>Elevating Your Content with Images</h2><p>Images can be added to the editor by pasting or dragging into the editing area, using the toolbar to insert one as a URL, or uploading directly from the File Browser. Easily manage your images on the server by configuring the <a class=\"e-rte-anchor\" href=\"https://ej2.syncfusion.com/aspnetcore/documentation/rich-text-editor/image\" title=\"Insert Image Settings API\">insertImageSettings</a> to upload, save, or remove them. </p><p>The Editor can integrate with the Syncfusion Image Editor to crop, rotate, annotate, and apply filters to images. Check out the demos <a class=\"e-rte-anchor\" href=\"https://ej2.syncfusion.com/aspnetcore/richtexteditor/imageeditorintegration#/material3\" title=\"Image Editor Demo\">here</a>.</p><p><img alt=\"Sky with sun\" src=\"https://cdn.syncfusion.com/ej2/richtexteditor-resources/RTE-Overview.png\" style=\"width: 440px\" class=\"e-rte-image e-imginline\"></p>";
            ViewBag.ajaxSettings = new {
                url = "https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations",
                getImageUrl = "https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage",
                uploadUrl = "https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload",
                downloadUrl = "https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
            };
            ViewBag.tools = new object[]  {
            "Undo","Redo", "|", 
            new {
                tooltipText= "Import from Word",
                template="<button class='e-tbar-btn e-control e-btn e-lib e-icon-btn' tabindex='-1' id='custom_tbarbtn_1' style='width:100%'><span class='e-rte-import-doc e-btn-icon e-icons'></span></button>"
            }, 
            new {
                tooltipText = "Export to Word",
                template= "<button class='e-tbar-btn e-control e-btn e-lib e-icon-btn' tabindex='-1' id='custom_tbarbtn_2' style='width:100%'><span class='e-rte-export-doc e-btn-icon e-icons'></span></button>"
            }, 
            new {
                tooltipText= "Export to PDF",
                template= "<button class='e-tbar-btn e-control e-btn e-lib e-icon-btn' tabindex='-1' id='custom_tbarbtn_3' style='width:100%'><span class='e-rte-export-pdf e-btn-icon e-icons'></span></button>",
            },
            "Bold", "Italic", "Underline", "StrikeThrough", "|",
            "FontName", "FontSize", "FontColor", "BackgroundColor", "|",
            "Formats", "Alignments","blockquote", "|", "NumberFormatList", "BulletFormatList", "|", "CreateLink", "Image", "CreateTable", "|", "ClearFormat", "SourceCode"
            };
            ViewBag.saveUrl = hostUrl + "api/RichTextEditor/SaveFile";
            ViewBag.removeUrl = hostUrl + "api/RichTextEditor/DeleteFile";
            ViewBag.path = hostUrl + "RichTextEditor/";
            ViewBag.mentionData = new EditorMentionUser().GetUserData();
            ViewBag.table = new[] {
                "TableHeader", "TableRows", "TableColumns", "TableCell", "-", "BackgroundColor", "TableRemove", "TableCellVerticalAlign", "Styles"
            };
            ViewBag.UploaderAjaxSettings = new Syncfusion.EJ2.Inputs.UploaderAsyncSettings { SaveUrl = hostUrl + "api/RichTextEditor/ImportFromWord" };
            Dictionary<string, object> HtmlAttribute = new Dictionary<string, object>()
            {
                { "name", "UploadFiles" },
                { "style", "display:none" }
            };
            ViewBag.HtmlAttribute = HtmlAttribute;
            return View();
        }
    }
}