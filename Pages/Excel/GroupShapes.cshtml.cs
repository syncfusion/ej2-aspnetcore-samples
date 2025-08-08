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

namespace EJ2CoreSampleBrowser.Pages.Excel
{
    public class GroupShapes : PageModel
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public GroupShapes(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public ActionResult OnPost(string button, string Group1)
        {
            string basePath = _hostingEnvironment.WebRootPath;

            if (button == null)
                return null;

            else if (button == "Input Document")
            {
                //New instance of XlsIO is created.[Equivalent to launching Microsoft Excel with no workbooks open].
                //The instantiation process consists of two steps.

                //Step 1 : Instantiate the spreadsheet creation engine.
                ExcelEngine excelEngine = new ExcelEngine();

                //Step 2 : Instantiate the excel application object.
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2016;

                FileStream inputStream = new FileStream(basePath + @"/XlsIO/GroupShapes.xlsx", FileMode.Open, FileAccess.Read);

                // Opening the Existing Worksheet from a Workbook.
                IWorkbook workbook = application.Workbooks.Open(inputStream);

                try
                {
                    workbook.Version = ExcelVersion.Excel2013;
                    string ContentType = "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    string fileName = "GroupShapes.xlsx";

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
            }
            else
            {
                //New instance of XlsIO is created.[Equivalent to launching Microsoft Excel with no workbooks open].
                //The instantiation process consists of two steps.

                //Step 1 : Instantiate the spreadsheet creation engine.
                ExcelEngine excelEngine = new ExcelEngine();

                //Step 2 : Instantiate the excel application object.
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2016;

                FileStream inputStream = new FileStream(basePath + @"/XlsIO/GroupShapes.xlsx", FileMode.Open, FileAccess.Read);
                // Opening the encrypted Workbook.
                IWorkbook workbook = application.Workbooks.Open(inputStream, ExcelParseOptions.Default, true, "PASSWORD");

                IWorksheet worksheet;

                if (Group1 == "Group")
                {
                    // The first worksheet object in the worksheets collection is accessed.
                    worksheet = workbook.Worksheets[0];
                    IShapes shapes = worksheet.Shapes;

                    IShape[] groupItems;
                    for (int i = 0; i < shapes.Count; i++)
                    {
                        if (shapes[i].Name == "Development" || shapes[i].Name == "Production" || shapes[i].Name == "Sales")
                        {
                            groupItems = new IShape[] { shapes[i], shapes[i + 1], shapes[i + 2], shapes[i + 3], shapes[i + 4], shapes[i + 5] };
                            shapes.Group(groupItems);
                            i = -1;
                        }
                    }

                    groupItems = new IShape[] { shapes[0], shapes[1], shapes[2], shapes[3], shapes[4], shapes[5], shapes[6] };

                    // Group the selected shapes
                    shapes.Group(groupItems);
                }
                else if (Group1 == "UngroupAll")
                {
                    // The second worksheet object in the worksheets collection is accessed.
                    worksheet = workbook.Worksheets[1];
                    IShapes shapes = worksheet.Shapes;

                    // Ungroup group shape and its all the inner shapes.
                    shapes.Ungroup(shapes[0] as IGroupShape, true);
                    worksheet.Activate();
                }
                else if (Group1 == "Ungroup")
                {
                    // The second worksheet object in the worksheets collection is accessed.
                    worksheet = workbook.Worksheets[1];
                    IShapes shapes = worksheet.Shapes;

                    // Ungroup group shape.
                    shapes.Ungroup(shapes[0] as IGroupShape);
                    worksheet.Activate();
                }

                try
                {
                    workbook.Version = ExcelVersion.Excel2013;
                    string ContentType = "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    string fileName = "GroupShapes.xlsx";

                    MemoryStream ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    ms.Position = 0;

                    return File(ms, ContentType, fileName);
                }
                catch
                {

                }

                // Close the workbook
                workbook.Close();
                excelEngine.Dispose();
            }
            return null;
        }
    }
}
