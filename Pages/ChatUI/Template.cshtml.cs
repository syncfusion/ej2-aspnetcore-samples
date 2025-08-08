#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
using Syncfusion.EJ2.Navigations;
using Syncfusion.EJ2.InteractiveChat;
using Syncfusion.EJ2.DropDowns;

namespace EJ2CoreSampleBrowser.Pages.ChatUI
{
    public class TemplateModel : PageModel
    {
        public List<TemplateDataModel> TemplateMessagedata { get; set; }

        public void OnGet()
        {
            List<TemplateDataModel> templateMessagedata = new List<TemplateDataModel>
            {
                new TemplateDataModel
                {
                    text = "Hello! I'm the Order tracking bot. how can I help you today?",
                    suggestions = new List<string> { "Track an order", "Cancel an order" }
                },
                new TemplateDataModel
                {
                    text = "Track an order",
                    reply = "Please select the order you want to track.",
                    suggestions = new List<string> { "Order #67890", "Order #53461" }
                },
                new TemplateDataModel
                {
                    text = "Order #67890",
                    reply = "Fetching details for order <b>#67890</b> </br></br> Your order is currently being processed and will ship in 2-3 days.",
                    suggestions = new List<string> { "Back to main menu", "Need help with something else" }
                },
                new TemplateDataModel
                {
                    text = "Order #53461",
                    reply = "Fetching details for order <b>#53461</b> </br></br> Your order is currently being processed and will ship in 2-3 days.",
                    suggestions = new List<string> { "Back to main menu", "Need help with something else" }
                },
                new TemplateDataModel
                {
                    text = "Order #87890",
                    reply = "Your order <b>#87890</b> has been cancelled.",
                    suggestions = new List<string> { "Back to main menu", "Need help with something else" }
                },
                new TemplateDataModel
                {
                    text = "Order #90910",
                    reply = "Your order <b>#90910</b> has been cancelled.",
                    suggestions = new List<string> { "Back to main menu", "Need help with something else" }
                },
                new TemplateDataModel
                {
                    text = "Cancel an order",
                    reply = "Pick the order you need to cancel.",
                    suggestions = new List<string> { "Order #87890", "Order #90910" }
                },
                new TemplateDataModel
                {
                    text = "Back to main menu",
                    reply = "You have returned to the main menu. What would you like to do next?",
                    suggestions = new List<string> { "Track an order", "Cancel an order" }
                },
                new TemplateDataModel
                {
                    text = "Need help with something else",
                    reply = "Please hold while we connect you to a support agent. You can chat with them for any additional queries.",
                    suggestions = new List<string>()
                }
            };
            TemplateMessagedata = templateMessagedata;
        }

        public class TemplateDataModel
        {
            public string text { get; set; }
            public string reply { get; set; }
            public List<string> suggestions { get; set; }
        }
    }
}
