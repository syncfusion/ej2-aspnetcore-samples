#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Pages.RichTextEditor;

public class RichTextEditorModel
{
    public string Value { get; set; }
    
}
public class RichTextEditorFor : PageModel
{
    [BindProperty]
    public RichTextEditorModel rteModel { get; set; }
    public string datasource = "<p>Type or edit the content to post the <b>Rich Text Editor</b> value.</p>" ;
    public void OnGet()
    {
        rteModel = new RichTextEditorModel
        {
            Value = datasource
        };
    }

    public void OnPost()
    {
        if (rteModel.Value != null)
        {
            var textWithoutHtml = RemoveHtmlTags(rteModel.Value.Trim());
            textWithoutHtml = textWithoutHtml.Replace(" ", "");
            int imgCount = CountImageTags(rteModel.Value);
            int adjustedLength = textWithoutHtml.Trim().Length + imgCount;
            if (string.IsNullOrWhiteSpace(textWithoutHtml) || adjustedLength < 20)
            {
                ModelState.AddModelError("rteModel.Value", "The Rich Text Editor content must contain at least 20 letters");
            }
            else
            {
                rteModel.Value = string.Empty;
                TempData["SuccessMessage"] = "Form submitted successfully!";
            }
        }
        else
        {
            ModelState.AddModelError("rteModel.Value", "Value is required");
        }
    }
    
    private string RemoveHtmlTags(string htmlContent)
    {
        return Regex.Replace(htmlContent, "<.*?>", string.Empty);
    }
    private int CountImageTags(string text)
    {
        var imgCount = Regex.Matches(text, "<img[^>]*>").Count;
        return imgCount;
    }
}
