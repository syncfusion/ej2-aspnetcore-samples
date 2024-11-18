#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Carousel;

public class DataBinding : PageModel
{
    public List<CarouselDataBinding> datasrc = new List<CarouselDataBinding>();
    public void OnGet()
    {
        datasrc.Add(new CarouselDataBinding
        {
            Id = 1,
            ImgPath = "./../css/carousel/images/san-francisco.jpg",
            Title = "San Francisco",
            Content = "San Francisco, officially the City and County of San Francisco, is a cultural, commercial, and financial center in the U.S. state of California. Located in Northern California, San Francisco is the 17th most populous city proper in the United States, and the fourth most populous in California.",
            URL = "https://en.wikipedia.org/wiki/San_Francisco"
        });
        datasrc.Add(new CarouselDataBinding
        {
            Id = 2,
            ImgPath = "./../css/carousel/images/london.jpg",
            Title = "London",
            Content = "London, the capital of England and the United Kingdom, is a 21st-century city with history stretching back to Roman times. At its centre stand the imposing Houses of Parliament, the iconic ‘Big Ben’ clock tower and Westminster Abbey, site of British monarch coronations.",
            URL = "https://en.wikipedia.org/wiki/London"
        });
        datasrc.Add(new CarouselDataBinding
        {
            Id = 3,
            ImgPath = "./../css/carousel/images/tokyo.jpg",
            Title = "Tokyo",
            Content = "Tokyo, Japan’s busy capital, mixes the ultramodern and the traditional, from neon-lit skyscrapers to historic temples. The opulent Meiji Shinto Shrine is known for its towering gate and surrounding woods. The Imperial Palace sits amid large public gardens.",
            URL = "https://en.wikipedia.org/wiki/Tokyo"
        });
        datasrc.Add(new CarouselDataBinding
        {
            Id = 4,
            ImgPath = "./../css/carousel/images/moscow.jpg",
            Title = "Moscow",
            Content = "Moscow, on the Moskva River in western Russia, is the nation’s cosmopolitan capital. In its historic core is the Kremlin, a complex that’s home to the president and tsarist treasures in the Armoury. Outside its walls is Red Square, Russia`s symbolic center.",
            URL = "https://en.wikipedia.org/wiki/Moscow"
        });
    }
}
public class CarouselDataBinding
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string ImgPath { get; set; }
    public string URL { get; set; }
}