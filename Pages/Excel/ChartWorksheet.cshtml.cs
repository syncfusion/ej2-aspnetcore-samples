#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.XlsIO;
using Syncfusion.Drawing;

namespace EJ2CoreSampleBrowser.Pages.Excel
{
    public class ChartWorksheet : PageModel
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ChartWorksheet(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public ActionResult OnPost(string Saveoption)
        {
            if (Saveoption == null)
                return null;

            //New instance of XlsIO is created.[Equivalent to launching Microsoft Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;

            // Default version is set as Excel 2007
            if (Saveoption == "Xls")
                application.DefaultVersion = ExcelVersion.Excel97to2003;
            else
                application.DefaultVersion = ExcelVersion.Excel2016;

            //A new workbook is created.[Equivalent to creating a new workbook in Microsoft Excel]
            //The new workbook will have 1 worksheet.
            IWorkbook workbook = application.Workbooks.Create(1);
            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];

            // Entering the Datas for the chart
            sheet.Range["A1"].Text = "Crescent City, CA";
            sheet.Range["A1:D1"].Merge();
            sheet.Range["A1"].CellStyle.Font.Bold = true;

            sheet.Range["B3"].Text = "Precipitation,in.";
            sheet.Range["C3"].Text = "Temperature,deg.F";

            sheet.Range["A4"].Text = "Jan";
            sheet.Range["A5"].Text = "Feb";
            sheet.Range["A6"].Text = "March";
            sheet.Range["A7"].Text = "Apr";
            sheet.Range["A8"].Text = "May";
            sheet.Range["A9"].Text = "June";
            sheet.Range["A10"].Text = "July";
            sheet.Range["A11"].Text = "Aug";
            sheet.Range["A12"].Text = "Sept";
            sheet.Range["A13"].Text = "Oct";
            sheet.Range["A14"].Text = "Nov";
            sheet.Range["A15"].Text = "Dec";

            sheet.Range["B4"].Number = 10.9;
            sheet.Range["B5"].Number = 8.9;
            sheet.Range["B6"].Number = 8.6;
            sheet.Range["B7"].Number = 4.8;
            sheet.Range["B8"].Number = 3.2;
            sheet.Range["B9"].Number = 1.4;
            sheet.Range["B10"].Number = 0.6;
            sheet.Range["B11"].Number = 0.7;
            sheet.Range["B12"].Number = 1.7;
            sheet.Range["B13"].Number = 5.4;
            sheet.Range["B14"].Number = 9.0;
            sheet.Range["B15"].Number = 10.4;

            sheet.Range["C4"].Number = 47.5;
            sheet.Range["C5"].Number = 48.7;
            sheet.Range["C6"].Number = 48.9;
            sheet.Range["C7"].Number = 50.2;
            sheet.Range["C8"].Number = 53.1;
            sheet.Range["C9"].Number = 56.3;
            sheet.Range["C10"].Number = 58.1;
            sheet.Range["C11"].Number = 59.0;
            sheet.Range["C12"].Number = 58.5;
            sheet.Range["C13"].Number = 55.4;
            sheet.Range["C14"].Number = 51.1;
            sheet.Range["C15"].Number = 47.8;
            sheet.UsedRange.AutofitColumns();

            // Adding a New chart to the Existing Worksheet   
            IChart chart = workbook.Charts.Add();
            chart.DataRange = sheet.Range["A3:C15"];
            chart.Name = "CrescentCity,CA";
            chart.ChartTitle = "Crescent City, CA";
            chart.IsSeriesInRows = false;

            chart.PrimaryValueAxis.Title = "Precipitation,in.";
            chart.PrimaryValueAxis.TitleArea.TextRotationAngle = 90;
            chart.PrimaryValueAxis.MaximumValue = 14.0;
            chart.PrimaryValueAxis.NumberFormat = "0.0";

            // Format serie
            IChartSerie serieOne = chart.Series[0];
            serieOne.Name = "Precipitation,in.";
            serieOne.SerieFormat.Fill.FillType = ExcelFillType.Gradient;
            serieOne.SerieFormat.Fill.TwoColorGradient(ExcelGradientStyle.Vertical, ExcelGradientVariants.ShadingVariants_2);
            serieOne.SerieFormat.Fill.GradientColorType = ExcelGradientColor.TwoColor;
            serieOne.SerieFormat.Fill.ForeColor = Color.Plum;

            //Show value as data labels
            serieOne.DataPoints.DefaultDataPoint.DataLabels.IsValue = true;
            serieOne.DataPoints.DefaultDataPoint.DataLabels.Position = ExcelDataLabelPosition.Outside;

            //Format the second serie
            IChartSerie serieTwo = chart.Series[1];
            serieTwo.SerieType = ExcelChartType.Line_Markers;
            serieTwo.Name = "Temperature,deg.F";

            //Format marker
            serieTwo.SerieFormat.MarkerStyle = ExcelChartMarkerType.Diamond;
            serieTwo.SerieFormat.MarkerSize = 8;
            serieTwo.SerieFormat.MarkerBackgroundColor = Color.DarkGreen;
            serieTwo.SerieFormat.MarkerForegroundColor = Color.DarkGreen;
            serieTwo.SerieFormat.LineProperties.LineColor = Color.DarkGreen;

            //Use Secondary Axis
            serieTwo.UsePrimaryAxis = false;

            //Display secondary axis for the series.
            chart.SecondaryCategoryAxis.IsMaxCross = true;
            chart.SecondaryValueAxis.IsMaxCross = true;

            //Set the title
            chart.SecondaryValueAxis.Title = "Temperature,deg.F";
            chart.SecondaryValueAxis.TitleArea.TextRotationAngle = 90;

            //Hide the secondary category axis
            chart.SecondaryCategoryAxis.Border.LineColor = Color.Transparent;
            chart.SecondaryCategoryAxis.MajorTickMark = ExcelTickMark.TickMark_None;
            chart.SecondaryCategoryAxis.TickLabelPosition = ExcelTickLabelPosition.TickLabelPosition_None;

            chart.Legend.Position = ExcelLegendPosition.Bottom;
            chart.Legend.IsVerticalLegend = false;

            sheet.Move(1);
            chart.Activate();

            try
            {
                string ContentType = null;
                string fileName = null;
                if (Saveoption == "Xls")
                {
                    workbook.Version = ExcelVersion.Excel97to2003;
                    ContentType = "Application/vnd.ms-excel";
                    fileName = "Chart.xls";
                }
                else
                {
                    workbook.Version = ExcelVersion.Excel2013;
                    ContentType = "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    fileName = "Chart.xlsx";
                }

                MemoryStream ms = new MemoryStream();
                workbook.SaveAs(ms);
                ms.Position = 0;

                return File(ms, ContentType, fileName);
            }
            catch (Exception)
            {
            }

            // Close the workbook
            workbook.Close();
            excelEngine.Dispose();
            return null;
        }
    }
}

