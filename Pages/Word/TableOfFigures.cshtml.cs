#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.DocIORenderer;

namespace EJ2CoreSampleBrowser.Pages.Word;

public class TableOfFigures : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;

    public TableOfFigures(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public ActionResult OnPost(string Group1, string Button, string ExcludeLabelsAndNumbers)
    {
        if (Group1 == null)
            return null;
            // return View();
        string basePath = _hostingEnvironment.WebRootPath;
        string dataPath = basePath + @"/Word/TableOfFiguresInput.docx";
        string contenttype1 = "application/vnd.ms-word.document.12";
        FileStream fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        if (Button == "View Template")
        {
            return File(fileStream, contenttype1, "TableOfFiguresInput.docx");
        }

        try
        {
            //Open an existing word document.
            using (WordDocument document = new WordDocument(fileStream, FormatType.Docx))
            {
                fileStream.Dispose();
                fileStream = null;

                #region Add Table of Figures

                //Create a new paragraph.
                WParagraph paragraph = new WParagraph(document);
                paragraph.AppendText("List of Figures");
                //Apply Heading1 style for paragraph.
                paragraph.ApplyStyle(BuiltinStyle.Heading1);
                //Insert the paragraph.
                document.LastSection.Body.ChildEntities.Insert(0, paragraph);

                //Create new paragraph and append TOC.
                paragraph = new WParagraph(document);
                TableOfContent tableOfContent = paragraph.AppendTOC(1, 3);
                //Disable a flag to exclude heading style paragraphs in TOC entries.
                tableOfContent.UseHeadingStyles = false;
                //Set the name of SEQ field identifier for table of figures.
                tableOfContent.TableOfFiguresLabel = "Figure";
                if (ExcludeLabelsAndNumbers == "ExcludeLabelsAndNumbers")
                    //Disable the flag, to exclude caption's label and number in TOC entries.
                    tableOfContent.IncludeCaptionLabelsAndNumbers = false;

                //Insert the paragraph to the text body.
                document.LastSection.Body.ChildEntities.Insert(1, paragraph);

                #endregion

                #region Add caption for pictures

                //Find all pictures from the document.
                List<Entity> pictures = document.FindAllItemsByProperty(EntityType.Picture, null, null);
                // Iterate each picture and add caption.
                foreach (WPicture picture in pictures)
                {
                    //Set alternate text as caption for picture.
                    WParagraph captionPara =
                        picture.AddCaption("Figure", CaptionNumberingFormat.Number, CaptionPosition.AfterImage) as
                            WParagraph;
                    captionPara.AppendText(" " + picture.AlternativeText);
                    //Apply formatting to the caption.
                    captionPara.ApplyStyle(BuiltinStyle.Caption);
                    captionPara.ParagraphFormat.BeforeSpacing = 8;
                    captionPara.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
                }

                #endregion


                #region Add Table of Tables

                // Create a new paragraph.
                paragraph = new WParagraph(document);
                paragraph.AppendText("List of Tables");
                // Apply Heading1 style for paragraph.
                paragraph.ApplyStyle(BuiltinStyle.Heading1);
                // Insert the paragraph.
                document.LastSection.Body.ChildEntities.Insert(2, paragraph);

                //Create a new paragraph and append TOC.
                paragraph = new WParagraph(document);
                tableOfContent = paragraph.AppendTOC(1, 3);
                //Disable a flag to exclude heading style paragraphs in TOC entries.
                tableOfContent.UseHeadingStyles = false;
                //Set the name of SEQ field identifier for table of tables.
                tableOfContent.TableOfFiguresLabel = "Table";
                if (ExcludeLabelsAndNumbers == "ExcludeLabelsAndNumbers")
                    //Disable the flag, to exclude caption's label and number in TOC entries.
                    tableOfContent.IncludeCaptionLabelsAndNumbers = false;
                // Insert the paragraph to the text body.
                document.LastSection.Body.ChildEntities.Insert(3, paragraph);

                #endregion

                #region Add caption for tables

                // Find all tables from the document.
                List<Entity> tables = document.FindAllItemsByProperty(EntityType.Table, null, null);
                //Iterate each table and add caption.
                foreach (WTable table in tables)
                {
                    //Gets the table index.
                    int tableIndex = table.OwnerTextBody.ChildEntities.IndexOf(table);
                    //Create a new paragraph and appends the sequence field to use as a caption.
                    WParagraph captionPara = new WParagraph(document);
                    captionPara.AppendText("Table ");
                    captionPara.AppendField("Table", FieldType.FieldSequence);
                    //Set alternate text as caption for table.
                    captionPara.AppendText(" " + table.Description);
                    // Apply formatting to the paragraph.
                    captionPara.ApplyStyle(BuiltinStyle.Caption);
                    captionPara.ParagraphFormat.BeforeSpacing = 8;
                    captionPara.ParagraphFormat.HorizontalAlignment = HorizontalAlignment.Center;
                    //Insert the paragraph next to the table.
                    table.OwnerTextBody.ChildEntities.Insert(tableIndex + 1, captionPara);
                }

                #endregion

                #region Update

                //Update all document fields to update SEQ fields.
                document.UpdateDocumentFields();
                //Update the table of contents.
                document.UpdateTableOfContents();

                #endregion

                #region Document SaveOption

                string filename = "";
                string contenttype = "";
                MemoryStream ms = new MemoryStream();
                //Save as .docx format.
                if (Group1 == "WordDocx")
                {
                    filename = "TableOfFigures.docx";
                    contenttype = "application/vnd.ms-word.document.12";
                    document.Save(ms, FormatType.Docx);
                }
                // Save as .doc format.
                else if (Group1 == "WordDoc")
                {
                    filename = "TableOfFigures.doc";
                    contenttype = "application/msword";
                    document.Save(ms, FormatType.Doc);
                }
                //Save as .xml format.
                else if (Group1 == "WordML")
                {
                    filename = "TableOfFigures.xml";
                    contenttype = "application/msword";
                    document.Save(ms, FormatType.WordML);
                }
                //Save as .pdf format.
                else if (Group1 == "Pdf")
                {
                    filename = "TableOfFigures.pdf";
                    contenttype = "application/pdf";
                    Syncfusion.DocIORenderer.DocIORenderer renderer = new Syncfusion.DocIORenderer.DocIORenderer();
                    Syncfusion.Pdf.PdfDocument pdfDoc = renderer.ConvertToPDF(document);
                    pdfDoc.Save(ms);
                    pdfDoc.Close();
                    renderer.Dispose();
                }

                #endregion Document SaveOption

                ms.Position = 0;
                return File(ms, contenttype, filename);
            }
        }
        catch (Exception)
        {
            var Message =
                string.Format(
                    "The input document could not be processed completely, Could you please email the document to support@syncfusion.com for troubleshooting.");
        }

        return null;
        // return View();
    }
}