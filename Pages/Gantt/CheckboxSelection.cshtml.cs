using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EJ2CoreSampleBrowser.Pages.Gantt
{
    public class CheckboxSelectionModel : PageModel
    {
        public class DropDownListData1
        {
            public string Id { get; set; }
            public string Type { get; set; }
            public static List<DropDownListData1> SelectionModeList ()
            {
                List<DropDownListData1> Data = new List<DropDownListData1>();
                Data.Add(new DropDownListData1 { Id = "self", Type = "Self" });
                Data.Add(new DropDownListData1 { Id = "hierarchy", Type = "Hierarchy" });
                Data.Add(new DropDownListData1 { Id = "filteredHierarchy", Type = "Filtered Hierarchy" });
                return Data;
            }
            
        }
    }
}