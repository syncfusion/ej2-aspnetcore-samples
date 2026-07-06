using Microsoft.AspNetCore.Mvc.RazorPages;
namespace EJ2CoreSampleBrowser.Pages.Diagram;
using Syncfusion.EJ2.Diagrams;

public class PuzzleModel : PageModel
{
        public DiagramConstraints Constraints { get; set; } = DiagramConstraints.Default & ~DiagramConstraints.UndoRedo;

}
