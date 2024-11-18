#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class BookDetails
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int PublishedYear { get; set; }
        public string Price { get; set; }

        public List<BookDetails> GetAllRecords()
        {
            List<BookDetails> books = new List<BookDetails>();
            books.Add(new BookDetails { Title = "The Great Adventure", Author = "Emily Thompson", Genre = "Fiction", PublishedYear = 2023, Price = "$12.99" });
            books.Add(new BookDetails { Title = "The Clockwork Mirage", Author = "John Doe", Genre = "Non-Fiction", PublishedYear = 2019, Price = "$19.99" });
            books.Add(new BookDetails { Title = "Science Explained", Author = "Jane Smith", Genre = "Science", PublishedYear = 2021, Price = "$15.50" });
            books.Add(new BookDetails { Title = "Advanced Mathematics", Author = "Alan Turing", Genre = "Education", PublishedYear = 2020, Price = "$22.00" });
            books.Add(new BookDetails { Title = "The Art of War", Author = "Sun Tzu", Genre = "History", PublishedYear = 2019, Price = "$10.00" });
            books.Add(new BookDetails { Title = "Programming in Python", Author = "Guido Van Rossum", Genre = "Tech", PublishedYear = 2024, Price = "$29.95" });
            books.Add(new BookDetails { Title = "Introduction to Physio", Author = "William James", Genre = "Psychology", PublishedYear = 2019, Price = "$17.50" });
            books.Add(new BookDetails { Title = "Modern Fiction", Author = "Margaret Atwood", Genre = "Fiction", PublishedYear = 2017, Price = "$14.75" });
            books.Add(new BookDetails { Title = "The Greatest Gatsby", Author = "Scott Fitzgerald", Genre = "Fiction", PublishedYear = 2015, Price = "$11.99" });
            books.Add(new BookDetails { Title = "Quantum Physics", Author = "Stephen Hawking", Genre = "Science", PublishedYear = 2018, Price = "$32.00" });
            books.Add(new BookDetails { Title = "World History", Author = "Roberts", Genre = "History", PublishedYear = 2021, Price = "$20.00" });
            books.Add(new BookDetails { Title = "The Catcher in the Rye", Author = "Salinger", Genre = "Fiction", PublishedYear = 2016, Price = "$13.00" });
            books.Add(new BookDetails { Title = "A Brief History of Time", Author = "Stephen Hawking", Genre = "Science", PublishedYear = 2012, Price = "$18.95" });
            books.Add(new BookDetails { Title = "The Hobbit", Author = "Tolkien", Genre = "Fantasy", PublishedYear = 2018, Price = "$15.00" });
            books.Add(new BookDetails { Title = "Animal Farm", Author = "George Orwell", Genre = "Fiction", PublishedYear = 2017, Price = "$12.50" });
            return books;
        }
    }
}