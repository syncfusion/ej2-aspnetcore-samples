#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
namespace EJ2CoreSampleBrowser.Pages.SpeechToText;

public class DefaultModel : PageModel
{
    public List<micolor> color = new List<micolor>();
    public List<languagetypes> language = new List<languagetypes>();

    public void OnGet(){
        color.Add( new micolor { text="Normal", value=""});
        color.Add( new micolor { text="Primary", value="e-primary"});
        color.Add( new micolor { text="Success", value="e-success"});
        color.Add( new micolor { text="Warning", value="e-warning"});
        color.Add( new micolor { text="Danger", value="e-danger"});
        color.Add( new micolor { text="Flat", value="e-flat"});
        color.Add( new micolor { text="Info", value="e-info"});

        language.Add( new languagetypes { text="English, US", value="en-US" });
        language.Add( new languagetypes { text="German, DE", value="de-DE" });
        language.Add( new languagetypes { text="Chinese, CN", value="zh-CN" });
        language.Add( new languagetypes { text="French, FR", value="fr-FR" });
        language.Add( new languagetypes { text="Arabic, SA", value="ar-SA" });
    }
    public class micolor
    {
        public string text { get; set; }
        public string value { get; set; }
    }
    public class languagetypes
    {
        public string text { get; set; }
        public string value { get; set; }
    }
}