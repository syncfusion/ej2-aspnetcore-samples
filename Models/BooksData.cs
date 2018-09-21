using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class BooksData
    {
        public string BookName { get; set; }
        public string BookID { get; set; }

        public List<BooksData> GetBooksData()
        {
            List<BooksData> book = new List<BooksData>();
            book.Add(new BooksData { BookName =  "Support Vector Machines Succinctly", BookID = "BOOK1" });
            book.Add(new BooksData { BookName =  "Scala Succinctly", BookID = "BOOK2" });
            book.Add(new BooksData { BookName =  "Application Security in .NET Succinctly", BookID = "BOOK3" });
            book.Add(new BooksData { BookName =  "ASP.NET WebHooks Succinctly", BookID = "BOOK4" });
            book.Add(new BooksData { BookName =  "Xamarin.Forms Succinctly", BookID = "BOOK5" });
            book.Add(new BooksData { BookName =  "Asynchronous Programming Succinctly", BookID = "BOOK6" });
            book.Add(new BooksData { BookName =  "Java Succinctly Part 2", BookID = "BOOK7" });
            book.Add(new BooksData { BookName =  "Java Succinctly Part 1", BookID = "BOOK8" });
            book.Add(new BooksData { BookName =  "PHP Succinctly", BookID = "BOOK9" });
            book.Add(new BooksData { BookName =  "Bing Maps V8 Succinctly", BookID = "BOOK10" });
            book.Add(new BooksData { BookName =  "WPF Debugging and Performance Succinctly", BookID = "BOOK11" });
            book.Add(new BooksData { BookName =  "Go Web Development Succinctly", BookID = "BOOK12" });
            book.Add(new BooksData { BookName =  "Go Succinctly", BookID = "BOOK13" });
            book.Add(new BooksData { BookName =  "More UWP Succinctly", BookID = "BOOK14" });
            book.Add(new BooksData { BookName =  "UWP Succinctly", BookID = "BOOK15" });
            book.Add(new BooksData { BookName =  "LINQPad Succinctly", BookID = "BOOK16" });
            book.Add(new BooksData { BookName =  "MongoDB 3 Succinctly", BookID = "BOOK17" });
            book.Add(new BooksData { BookName =  "R Programming Succinctly", BookID = "BOOK18" });
            book.Add(new BooksData { BookName =  "Azure Cosmos DB and DocumentDB Succinctly", BookID = "BOOK19" });
            book.Add(new BooksData { BookName =  "Unity Game Development Succinctly", BookID = "BOOK20" });
            book.Add(new BooksData { BookName =  "Aurelia Succinctly", BookID = "BOOK21" });
            book.Add(new BooksData { BookName =  "Microsoft Bot Framework Succinctly", BookID = "BOOK22" });
            book.Add(new BooksData { BookName =  "ASP.NET Core Succinctly", BookID = "BOOK23" });
            book.Add(new BooksData { BookName =  "Twilio with C# Succinctly", BookID = "BOOK24" });
            book.Add(new BooksData { BookName =  "Angular 2 Succinctly", BookID = "BOOK25" });
            book.Add(new BooksData { BookName =  "Visual Studio 2017 Succinctly", BookID = "BOOK26" });
            book.Add(new BooksData { BookName =  "Camtasia Succinctly", BookID = "BOOK27" });
            book.Add(new BooksData { BookName =  "SQL Queries Succinctly", BookID = "BOOK28" });
            book.Add(new BooksData { BookName =  "Keystone.js Succinctly", BookID = "BOOK29" });
            book.Add(new BooksData { BookName =  "Groovy Succinctly", BookID = "BOOK30" });
            book.Add(new BooksData { BookName =  "SQL Server for C# Developers Succinctly", BookID = "BOOK31" });
            book.Add(new BooksData { BookName =  "Ubuntu Server Succinctly", BookID = "BOOK32" });
            book.Add(new BooksData { BookName =  "Statistics Fundamentals Succinctly", BookID = "BOOK33" });
            book.Add(new BooksData { BookName =  ".NET Core Succinctly", BookID = "BOOK34" });
            book.Add(new BooksData { BookName =  "SOLID Principles Succinctly", BookID = "BOOK35" });
            book.Add(new BooksData { BookName =  "Node.js Succinctly", BookID = "BOOK36" });
            book.Add(new BooksData { BookName =  "Customer Success for C# Developers Succinctly", BookID = "BOOK37" });
            book.Add(new BooksData { BookName =  "Data Capture and Extraction with C# Succinctly", BookID = "BOOK38" });
            book.Add(new BooksData { BookName =  "Hadoop Succinctly", BookID = "BOOK39" });
            book.Add(new BooksData { BookName =  "SciPy Programming Succinctly", BookID = "BOOK40" });
            book.Add(new BooksData { BookName =  "Hive Succinctly", BookID = "BOOK41" });
            book.Add(new BooksData { BookName =  "React.js Succinctly", BookID = "BOOK42" });
            book.Add(new BooksData { BookName =  "ECMAScript 6 Succinctly", BookID = "BOOK43" });
            book.Add(new BooksData { BookName =  "GitHub Succinctly", BookID = "BOOK44" });
            book.Add(new BooksData { BookName =  "Gulp Succinctly", BookID = "BOOK45" });
            book.Add(new BooksData { BookName =  "Visual Studio Code Succinctly", BookID = "BOOK46" });
            book.Add(new BooksData { BookName =  "Object-Oriented Programming in C# Succinctly", BookID = "BOOK47" });
            book.Add(new BooksData { BookName =  "C# Code Contracts Succinctly", BookID = "BOOK48" });
            book.Add(new BooksData { BookName =  "Leaflet.js Succinctly", BookID = "BOOK49" });
            book.Add(new BooksData { BookName =  "Delphi Succinctly", BookID = "BOOK50" });
            book.Add(new BooksData { BookName =  "SQL on Azure Succinctly", BookID = "BOOK51" });
            book.Add(new BooksData { BookName =  "Web Servers Succinctly", BookID = "BOOK52" });
            book.Add(new BooksData { BookName =  "ASP.NET Multitenant Applications Succinctly", BookID = "BOOK53" });
            book.Add(new BooksData { BookName =  "ASP.NET MVC Succinctly", BookID = "BOOK54" });
            book.Add(new BooksData { BookName =  "Windows Azure Websites Succinctly", BookID = "BOOK55" });
            book.Add(new BooksData { BookName =  "Localization for .NET Succinctly", BookID = "BOOK56" });
            book.Add(new BooksData { BookName =  "ASP.NET Web API Succinctly", BookID = "BOOK57" });
            book.Add(new BooksData { BookName =  "ASP.NET MVC 4 Mobile Websites Succinctly", BookID = "BOOK58" });
            book.Add(new BooksData { BookName =  "jQuery Succinctly", BookID = "BOOK59" });
            book.Add(new BooksData { BookName =  "JavaScript Succinctly", BookID = "BOOK60" });
            return book;
        }
    }
}
