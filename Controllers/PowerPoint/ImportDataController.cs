#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Syncfusion.Presentation;
using Microsoft.AspNetCore.Hosting;
using EJ2CoreSampleBrowser.Models;
using Syncfusion.EJ2.Base;
using System.Collections.Generic;
using System.Collections;
using Syncfusion.OfficeChart;
using System.Globalization;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class PowerPointController : Controller
    {
        private List<DataPosition> order1 = new List<DataPosition>();
        #region Action Methods
        /// <summary>
        /// Imports the data to the Grid.
        /// </summary>
        /// <returns></returns>
        public ActionResult ImportData()
        {
            if(PresentationData.presentationData == null)
            {
                PresentationData.presentationData = new PresentationData().GetAllRecords();
                order1.Add(new DataPosition() { text = "Top" });
                order1.Add(new DataPosition() { text = "Bottom" });
                ViewBag.ddData = order1;
            }
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="button">Button name to perfrom specific operation</param>
        /// <param name="Group">Radio button group value</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ImportData(string button, string Group)
        {
            if (button == null)
                return View();
            //Instatiate the presentation
            IPresentation presentation = null;
            //Checks whether the export option is table
            if (Group == "Table")
            {
                //Gets the generated presentation after importing the data to the presentation slide as table
                presentation = CreateTableFromGrid();
            }
            else if (Group == "Chart")
            {
                //Gets the generated presentation after importing the data to the presentation slide as chart
                presentation = CreateChartFromGrid();
            }

            MemoryStream ms = new MemoryStream();

            //Saves the presentation to the memory stream.
            presentation.Save(ms);
            //Set the position of the stream to beginning.
            ms.Position = 0;

            //Initialize the file stream to download the presentation.
            FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/vnd.openxmlformats-officedocument.presentationml.presentation");
            //Set the file name.
            fileStreamResult.FileDownloadName = Group + ".pptx";

            return fileStreamResult;

        }
        /// <summary>
        /// Update the edited data to the Grid
        /// </summary>
        /// <param name="Object"></param>
        /// <returns></returns>
        public ActionResult Update([FromBody] CRUDModel model)
        {
            var ord = model.Value;
            PresentationData val = PresentationData.presentationData.Where(or => or.Year == ord.Year).FirstOrDefault();
            if(val != null)
            {
                val.Year = ord.Year;
                val.Jan = ord.Jan;
                val.Feb = ord.Feb;
                val.Mar = ord.Mar;
                val.Apr = ord.Apr;
                val.May = ord.May;
            }
            return Json(model.Value);
        }
        /// <summary>
        /// Delete the specific data from the grid
        /// </summary>
        /// <param name="Object"></param>
        /// <returns></returns>
        public ActionResult Delete([FromBody] CRUDModel model)
        {
            var ord = model.Value;
            var key = model.key;
            PresentationData.presentationData.Remove(PresentationData.presentationData.Where(or => or.Year == int.Parse(key.ToString())).FirstOrDefault());
            IEnumerable DataSource = PresentationData.presentationData;
            return Json(DataSource);
        }
        /// <summary>
        /// Insert the data into the start position of the grid
        /// </summary>
        /// <param name="Object"></param>
        /// <returns></returns>
        public ActionResult Insert([FromBody] CRUDModel model)
        {
            int insertPosition = 0;
            string position = PresentationData.dropBoxValue;
            if (position == "Bottom")
            {
                insertPosition = PresentationData.presentationData.Count;
            }
            else
            {
                insertPosition = 0;
            }
            var ord = model.Value;
            PresentationData.presentationData.Insert(insertPosition, ord);
            return Json(model.Value);
        }
        /// <summary>
        /// Gets the data from server and update it to the grid
        /// </summary>
        /// <param name="dm"></param>
        /// <returns></returns>
        public ActionResult UrlDatasource([FromBody] DataManagerRequest dm)
        {
            //Gets the data
            IEnumerable DataSource = PresentationData.presentationData;
            //Create a new instance of DataOperations
            DataOperations operation = new DataOperations();
            //Gets the count of the data
            int count = DataSource.Cast<PresentationData>().Count();
            if (dm.Skip != 0)
            {
                DataSource = operation.PerformSkip(DataSource, dm.Skip);
            }
            if (dm.Take != 0)
            {
                DataSource = operation.PerformTake(DataSource, dm.Take);
            }
            return dm.RequiresCounts ? Json(new { result = DataSource, count = count }) : Json(DataSource);

        }
        /// <summary>
        /// Gets the current position of Grid to add data into the grid
        /// </summary>
        /// <param name="position">Gets the position of the value should get added from the View</param>
        /// <returns></returns>
        public IActionResult Dropdown([FromBody] CRUDModel model)
        {
            var value = model.rowPosition;
            PresentationData.dropBoxValue = value;
            return View();
        }
        #endregion
        #region Helper Methods
        /// <summary>
        /// Exports the Data as chart to the PowerPoint Slide
        /// </summary>
        /// <returns>Returns the generated presentation</returns>
        private IPresentation CreateChartFromGrid()
        {
            string basePath = _hostingEnvironment.WebRootPath;
            FileStream fileStreamInput = new FileStream(basePath + @"/PowerPoint/DataTemplate.pptx", FileMode.Open, FileAccess.Read);
            IPresentation presentation = Presentation.Open(fileStreamInput);
            foreach (ISlide slide in presentation.Slides)
            {
                //Iterate each shape in the slide
                for (int i = 0; i < slide.Shapes.Count; i++)
                {
                    //Retrieves the shape
                    IShape shape = slide.Shapes[i] as IShape;
                    //Removes the shape from the shape collection.
                    slide.Shapes.Remove(shape);
                }
            }
            int slideIndex = 0;
            //Clone the slide
            ISlide clonedSlide = presentation.Slides[0].Clone();
            //Iterate each data of the Grid
            foreach (PresentationData presentationData in PresentationData.presentationData)
            {
                if (slideIndex > 0)
                {
                    presentation.Slides.Add(clonedSlide);
                }
                //Gets the slide of the presentation
                ISlide slide = slide = presentation.Slides[slideIndex];
                //Adds chart to the slide with position and size
                IPresentationChart chart = slide.Charts.AddChart(100, 10, 700, 500);
                //Set the first row of the chart values
                chart.ChartData.SetValue(1, 2, "Jan");
                chart.ChartData.SetValue(1, 3, "Feb");
                chart.ChartData.SetValue(1, 4, "Mar");
                chart.ChartData.SetValue(1, 5, "Apr");
                chart.ChartData.SetValue(1, 6, "May");
                //Initalize the row index
                int rowIndex = 2;
                int?[] array = new int?[] { presentationData.Year, presentationData.Jan, presentationData.Feb, presentationData.Mar, presentationData.Apr, presentationData.May };
                for (int i = 0; i < array.Length; i++)
                {
                    //Initialize the column index
                    int columnIndex = i + 1;
                    //Set the value for chart
                    chart.ChartData.SetValue(rowIndex, columnIndex, array[i].Value);
                    if (columnIndex == array.Length)
                    {
                        //Creates a new chart series with the name
                        IOfficeChartSerie series = chart.Series.Add(array[0].Value.ToString());

                        //Sets the data range of chart series � start row, start column, end row, end column
                        series.Values = chart.ChartData[2, 2, 2, 6];

                        //Sets the data range of the category axis
                        chart.PrimaryCategoryAxis.CategoryLabels = chart.ChartData[1, 2, 1, 6];

                        //Sets the type of the chart
                        chart.ChartType = OfficeChartType.Pie;

                        //Sets a value indicates wherher to fill style is visible or not
                        chart.ChartArea.Fill.Visible = false;

                        IOfficeChartFrameFormat chartPlotArea = chart.PlotArea;
                        //Sets a value indicates wherher to fill style is visible or not
                        chartPlotArea.Fill.Visible = false;

                        //Specifies the chart title
                        chart.ChartTitle = "Sales details of the year " + array[0].Value.ToString();

                        //Sets the legend position
                        chart.Legend.Position = OfficeLegendPosition.Right;
                    }
                }
                rowIndex++;
                slideIndex++;
            }
            return presentation;
        }

        /// <summary>
        /// Exports the Data as table to the PowerPoint Slide
        /// </summary>
        /// <returns>Returns the generated presentation</returns>
        private IPresentation CreateTableFromGrid()
        {
            string basePath = _hostingEnvironment.WebRootPath;
            FileStream fileStreamInput = new FileStream(basePath + @"/PowerPoint/DataTemplate.pptx", FileMode.Open, FileAccess.Read);
            IPresentation presentation = Presentation.Open(fileStreamInput);
            //Clone the first slide of the presentation
            ISlide clonedSlide = presentation.Slides[0].Clone();
            //Initialize the slide index value
            int slideIndex = 0;
            //Create a new instance of slide
            ISlide slide = null;
            //Iterate and get data from Grid
            foreach (PresentationData presentationData in PresentationData.presentationData)
            {
                //Fetch all the grid details to array
                int?[] array = new int?[] { presentationData.Year, presentationData.Jan, presentationData.Feb, presentationData.Mar, presentationData.Apr, presentationData.May };
                //Check whether the current slide is the first slide or not
                if (slideIndex > 0)
                {
                    //Adds the cloned slide to the presentation
                    presentation.Slides.Add(clonedSlide);
                }
                //Gets the slide based on slide index from presentation
                slide = presentation.Slides[slideIndex];
                //Checks whether the slide has table    
                if (slide.Tables.Count > 0)
                {
                    //Gets the first occurrence of table
                    ITable oldTable = slide.Tables[0];
                    //Iterate each data from the grid
                    for (int i = 0; i < array.Length; i++)
                    {
                        //Gets the current instance of table cell
                        ICell cell = oldTable[i, 1];
                        //Checks whether the current cell is first row and second column
                        if (i == 0)
                        {
                            //Add paragraph to the cell
                            cell.TextBody.Paragraphs[0].Text = array[i].Value.ToString();
                        }
                        else
                        {
                            //Gets the month name
                            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);
                            //Add paragraph to the cell
                            cell.TextBody.Paragraphs[0].Text = monthName + " - " + array[i].Value.ToString();
                        }
                        //Set the font size of the paragrpah
                        cell.TextBody.Paragraphs[0].Font.FontSize = 24;
                    }
                }
                slideIndex++;
            }
            return presentation;
        }
        #endregion
        #region Helper Class
        /// <summary>
        /// Gets the data from the Grid
        /// </summary>
        public class CRUDModel
        {
            public PresentationData Value { get; set; }

            public int key { get; set; }

            public string action { get; set; }

            public string rowPosition { get; set; }
        }
        /// <summary>
        /// Position of Data in the Grid
        /// </summary>
        public class DataPosition
        {
            //Gets ot sets the position of the data in Grid
            public string text { get; set; }

        }
        #endregion
    }
}
