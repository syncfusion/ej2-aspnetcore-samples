#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.RichTextEditor;

public class MentionIntegration : PageModel
{
    public List<EmailData> mention = new List<EmailData>();
    public void OnGet()
    {
        mention.Add(new EmailData { Name = "Selma Rose", Status = "active", Eimg = "2", EmailId = "selma@gmail.com" });
        mention.Add(new EmailData { Name = "Maria", Status = "active", Eimg = "1", EmailId = "maria@gmail.com" });
        mention.Add(new EmailData { Name = "Camden Kate", Status = "active", Eimg = "9", EmailId = "camden@gmail.com" });
        mention.Add(new EmailData { Name = "Robert", Status = "busy", Eimg = "dp", EmailId = "robert@gmail.com" });
        mention.Add(new EmailData { Name = "Garth", Status = "active", Eimg = "7", EmailId = "garth@gmail.com" });
        mention.Add(new EmailData { Name = "Andrew James", Status = "away", Eimg = "pic04", EmailId = "james@gmail.com" });
        mention.Add(new EmailData { Name = "Olivia", Status = "busy", Eimg = "5", EmailId = "olivia@gmail.com" });
        mention.Add(new EmailData { Name = "Sophia", Status = "away", Eimg = "6", EmailId = "sophia@gmail.com" });
        mention.Add(new EmailData { Name = "Margaret", Status = "active", Eimg = "3", EmailId = "margaret@gmail.com" });
        mention.Add(new EmailData { Name = "Ursula Ann", Status = "active", Eimg = "dp", EmailId = "laura@gmail.com" });
        mention.Add(new EmailData { Name = "Laura Grace", Status = "active", Eimg = "7", EmailId = "laura@gmail.com" });
        mention.Add(new EmailData { Name = "Albert", Status = "active", Eimg = "pic03", EmailId = "albert@gmail.com" });
        mention.Add(new EmailData { Name = "William", Status = "away", Eimg = "10", EmailId = "william@gmail.com" });
    }
}

public class EmailData
{
    public string Name { get; set; }
    public string Status { get; set; }
    public string Eimg { get; set; }
    public string EmailId { get; set; }
}