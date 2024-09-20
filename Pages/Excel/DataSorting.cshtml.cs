#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.XlsIO;
using Syncfusion.Drawing;

namespace EJ2CoreSampleBrowser_NET8.Pages.Excel
{
    public class DataSorting : PageModel
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public DataSorting(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public ActionResult OnPost(string view, string SortData, string FirstColumn, string SecColumn, string SecondLevel, string ThirdColumn, string ThirdLevel, string SortBy, string Sortcolor, string colorSortBy, string cmbAlgorithm)
        {
            string basePath = _hostingEnvironment.WebRootPath;

            if (FirstColumn == null)
                return null;

            if (view == "View Input Template")
            {
                ExcelEngine excelEngine = new ExcelEngine();
                FileStream inputStream = new FileStream(basePath + @"/XlsIO/SortingData.xlsx", FileMode.Open, FileAccess.Read);
                IWorkbook workbook = excelEngine.Excel.Workbooks.Open(inputStream);
                try
                {

                    workbook.Version = ExcelVersion.Excel2013;
                    MemoryStream ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    ms.Position = 0;

                    return File(ms, "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "InputTemplate.xlsx");
                }
                catch (Exception)
                {
                }

                // Close the workbook
                workbook.Close();
                excelEngine.Dispose();
                return null;
            }

            if (SortData == "Sort Values")
            {
                int firstIndex, secIndex, thirdIndex;
                firstIndex = GetSelectedIndex(FirstColumn);
                secIndex = GetSelectedIndex(SecColumn);
                thirdIndex = GetSelectedIndex(ThirdColumn);
                bool secondLevel = (SecondLevel != null);
                bool thirdLevel = (ThirdLevel != null);
                OrderBy orderBy = (SortBy == "Ascending") ? OrderBy.Ascending : OrderBy.Descending;
                return SortValues(firstIndex, secIndex, thirdIndex, secondLevel, thirdLevel, orderBy);
            }

            return null;
        }
        #region Helper Methods
        private int GetSelectedIndex(string value)
        {
            switch (value)
            {
                case "ID": return 0;
                case "Name": return 1;
                case "Salary": return 3;
                default: return 0;
            }
        }
        private ActionResult SortColor(SortOn sortOn, int firstIndex, OrderBy orderBy)
        {
            string basePath = _hostingEnvironment.WebRootPath;

            ExcelEngine excelEngine = new ExcelEngine();
            FileStream inputStream = new FileStream(basePath + @"/XlsIO/SortingData.xlsx", FileMode.Open, FileAccess.Read);
            IWorkbook book = excelEngine.Excel.Workbooks.Open(inputStream);
            book.Version = ExcelVersion.Excel2016;
            IWorksheet sheet = book.Worksheets[1];
            IRange range = sheet["A2:C50"];

            IDataSort sorter = book.CreateDataSorter();
            sorter.SortRange = range;

            ISortField field = sorter.SortFields.Add(2, sortOn, orderBy);
            field.Color = Color.Red;
            field = sorter.SortFields.Add(2, sortOn, orderBy);
            field.Color = Color.Blue;
            sorter.Sort();
            book.Worksheets.Remove(0);

            try
            {

                book.Version = ExcelVersion.Excel2013;
                MemoryStream ms = new MemoryStream();
                book.SaveAs(ms);
                ms.Position = 0;

                return File(ms, "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Output.xlsx");
            }
            catch (Exception)
            {
            }

            // Close the workbook
            book.Close();
            excelEngine.Dispose();
            return null;

        }
        private ActionResult SortValues(int firstIndex, int secIndex, int thirdIndex, bool secondLevel, bool thirdLevel, OrderBy orderBy)
        {
            string basePath = _hostingEnvironment.WebRootPath;

            ExcelEngine excelEngine = new ExcelEngine();
            FileStream inputStream = new FileStream(basePath + @"/XlsIO/SortingData.xlsx", FileMode.Open, FileAccess.Read);
            IWorkbook book = excelEngine.Excel.Workbooks.Open(inputStream); IWorksheet sheet = book.Worksheets[0];

            IRange range = sheet["A2:D51"];

            //Create the data sorter.
            IDataSort sorter = book.CreateDataSorter();
            //Specify the range to sort.
            sorter.SortRange = range;


            //Specify the sort field attributes (column index and sort order)
            ISortField field = sorter.SortFields.Add(firstIndex, SortOn.Values, orderBy);
            //sort the data based on the sort field attributes.

            if (secondLevel)
            {
                field = sorter.SortFields.Add(secIndex, SortOn.Values, orderBy);
            }

            if (thirdLevel)
            {
                field = sorter.SortFields.Add(thirdIndex, SortOn.Values, orderBy);
            }
            sorter.Algorithm = SortingAlgorithms.QuickSort;
            sorter.Sort();
            book.Worksheets.Remove(1);
            try
            {

                book.Version = ExcelVersion.Excel2013;
                MemoryStream ms = new MemoryStream();
                book.SaveAs(ms);
                ms.Position = 0;

                return File(ms, "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Output.xlsx");
            }
            catch (Exception)
            {
            }

            // Close the workbook
            book.Close();
            excelEngine.Dispose();
            return null;
        }
        #endregion  
    }
}
