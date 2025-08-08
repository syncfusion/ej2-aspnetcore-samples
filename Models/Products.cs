#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
    public class Products
    {    
        public string Name { get; set; }
        public string Price { get; set; }
        public string Availability { get; set; }
        public string Category { get; set; }
        public double Rating { get; set; }

        public List<Products> GetAllRecords()
        {
            List<Products> products = new List<Products>();
             products.Add(new Products  { Name = "Laptop", Price = "999.99m", Availability = "In Stock", Category = "Electronics", Rating = 4.5 });
             products.Add(new Products  { Name = "Smartphone", Price = "599.99m", Availability = "Out of Stock", Category = "Electronics", Rating = 4.3 });
             products.Add(new Products  { Name = "Tablet", Price = "299.99m", Availability = "In Stock", Category = "Electronics", Rating = 4.2 });
             products.Add(new Products  { Name = "Headphones", Price = "49.99m", Availability = "In Stock", Category = "Accessories", Rating = 4.0 });
             products.Add(new Products  { Name = "Smartwatch", Price = "199.99m", Availability = "Limited Stock", Category = "Wearables", Rating = 4.4 });
             products.Add(new Products  { Name = "Monitor", Price = "129.99m", Availability = "In Stock", Category = "Electronics", Rating = 4.6 });
             products.Add(new Products  { Name = "Keyboard", Price = "39.99m", Availability = "In Stock", Category = "Accessories", Rating = 4.1 });
             products.Add(new Products  { Name = "Mouse", Price = "19.99m", Availability = "Out of Stock", Category = "Accessories", Rating = 4.3 });
             products.Add(new Products  { Name = "Printer", Price = "89.99m", Availability = "In Stock", Category = "Office Supplies", Rating = 4.2 });
             products.Add(new Products  { Name = "Camera", Price = "499.99m", Availability = "In Stock", Category = "Electronics", Rating = 4.7 });
             products.Add(new Products  { Name = "Speakers", Price = "149.99m", Availability = "In Stock", Category = "Accessories", Rating = 4.5 });
             products.Add(new Products  { Name = "Router", Price = "79.99m", Availability = "Out of Stock", Category = "Electronics", Rating = 4.4 });
             products.Add(new Products  { Name = "External Hard Drive", Price = "59.99m", Availability = "In Stock", Category = "Storage", Rating = 4.6 });
             products.Add(new Products  { Name = "USB Flash Drive", Price = "9.99m", Availability = "In Stock", Category = "Storage", Rating = 4.2 });
             products.Add(new Products  { Name = "Webcam", Price = "29.99m", Availability = "Limited Stock", Category = "Accessories", Rating = 4.1 });
             products.Add(new Products  { Name = "Smart TV", Price = "799.99m", Availability = "In Stock", Category = "Electronics", Rating = 4.8 });
             products.Add(new Products  { Name = "Projector", Price = "299.99m", Availability = "Out of Stock", Category = "Electronics", Rating = 4.5 });
             products.Add(new Products  { Name = "VR Headset", Price = "349.99m", Availability = "In Stock", Category = "Electronics", Rating = 4.7 });
             products.Add(new Products  { Name = "Drone", Price = "599.99m", Availability = "In Stock", Category = "Electronics", Rating = 4.6 });
             products.Add(new Products  { Name = "Fitness Tracker", Price = "99.99m", Availability = "In Stock", Category = "Wearables", Rating = 4.3 });
            return products;
        }
    }
}