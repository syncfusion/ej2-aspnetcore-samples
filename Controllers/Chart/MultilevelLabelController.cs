using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Charts;

namespace EJ2CoreSampleBrowser.Controllers.Chart
{
    public partial class ChartController : Controller
    {
        public IActionResult Multilevellabel()
        {


            List<MultiLevelLabelsData> chartData = new List<MultiLevelLabelsData>
            {
                new MultiLevelLabelsData { x = "Grapes",  y = 28 },
                new MultiLevelLabelsData { x = "Apples",  y = 87 },
                new MultiLevelLabelsData { x = "Pears",   y = 42 },
                new MultiLevelLabelsData { x = "Grapes",  y = 13 },
                new MultiLevelLabelsData { x = "Apples",  y = 13 },
                new MultiLevelLabelsData { x = "Pears",   y = 10 },
                new MultiLevelLabelsData { x = "Tomato",  y = 31 },
                new MultiLevelLabelsData { x = "Potato",  y = 96 },
                new MultiLevelLabelsData { x = "Cucumber",y = 41 },
                new MultiLevelLabelsData { x = "Onion",   y = 59 }
             };
            ViewBag.dataSource = chartData;
            List<ChartMultiLevelLabel> multilevels = new List<ChartMultiLevelLabel>();
            ChartMultiLevelLabel one = new ChartMultiLevelLabel();
            ChartCategory category = new ChartCategory();
            category.Start = "-0.5";
            category.End = "0.5";
            category.Text = "Seedless";
            ChartCategory category1 = new ChartCategory();
            category1.Start = "0.5";
            category1.End = "2.5";
            category1.Text = "Seedled";
            ChartCategory category2 = new ChartCategory();
            category2.Start = "2.5";
            category2.End = "3.5";
            category2.Text = "Seedless";
            ChartCategory category3 = new ChartCategory();
            category3.Start = "3.5";
            category3.End = "5.5";
            category3.Text = "Seedled";
            ChartCategory category4 = new ChartCategory();
            category4.Start = "5.5";
            category4.End = "6.5";
            category4.Text = "Seedless";
            ChartCategory category5 = new ChartCategory();
            category5.Start = "6.5";
            category5.End = "7.5";
            category5.Text = "Seedled";
            ChartCategory category6 = new ChartCategory();
            category6.Start = "7.5";
            category6.End = "8.5";
            category6.Text = "Seedless";
            ChartCategory category7 = new ChartCategory();
            category7.Start = "8.5";
            category7.End = "9.5";
            category7.Text = "Seedled";
            List<ChartCategory> categoryOne = new List<ChartCategory>();
            categoryOne.Add(category);
            categoryOne.Add(category1);
            categoryOne.Add(category2);
            categoryOne.Add(category3);
            categoryOne.Add(category4);
            categoryOne.Add(category5);
            categoryOne.Add(category6);
            categoryOne.Add(category7);
            one.Categories = categoryOne;


            ChartMultiLevelLabel two = new ChartMultiLevelLabel();
            ChartCategory category11 = new ChartCategory();
            category11.Start = "-0.5";
            category11.End = "2.5";
            category11.Text = "In Season";
            ChartCategory category12 = new ChartCategory();
            category12.Start = "2.5";
            category12.End = "5.5";
            category12.Text = "Out of Season";
            ChartCategory category22 = new ChartCategory();
            category22.Start = "5.5";
            category22.End = "7.5";
            category22.Text = "In Season";
            ChartCategory category33 = new ChartCategory();
            category33.Start = "7.5";
            category33.End = "9.5";
            category33.Text = "Out of Season";
            List<ChartCategory> categoryTwo = new List<ChartCategory>();
            categoryTwo.Add(category11);
            categoryTwo.Add(category12);
            categoryTwo.Add(category22);
            categoryTwo.Add(category33);
            two.Categories = categoryTwo;


            ChartMultiLevelLabel three = new ChartMultiLevelLabel();
            ChartCategory category111 = new ChartCategory();
            category111.Start = "-0.5";
            category111.End = "5.5";
            category111.Text = "Fruits";
            ChartCategory category222 = new ChartCategory();
            category222.Start = "5.5";
            category222.End = "9.5";
            category222.Text = "Vegetables";
            List<ChartCategory> categoryThree = new List<ChartCategory>();
            categoryThree.Add(category111);
            categoryThree.Add(category222);
            three.Categories = categoryThree;

            multilevels.Add(one);
            multilevels.Add(two);
            multilevels.Add(three);
            ViewBag.multiLevelLabels = multilevels;
            return View();
        }
        public class MultiLevelLabelsData
        {
            public string x;
            public double y;
        }
    }
}