#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.Office;
using Syncfusion.Drawing;

namespace EJ2CoreSampleBrowser.Pages.Word;

public class EditSmartArt : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public EditSmartArt(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public IActionResult OnPost(string Button)
    {
        if (Button == null)
            return null;
            // return View();
        string basePath = _hostingEnvironment.WebRootPath;
        string dataPath = basePath + @"/Word/EditSmartArtInput.docx";
        string contenttype = "application/vnd.ms-word.document.12";
        //Loads Template document stream.
        FileStream fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        if (Button == "View Template")
            return File(fileStream, contenttype, "EditSmartArtInput.docx");

        //Loads file stream into Word document.
        WordDocument document = new WordDocument(fileStream, FormatType.Docx);
        fileStream.Dispose();
        fileStream = null;
        //Gets the last paragraph in the document.
        WParagraph paragraph = document.LastParagraph;
        //Retrieves the SmartArt object from the paragraph.
        WSmartArt smartArt = paragraph.ChildEntities[0] as WSmartArt;
        //Sets the background fill type of the SmartArt to solid.
        smartArt.Background.FillType = OfficeShapeFillType.Solid;
        //Sets the background color of the SmartArt.
        smartArt.Background.SolidFill.Color = Color.FromArgb(255, 242, 169, 132);
        //Gets the first node of the SmartArt.
        IOfficeSmartArtNode node = smartArt.Nodes[0];
        //Modifies the text content of the first node.
        node.TextBody.Text = "Goals";
        //Retrieves the first shape of the node.
        IOfficeSmartArtShape shape = node.Shapes[0];
        //Sets the fill color of the shape.
        shape.Fill.SolidFill.Color = Color.FromArgb(255, 160, 43, 147);
        //Sets the line format color of the shape.
        shape.LineFormat.Fill.SolidFill.Color = Color.FromArgb(255, 160, 43, 147);
        //Gets the first child node of the current node.
        IOfficeSmartArtNode childNode = node.ChildNodes[0];
        //Modifies the text content of the child node.
        childNode.TextBody.Text = "Set clear goals to the team.";
        //Sets the line format color of the first shape in the child node.
        childNode.Shapes[0].LineFormat.Fill.SolidFill.Color = Color.FromArgb(255, 160, 43, 147);

        //Retrieves the second node in the SmartArt and updates its text content.
        node = smartArt.Nodes[1];
        node.TextBody.Text = "Progress";

        //Retrieves the third node in the SmartArt and updates its text content.
        node = smartArt.Nodes[2];
        node.TextBody.Text = "Result";
        //Retrieves the first shape of the third node.
        shape = node.Shapes[0];
        //Sets the fill color of the shape.
        shape.Fill.SolidFill.Color = Color.FromArgb(255, 78, 167, 46);
        //Sets the line format color of the shape.
        shape.LineFormat.Fill.SolidFill.Color = Color.FromArgb(255, 78, 167, 46);
        //Sets the line format color of the first shape in the child node.
        node.ChildNodes[0].Shapes[0].LineFormat.Fill.SolidFill.Color = Color.FromArgb(255, 78, 167, 46);

        string filename = "EditSmartArt.docx";
        MemoryStream ms = new MemoryStream();
        document.Save(ms, FormatType.Docx);
        document.Close();
        ms.Position = 0;
        return File(ms, contenttype, filename);
    }
}