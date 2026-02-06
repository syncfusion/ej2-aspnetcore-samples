#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Barcode;

public class datamatrixModel : PageModel
{
    public List<coorectionLevel> encoding { get; set; }
    public List<coorectionLevel> size { get; set; }
    public void OnGet()
    { 
        encoding = new List<coorectionLevel>();
    encoding.Add(new coorectionLevel() { text = "Auto", value = "Auto" });
    encoding.Add(new coorectionLevel() { text = "ASCII", value = "ASCII" });
    encoding.Add(new coorectionLevel() { text = "ASCIINumeric", value = "ASCIINumeric" });
    encoding.Add(new coorectionLevel() { text = "Base256", value = "Base256" });


    size = new List<coorectionLevel>();
    size.Add(new coorectionLevel() { text = "Size22x22", value = "7" });
    size.Add(new coorectionLevel() { text = "Size24x24", value = "8" });
    size.Add(new coorectionLevel() { text = "Size26x26", value = "9" });
    size.Add(new coorectionLevel() { text = "Size32x32", value = "10" });
    size.Add(new coorectionLevel() { text = "Size36x36", value = "11" });
    size.Add(new coorectionLevel() { text = "Size40x40", value = "12" });
    size.Add(new coorectionLevel() { text = "Size44x44", value = "13" });
    size.Add(new coorectionLevel() { text = "Size48x48", value = "14" });
    size.Add(new coorectionLevel() { text = "Size52x52", value = "15" });
    size.Add(new coorectionLevel() { text = "Size64x64", value = "16" });
    size.Add(new coorectionLevel() { text = "Size72x72", value = "17" });
    size.Add(new coorectionLevel() { text = "Size80x80", value = "18" });
    size.Add(new coorectionLevel() { text = "Size88x88", value = "19" });
    size.Add(new coorectionLevel() { text = "Size96x96", value = "20" });
    size.Add(new coorectionLevel() { text = "Size104x104", value = "21" });
    size.Add(new coorectionLevel() { text = "Size120x120", value = "22" });
    size.Add(new coorectionLevel() { text = "Size132x132", value = "23" });
    size.Add(new coorectionLevel() { text = "Size144x144", value = "24" });
    size.Add(new coorectionLevel() { text = "Auto", value = "0" });
    size.Add(new coorectionLevel() { text = "Size10x10", value = "1" });
    size.Add(new coorectionLevel() { text = "Size12x12", value = "2" });
    size.Add(new coorectionLevel() { text = "Size14x14", value = "3" });
    size.Add(new coorectionLevel() { text = "Size16x16", value = "4" });
    size.Add(new coorectionLevel() { text = "Size18x18", value = "5" });
    size.Add(new coorectionLevel() { text = "Size20x20", value = "6" });
    size.Add(new coorectionLevel() { text = "Size8x18", value = "25" });
    size.Add(new coorectionLevel() { text = "Size8x32", value = "26" });
    size.Add(new coorectionLevel() { text = "Size12x26", value = "27" });
    size.Add(new coorectionLevel() { text = "Size12x36", value = "28" });
    size.Add(new coorectionLevel() { text = "Size16x36", value = "29" });
    size.Add(new coorectionLevel() { text = "Size16x48", value = "30" });
    }
}
public class coorectionLevel
{
    public string text;
    public string value;
}