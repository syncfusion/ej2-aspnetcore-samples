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

namespace EJ2MVCSampleBrowser.Controllers
{
    public partial class RichTextEditorController : Controller
    {
        public ActionResult ImportWord()
        {
            ViewBag.rteValue = "<h2 style=\"text-align: center;\">Invitation to Microsoft Webinar Meet-Up</h2><p> Dear Guest, </p><p> We're thrilled to extend a special invitation to you for an exclusive Microsoft webinar meet-up, where we'll explore the latest innovations and insights driving the future of technology. As a valued member of our community, we believe this event will offer invaluable knowledge and networking opportunities. </p><h2>Event Details:</h2><table class=\"e-rte-table\" style=\"width: 100%; height: 125px;\"> <tbody> <tr style=\"height: 20%;\"> <th class=\"\">Time:</th> <td>10:00 AM - 12:00 PM</td> </tr> <tr style=\"height: 20%;\"> <th>Duration:</th> <td>2 hours</td> </tr> <tr style=\"height: 20%;\"> <th>Platform:</th> <td>Microsoft Teams</td> </tr> </tbody></table><p><br></p><h2>Agenda:</h2><ul> <li>Introduction to Cutting-Edge Microsoft Technologies</li> <li>Deep Dive into AI in Business: Leveraging Microsoft Azure Solutions</li> <li>Live Q&amp;A Session with Industry Experts</li> <li>Networking Opportunities with Peers and Professionals</li> </ul><h2>Why Attend?</h2><ul> <li>Gain insights into the latest trends and advancements in technology.</li> <li>Interact with industry experts and expand your professional network.</li> <li>Get your questions answered in real-time during the live Q&amp;A session.</li> <li>Access exclusive resources and offers available only to webinar attendees.</li> </ul><p> Feel free to invite your colleagues and peers who might benefit from this enriching experience. Simply forward this email to them or share the event details. </p><p> We're looking forward to your participation and to exploring the exciting world of Microsoft technology together. Should you have any questions or require further information, please don't hesitate to contact us at <a href=\"mailto:webinar@company.com\">webinar@company.com</a>.</p><p> <br></p><p>Warm regards,</p><p>John Doe<br>Event Coordinator<br>ABC Company</p>";
            ViewBag.tools = new object[]  {"Undo","Redo","|",
            new {
                tooltipText= "Import from Word",
                template="<button class='e-tbar-btn e-control e-btn e-lib e-icon-btn' tabindex='-1' id='custom_tbarbtn_1' style='width:100%'><span class='e-rte-import-doc e-btn-icon e-icons'></span></button>"
            },
            "Bold", "Italic", "Underline", "StrikeThrough", "|",
            "FontName", "FontSize", "FontColor", "BackgroundColor", "|",
            "Formats", "Alignments","blockquote", "|", "NumberFormatList", "BulletFormatList", "|", "CreateLink", "Image", "CreateTable", "|", "ClearFormat", "SourceCode"
            };
            string hostUrl = "https://services.syncfusion.com/aspnet/production/";
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