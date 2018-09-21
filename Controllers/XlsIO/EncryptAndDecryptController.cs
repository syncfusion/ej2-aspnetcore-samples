#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
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
using Syncfusion.XlsIO;
using Syncfusion.Drawing;
using System.Globalization;
using System.IO;

namespace EJ2CoreSampleBrowser.Controllers.XlsIO
{
    public partial class XlsIOController : Controller
    {
        //
        // GET: /EncryptAndDecrypt/
        public ActionResult EncryptAndDecrypt(string button, string SaveOption)
        {
            string basePath = _hostingEnvironment.WebRootPath;

            if (button == null)
                return View();

            else if (button == "Encrypt Document")
            {

                //New instance of XlsIO is created.[Equivalent to launching Microsoft Excel with no workbooks open].
                //The instantiation process consists of two steps.

                //Step 1 : Instantiate the spreadsheet creation engine.
                ExcelEngine excelEngine = new ExcelEngine();

                //Step 2 : Instantiate the excel application object.
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2016;

                FileStream inputStream = new FileStream(ResolveApplicationPath("Encrypt.xlsx"), FileMode.Open, FileAccess.Read);
                
                // Opening the Existing Worksheet from a Workbook.
                IWorkbook workbook = application.Workbooks.Open(inputStream);
                
                //Encrypt the workbook with password.
                workbook.PasswordToOpen = "PASSWORD";

                try
                {
                    string ContentType = null;
                    string fileName = null;
                    if (SaveOption == "Xls")
                    {
                        workbook.Version = ExcelVersion.Excel97to2003;
                        ContentType = "Application/vnd.ms-excel";
                        fileName = "EncryptedWorkbook.xls";
                    }
                    else
                    {
                        workbook.Version = ExcelVersion.Excel2013;
                        ContentType = "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        fileName = "EncryptedWorkbook1.xlsx";
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

                FileStream inputStream = new FileStream(ResolveApplicationPath("EncryptedWorkbook.xlsx"), FileMode.Open, FileAccess.Read);
                // Opening the encrypted Workbook.
                IWorkbook workbook = application.Workbooks.Open(inputStream, ExcelParseOptions.Default, true, "PASSWORD");

                //Modify the decrypted document.
                workbook.Worksheets[0].Range["B2"].Text = "Demo for workbook decryption with Essential XlsIO";
                workbook.Worksheets[0].Range["B5"].Text = "This document is decrypted using password 'PASSWORD'.";

                workbook.PasswordToOpen = "";

                try
                {
                    string ContentType = null;
                    string fileName = null;
                    if (SaveOption == "Xls")
                    {
                        workbook.Version = ExcelVersion.Excel97to2003;
                        ContentType = "Application/vnd.ms-excel";
                        fileName = "EncryptAndDecrypt.xls";
                    }
                    else
                    {
                        workbook.Version = ExcelVersion.Excel2013;
                        ContentType = "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        fileName = "EncryptAndDecrypt.xlsx";
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
            }
            return View();
        }

    }
}
