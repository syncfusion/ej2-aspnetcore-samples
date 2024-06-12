#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.XlsIO;
using Syncfusion.Drawing;
using System.IO;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Controllers.Excel
{

    public partial class ExcelController : Controller
    {
        public ActionResult AutoFilter(string id, string FilterType, string button, string colorsList, string rdb1, string rdb3, string iconText, string iconSetTypeList, string field, string checkbox)
        {

            string basePath = _hostingEnvironment.WebRootPath;
            
            if (FilterType == null)
            {
                ViewBag.datasource = icons.GetSymbols(); 
                ViewBag.datasource2 = icons.GetRating();
                ViewBag.datasource3 = icons.GetArrows();
                return View();
            }
            else if (button == "Input Template")
            {
                //Step 1 : Instantiate the spreadsheet creation engine.
                ExcelEngine excelEngine = new ExcelEngine();
                //Step 2 : Instantiate the excel application object.
                IApplication application = excelEngine.Excel;
                IWorkbook workbook;
                if (FilterType == "Advanced Filter")
                {
                    FileStream inputStream = new FileStream(basePath + @"/XlsIO/AdvancedFilterData.xlsx", FileMode.Open, FileAccess.Read);
                    workbook = application.Workbooks.Open(inputStream);
                }
                else if(FilterType == "Color Filter")
                {
                    FileStream inputStream = new FileStream(basePath + @"/XlsIO/FilterData_Color.xlsx", FileMode.Open, FileAccess.Read);
                    workbook = application.Workbooks.Open(inputStream);
                }
                else if (FilterType == "Icon Filter")
                {
                    FileStream inputStream = new FileStream(basePath + @"/XlsIO/IconFilterData.xlsx", FileMode.Open, FileAccess.Read);
                    workbook = application.Workbooks.Open(inputStream);
                }
                else
                {
                    FileStream inputStream = new FileStream(basePath + @"/XlsIO/FilterData.xlsx", FileMode.Open, FileAccess.Read);
                    workbook = application.Workbooks.Open(inputStream);
                }
                MemoryStream ms = new MemoryStream();
                workbook.SaveAs(ms);
                ms.Position = 0;
                return File(ms, "Application/msexcel", "InputTemplate.xlsx");


            }
            else
            {
                string fileName = null;

                //Step 1 : Instantiate the spreadsheet creation engine.
                ExcelEngine excelEngine = new ExcelEngine();
                //Step 2 : Instantiate the excel application object.
                IApplication application = excelEngine.Excel;
                IWorkbook workbook;
                if (FilterType == "Advanced Filter")
                {
                    FileStream inputStream = new FileStream(basePath + @"/XlsIO/AdvancedFilterData.xlsx", FileMode.Open, FileAccess.Read);
                    workbook = application.Workbooks.Open(inputStream);
                }
                else if (FilterType == "Color Filter")
                {
                    FileStream inputStream = new FileStream(basePath + @"/XlsIO/FilterData_Color.xlsx", FileMode.Open, FileAccess.Read);
                    workbook = application.Workbooks.Open(inputStream);
                }
                else if (FilterType == "Icon Filter")
                {
                    FileStream inputStream = new FileStream(basePath + @"/XlsIO/IconFilterData.xlsx", FileMode.Open, FileAccess.Read);
                    workbook = application.Workbooks.Open(inputStream);
                }
                else
                {
                    FileStream inputStream = new FileStream(basePath + @"/XlsIO/FilterData.xlsx", FileMode.Open, FileAccess.Read);
                    workbook = application.Workbooks.Open(inputStream);
                }
                IWorksheet sheet = workbook.Worksheets[0];
                if (FilterType != "Advanced Filter")
                    sheet.AutoFilters.FilterRange = sheet.Range[1, 1, 49, 3];
                
                switch(FilterType)
                {
                    case "Custom Filter":
                        fileName = "CustomFilter.xlsx";
                        IAutoFilter filter1 = sheet.AutoFilters[0];
                        filter1.IsAnd = false;
                        filter1.FirstCondition.ConditionOperator = ExcelFilterCondition.Equal;
                        filter1.FirstCondition.DataType = ExcelFilterDataType.String;
                        filter1.FirstCondition.String = "Owner";

                        filter1.SecondCondition.ConditionOperator = ExcelFilterCondition.Equal;
                        filter1.SecondCondition.DataType = ExcelFilterDataType.String;
                        filter1.SecondCondition.String = "Sales Representative";            
                        break;
                         
                    case "Text Filter":
                        fileName = "TextFilter.xlsx";
                        IAutoFilter filter2 = sheet.AutoFilters[0];
                        filter2.AddTextFilter(new string[] { "Owner", "Sales Representative", "Sales Associate" });
                        break;

                    case "DateTime Filter":
                        fileName = "DateTimeFilter.xlsx";
                         IAutoFilter filter3 = sheet.AutoFilters[1];
                         filter3.AddDateFilter(new DateTime(2004, 9, 1, 1, 0, 0, 0), DateTimeGroupingType.month);
                         filter3.AddDateFilter(new DateTime(2011, 1, 1, 1, 0, 0, 0), DateTimeGroupingType.year);
                        break;

                    case "Dynamic Filter":
                        fileName = "DynamicFilter.xlsx";
                         IAutoFilter filter4 = sheet.AutoFilters[1];
                         filter4.AddDynamicFilter(DynamicFilterType.Quarter1);
                        break;

                    case "Color Filter":
                        fileName = "ColorFilter.xlsx";
                        #region ColorFilter
                        sheet.AutoFilters.FilterRange = sheet["A1:C49"];

                        Syncfusion.Drawing.Color color = Syncfusion.Drawing.Color.Empty;
                        switch (colorsList.ToLower())
                        {
                            case "red":
                                color = Color.Red;
                                break;
                            case "blue":
                                color = Color.Blue;
                                break;
                            case "green":
                                color = Color.Green;
                                break;
                            case "yellow":
                                color = Color.Yellow;
                                break;
                            case "empty":
                                color = Color.Empty;
                                break;
                        }
                        if (rdb3 == "FontColor")
                        {
                            IAutoFilter filter = sheet.AutoFilters[2];
                            filter.AddColorFilter(color, ExcelColorFilterType.FontColor);
                        }
                        else
                        {
                            IAutoFilter filter = sheet.AutoFilters[0];
                            filter.AddColorFilter(color, ExcelColorFilterType.CellColor);
                        }


                        #endregion
                        break;

                    case "Icon Filter":
                        fileName = "IconFilter.xlsx";
                        #region IconFilter
                        sheet.AutoFilters.FilterRange = sheet["A4:D44"];
                        int filterIndex = 0;
                        ExcelIconSetType iconset = ExcelIconSetType.FiveArrows;
                        int iconId = 0;
                        switch (iconSetTypeList)
                        {
                            case "ThreeSymbols":
                                iconset = ExcelIconSetType.ThreeSymbols;
                                filterIndex = 3;
                                break;
                            case "FourRating":
                                iconset = ExcelIconSetType.FourRating;
                                filterIndex = 1;
                                break;
                            case "FiveArrows":
                                iconset = ExcelIconSetType.FiveArrows;
                                filterIndex = 2;
                                break;
                        }
                        switch (iconText)
                        {
                            case "0":
                                //Do nothing
                                break;
                            case "1":
                                iconId = 1;
                                break;
                            case "2":
                                iconId = 2;
                                break;
                            case "3":
                                if (iconSetTypeList.Equals("ThreeSymbols"))
                                    iconset = (ExcelIconSetType)(-1);
                                else
                                    iconId = 3;
                                break;
                            case "4":
                                if (iconSetTypeList.Equals("FourRating"))
                                    iconset = (ExcelIconSetType)(-1);
                                else
                                    iconId = 4;
                                break;
                            case "5":
                                iconset = (ExcelIconSetType)(-1);
                                break;
                        }
                        IAutoFilter filter5 = sheet.AutoFilters[filterIndex];
                        filter5.AddIconFilter(iconset, iconId);
                        #endregion
                        break;

                    case "Advanced Filter":
                        fileName = "AdvancedFilter.xlsx";
                        #region AdvancedFilter

                        IRange filterRange = sheet.Range["A8:G51"];
                        IRange criteriaRange = sheet.Range["A2:B5"];
                        if (rdb1 == "FilterIN")
                        {
                            sheet.AdvancedFilter(ExcelFilterAction.FilterInPlace, filterRange, criteriaRange, null, checkbox == "Unique");
                        }
                        else if (rdb1 == "FilterCopy")
                        {
                            IRange range = sheet.Range["I7:O7"];
                            range.Merge();
                            range.Text = "FilterCopy";
                            range.CellStyle.Font.RGBColor = Syncfusion.Drawing.Color.FromArgb(0, 112, 192);
                            range.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                            range.CellStyle.Font.Bold = true;
                            IRange copyRange = sheet.Range["I8"];
                            sheet.AdvancedFilter(ExcelFilterAction.FilterCopy, filterRange, criteriaRange, copyRange, checkbox == "Unique");
                        }
                        break;
                        #endregion
                }
              
                workbook.Version = ExcelVersion.Excel2016;

                try
                {
                    MemoryStream result = new MemoryStream();
                    workbook.SaveAs(result);
                    result.Position = 0;


                    return File(result, "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                }
                catch (Exception)
                {
                }

                //Close the workbook.
                workbook.Close();
                excelEngine.Dispose();
                return View();
			}
        }

     

    }
}
