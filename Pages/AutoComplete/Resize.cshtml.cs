#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.AutoComplete;

public class Resize : PageModel
{
    public List<BookData> Book = new List<BookData>();
    public void OnGet()
    {
        Book.Add(new BookData { BookName =  "Support Vector Machines Succinctly", BookID = "BOOK1" });
        Book.Add(new BookData { BookName =  "Scala Succinctly", BookID = "BOOK2" });
        Book.Add(new BookData { BookName =  "Application Security in .NET Succinctly", BookID = "BOOK3" });
        Book.Add(new BookData { BookName =  "ASP.NET WebHooks Succinctly", BookID = "BOOK4" });
        Book.Add(new BookData { BookName =  "Xamarin.Forms Succinctly", BookID = "BOOK5" });
        Book.Add(new BookData { BookName =  "Asynchronous Programming Succinctly", BookID = "BOOK6" });
        Book.Add(new BookData { BookName =  "Java Succinctly Part 2", BookID = "BOOK7" });
        Book.Add(new BookData { BookName =  "Java Succinctly Part 1", BookID = "BOOK8" });
        Book.Add(new BookData { BookName =  "PHP Succinctly", BookID = "BOOK9" });
        Book.Add(new BookData { BookName =  "Bing Maps V8 Succinctly", BookID = "BOOK10" });
        Book.Add(new BookData { BookName =  "WPF Debugging and Performance Succinctly", BookID = "BOOK11" });
        Book.Add(new BookData { BookName =  "Go Web Development Succinctly", BookID = "BOOK12" });
        Book.Add(new BookData { BookName =  "Go Succinctly", BookID = "BOOK13" });
        Book.Add(new BookData { BookName =  "More UWP Succinctly", BookID = "BOOK14" });
        Book.Add(new BookData { BookName =  "UWP Succinctly", BookID = "BOOK15" });
        Book.Add(new BookData { BookName =  "LINQPad Succinctly", BookID = "BOOK16" });
        Book.Add(new BookData { BookName =  "MongoDB 3 Succinctly", BookID = "BOOK17" });
        Book.Add(new BookData { BookName =  "R Programming Succinctly", BookID = "BOOK18" });
        Book.Add(new BookData { BookName =  "Azure Cosmos DB and DocumentDB Succinctly", BookID = "BOOK19" });
        Book.Add(new BookData { BookName =  "Unity Game Development Succinctly", BookID = "BOOK20" });
        Book.Add(new BookData { BookName =  "Aurelia Succinctly", BookID = "BOOK21" });
        Book.Add(new BookData { BookName =  "Microsoft Bot Framework Succinctly", BookID = "BOOK22" });
        Book.Add(new BookData { BookName =  "ASP.NET Core Succinctly", BookID = "BOOK23" });
        Book.Add(new BookData { BookName =  "Twilio with C# Succinctly", BookID = "BOOK24" });
        Book.Add(new BookData { BookName =  "Angular 2 Succinctly", BookID = "BOOK25" });
        Book.Add(new BookData { BookName =  "Visual Studio 2017 Succinctly", BookID = "BOOK26" });
        Book.Add(new BookData { BookName =  "Camtasia Succinctly", BookID = "BOOK27" });
        Book.Add(new BookData { BookName =  "SQL Queries Succinctly", BookID = "BOOK28" });
        Book.Add(new BookData { BookName =  "Keystone.js Succinctly", BookID = "BOOK29" });
        Book.Add(new BookData { BookName =  "Groovy Succinctly", BookID = "BOOK30" });
        Book.Add(new BookData { BookName =  "SQL Server for C# Developers Succinctly", BookID = "BOOK31" });
        Book.Add(new BookData { BookName =  "Ubuntu Server Succinctly", BookID = "BOOK32" });
        Book.Add(new BookData { BookName =  "Statistics Fundamentals Succinctly", BookID = "BOOK33" });
        Book.Add(new BookData { BookName =  ".NET Core Succinctly", BookID = "BOOK34" });
        Book.Add(new BookData { BookName =  "SOLID Principles Succinctly", BookID = "BOOK35" });
        Book.Add(new BookData { BookName =  "Node.js Succinctly", BookID = "BOOK36" });
        Book.Add(new BookData { BookName =  "Customer Success for C# Developers Succinctly", BookID = "BOOK37" });
        Book.Add(new BookData { BookName =  "Data Capture and Extraction with C# Succinctly", BookID = "BOOK38" });
        Book.Add(new BookData { BookName =  "Hadoop Succinctly", BookID = "BOOK39" });
        Book.Add(new BookData { BookName =  "SciPy Programming Succinctly", BookID = "BOOK40" });
        Book.Add(new BookData { BookName =  "Hive Succinctly", BookID = "BOOK41" });
        Book.Add(new BookData { BookName =  "React.js Succinctly", BookID = "BOOK42" });
        Book.Add(new BookData { BookName =  "ECMAScript 6 Succinctly", BookID = "BOOK43" });
        Book.Add(new BookData { BookName =  "GitHub Succinctly", BookID = "BOOK44" });
        Book.Add(new BookData { BookName =  "Gulp Succinctly", BookID = "BOOK45" });
        Book.Add(new BookData { BookName =  "Visual Studio Code Succinctly", BookID = "BOOK46" });
        Book.Add(new BookData { BookName =  "Object-Oriented Programming in C# Succinctly", BookID = "BOOK47" });
        Book.Add(new BookData { BookName =  "C# Code Contracts Succinctly", BookID = "BOOK48" });
        Book.Add(new BookData { BookName =  "Leaflet.js Succinctly", BookID = "BOOK49" });
        Book.Add(new BookData { BookName =  "Delphi Succinctly", BookID = "BOOK50" });
        Book.Add(new BookData { BookName =  "SQL on Azure Succinctly", BookID = "BOOK51" });
        Book.Add(new BookData { BookName =  "Web Servers Succinctly", BookID = "BOOK52" });
        Book.Add(new BookData { BookName =  "ASP.NET Multitenant Applications Succinctly", BookID = "BOOK53" });
        Book.Add(new BookData { BookName =  "ASP.NET MVC Succinctly", BookID = "BOOK54" });
        Book.Add(new BookData { BookName =  "Windows Azure Websites Succinctly", BookID = "BOOK55" });
        Book.Add(new BookData { BookName =  "Localization for .NET Succinctly", BookID = "BOOK56" });
        Book.Add(new BookData { BookName =  "ASP.NET Web API Succinctly", BookID = "BOOK57" });
        Book.Add(new BookData { BookName =  "ASP.NET MVC 4 Mobile Websites Succinctly", BookID = "BOOK58" });
        Book.Add(new BookData { BookName =  "jQuery Succinctly", BookID = "BOOK59" });
        Book.Add(new BookData { BookName =  "JavaScript Succinctly", BookID = "BOOK60" });
    }
}

public class BookData
{
    public string BookName { get; set; }
    public string BookID { get; set; }
}