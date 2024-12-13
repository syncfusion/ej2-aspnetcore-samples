#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.FileManager;

public class FlatData : PageModel
{
    public List<FileData> resultData = new List<FileData>();
    public void OnGet()
    {
        var permission = new Permission
        {
            copy = false,
            download = false,
            write = false,
            writeContents = false,
            read = true,
            upload = false,
            message = ""
        };


        resultData.Add(new FileData
        {
            dateCreated = DateTime.Now,
            dateModified = DateTime.Parse("2024-01-08T18:16:38.4384894+05:30"),
            filterPath = "",
            hasChild = true,
            id = "0",
            isFile = false,
            name = "Files",
            parentId = "",
            size = 1779448,
            type = "folder",
        });
        resultData.Add(new FileData
        {
            dateCreated = DateTime.Parse("2023-11-15T19:02:02.3419426+05:30"),
            dateModified = DateTime.Parse("2024-01-08T16:55:20.9464164+05:30"),
            filterPath = "\\",
            hasChild = false,
            id = "1",
            isFile = false,
            name = "Documents",
            parentId = "0",
            size = 680786,
            type = "folder",
            permission = permission
        });
        resultData.Add(new FileData
        {
            dateCreated = DateTime.Parse("2023-11-15T19:02:02.3419426+05:30"),
            dateModified = DateTime.Parse("2024-01-08T16:55:20.9464164+05:30"),
            filterPath = "\\",
            hasChild = false,
            id = "2",
            isFile = false,
            name = "Downloads",
            parentId = "0",
            size = 6172,
            type = "folder"
        });
        resultData.Add(new FileData
        {
            dateCreated = DateTime.Parse("2023-11-15T19:02:02.3419426+05:30"),
            dateModified = DateTime.Parse("2024-01-08T16:55:20.9464164+05:30"),
            filterPath = "\\",
            hasChild = false,
            id = "3",
            isFile = false,
            name = "Music",
            parentId = "0",
            size = 20,
            type = "folder"
        });
        resultData.Add(new FileData
        {
            dateCreated = DateTime.Parse("2023-11-15T19:02:02.3419426+05:30"),
            dateModified = DateTime.Parse("2024-01-08T16:55:20.9464164+05:30"),
            filterPath = "\\",
            hasChild = true,
            id = "4",
            isFile = false,
            name = "Pictures",
            parentId = "0",
            size = 228465,
            type = "folder"
        });
        resultData.Add(new FileData
        {
            dateCreated = DateTime.Parse("2023-11-15T19:02:02.3419426+05:30"),
            dateModified = DateTime.Parse("2024-01-08T16:55:20.9464164+05:30"),
            filterPath = "\\",
            hasChild = false,
            id = "5",
            isFile = false,
            name = "Videos",
            parentId = "0",
            size = 20,
            type = "folder"
        });
        resultData.Add(new FileData
        {
            dateCreated = DateTime.Parse("2023-11-15T19:02:02.3419426+05:30"),
            dateModified = DateTime.Parse("2024-01-08T16:55:20.9464164+05:30"),
            filterPath = "\\Documents\\",
            hasChild = false,
            id = "6",
            isFile = true,
            name = "EJ2_File_Manager",
            parentId = "1",
            size = 12403,
            type = ".docx"
        });
        resultData.Add(new FileData
        {
            dateCreated = DateTime.Parse("2023-11-15T19:02:02.3419426+05:30"),
            dateModified = DateTime.Parse("2024-01-08T16:55:20.9464164+05:30"),
            filterPath = "\\Documents\\",
            hasChild = false,
            id = "7",
            isFile = true,
            name = "EJ2_File_Manager",
            parentId = "1",
            size = 90099,
            type = ".pdf"
        });
        resultData.Add(new FileData
        {
            dateCreated = DateTime.Parse("2023-11-15T19:02:02.3419426+05:30"),
            dateModified = DateTime.Parse("2024-01-08T16:55:20.9464164+05:30"),
            filterPath = "\\Documents\\",
            hasChild = false,
            id = "8",
            isFile = true,
            name = "File_Manager_PPT",
            parentId = "1",
            size = 578010,
            type = ".pptx"
        });
        resultData.Add(new FileData
        {
            dateCreated = DateTime.Parse("2023-11-15T19:02:02.3419426+05:30"),
            dateModified = DateTime.Parse("2024-01-08T16:55:20.9464164+05:30"),
            filterPath = "\\Documents\\",
            hasChild = false,
            id = "9",
            isFile = true,
            name = "File_Manager",
            parentId = "1",
            size = 274,
            type = ".txt"
        });
        resultData.Add(new FileData
        {
            dateCreated = DateTime.Parse("2023-11-15T19:02:02.3419426+05:30"),
            dateModified = DateTime.Parse("2024-01-08T16:55:20.9464164+05:30"),
            filterPath = "\\Downloads\\",
            hasChild = false,
            id = "10",
            isFile = true,
            name = "Sample_Work_Sheet",
            parentId = "2",
            size = 6172,
            type = ".xlsx"
        });
        resultData.Add(new FileData
        {
            dateCreated = DateTime.Parse("2023-11-15T19:02:02.3419426+05:30"),
            dateModified = DateTime.Parse("2024-01-08T16:55:20.9464164+05:30"),
            filterPath = "\\Music\\",
            hasChild = false,
            id = "11",
            isFile = true,
            name = "Music",
            parentId = "3",
            size = 10,
            type = ".mp3"
        });
        resultData.Add(new FileData
        {
            dateCreated = DateTime.Parse("2023-11-15T19:02:02.3419426+05:30"),
            dateModified = DateTime.Parse("2024-01-08T16:55:20.9464164+05:30"),
            filterPath = "\\Music\\",
            hasChild = false,
            id = "12",
            isFile = true,
            name = "Sample_Music",
            parentId = "3",
            size = 10,
            type = ".mp3"
        });
        resultData.Add(new FileData
        {
            dateCreated = DateTime.Parse("2023-11-15T19:02:02.3419426+05:30"),
            dateModified = DateTime.Parse("2024-01-08T16:55:20.9464164+05:30"),
            filterPath = "\\Videos\\",
            hasChild = false,
            id = "13",
            isFile = true,
            name = "Demo_Video",
            parentId = "5",
            size = 10,
            type = ".mp4"
        });
        resultData.Add(new FileData
        {
            dateCreated = DateTime.Parse("2023-11-15T19:02:02.3419426+05:30"),
            dateModified = DateTime.Parse("2024-01-08T16:55:20.9464164+05:30"),
            filterPath = "\\Videos\\",
            hasChild = false,
            id = "14",
            isFile = true,
            name = "Sample_Video",
            parentId = "5",
            size = 10,
            type = ".mp4"
        });
        resultData.Add(new FileData
        {
            dateCreated = DateTime.Parse("2023-11-15T19:02:02.3419426+05:30"),
            dateModified = DateTime.Parse("2024-01-08T16:55:20.9464164+05:30"),
            filterPath = "\\Pictures\\",
            hasChild = false,
            id = "15",
            isFile = false,
            name = "Employees",
            parentId = "4",
            size = 237568,
            type = "folder",
        });
        resultData.Add(new FileData
        {
            dateCreated = DateTime.Parse("2023-11-15T19:02:02.3419426+05:30"),
            dateModified = DateTime.Parse("2024-01-08T16:55:20.9464164+05:30"),
            filterPath = "\\Pictures\\Employees\\",
            hasChild = false,
            id = "16",
            isFile = true,
            name = "Albert",
            parentId = "15",
            size = 53248,
            type = ".png",
            imageUrl = "https://ej2.syncfusion.com/demos/src/avatar/images/pic01.png"
        });
        resultData.Add(new FileData
        {
            dateCreated = DateTime.Parse("2023-11-15T19:02:02.3419426+05:30"),
            dateModified = DateTime.Parse("2024-01-08T16:55:20.9464164+05:30"),
            filterPath = "\\Pictures\\Employees\\",
            hasChild = false,
            id = "17",
            isFile = true,
            name = "Nancy",
            parentId = "15",
            size = 65536,
            type = ".png",
            imageUrl = "https://ej2.syncfusion.com/demos/src/avatar/images/pic02.png"
        });
        resultData.Add(new FileData
        {
            dateCreated = DateTime.Parse("2023-11-15T19:02:02.3419426+05:30"),
            dateModified = DateTime.Parse("2024-01-08T16:55:20.9464164+05:30"),
            filterPath = "\\Pictures\\Employees\\",
            hasChild = false,
            id = "18",
            isFile = true,
            name = "Michael",
            parentId = "15",
            size = 69632,
            type = ".png",
            imageUrl = "https://ej2.syncfusion.com/demos/src/avatar/images/pic03.png"
        });
        resultData.Add(new FileData
        {
            dateCreated = DateTime.Parse("2023-11-15T19:02:02.3419426+05:30"),
            dateModified = DateTime.Parse("2024-01-08T16:55:20.9464164+05:30"),
            filterPath = "\\Pictures\\Employees\\",
            hasChild = false,
            id = "19",
            isFile = true,
            name = "Robert",
            parentId = "15",
            size = 48951,
            type = ".png",
            imageUrl = "https://ej2.syncfusion.com/demos/src/avatar/images/pic04.png"
        });
    }
}
public class Permission
{
    public bool copy { get; set; }
    public bool download { get; set; }
    public bool write { get; set; }
    public bool writeContents { get; set; }
    public bool read { get; set; }
    public bool upload { get; set; }
    public string? message { get; set; }
}

public class FileData
{
    public DateTime dateCreated { get; set; }
    public DateTime dateModified { get; set; }
    public string? filterPath { get; set; }
    public bool hasChild { get; set; }
    public string? id { get; set; }
    public bool isFile { get; set; }
    public string? name { get; set; }
    public string? parentId { get; set; }
    public int size { get; set; }
    public string? type { get; set; }
    public Permission? permission { get; set; }
    public string? imageUrl { get; set; }
}