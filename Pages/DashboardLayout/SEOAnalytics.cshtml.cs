#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace EJ2CoreSampleBrowser_NET8.Pages.DashboardLayout;

public class SEOAnalytics : PageModel
{
    public object GetWroldMap()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/WorldMap.json");
        return JsonConvert.DeserializeObject(allText);
    }
    public object getDataSource()
    {
        string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/defaultdata.js");
        return JsonConvert.DeserializeObject(allText);
    }
    
    public List<expenseData> Data = new List<expenseData>();
    public List<lineData> LineDataSource = new List<lineData>();
    public List<lineData> LineDataSource1 = new List<lineData>();
    public List<columnData> ColumDataSource = new List<columnData>();
    public List<columnData> ColumDataSource1 = new List<columnData>();
    public List<columnData> ColumDataSource2 = new List<columnData>();
    public List<pieData> PieDataSource = new List<pieData>();
    public void OnGet()
    {
        Data.Add(new expenseData
        {
            UniqueId = "T100003",
            dateTime = new DateTime(2017, 3, 1),
            Category = "Food",
            PaymentMode = "Cash",
            TransactionType = "Expense",
            Description = "Confederate cush",
            Amount = "900",
            MonthShort = "Mar",
            MonthFull = "March, 2017",
            FormattedDate = "03/01/2017 08:53 PM",
            Device = "Tablet",
        });
        Data.Add(new expenseData
        {
            UniqueId = "T100004",
            dateTime = new DateTime(2017, 4, 1),
            Category = "Transportation",
            PaymentMode = "Credit Card",
            TransactionType = "Expense",
            Description = "Public and other transportation",
            Amount = "1200",
            MonthShort = "Apr",
            MonthFull = "April, 2017",
            FormattedDate = "04/01/2017 10:44 PM",
            Device = "Desktop",
        });
        Data.Add(new expenseData
        {
            UniqueId = "T100005",
            dateTime = new DateTime(2017, 5, 1),
            Category = "Transportation",
            PaymentMode = "Cash",
            TransactionType = "Expense",
            Description = "Public and other transportation",
            Amount = "600",
            MonthShort = "May",
            MonthFull = "May, 2017",
            FormattedDate = "05/01/2017 08:53 PM",
            Device = "Mobile",
        });

        LineDataSource.Add(new lineData { x = new DateTime(2002, 1, 1), y = 2.2 });
        LineDataSource.Add(new lineData { x = new DateTime(2003, 1, 1), y = 3.4 });
        LineDataSource.Add(new lineData { x = new DateTime(2004, 1, 1), y = 2.8 });
        LineDataSource.Add(new lineData { x = new DateTime(2005, 1, 1), y = 1.6 });
        LineDataSource.Add(new lineData { x = new DateTime(2006, 1, 1), y = 2.3 });
        LineDataSource.Add(new lineData { x = new DateTime(2007, 1, 1), y = 2.5 });
        LineDataSource.Add(new lineData { x = new DateTime(2008, 1, 1), y = 2.9 });
        LineDataSource.Add(new lineData { x = new DateTime(2009, 1, 1), y = 3.8 });
        LineDataSource.Add(new lineData { x = new DateTime(2010, 1, 1), y = 1.4 });
        LineDataSource.Add(new lineData { x = new DateTime(2011, 1, 1), y = 3.1 });
        
        LineDataSource1.Add(new lineData { x = new DateTime(2002, 1, 1), y = 2 });
        LineDataSource1.Add(new lineData { x = new DateTime(2003, 1, 1), y = 1.7 });
        LineDataSource1.Add(new lineData { x = new DateTime(2004, 1, 1), y = 1.8 });
        LineDataSource1.Add(new lineData { x = new DateTime(2005, 1, 1), y = 2.1 });
        LineDataSource1.Add(new lineData { x = new DateTime(2006, 1, 1), y = 2.3 });
        LineDataSource1.Add(new lineData { x = new DateTime(2007, 1, 1), y = 1.7 });
        LineDataSource1.Add(new lineData { x = new DateTime(2008, 1, 1), y = 1.5 });
        LineDataSource1.Add(new lineData { x = new DateTime(2009, 1, 1), y = 2.8 });
        LineDataSource1.Add(new lineData { x = new DateTime(2010, 1, 1), y = 1.5 });
        LineDataSource1.Add(new lineData { x = new DateTime(2011, 1, 1), y = 2.3 });
        
        ColumDataSource.Add(new columnData { x = "Jan", y = 46 });
        ColumDataSource.Add(new columnData { x = "Feb", y = 27 });
        ColumDataSource.Add(new columnData { x = "Mar", y = 26 });
        
        ColumDataSource1.Add(new columnData { x = "Jan", y = 37 });
        ColumDataSource1.Add(new columnData { x = "Feb", y = 23 });
        ColumDataSource1.Add(new columnData { x = "Mar", y = 18 });
        
        ColumDataSource2.Add(new columnData { x = "Jan", y = 38 });
        ColumDataSource2.Add(new columnData { x = "Feb", y = 17 });
        ColumDataSource2.Add(new columnData { x = "Mar", y = 26 });
        
        PieDataSource.Add(new pieData { x = "Desktop", y = 37, text = "60%" });
        PieDataSource.Add(new pieData { x = "Mobile", y = 17, text = "10%" });
        PieDataSource.Add(new pieData { x = "Tablet", y = 19, text = "20%" });
    }
    // public object GetWroldMap()
    // {
    //     string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/WorldMap.json");
    //     return JsonConvert.DeserializeObject(allText);
    // }

    // public object getDataSource()
    // {
    //     string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/defaultdata.js");
    //     return JsonConvert.DeserializeObject(allText);
    // }
}

public class expenseData
{
    public string UniqueId;
    public DateTime dateTime;
    public string Category;
    public string PaymentMode;
    public string TransactionType;
    public string Description;
    public string Amount;
    public string MonthShort;
    public string MonthFull;
    public string FormattedDate;
    public string Device;
}
public class lineData
{
    public DateTime x;
    public double y;
}

public class columnData
{
    public string x;
    public double y;
}

public class pieData
{
    public string x;
    public double y;
    public string text;
}