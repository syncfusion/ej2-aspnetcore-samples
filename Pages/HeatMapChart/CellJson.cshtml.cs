#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser_NET8.Pages.HeatMapChart;

public class CellJson : PageModel
{
    public List<heatmapDatasourceCell> data = new List<heatmapDatasourceCell>();
    public void OnGet()
    {
        data.Add(new heatmapDatasourceCell { rowid = "France", columnid = "2010", value = "77.6" });
        data.Add(new heatmapDatasourceCell { rowid = "France", columnid = "2011", value = "79.4" });
        data.Add(new heatmapDatasourceCell { rowid = "France", columnid = "2012", value = "80.8" });
        data.Add(new heatmapDatasourceCell { rowid = "France", columnid = "2013", value = "86.6" });
        data.Add(new heatmapDatasourceCell { rowid = "France", columnid = "2014", value = "83.7" });
        data.Add(new heatmapDatasourceCell { rowid = "France", columnid = "2015", value = "84.5" });
        data.Add(new heatmapDatasourceCell { rowid = "France", columnid = "2016", value = "82.6" });

        data.Add(new heatmapDatasourceCell { rowid = "USA", columnid = "2010", value = "60.6" });
        data.Add(new heatmapDatasourceCell { rowid = "USA", columnid = "2011", value = "65.4" });
        data.Add(new heatmapDatasourceCell { rowid = "USA", columnid = "2012", value = "70.8" });
        data.Add(new heatmapDatasourceCell { rowid = "USA", columnid = "2013", value = "73.8" });
        data.Add(new heatmapDatasourceCell { rowid = "USA", columnid = "2014", value = "75.3" });
        data.Add(new heatmapDatasourceCell { rowid = "USA", columnid = "2015", value = "77.5" });
        data.Add(new heatmapDatasourceCell { rowid = "USA", columnid = "2016", value = "77.6" });

        data.Add(new heatmapDatasourceCell { rowid = "Spain", columnid = "2010", value = "64.9" });
        data.Add(new heatmapDatasourceCell { rowid = "Spain", columnid = "2011", value = "52.6" });
        data.Add(new heatmapDatasourceCell { rowid = "Spain", columnid = "2012", value = "60.8" });
        data.Add(new heatmapDatasourceCell { rowid = "Spain", columnid = "2013", value = "65.6" });
        data.Add(new heatmapDatasourceCell { rowid = "Spain", columnid = "2014", value = "52.6" });
        data.Add(new heatmapDatasourceCell { rowid = "Spain", columnid = "2015", value = "68.5" });
        data.Add(new heatmapDatasourceCell { rowid = "Spain", columnid = "2016", value = "75.6" });

        data.Add(new heatmapDatasourceCell { rowid = "China", columnid = "2010", value = "55.6" });
        data.Add(new heatmapDatasourceCell { rowid = "China", columnid = "2011", value = "52.3" });
        data.Add(new heatmapDatasourceCell { rowid = "China", columnid = "2012", value = "54.8" });
        data.Add(new heatmapDatasourceCell { rowid = "China", columnid = "2013", value = "51.1" });
        data.Add(new heatmapDatasourceCell { rowid = "China", columnid = "2014", value = "55.6" });
        data.Add(new heatmapDatasourceCell { rowid = "China", columnid = "2015", value = "56.9" });
        data.Add(new heatmapDatasourceCell { rowid = "China", columnid = "2016", value = "59.3" });


        data.Add(new heatmapDatasourceCell { rowid = "Italy", columnid = "2010", value = "43.6" });
        data.Add(new heatmapDatasourceCell { rowid = "Italy", columnid = "2011", value = "43.2" });
        data.Add(new heatmapDatasourceCell { rowid = "Italy", columnid = "2012", value = "55.8" });
        data.Add(new heatmapDatasourceCell { rowid = "Italy", columnid = "2013", value = "50.1" });
        data.Add(new heatmapDatasourceCell { rowid = "Italy", columnid = "2014", value = "48.5" });
        data.Add(new heatmapDatasourceCell { rowid = "Italy", columnid = "2015", value = "50.7" });
        data.Add(new heatmapDatasourceCell { rowid = "Italy", columnid = "2016", value = "52.4" });

        data.Add(new heatmapDatasourceCell { rowid = "UK", columnid = "2010", value = "28.2" });
        data.Add(new heatmapDatasourceCell { rowid = "UK", columnid = "2011", value = "31.6" });
        data.Add(new heatmapDatasourceCell { rowid = "UK", columnid = "2012", value = "29.8" });
        data.Add(new heatmapDatasourceCell { rowid = "UK", columnid = "2013", value = "33.1" });
        data.Add(new heatmapDatasourceCell { rowid = "UK", columnid = "2014", value = "32.6" });
        data.Add(new heatmapDatasourceCell { rowid = "UK", columnid = "2015", value = "34.4" });
        data.Add(new heatmapDatasourceCell { rowid = "UK", columnid = "2016", value = "35.8" });

        data.Add(new heatmapDatasourceCell { rowid = "Germany", columnid = "2010", value = "26.8" });
        data.Add(new heatmapDatasourceCell { rowid = "Germany", columnid = "2011", value = "29" });
        data.Add(new heatmapDatasourceCell { rowid = "Germany", columnid = "2012", value = "26.8" });
        data.Add(new heatmapDatasourceCell { rowid = "Germany", columnid = "2013", value = "27.6" });
        data.Add(new heatmapDatasourceCell { rowid = "Germany", columnid = "2014", value = "33" });
        data.Add(new heatmapDatasourceCell { rowid = "Germany", columnid = "2015", value = "35" });
        data.Add(new heatmapDatasourceCell { rowid = "Germany", columnid = "2016", value = "35.6" });

        data.Add(new heatmapDatasourceCell { rowid = "Mexico", columnid = "2010", value = "23.2" });
        data.Add(new heatmapDatasourceCell { rowid = "Mexico", columnid = "2011", value = "24.9" });
        data.Add(new heatmapDatasourceCell { rowid = "Mexico", columnid = "2012", value = "30.1" });
        data.Add(new heatmapDatasourceCell { rowid = "Mexico", columnid = "2013", value = "22.2" });
        data.Add(new heatmapDatasourceCell { rowid = "Mexico", columnid = "2014", value = "29.3" });
        data.Add(new heatmapDatasourceCell { rowid = "Mexico", columnid = "2015", value = "32.1" });
        data.Add(new heatmapDatasourceCell { rowid = "Mexico", columnid = "2016", value = "35" });

        data.Add(new heatmapDatasourceCell { rowid = "Thailand", columnid = "2010", value = "15.9" });
        data.Add(new heatmapDatasourceCell { rowid = "Thailand", columnid = "2011", value = "19.8" });
        data.Add(new heatmapDatasourceCell { rowid = "Thailand", columnid = "2012", value = "21.8" });
        data.Add(new heatmapDatasourceCell { rowid = "Thailand", columnid = "2013", value = "23.5" });
        data.Add(new heatmapDatasourceCell { rowid = "Thailand", columnid = "2014", value = "24.8" });
        data.Add(new heatmapDatasourceCell { rowid = "Thailand", columnid = "2015", value = "29.9" });
        data.Add(new heatmapDatasourceCell { rowid = "Thailand", columnid = "2016", value = "32.6" });


        data.Add(new heatmapDatasourceCell { rowid = "Austria", columnid = "2010", value = "22" });
        data.Add(new heatmapDatasourceCell { rowid = "Austria", columnid = "2011", value = "21.3" });
        data.Add(new heatmapDatasourceCell { rowid = "Austria", columnid = "2012", value = "24.2" });
        data.Add(new heatmapDatasourceCell { rowid = "Austria", columnid = "2013", value = "23.2" });
        data.Add(new heatmapDatasourceCell { rowid = "Austria", columnid = "2014", value = "25" });
        data.Add(new heatmapDatasourceCell { rowid = "Austria", columnid = "2015", value = "26.7" });
        data.Add(new heatmapDatasourceCell { rowid = "Austria", columnid = "2016", value = "28.1" });
    }
}

public class heatmapDatasourceCell
{
    public string rowid { get; set; }
    public string columnid { get; set; }
    public string value { get; set; }
}