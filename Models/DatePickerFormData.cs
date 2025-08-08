#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
