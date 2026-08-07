using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ2CoreSampleBrowser.Models
{
    public class DateFormats
    {
        public string Id { get; set; }
        public string Text { get; set; }

        public List<string> GetDateFormatsWithId()
        {
            return new List<string>
            {
                "dd-MMM-yy", "yyyy-MM-dd", "dd-MMMM-yyyy" 
            };
        }

        public List<string> GetDateRangeFormatsWithId()
        {
            return new List<string>
            {
                "dd-MMM-yy", "yyyy-MM-dd", "dd-MMMM-yyyy" , "dd/MMM/yy hh:mm a"
            };
        }

        public List<string> GetInputFormats()
        {
            return new List<string>
            {
                "dd/MM/yyyy", "ddMMMyy", "yyyyMMdd", "dd.MM.yy", "MM/dd/yyyy", "yyyy/MMM/dd", "dd-MM-yyyy"
            };
        }
    }
}
