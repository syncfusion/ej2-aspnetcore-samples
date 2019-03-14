using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class FormatOption
    {
        public string Id { get; set; }
        public string Format { get; set; }

        public List<FormatOption> FormatOptions()
        {
            List<FormatOption> formattingOption = new List<FormatOption>();
            formattingOption.Add(new FormatOption { Id = "promptFromatting", Format = "Prompt" });
            formattingOption.Add(new FormatOption { Id = "plainTextFormatting", Format = "Plain Text" });
            formattingOption.Add(new FormatOption { Id = "keepFormatting", Format = "Keep Format" });
            formattingOption.Add(new FormatOption { Id = "cleanFormatting", Format = "Clean Format" });
            return formattingOption;
        }
    }
}
