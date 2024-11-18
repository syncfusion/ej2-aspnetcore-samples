#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.ListView;

public class NestedList : PageModel
{
    public List<object> listdata = new List<object>();
    public void OnGet()
    {
        listdata.Add(new
        {
            id = "01",
            text = "Music",
            icon = "folder",
            child = new List<object>() { new { id = "01-01", text = "Gouttes.mp3", icon = "file" } }

        });
        listdata.Add(new
        {

            id = "02",
            text = "Videos",
            icon = "folder",
            child = new List<object>() {
            new { id= "02-01", text= "Naturals.mp4", icon= "file" },
            new { id= "02-02", text= "Wild.mpeg", icon= "file" },
        }

        });
        listdata.Add(new
        {

            id = "03",
            text = "Documents",
            icon = "folder",
            child = new List<object>() {
            new { id= "03-01", text= "Environment Pollution.docx", icon= "file" },
            new { id= "03-02", text= "Global Water, Sanitation, & Hygiene.docx", icon= "file" },
            new { id= "03-03", text= "Global Warming.ppt", icon= "file" },
            new { id= "03-04", text= "Social Network.pdf", icon= "file" },
            new { id= "03-05", text= "Youth Empowerment.pdf", icon= "file" }
        }


        });

        listdata.Add(new
        {

            id = "04",
            text = "Pictures",
            icon = "folder",
            child = new List<object>() {
            new {
                id= "04-01", text= "Camera Roll", icon= "folder",
                child= new List<object>() {
                    new  { id= "04-01-01", text= "WIN_20160726_094117.JPG", icon= "file" },
                    new { id= "04-01-02", text= "WIN_20160726_094118.JPG", icon= "file" },
                    new { id= "04-01-03", text= "WIN_20160726_094119.JPG", icon= "file" }
                }
            },
            new   {
                id= "04-02", text= "Wind.jpg", icon= "file"
            },
            new  {
                id= "04-02", text= "Stone.jpg", icon= "file"
            },
            new   {
                id= "04-02", text= "Home.jpg", icon= "file"
            },
            new  {
                id= "04-02", text= "Bridge.png", icon= "file"
            }
        }

        });
        listdata.Add(new
        {

            id = "05",
            text = "Downloads",
            icon = "folder",
            child = new List<object>() {
            new { id= "05-01", text= "UI-Guide.pdf", icon= "file" },
            new  { id= "05-02", text= "Tutorials.zip", icon= "file" },
            new  { id= "05-03", text= "Game.exe", icon= "file" },
            new { id= "05-04", text= "TypeScript.7z", icon= "file" },
        }

        });
    }
}