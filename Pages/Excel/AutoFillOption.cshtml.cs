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
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Syncfusion.EJ2.Spreadsheet;

namespace EJ2CoreSampleBrowser.Pages.Excel
{
    public class AutoFillOption: PageModel
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public AutoFillOption(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        private bool m_isTrend;
        public bool IsTrend { get {return m_isTrend; } set {m_isTrend = value; } }
        public List<string> FillOptions { get; set; }
        private string m_fillType = "AutoFill";
        public string FillType 
        {
            get
            {
                return m_fillType;
            }
            set
            {
                m_fillType = value;
            }

        }

        public void OnGet(bool isTrend)
        {
            m_isTrend = isTrend;
            FillOptions = GetFillOptions(isTrend);
        }

        public List<string> GetFillOptions(bool isTrend)
        {

            List<string> options; 

            if (!isTrend)
            {
                options = new List<string>{
                                "Default",
                                "Copy",
                                "Series",
                                "Formats",
                                "Values",
                                "Days",
                                "Weekdays",
                                "Months",
                                "Years",
                                "Linear Trend",
                                "Growth Trend"
                            };
            }
            else
            {
                options = new List<string>() { "Linear", "Growth" };
            }

            return options;
        }
        public IActionResult OnPost(string FillOption, string StepValueText, string StopValueText, string SeriesBy, bool IsTrend, string FillType)
        {
            IWorkbook workbook;

            if (FillType.Contains("AutoFill"))
            {

                workbook = AutoFill(GetAutoFillEnum(FillOption));
            }
            else
            {

                workbook = AutoFill(GetFillSeriesEnum( FillOption), SeriesBy == "Rows" ? ExcelSeriesBy.Rows : ExcelSeriesBy.Columns, StepValueText, StopValueText, IsTrend);
            }

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;

            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", FillType.Contains("AutoFill")? "AutoFill.xlsx" : "FilleSeries.xlsx");
        }


        public IWorkbook AutoFill(ExcelAutoFillType autoFillOption)
        {

            //Instantiate the spreadsheet creation engine
            ExcelEngine excelEngine = new ExcelEngine();

            //Instantiate the excel application object
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Xlsx;
            IWorkbook workbook = application.Workbooks.Create(1);

            IWorksheet sheet = workbook.Worksheets[0];
            sheet["A1"].Number = 2;
            sheet["A2"].Number = 4;
            sheet["A3"].Number = 6;

            switch (autoFillOption)
            {
                case ExcelAutoFillType.FillDefault:
                case ExcelAutoFillType.FillCopy:
                case ExcelAutoFillType.FillValues:
                case ExcelAutoFillType.FillSeries:
                case ExcelAutoFillType.GrowthTrend:
                case ExcelAutoFillType.LinearTrend:
                    {
                        sheet["A1:A3"].AutoFill(sheet["A4:A1000"], autoFillOption);
                        break;
                    }
                case ExcelAutoFillType.FillFormats:
                    {
                        sheet["A1"].CellStyle.Color = Color.Blue;
                        sheet["A2"].CellStyle.Color = Color.Red;
                        sheet["A3"].CellStyle.Color = Color.Chocolate;
                        sheet["A1:A3"].NumberFormat = "$0.00";
                        sheet["A1:A3"].AutoFill(sheet["A4:A1000"], autoFillOption);
                        break;
                    }
                case ExcelAutoFillType.FillMonths:
                case ExcelAutoFillType.FillDays:
                case ExcelAutoFillType.FillWeekdays:
                case ExcelAutoFillType.FillYears:
                    {
                        DateTime dateTime = new DateTime(2025, 1, 1);
                        sheet["A1"].Value2 = dateTime;
                        sheet["A2"].Value2 = dateTime.AddDays(1);
                        sheet["A3"].Value2 = dateTime.AddDays(2);
                        sheet["A1:A3"].NumberFormat = "m/d/yyyy";
                        sheet["A1:A3"].AutoFill(sheet["A4:A1000"], autoFillOption);
                        break;
                    }

            }
            sheet.UsedRange.ColumnWidth = 10;
            return workbook;


        }

        /// <summary>
        /// Table Slicer
        /// </summary>
        /// <returns>Return the created excel document as stream</returns>
        public IWorkbook AutoFill(ExcelFillSeries fillSeries, ExcelSeriesBy seriesBy, object stepValue, object stopValue, bool enableTrend)
        {
            ExcelEngine excelEngine = new ExcelEngine();

            //Step 2 : Instantiate the excel application object
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2016;

            IWorkbook workbook = application.Workbooks.Create();
            IWorksheet sheet = workbook.Worksheets[0];
            if (seriesBy == ExcelSeriesBy.Columns)
            {
                sheet["A1"].Number = 2;
                sheet["A2"].Number = 4;
                sheet["A3"].Number = 6;
            }
            else
            {
                sheet["A1"].Number = 2;
                sheet["B1"].Number = 4;
                sheet["C1"].Number = 6;
            }

            stepValue = stepValue != null ? ConvertObject(stepValue.ToString()) : stepValue;
            stopValue = stopValue != null ? ConvertObject(stopValue.ToString()) : stopValue;

            switch (fillSeries)
            {
                case ExcelFillSeries.AutoFill:
                case ExcelFillSeries.Linear:
                case ExcelFillSeries.Growth:
                    break;
                case ExcelFillSeries.Years:
                case ExcelFillSeries.Days:
                case ExcelFillSeries.Weekdays:
                case ExcelFillSeries.Months:
                    {
                        if (seriesBy == ExcelSeriesBy.Columns)
                        {
                            DateTime dateTime = new DateTime(2025, 1, 1);
                            sheet["A1"].Value2 = dateTime;
                            sheet["A2"].Value2 = dateTime.AddDays(1);
                            sheet["A3"].Value2 = dateTime.AddDays(2);
                            sheet["A1:A3"].NumberFormat = "m/d/yyyy";
                        }
                        else
                        {
                            DateTime dateTime = new DateTime(2025, 1, 1);
                            sheet["A1"].Value2 = dateTime;
                            sheet["B1"].Value2 = dateTime.AddDays(1);
                            sheet["C1"].Value2 = dateTime.AddDays(2);
                            sheet["A1:C1"].NumberFormat = "m/d/yyyy";
                        }

                        break;
                    }

            }
            if (seriesBy == ExcelSeriesBy.Columns)
            {
                if (enableTrend)
                    sheet[1, 1, 1000, 1].FillSeries(seriesBy, fillSeries, enableTrend);
                else if (stepValue == null && stopValue == null)
                {
                    if (fillSeries == ExcelFillSeries.AutoFill)
                    {
                        sheet[1, 1, 1000, 1].FillSeries(seriesBy, fillSeries, enableTrend);
                    }
                }
                else if (stepValue == null && stopValue != null || stepValue != null && stopValue == null)
                {
                    bool isStepValue = stepValue != null ;
                    if (isStepValue)
                    {
                        if (stepValue is DateTime)
                            sheet[1, 1, 1000, 1].FillSeries(seriesBy, fillSeries, (DateTime)stepValue, isStepValue);
                        else if (stepValue is double)
                            sheet[1, 1, 1000, 1].FillSeries(seriesBy, fillSeries, (double)stepValue, isStepValue);
                    }
                    else
                    {
                        if (stopValue is DateTime)
                            sheet[1, 1, 1000, 1].FillSeries(seriesBy, fillSeries, (DateTime)stopValue, isStepValue);
                        else if (stopValue is double)
                            sheet[1, 1, 1000, 1].FillSeries(seriesBy, fillSeries, (double)stopValue, isStepValue);
                    }
                }
                else
                {
                    if (stepValue is DateTime && stopValue is DateTime)
                        sheet[1, 1, 1000, 1].FillSeries(seriesBy, fillSeries, (DateTime)stepValue, (DateTime)stopValue);
                    else if (stepValue is DateTime && stopValue is double)
                        sheet[1, 1, 1000, 1].FillSeries(seriesBy, fillSeries, (DateTime)stepValue, (double)stopValue);
                    else if (stepValue is double && stopValue is double)
                        sheet[1, 1, 1000, 1].FillSeries(seriesBy, fillSeries, (double)stepValue, (double)stopValue);
                    else if (stepValue is double && stopValue is DateTime)
                        sheet[1, 1, 1000, 1].FillSeries(seriesBy, fillSeries, (double)stepValue, (DateTime)stopValue);
                }
            }
            else
            {
                if (enableTrend)
                    sheet[1, 1, 1, 1000].FillSeries(seriesBy, fillSeries, enableTrend);
                else if (stepValue == null && stopValue == null)
                {
                    if (fillSeries == ExcelFillSeries.AutoFill)
                    {
                        sheet[1, 1, 1, 1000].FillSeries(seriesBy, fillSeries, enableTrend);
                    }
                }
                else if (stepValue == null && stopValue != null || stepValue != null && stopValue == null)
                {
                    bool isStepValue = stepValue != null;
                    if (isStepValue)
                    {
                        if (stepValue is DateTime)
                            sheet[1, 1, 1, 1000].FillSeries(seriesBy, fillSeries, (DateTime)stepValue, isStepValue);
                        else if (stepValue is double)
                            sheet[1, 1, 1, 1000].FillSeries(seriesBy, fillSeries, (double)stepValue, isStepValue);
                    }
                    else
                    {
                        if (stopValue is DateTime)
                            sheet[1, 1, 1, 1000].FillSeries(seriesBy, fillSeries, (DateTime)stopValue, isStepValue);
                        else if (stopValue is double)
                            sheet[1, 1, 1, 1000].FillSeries(seriesBy, fillSeries, (double)stopValue, isStepValue);
                    }
                }
                else
                {
                    if (stepValue is DateTime && stopValue is DateTime)
                        sheet[1, 1, 1, 1000].FillSeries(seriesBy, fillSeries, (DateTime)stepValue, (DateTime)stopValue);
                    else if (stepValue is DateTime && stopValue is double)
                        sheet[1, 1, 1, 1000].FillSeries(seriesBy, fillSeries, (DateTime)stepValue, (double)stopValue);
                    else if (stepValue is double && stopValue is double)
                        sheet[1, 1, 1, 1000].FillSeries(seriesBy, fillSeries, (double)stepValue, (double)stopValue);
                    else if (stepValue is double && stopValue is DateTime)
                        sheet[1, 1, 1, 1000].FillSeries(seriesBy, fillSeries, (double)stepValue, (DateTime)stopValue);
                }
            }
            sheet.UsedRange.ColumnWidth = 10;

            return workbook;

        }


        public object ConvertObject(string value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            if (double.TryParse(value, out double d)) return d;
            if (DateTime.TryParse(value, out DateTime dt)) return dt;
            return value;
        }

        private ExcelAutoFillType GetAutoFillEnum(string type)
        {
            switch (type)
            {
                case "Default":
                    return ExcelAutoFillType.FillDefault;
                case "Copy":
                    return ExcelAutoFillType.FillCopy;
                case "Series":
                    return ExcelAutoFillType.FillSeries;
                case "Formats":
                    return ExcelAutoFillType.FillFormats;
                case "Values":
                    return ExcelAutoFillType.FillValues;
                case "Days":
                    return ExcelAutoFillType.FillDays;
                case "Weekdays":
                    return ExcelAutoFillType.FillWeekdays;
                case "Months":
                    return ExcelAutoFillType.FillMonths;
                case "Years":
                    return ExcelAutoFillType.FillYears;
                case "Linear Trend":
                    return ExcelAutoFillType.LinearTrend;
                case "Growth Trend":
                    return ExcelAutoFillType.GrowthTrend;
                default:
                    return ExcelAutoFillType.FillDefault;
            }
        }
        private ExcelFillSeries GetFillSeriesEnum(string type)
        {
            switch (type)
            {
                case "Linear":
                    return ExcelFillSeries.Linear;
                case "Growth":
                    return ExcelFillSeries.Growth;
                case "Days":
                    return ExcelFillSeries.Days;
                case "Weekdays":
                    return ExcelFillSeries.Weekdays;
                case "Months":
                    return ExcelFillSeries.Months;
                case "Years":
                    return ExcelFillSeries.Years;
                case "Auto Fill":
                    return ExcelFillSeries.AutoFill;
                default:
                    return ExcelFillSeries.AutoFill;
            }
        }
    }

}
