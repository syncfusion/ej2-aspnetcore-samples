#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.ColorSpace;
using Syncfusion.Pdf.Functions;
using Syncfusion.Pdf.Graphics;

namespace EJ2CoreSampleBrowser.Pages.Pdf;

public class GraphicBrushes : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public GraphicBrushes(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public ActionResult OnPost(string InsideBrowser)
    {
        //Create a new PDF document
        PdfDocument document = new PdfDocument();
        document.PageSettings = new PdfPageSettings(new SizeF(300, 400));

        #region Graphic Brushes

        PdfPage page = document.Pages.Add();
        PdfGraphics graphics = page.Graphics;

        string basePath = _hostingEnvironment.WebRootPath;
        string dataPath = string.Empty;
        dataPath = basePath + @"/PDF/";

        //Read the file
        FileStream file = new FileStream(dataPath + "simple.jpg", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

        PdfImage image = PdfImage.FromStream(file);

        PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 8f, PdfFontStyle.Bold);
        PdfBrush textBrush = PdfBrushes.Black;

        graphics.DrawString("PDF Graphic Brushes", font, textBrush, new PointF(75, 20));
        #region SolidBrush
        graphics.DrawString("Solid Brush", font, textBrush, new PointF(85, 33));
        // Draw ellipse with solid brush.
        RectangleF rectangle = new RectangleF(20, 46, 50, 50);
        PdfSolidBrush brush = new PdfSolidBrush(Color.Black);

        graphics.DrawEllipse(brush, rectangle);

        graphics.TranslateTransform(60, 0);
        brush = new PdfSolidBrush(Color.Green);
        graphics.DrawEllipse(brush, rectangle);

        graphics.TranslateTransform(60, 0);
        brush.Color = Color.Red;
        graphics.DrawEllipse(brush, rectangle);
        #endregion

        #region TilingBrush

        // Draw ellipse with tiling brush.
        graphics.TranslateTransform(-120, 65);
        graphics.DrawString("Tiling Brush", font, textBrush, new PointF(85, 33));

        PdfTilingBrush tilingBrush = new PdfTilingBrush(new SizeF(10, 10));
        RectangleF rect = new RectangleF(0, 0, 10, 10);

        // Draw image on to the tiling brush.
        tilingBrush.Graphics.DrawImage(image, rect);

        // Draw ellipse using tiling brush.
        graphics.DrawEllipse(tilingBrush, rectangle);

        graphics.TranslateTransform(60, 0);
        tilingBrush = new PdfTilingBrush(rect);
        // Draw shapes inside tiling brush.
        tilingBrush.Graphics.DrawEllipse(PdfPens.Yellow, rect);
        tilingBrush.Graphics.DrawLine(PdfPens.Green, 0, 0, 10, 10);
        tilingBrush.Graphics.DrawLine(PdfPens.Red, 0, 10, 10, 0);
        graphics.DrawEllipse(tilingBrush, rectangle);

        graphics.TranslateTransform(60, 0);
        rect = new RectangleF(0, 0, 20, 20);
        PdfTilingBrush tilingBrushNew = new PdfTilingBrush(rect);
        tilingBrushNew.Graphics.DrawEllipse(tilingBrush, rect);
        graphics.DrawEllipse(tilingBrushNew, rectangle);
        #endregion

        #region HatchBrush
        // Draw ellipse with hatch brush.
        graphics.TranslateTransform(-120, 65);
        graphics.DrawString("Hatch Brush", font, textBrush, new PointF(85, 33));
        Color systemForeColor = Color.FromArgb(255, 255, 255, 0);
        Color systemBackColor = Color.FromArgb(255, 78, 167, 46);
        PdfHatchBrush hatchBrush = new PdfHatchBrush(PdfHatchStyle.Cross, new PdfColor(systemForeColor), new PdfColor(systemBackColor));

        graphics.DrawEllipse(PdfPens.Black, hatchBrush, rectangle);

        graphics.TranslateTransform(60, 0);
        systemForeColor = Color.FromArgb(255, 255, 0, 0);
        systemBackColor = Color.FromArgb(255, 78, 0, 46);
        hatchBrush = new PdfHatchBrush(PdfHatchStyle.DarkDownwardDiagonal, new PdfColor(systemForeColor), new PdfColor(systemBackColor)); graphics.DrawEllipse(brush, rectangle);
        graphics.DrawEllipse(PdfPens.Black, hatchBrush, rectangle);

        graphics.TranslateTransform(60, 0);
        systemForeColor = Color.FromArgb(255, 255, 0, 255);
        systemBackColor = Color.FromArgb(255, 78, 100, 46);
        hatchBrush = new PdfHatchBrush(PdfHatchStyle.SolidDiamond, new PdfColor(systemForeColor), new PdfColor(systemBackColor));
        graphics.DrawEllipse(PdfPens.Black, hatchBrush, rectangle);
        #endregion


        #region LinearGradientBrush
        // Draw ellipse with linear gradient brush.
        graphics.TranslateTransform(-120, 65);
        graphics.DrawString("Linear Gradient Brush", font, textBrush, new PointF(70, 33));
        PdfColor color1 = Color.Red;
        PdfColor color2 = Color.Yellow;

        // Create a new linear gradient brush.
        PdfGradientBrush gradientBrush = new PdfLinearGradientBrush(rectangle.Location, (PointF)rectangle.Size, color1, color2);

        // Format before draw.
        gradientBrush.AntiAlias = false;
        gradientBrush.Background = Color.Green;
        graphics.DrawEllipse(gradientBrush, rectangle);

        graphics.TranslateTransform(60, 0);
        color2 = Color.Green;
        gradientBrush = new PdfLinearGradientBrush(rectangle, color1, color2, 30f);
        gradientBrush.AntiAlias = true;
        graphics.DrawEllipse(gradientBrush, rectangle);

        graphics.TranslateTransform(60, 0);
        color1 = Color.Yellow;
        gradientBrush = new PdfLinearGradientBrush(rectangle, color1, color2, PdfLinearGradientMode.ForwardDiagonal);
        graphics.DrawEllipse(gradientBrush, rectangle);

        #endregion

        #region RadialGradientBrush
        // Draw ellipse with radial gradient brush.
        graphics.TranslateTransform(-120, 65);
        graphics.DrawString("Radial Gradient Brush", font, textBrush, new PointF(70, 33));
        color1 = Color.Red;
        color2 = Color.Yellow;

        PointF point = new PointF(25, 25);

        // Create a new radial gradient brush.
        gradientBrush = new PdfRadialGradientBrush(point, 50f, point, 5f, color1, color2);

        // Format before draw.
        gradientBrush.AntiAlias = false;
        gradientBrush.Background = Color.Green;
        graphics.DrawEllipse(gradientBrush, rectangle);
        #endregion
        graphics.TranslateTransform(0, -250f);
        PdfBrush onlyBrush = new PdfSolidBrush(Color.Black);
        graphics.DrawString("PDF Brushes", font, onlyBrush, new PointF(200, 23));

        Type type = typeof(PdfBrushes);
        object[] parameters = null;
        System.Reflection.PropertyInfo[] properties = type.GetProperties();

        for (int i = 0; i < properties.Length; i++)
        {
            onlyBrush = (PdfSolidBrush)properties[i].GetValue(null, parameters);
            graphics.DrawRectangle(onlyBrush, new RectangleF(200, 38, 50, 2));
            graphics.TranslateTransform(0, 2);
        }
        #endregion


        #region PdfColorSpace
        // Add a new page to the document.
        page = document.Pages.Add();
        PdfGraphics g = page.Graphics;
        g.DrawString("Color Spaces", font, textBrush, new PointF(100, 15));

        //Set DeviceRGB Colorspace.
        document.ColorSpace = PdfColorSpace.RGB;
        page.Graphics.DrawString("Device RGB", font, textBrush, new PointF(20, 30));
        PdfBrush brush1 = PdfBrushes.Green;
        g.DrawRectangle(brush1, new RectangleF(30, 45, 30, 30));

        //Set DeviceCMYK Colorspace.
        document.ColorSpace = PdfColorSpace.CMYK;
        page.Graphics.DrawString("Device CMYK", font, textBrush, new PointF(100, 30));
        g.DrawEllipse(brush1, new RectangleF(110, 45, 30, 30));

        //Set DeviceGray Colorspace.
        document.ColorSpace = PdfColorSpace.GrayScale;
        page.Graphics.DrawString("Device Gray", font, textBrush, new PointF(180, 30));
        g.DrawPie(brush1, new RectangleF(190, 45, 30, 30), 0, 45);
        #endregion

        #region CIE Based Color Space

        #region CalRGB Color
        document.ColorSpace = PdfColorSpace.RGB;

        g.DrawString("CalRGB Color", font, textBrush, new PointF(20, 82));

        rect = new RectangleF(30, 97, 30, 30);

        // Create a new instance of PdfCalRGBColorSpace class.
        PdfCalRGBColorSpace calRgbCS = new PdfCalRGBColorSpace();
        calRgbCS.Gamma = new double[] { 1.6, 1.1, 2.5 };
        calRgbCS.Matrix = new double[] { 1, 0, 0, 0, 1, 0, 0, 0, 1 };
        calRgbCS.WhitePoint = new double[] { 0.2, 1, 0.8 };

        // Create a new instance of PdfCalRGBColor class.
        PdfCalRGBColor calRGBColor = new PdfCalRGBColor(calRgbCS);
        calRGBColor.Red = 0;
        calRGBColor.Green = 1;
        calRGBColor.Blue = 0;

        // Create brush from CalRGBColor.
        PdfBrush colorSpaceBrush = new PdfSolidBrush(calRGBColor);

        // Draw using CalRGBColor brush.
        g.DrawRectangle(colorSpaceBrush, rect);
        #endregion

        #region CalGray Color
        g.DrawString("CalGray Color", font, textBrush, new PointF(100, 82));
        rect = new RectangleF(110, 97, 30, 30);

        // Create a new instance of PdfCalGrayColorSpace class.
        PdfCalGrayColorSpace calGrayCS = new PdfCalGrayColorSpace();
        calGrayCS.Gamma = 0.7;
        calGrayCS.WhitePoint = new double[] { 0.2, 1, 0.8 };

        // Create a new instance of PdfCalGrayColor class.
        PdfCalGrayColor calGrayColor = new PdfCalGrayColor(calGrayCS);
        calGrayColor.Gray = 0.1;

        // Create brush from PdfCalGrayColor.
        colorSpaceBrush = new PdfSolidBrush(calGrayColor);

        // Draw using PdfCalGrayColor brush.
        g.DrawRectangle(colorSpaceBrush, rect);
        #endregion

        #region Lab Color
        g.DrawString("Lab Color", font, textBrush, new PointF(180, 82));

        rect = new RectangleF(190, 97, 30, 30);

        // Create a new instance of PdfLabColorSpace class.
        PdfLabColorSpace labCS = new PdfLabColorSpace();
        labCS.Range = new double[] { 0.2, 1, 0.8, 23.5 };
        labCS.WhitePoint = new double[] { 0.2, 1, 0.8 };

        // Create a new instance of PdfLabColor class.
        PdfLabColor labColor = new PdfLabColor(labCS);
        labColor.L = 90;
        labColor.A = 0.5;
        labColor.B = 20;

        // Create brush using PdfLabColor.
        colorSpaceBrush = new PdfSolidBrush(labColor);

        // Draw using PdfLabColor brush.
        g.DrawRectangle(colorSpaceBrush, rect);
        #endregion

        #region ICC Color

        g.DrawString("ICC Color", font, textBrush, new PointF(20, 134));
        rect = new RectangleF(30, 149, 30, 30);

        PdfCalRGBColorSpace calRgbCS3 = new PdfCalRGBColorSpace();
        calRgbCS3.Gamma = new double[] { 7.6, 5.1, 8.5 };
        calRgbCS3.Matrix = new double[] { 1, 0, 0, 0, 1, 0, 0, 0, 1 };
        calRgbCS3.WhitePoint = new double[] { 0.7, 1, 0.8 };

        // Read the ICC profile.
        FileStream fs = new FileStream(dataPath + "rgb.icc", FileMode.Open, FileAccess.Read);
        byte[] profileData = new byte[fs.Length];
        fs.Read(profileData, 0, profileData.Length);
        fs.Dispose();

        PdfICCColorSpace IccBasedCS4 = new PdfICCColorSpace();
        IccBasedCS4.ProfileData = profileData;
        IccBasedCS4.AlternateColorSpace = calRgbCS3;
        IccBasedCS4.ColorComponents = 3;
        IccBasedCS4.Range = new double[] { 0.0, 1.0, 0.0, 1.0, 0.0, 1.0 };
        PdfICCColor red4 = new PdfICCColor(IccBasedCS4);
        red4.ColorComponents = new double[] { 1, 0, 1 };
        colorSpaceBrush = new PdfSolidBrush(red4);

        g.DrawRectangle(colorSpaceBrush, rect);

        #endregion

        #region Separation Color

        g.DrawString("Separation Color", font, textBrush, new PointF(100, 134));
        rect = new RectangleF(110, 149, 30, 30);

        PdfExponentialInterpolationFunction function = new PdfExponentialInterpolationFunction(true);
        float[] numArray = new float[3];
        numArray[0] = 90f;
        numArray[1] = 0.5f;
        numArray[2] = 20f;
        function.C1 = numArray;

        PdfLabColorSpace calLabCS8 = new PdfLabColorSpace();
        calLabCS8.Range = new double[] { 0.2, 1, 0.8, 23.5 };
        calLabCS8.WhitePoint = new double[] { 0.2, 1, 0.8 };

        PdfSeparationColorSpace colorspace8 = new PdfSeparationColorSpace();
        colorspace8.AlternateColorSpaces = calLabCS8;
        colorspace8.TintTransform = function;
        colorspace8.Colorant = "PANTONE Orange 021 C";
        PdfSeparationColor color8 = new PdfSeparationColor(colorspace8);
        color8.Tint = 0.7;

        colorSpaceBrush = new PdfSolidBrush(color8);
        g.DrawRectangle(colorSpaceBrush, rect);

        #endregion

        #region Indexed Color

        g.DrawString("Indexed Color", font, textBrush, new PointF(180, 134));
        rect = new RectangleF(190, 149, 30, 30);

        PdfIndexedColorSpace colorspace7 = new PdfIndexedColorSpace();
        colorspace7.BaseColorSpace = new PdfDeviceColorSpace(PdfColorSpace.RGB);
        colorspace7.MaxColorIndex = 3;
        colorspace7.IndexedColorTable = new byte[] { 150, 0, 222, 255, 0, 0, 0, 255, 0, 0, 0, 255 };

        PdfIndexedColor color7 = new PdfIndexedColor(colorspace7);
        color7.SelectColorIndex = 3;

        colorSpaceBrush = new PdfSolidBrush(color7);
        g.DrawRectangle(colorSpaceBrush, rect);

        #endregion

        #endregion

        //Save the PDF to the MemoryStream
        MemoryStream ms = new MemoryStream();

        document.Save(ms);

        //If the position is not set to '0' then the PDF will be empty.
        ms.Position = 0;

        //Close the PDF document.
        document.Close(true);

        //Download the PDF document in the browser.
        FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
        fileStreamResult.FileDownloadName = "GraphicBrushes.pdf";
        return fileStreamResult;
    }
}