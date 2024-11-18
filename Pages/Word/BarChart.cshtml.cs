#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.OfficeChart;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.DocIORenderer;

namespace EJ2CoreSampleBrowser.Pages.Word;

public class BarChart : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public BarChart(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public ActionResult OnPost(string Group1)
    {
        if (Group1 == null)
            return null;
            // return View();

        //A new document is created.
        WordDocument document = new WordDocument();
        //Add new section to the Word document
        IWSection section = document.AddSection();
        //Set page margins of the section
        section.PageSetup.Margins.All = 72;
        //Add new paragraph to the section
        IWParagraph paragraph = section.AddParagraph();
        //Apply heading style to the title paragraph
        paragraph.ApplyStyle(BuiltinStyle.Heading1);
        //Apply center alignment to the paragraph
        paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
        //Append text to the paragraph
        paragraph.AppendText("Northwind Management Report").CharacterFormat.TextColor =
            Syncfusion.Drawing.Color.FromArgb(46, 116, 181);
        //Add new paragraph
        paragraph = section.AddParagraph();
        //Set before spacing to the paragraph
        paragraph.ParagraphFormat.BeforeSpacing = 20;
        string basePath = _hostingEnvironment.WebRootPath;
        string dataPath = basePath + @"/Word/Excel_Template.xlsx";
        //Load the excel template as stream
        Stream excelStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read);
        //Create and Append chart to the paragraph with excel stream as parameter
        WChart BarChart = paragraph.AppendChart(excelStream, 1, "B2:C6", 470, 300);
        //Set chart data
        BarChart.ChartType = OfficeChartType.Bar_Clustered;
        BarChart.ChartTitle = "Purchase Details";
        BarChart.ChartTitleArea.FontName = "Calibri (Body)";
        BarChart.ChartTitleArea.Size = 14;
        //Set name to chart series            
        BarChart.Series[0].Name = "Sum of Purchases";
        BarChart.Series[1].Name = "Sum of Future Expenses";
        //Set Chart Data table
        BarChart.HasDataTable = true;
        BarChart.DataTable.HasBorders = true;
        BarChart.DataTable.HasHorzBorder = true;
        BarChart.DataTable.HasVertBorder = true;
        BarChart.DataTable.ShowSeriesKeys = true;
        BarChart.HasLegend = false;
        //Setting background color
        BarChart.ChartArea.Fill.ForeColor = Syncfusion.Drawing.Color.FromArgb(208, 206, 206);
        BarChart.PlotArea.Fill.ForeColor = Syncfusion.Drawing.Color.FromArgb(208, 206, 206);
        //Setting line pattern to the chart area
        BarChart.PrimaryCategoryAxis.Border.LinePattern = OfficeChartLinePattern.None;
        BarChart.PrimaryValueAxis.Border.LinePattern = OfficeChartLinePattern.None;
        BarChart.ChartArea.Border.LinePattern = OfficeChartLinePattern.None;
        BarChart.PrimaryValueAxis.MajorGridLines.Border.LineColor = Syncfusion.Drawing.Color.FromArgb(175, 171, 171);
        //Set label for primary catagory axis
        BarChart.PrimaryCategoryAxis.CategoryLabels = BarChart.ChartData[2, 1, 6, 1];

        string filename = "";
        string contenttype = "";
        MemoryStream ms = new MemoryStream();

        #region Document SaveOption

        if (Group1 == "WordDocx")
        {
            filename = "BarChart.docx";
            contenttype = "application/msword";
            document.Save(ms, FormatType.Docx);
        }
        else if (Group1 == "WordML")
        {
            filename = "BarChart.xml";
            contenttype = "application/msword";
            document.Save(ms, FormatType.WordML);
        }
        else
        {
            filename = "BarChart.pdf";
            contenttype = "application/pdf";
            DocIORenderer renderer = new DocIORenderer();
            renderer.ConvertToPDF(document).Save(ms);
        }

        #endregion Document SaveOption

        document.Close();
        ms.Position = 0;
        return File(ms, contenttype, filename);
    }
}