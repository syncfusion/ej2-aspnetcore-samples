#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.Pdf;
using Syncfusion.XlsIO;
using Syncfusion.XlsIORenderer;

namespace EJ2CoreSampleBrowser.Pages.Excel
{
    public class Comments : PageModel
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public Comments(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public ActionResult OnPost(string button)
        {
            string basePath = _hostingEnvironment.WebRootPath;

            if (button == null)
                return null;
            else if (button == "Input Template")
            {
                Stream ms = new FileStream(basePath + @"/XlsIO/CommentsTemplate.xlsx", FileMode.Open, FileAccess.Read);
                return File(ms, "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "CommentsTemplate.xlsx");
            }
            else if (button == "Create Document")
            {
                //Initialize ExcelEngine
                using (ExcelEngine excelEngine = new ExcelEngine())
                {
                    //Initialize IApplication and set the default application version
                    IApplication application = excelEngine.Excel;
                    application.DefaultVersion = ExcelVersion.Xlsx;

                    //Load the Excel template into IWorkbook and get the worksheet into IWorksheet
                    FileStream excelStream = new FileStream(basePath + @"/XlsIO/CommentsTemplate.xlsx", FileMode.Open);
                    IWorkbook workbook = application.Workbooks.Open(excelStream);
                    IWorksheet worksheet = workbook.Worksheets[0];

                    //Add Comments
                    AddComments(worksheet);

                    MemoryStream ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    ms.Position = 0;

                    excelEngine.Dispose();
                    excelStream.Dispose();

                    return File(ms, "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ExcelComments.xlsx");
                }
            }
            else
            {
                //Initialize ExcelEngine
                using (ExcelEngine excelEngine = new ExcelEngine())
                {
                    //Initialize IApplication and set the default application version
                    IApplication application = excelEngine.Excel;
                    application.DefaultVersion = ExcelVersion.Xlsx;

                    //Load the Excel template into IWorkbook and get the worksheet into IWorksheet
                    FileStream excelStream = new FileStream(basePath + @"/XlsIO/CommentsTemplate.xlsx", FileMode.Open);
                    IWorkbook workbook = application.Workbooks.Open(excelStream);
                    IWorksheet worksheet = workbook.Worksheets[0];

                    //Add Comments
                    AddComments(worksheet);

                    //Set print location of comments
                    worksheet.PageSetup.PrintComments = ExcelPrintLocation.PrintSheetEnd;

                    //Initialize XlsIORenderer and convert the Excel document to PDF
                    XlsIORenderer renderer = new XlsIORenderer();
                    PdfDocument document = renderer.ConvertToPDF(workbook);

                    MemoryStream ms = new MemoryStream();
                    document.Save(ms);
                    ms.Position = 0;

                    excelEngine.Dispose();
                    excelStream.Dispose();

                    return File(ms, "application/pdf", "ExcelComments.pdf");
                }
            }
        }
        private void AddComments(IWorksheet worksheet)
        {
            //Add Comments (Notes)
            IComment comment = worksheet.Range["H1"].AddComment();
            comment.Text = "This Total column comment will be printed at the end of sheet.";
            comment.IsVisible = true;

            //Add Threaded Comments
            IThreadedComment threadedComment = worksheet.Range["H16"].AddThreadedComment("What is the reason for the higher total amount of \"desk\"  in the west region?", "User1", DateTime.Now);
            threadedComment.AddReply("The unit cost of desk is higher compared to other items in the west region. As a result, the total amount is elevated.", "User2", DateTime.Now);
            threadedComment.AddReply("Additionally, Wilson sold 31 desks in the west region, which is also a contributing factor to the increased total amount.", "User3", DateTime.Now);
        }
    }
}
