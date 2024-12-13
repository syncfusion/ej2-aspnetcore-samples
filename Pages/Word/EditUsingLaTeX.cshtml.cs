#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;

namespace EJ2CoreSampleBrowser.Pages.Word;

public class EditUsingLaTeX : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public EditUsingLaTeX(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public IActionResult OnPost(string LaTeX, string Button, string Group1)
    {
        if (Button == null)
            return null;
            // return View();
        string basePath = _hostingEnvironment.WebRootPath;
        string dataPath = basePath + @"/Word/EditEquationLaTeXInput.docx";
        string contenttype = "application/vnd.ms-word.document.12";
        // Load Template document stream.
        FileStream fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        if (Button == "View Template")
            return File(fileStream, contenttype, "EditEquationLaTeXInput.docx");

        //Creates an empty Word document instance.          
        WordDocument document = new WordDocument();
        //Opens template document.
        document.Open(fileStream, FormatType.Docx);
        fileStream.Dispose();
        fileStream = null;

        //Find all the equations in the Word document.
        List<Entity> entities = document.FindAllItemsByProperty(EntityType.Math, null, null);

        //Get the first math equation.
        WMath math = entities[0] as WMath;

        //Update the modified laTeX code to the equation.
        if (!string.IsNullOrEmpty(LaTeX))
            math.MathParagraph.LaTeX = LaTeX;

        string filename = "";
        MemoryStream ms = new MemoryStream();

        #region Document SaveOption

        if (Group1 == "WordDocx")
        {
            filename = "EditEquationLaTeX.docx";
            contenttype = "application/msword";
            document.Save(ms, FormatType.Docx);
        }
        else
        {
            filename = "EditEquationLaTeX.pdf";
            contenttype = "application/pdf";
            DocIORenderer renderer = new DocIORenderer();
            renderer.ConvertToPDF(document).Save(ms);
        }

        #endregion Document SaveOption

        document.Close();
        ms.Position = 0;
        return File(ms, contenttype, filename);
    }
}