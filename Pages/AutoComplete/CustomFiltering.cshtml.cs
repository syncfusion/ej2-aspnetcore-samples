#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.AutoComplete;

public class CustomFiltering : PageModel
{
    public List<BooksData> Book = new List<BooksData>();
    public void OnGet()
    {
        Book.Add(new BooksData { BookName =  "Support Vector Machines Succinctly", BookID = "BOOK1" });
        Book.Add(new BooksData { BookName =  "Scala Succinctly", BookID = "BOOK2" });
        Book.Add(new BooksData { BookName =  "Application Security in .NET Succinctly", BookID = "BOOK3" });
        Book.Add(new BooksData { BookName =  "ASP.NET WebHooks Succinctly", BookID = "BOOK4" });
        Book.Add(new BooksData { BookName =  "Xamarin.Forms Succinctly", BookID = "BOOK5" });
        Book.Add(new BooksData { BookName =  "Asynchronous Programming Succinctly", BookID = "BOOK6" });
        Book.Add(new BooksData { BookName =  "Java Succinctly Part 2", BookID = "BOOK7" });
        Book.Add(new BooksData { BookName =  "Java Succinctly Part 1", BookID = "BOOK8" });
        Book.Add(new BooksData { BookName =  "PHP Succinctly", BookID = "BOOK9" });
        Book.Add(new BooksData { BookName =  "Bing Maps V8 Succinctly", BookID = "BOOK10" });
        Book.Add(new BooksData { BookName =  "WPF Debugging and Performance Succinctly", BookID = "BOOK11" });
        Book.Add(new BooksData { BookName =  "Go Web Development Succinctly", BookID = "BOOK12" });
        Book.Add(new BooksData { BookName =  "Go Succinctly", BookID = "BOOK13" });
        Book.Add(new BooksData { BookName =  "More UWP Succinctly", BookID = "BOOK14" });
        Book.Add(new BooksData { BookName =  "UWP Succinctly", BookID = "BOOK15" });
        Book.Add(new BooksData { BookName =  "LINQPad Succinctly", BookID = "BOOK16" });
        Book.Add(new BooksData { BookName =  "MongoDB 3 Succinctly", BookID = "BOOK17" });
        Book.Add(new BooksData { BookName =  "R Programming Succinctly", BookID = "BOOK18" });
        Book.Add(new BooksData { BookName =  "Azure Cosmos DB and DocumentDB Succinctly", BookID = "BOOK19" });
        Book.Add(new BooksData { BookName =  "Unity Game Development Succinctly", BookID = "BOOK20" });
        Book.Add(new BooksData { BookName =  "Aurelia Succinctly", BookID = "BOOK21" });
        Book.Add(new BooksData { BookName =  "Microsoft Bot Framework Succinctly", BookID = "BOOK22" });
        Book.Add(new BooksData { BookName =  "ASP.NET Core Succinctly", BookID = "BOOK23" });
        Book.Add(new BooksData { BookName =  "Twilio with C# Succinctly", BookID = "BOOK24" });
        Book.Add(new BooksData { BookName =  "Angular 2 Succinctly", BookID = "BOOK25" });
        Book.Add(new BooksData { BookName =  "Visual Studio 2017 Succinctly", BookID = "BOOK26" });
        Book.Add(new BooksData { BookName =  "Camtasia Succinctly", BookID = "BOOK27" });
        Book.Add(new BooksData { BookName =  "SQL Queries Succinctly", BookID = "BOOK28" });
        Book.Add(new BooksData { BookName =  "Keystone.js Succinctly", BookID = "BOOK29" });
        Book.Add(new BooksData { BookName =  "Groovy Succinctly", BookID = "BOOK30" });
        Book.Add(new BooksData { BookName =  "SQL Server for C# Developers Succinctly", BookID = "BOOK31" });
        Book.Add(new BooksData { BookName =  "Ubuntu Server Succinctly", BookID = "BOOK32" });
        Book.Add(new BooksData { BookName =  "Statistics Fundamentals Succinctly", BookID = "BOOK33" });
        Book.Add(new BooksData { BookName =  ".NET Core Succinctly", BookID = "BOOK34" });
        Book.Add(new BooksData { BookName =  "SOLID Principles Succinctly", BookID = "BOOK35" });
        Book.Add(new BooksData { BookName =  "Node.js Succinctly", BookID = "BOOK36" });
        Book.Add(new BooksData { BookName =  "Customer Success for C# Developers Succinctly", BookID = "BOOK37" });
        Book.Add(new BooksData { BookName =  "Data Capture and Extraction with C# Succinctly", BookID = "BOOK38" });
        Book.Add(new BooksData { BookName =  "Hadoop Succinctly", BookID = "BOOK39" });
        Book.Add(new BooksData { BookName =  "SciPy Programming Succinctly", BookID = "BOOK40" });
        Book.Add(new BooksData { BookName =  "Hive Succinctly", BookID = "BOOK41" });
        Book.Add(new BooksData { BookName =  "React.js Succinctly", BookID = "BOOK42" });
        Book.Add(new BooksData { BookName =  "ECMAScript 6 Succinctly", BookID = "BOOK43" });
        Book.Add(new BooksData { BookName =  "GitHub Succinctly", BookID = "BOOK44" });
        Book.Add(new BooksData { BookName =  "Gulp Succinctly", BookID = "BOOK45" });
        Book.Add(new BooksData { BookName =  "Visual Studio Code Succinctly", BookID = "BOOK46" });
        Book.Add(new BooksData { BookName =  "Object-Oriented Programming in C# Succinctly", BookID = "BOOK47" });
        Book.Add(new BooksData { BookName =  "C# Code Contracts Succinctly", BookID = "BOOK48" });
        Book.Add(new BooksData { BookName =  "Leaflet.js Succinctly", BookID = "BOOK49" });
        Book.Add(new BooksData { BookName =  "Delphi Succinctly", BookID = "BOOK50" });
        Book.Add(new BooksData { BookName =  "SQL on Azure Succinctly", BookID = "BOOK51" });
        Book.Add(new BooksData { BookName =  "Web Servers Succinctly", BookID = "BOOK52" });
        Book.Add(new BooksData { BookName =  "ASP.NET Multitenant Applications Succinctly", BookID = "BOOK53" });
        Book.Add(new BooksData { BookName =  "ASP.NET MVC Succinctly", BookID = "BOOK54" });
        Book.Add(new BooksData { BookName =  "Windows Azure Websites Succinctly", BookID = "BOOK55" });
        Book.Add(new BooksData { BookName =  "Localization for .NET Succinctly", BookID = "BOOK56" });
        Book.Add(new BooksData { BookName =  "ASP.NET Web API Succinctly", BookID = "BOOK57" });
        Book.Add(new BooksData { BookName =  "ASP.NET MVC 4 Mobile Websites Succinctly", BookID = "BOOK58" });
        Book.Add(new BooksData { BookName =  "jQuery Succinctly", BookID = "BOOK59" });
        Book.Add(new BooksData { BookName =  "JavaScript Succinctly", BookID = "BOOK60" });
    }
}

public class BooksData
{
    public string BookName { get; set; }
    public string BookID { get; set; }
}