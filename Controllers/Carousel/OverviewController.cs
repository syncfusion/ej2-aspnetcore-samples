#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Carousel
{
    public partial class CarouselController : Controller
    {
        public IActionResult Overview()
        {
            List<CarouselData> appData = new List<CarouselData>();
            appData.Add(new CarouselData
            {
                imageUrl = "./../css/carousel/images/google-pixel-6-pro.png",
                title = "Google Pixel",
                model = "Pixel 6 Pro",
                brand = "Google",
                releaseDate = "Oct 28, 2021",
                ram = "12GB",
                rom = "128GB",
                platform = "Android",
                version = 12
            });
            appData.Add(new CarouselData
            {
                imageUrl = "./../css/carousel/images/iphone-13-pro.png",
                title = "iPhone",
                model = "iPhone 13 Pro",
                brand = "Apple",
                releaseDate = "Sept 14, 2021",
                ram = "4GB",
                rom = "128GB",
                platform = "iOS",
                version = 15
            });
            appData.Add(new CarouselData
            {
                imageUrl = "./../css/carousel/images/nokia-xr-20.png",
                title = "Nokia",
                model = "XR-20",
                brand = "Nokia",
                releaseDate = "Oct 30, 2021",
                ram = "6GB",
                rom = "128GB",
                platform = "Android",
                version = 11
            });
            appData.Add(new CarouselData
            {
                imageUrl = "./../css/carousel/images/one-plus-9-pro.png",
                title = "OnePlus",
                model = "OP9 Pro",
                brand = "OnePlus",
                releaseDate = "March 23, 2021",
                ram = "8GB",
                rom = "128GB",
                platform = "OxygenOS based on Android",
                version = 11
            });
            appData.Add(new CarouselData
            {
                imageUrl = "./../css/carousel/images/samsung-s21-fe.png",
                title = "Samsung",
                model = "S21 FE",
                brand = "Samsung",
                releaseDate = "Jan 27, 2021",
                ram = "8GB",
                rom = "128GB",
                platform = "Samsung One UI 4.0 based on Android",
                version = 12
            });
            ViewBag.dataSource = appData;
            return View();
        }
        public class CarouselData
        {
            public string imageUrl { get; set; }
            public string title { get; set; }
            public string model { get; set; }
            public string brand { get; set; }
            public string releaseDate { get; set; }
            public string ram { get; set; }
            public string rom { get; set; }
            public string platform { get; set; }
            public int version { get; set; }
        }
    }
}
