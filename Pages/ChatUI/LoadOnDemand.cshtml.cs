using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EJ2CoreSampleBrowser.Models;
using Syncfusion.EJ2.InteractiveChat;

namespace EJ2CoreSampleBrowser.Pages.ChatUI
{
    public class LoadOnDemandModel : PageModel
    {
        public UserModel CurrentUser { get; set; }
        public List<ChatUIMessage> ChatMessagesData { get; set; } = new List<ChatUIMessage>();
        public UserModel CurrentUserModel { get; set; } = new UserModel() { id = "user1", user = "Albert" };
        public UserModel MichaleUserModel { get; set; } = new UserModel() { id = "user2", user = "Michale Suyama", avatarUrl = "../css/chatui/images/andrew.png" };

        public void OnGet()
        {
            CurrentUser = CurrentUserModel;
        }

        public class UserModel
        {
            public string id { get; set; }
            public string user { get; set; }
            public string avatarUrl { get; set; }
        }
    }
}
