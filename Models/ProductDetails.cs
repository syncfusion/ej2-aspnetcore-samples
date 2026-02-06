#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
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
    public class ProductDetails
    {    
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

        public List<ProductDetails> GetAllRecords()
        {
            List<ProductDetails> ProductDetails = new List<ProductDetails>();
             ProductDetails.Add(new ProductDetails  { ProductID= 1, ProductName= "Chai", UnitPrice= "18m", UnitsInStock= 39 });
             ProductDetails.Add(new ProductDetails  { ProductID= 2, ProductName= "Chang", UnitPrice= "19m", UnitsInStock= 45 });
             ProductDetails.Add(new ProductDetails  { ProductID= 3, ProductName= "Aniseed Syrup", UnitPrice= "23m", UnitsInStock= 79 });
             ProductDetails.Add(new ProductDetails  { ProductID= 4, ProductName= "Chef Anton Cajun Seasoning", UnitPrice= "28m", UnitsInStock= 28 });
             ProductDetails.Add(new ProductDetails  { ProductID= 5, ProductName= "Gumbo Mix", UnitPrice= "11m", UnitsInStock= 50 });
             ProductDetails.Add(new ProductDetails  { ProductID= 6, ProductName= "Grandma Boysenberry", UnitPrice= "37m", UnitsInStock= 49 });
             ProductDetails.Add(new ProductDetails  { ProductID= 7, ProductName= "Northwoods Cranberry Sauce", UnitPrice= "23m", UnitsInStock= 91 });
             ProductDetails.Add(new ProductDetails  { ProductID= 8, ProductName= "Mishi Kobe Niku", UnitPrice= "32m", UnitsInStock= 16 });
             ProductDetails.Add(new ProductDetails  { ProductID= 9, ProductName= "Ikura", UnitPrice= "80m", UnitsInStock= 29 });
             ProductDetails.Add(new ProductDetails  { ProductID= 10, ProductName= "Uncle Bob Organic Dried Pears", UnitPrice= "26m", UnitsInStock= 32 });
             ProductDetails.Add(new ProductDetails  { ProductID= 11, ProductName= "Organic Dried Pears", UnitPrice= "29m", UnitsInStock= 19 });
            return ProductDetails;
        }
    }
}