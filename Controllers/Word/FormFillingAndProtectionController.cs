#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Microsoft.AspNetCore.Mvc;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.Drawing;
using System;
using System.IO;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.Word
{
    public partial class WordController : Controller
    {	
        public IActionResult FormFillingAndProtection(string Button)
        {
            if (Button == null)
                return View();
            string basePath = _hostingEnvironment.WebRootPath;
            string dataPath = basePath + @"/Word/ContentControlTemplate.docx";
            string contenttype1 = "application/vnd.ms-word.document.12";
            // Load Template document stream.
            FileStream fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            if (Button == "View Template")
            {
                return File(fileStream, contenttype1, "ContentControlTemplate.docx");
            }           
            // Creates an empty Word document instance.          
            WordDocument document = new WordDocument();
            // Opens template document.
            document.Open(fileStream, FormatType.Docx);
            fileStream.Dispose();
            fileStream = null;
            WTextRange textRange;
            #region Fill data and lock the contents of content control

            #region Drop down list content control
            //Find the drop down list content control with title "Status".
            IInlineContentControl inlineControl = document.FindItemByProperty(EntityType.InlineContentControl,
                "ContentControlProperties.Title", "Status") as IInlineContentControl;
            inlineControl.ContentControlProperties.LockContents = true;
            //Sets default option to display.
            textRange = inlineControl.ParagraphItems[0] as WTextRange;
            textRange.Text = "In-Progress";
            ApplyCharacterFormat(textRange);
            inlineControl.ParagraphItems.Add(textRange);

            //Adds items to the dropdown list.
            ContentControlListItem item;
            item = new ContentControlListItem();
            item.DisplayText = "Testing";
            item.Value = "2";
            inlineControl.ContentControlProperties.ContentControlListItems.Add(item);

            item = new ContentControlListItem();
            item.DisplayText = "Review";
            item.Value = "3";
            inlineControl.ContentControlProperties.ContentControlListItems.Add(item);

            item = new ContentControlListItem();
            item.DisplayText = "Completed";
            item.Value = "4";
            inlineControl.ContentControlProperties.ContentControlListItems.Add(item);
            #endregion


            #region Calendar content control
            //Find the first date picker content control with tag "Date".
            inlineControl = document.FindItemByProperties(EntityType.InlineContentControl,
               new string[2] { "ContentControlProperties.Type", "ContentControlProperties.Tag" },
               new string[2] { "Date", "Date" }) as IInlineContentControl;
            textRange = inlineControl.ParagraphItems[0] as WTextRange;
            //Sets today's date to display.
            textRange.Text = DateTime.Now.ToShortDateString();
            ApplyCharacterFormat(textRange);
            //Protects the content control.
            inlineControl.ContentControlProperties.LockContents = true;

            //Find the inline content control with title "StartDate".
            inlineControl = document.FindItemByProperty(EntityType.InlineContentControl,
               "ContentControlProperties.Title", "StartDate") as IInlineContentControl;
            inlineControl.ContentControlProperties.LockContents = true;
            //Sets default date to display.
            textRange = inlineControl.ParagraphItems[0] as WTextRange;
            textRange.Text = DateTime.Now.AddDays(-6).ToShortDateString();
            ApplyCharacterFormat(textRange);

            //Find the inline content control with title "EndDate".
            inlineControl = document.FindItemByProperty(EntityType.InlineContentControl,
               "ContentControlProperties.Title", "EndDate") as IInlineContentControl;
            inlineControl.ContentControlProperties.LockContents = true;
            //Sets default date to display.
            textRange = inlineControl.ParagraphItems[0] as WTextRange;
            textRange.Text = DateTime.Now.AddDays(-1).ToShortDateString();
            ApplyCharacterFormat(textRange);
            #endregion

            #region Plain text content controls
            //Find the plain text content control with title "ProjectName".
            inlineControl = document.FindItemByProperty(EntityType.InlineContentControl,
                "ContentControlProperties.Title", "ProjectName") as IInlineContentControl;
            //Protects the content control.
            inlineControl.ContentControlProperties.LockContents = true;
            textRange = inlineControl.ParagraphItems[0] as WTextRange;
            //Sets text in plain text content control.
            textRange.Text = "Website for Adventure works cycle";
            ApplyCharacterFormat(textRange);


            //Find the plain text content control with title "ProjectManager".
            inlineControl = document.FindItemByProperty(EntityType.InlineContentControl,
                "ContentControlProperties.Title", "ProjectManager") as IInlineContentControl;
            //Protects the content control.
            inlineControl.ContentControlProperties.LockContents = true;
            //Sets text in plain text content control.
            textRange = inlineControl.ParagraphItems[0] as WTextRange;
            textRange.Text = "Nancy Davolio";
            ApplyCharacterFormat(textRange);

            //Find the plain text content control with title "TeamSize".
            inlineControl = document.FindItemByProperty(EntityType.InlineContentControl,
                "ContentControlProperties.Title", "TeamSize") as IInlineContentControl;
            //Protects the content control.
            inlineControl.ContentControlProperties.LockContents = true;
            //Sets text in plain text content control.
            textRange = inlineControl.ParagraphItems[0] as WTextRange;
            textRange.Text = "10";
            ApplyCharacterFormat(textRange);


            //Find the plain text content control with title "TeamName".
            inlineControl = document.FindItemByProperty(EntityType.InlineContentControl,
                "ContentControlProperties.Title", "TeamName") as IInlineContentControl;
            //Protects the content control.
            inlineControl.ContentControlProperties.LockContents = true;
            textRange = inlineControl.ParagraphItems[0] as WTextRange;
            //Sets text in plain text content control.
            textRange.Text = "Adventure Works Cycle";
            ApplyCharacterFormat(textRange);

            //Find the plain text content control with title "ProjectVision".
            inlineControl = document.FindItemByProperty(EntityType.InlineContentControl,
                "ContentControlProperties.Title", "ProjectVision") as IInlineContentControl;
            //Protects the content control.
            inlineControl.ContentControlProperties.LockContents = true;
            textRange = inlineControl.ParagraphItems[0] as WTextRange;
            //Sets text in rich text content control.
            textRange.Text = "Launch a website on " + DateTime.Now.AddDays(50).ToShortDateString() + " that allows customers to purchase products online " +
                "and reflects Adventure Works Cycle having the highest quality and the best products in its category.";
            ApplyCharacterFormat(textRange);

            //Find the plain text content control with title "Issues".
            inlineControl = document.FindItemByProperty(EntityType.InlineContentControl,
                "ContentControlProperties.Title", "Issues") as IInlineContentControl;
            textRange = inlineControl.ParagraphItems[0] as WTextRange;
            //Sets text in rich text content control.
            textRange.Text = "By the end of next month, if we do not have a finalized product image, we will not be able to meet our deployment deadline.";
            ApplyCharacterFormat(textRange);
            //Protects the content control.
            inlineControl.ContentControlProperties.LockContents = true;

            //Find the plain text content control with title "MilestoneAccomplished"
            inlineControl = document.FindItemByProperty(EntityType.InlineContentControl,
                "ContentControlProperties.Title", "MilestoneAccomplished") as IInlineContentControl;
            //Clear the existing content in content control
            inlineControl.ParagraphItems.Clear();
            //Add first milestone as WTextRange
            textRange = new WTextRange(document);
            inlineControl.ParagraphItems.Add(textRange);
            inlineControl.ContentControlProperties.Multiline = true;
            //Sets text in rich text content control.
            textRange.Text = "Framed the basic structure of website.";
            ApplyCharacterFormat(textRange);
            //Add line break
            Break br = new Break(document, BreakType.LineBreak);
            inlineControl.ParagraphItems.Add(br);
            //Add next milestone as WTextRange
            textRange = new WTextRange(document);
            inlineControl.ParagraphItems.Add(textRange);
            textRange.Text = " Applied for design review.";
            ApplyCharacterFormat(textRange);
            //Protects the content control.
            inlineControl.ContentControlProperties.LockContents = true;

            //Find the plain text content control with title "NextWeekMilestones"
            inlineControl = document.FindItemByProperty(EntityType.InlineContentControl,
                "ContentControlProperties.Title", "NextWeekMilestones") as IInlineContentControl;
            //Clear the existing content in content control
            inlineControl.ParagraphItems.Clear();
            //Add first milestone as WTextRange
            textRange = new WTextRange(document);
            inlineControl.ParagraphItems.Add(textRange);
            inlineControl.ContentControlProperties.Multiline = true;
            //Sets text in rich text content control.
            textRange.Text = "Prepare design files for development.";
            ApplyCharacterFormat(textRange);
            //Add line break
            br = new Break(document, BreakType.LineBreak);
            inlineControl.ParagraphItems.Add(br);
            //Add next milestone as WTextRange
            textRange = new WTextRange(document);
            inlineControl.ParagraphItems.Add(textRange);
            textRange.Text = " Start development - Sprint 1 (Homepage & Product Detail Page).";
            ApplyCharacterFormat(textRange);
            //Protects the content control.
            inlineControl.ContentControlProperties.LockContents = true;

            //Find the plain text content control with title "UpcomingMilestones"
            inlineControl = document.FindItemByProperty(EntityType.InlineContentControl,
                "ContentControlProperties.Title", "UpcomingMilestones") as IInlineContentControl;
            //Clear the existing content in content control
            inlineControl.ParagraphItems.Clear();
            //Add first milestone as WTextRange
            textRange = new WTextRange(document);
            inlineControl.ParagraphItems.Add(textRange);
            //Enable multiline in content control
            inlineControl.ContentControlProperties.Multiline = true;
            //Sets text in rich text content control.
            textRange.Text = DateTime.Now.AddDays(15).ToShortDateString() + " : Design Approval";
            ApplyCharacterFormat(textRange);
            //Add line break
            br = new Break(document, BreakType.LineBreak);
            inlineControl.ParagraphItems.Add(br);
            //Add next milestone as WTextRange
            textRange = new WTextRange(document);
            inlineControl.ParagraphItems.Add(textRange);
            textRange.Text = " " + DateTime.Now.AddDays(30).ToShortDateString() + " : Development Begins";
            ApplyCharacterFormat(textRange);
            //Add line break
            br = new Break(document, BreakType.LineBreak);
            inlineControl.ParagraphItems.Add(br);
            //Add next milestone as WTextRange
            textRange = new WTextRange(document);
            inlineControl.ParagraphItems.Add(textRange);
            textRange.Text = " " + DateTime.Now.AddDays(45).ToShortDateString() + " : Deployment";
            ApplyCharacterFormat(textRange);
            //Protects the content control.
            inlineControl.ContentControlProperties.LockContents = true;
            #endregion

            #region CheckBox Content control
            //Find checkbox content control with tag "C#".
            inlineControl = document.FindItemByProperties(EntityType.InlineContentControl,
                new string[2] { "ContentControlProperties.Type", "ContentControlProperties.Tag" },
                new string[2] { "CheckBox", "C#" }) as InlineContentControl;
            inlineControl.ContentControlProperties.LockContents = true;
            //Sets checkbox as checked state.
            inlineControl.ContentControlProperties.IsChecked = true;
            #endregion

            #region Drop down list content control
            //Find the drop down list content control with title "Platform".
            inlineControl = document.FindItemByProperty(EntityType.InlineContentControl,
                "ContentControlProperties.Title", "Platform") as IInlineContentControl;
            inlineControl.ContentControlProperties.LockContents = true;
            //Sets default option to display.
            textRange = inlineControl.ParagraphItems[0] as WTextRange;
            textRange.Text = "ASP.NET";
            ApplyCharacterFormat(textRange);
            inlineControl.ParagraphItems.Add(textRange);

            //Adds items to the dropdown list.
            item = new ContentControlListItem();
            item.DisplayText = "ASP.NET MVC";
            item.Value = "2";
            inlineControl.ContentControlProperties.ContentControlListItems.Add(item);

            item = new ContentControlListItem();
            item.DisplayText = "ASP.NET Core";
            item.Value = "3";
            inlineControl.ContentControlProperties.ContentControlListItems.Add(item);

            item = new ContentControlListItem();
            item.DisplayText = "Blazor";
            item.Value = "4";
            inlineControl.ContentControlProperties.ContentControlListItems.Add(item);
            #endregion
            
            #region Block content control
            //Find all the block content controls which having title "Description".
            List<Entity> blockContentControls = document.FindAllItemsByProperty(EntityType.BlockContentControl,
                "ContentControlProperties.Title", "ContactInformation");
            //Access the first block content control.
            BlockContentControl blockContentControl = blockContentControls[0] as BlockContentControl;
            //Protects the block content control
            blockContentControl.ContentControlProperties.LockContents = true;
            #endregion
            #endregion

            FormatType type = FormatType.Docx;
            string filename = "FormFillingAndProtection.docx";
            string contenttype = "application/vnd.ms-word.document.12";
            
            MemoryStream ms = new MemoryStream();
            document.Save(ms, type);
            document.Close();
            ms.Position = 0;
            return File(ms, contenttype, filename);
        }
        /// <summary>
        /// Apply character format for text range
        /// </summary>
        private void ApplyCharacterFormat(WTextRange textRange)
        {
            textRange.CharacterFormat.FontName = "Century Gothic";
            textRange.CharacterFormat.FontSize = 12;
            textRange.CharacterFormat.TextColor = Color.Black;
        }
    }
}
