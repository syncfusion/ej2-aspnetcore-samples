#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
        public string Text { get; set; }
        public string Value { get; set; }

        public List<FormatOption> FormatOptions()
        {
            List<FormatOption> formattingOption = new List<FormatOption>();
            formattingOption.Add(new FormatOption { Id = "promptFromatting", Format = "Prompt" });
            formattingOption.Add(new FormatOption { Id = "plainTextFormatting", Format = "Plain Text" });
            formattingOption.Add(new FormatOption { Id = "keepFormatting", Format = "Keep Format" });
            formattingOption.Add(new FormatOption { Id = "cleanFormatting", Format = "Clean Format" });
            return formattingOption;
        }
        public List<FormatOption> SaveFormat()
        {
            List<FormatOption> saveFormats = new List<FormatOption>();
            saveFormats.Add(new FormatOption { Id = "Blob", Format = "Blob" });
            saveFormats.Add(new FormatOption { Id = "Base64", Format = "Base64" });
            return saveFormats;
        }
        public List<FormatOption> EnterOption()
        {
            List<FormatOption> enterOptions = new List<FormatOption>();
            enterOptions.Add(new FormatOption { Text = "Create a new <p>", Format = "P" });
            enterOptions.Add(new FormatOption { Text = "Create a new <div>", Format = "DIV" });
            enterOptions.Add(new FormatOption { Text = "Create a new <br>", Format = "BR" });
            return enterOptions;
        }
        public List<FormatOption> ShiftEnterOption()
        {
            List<FormatOption> shiftEnterOptions = new List<FormatOption>();
            shiftEnterOptions.Add(new FormatOption { Text = "Create a new <br>", Format = "BR" });
            shiftEnterOptions.Add(new FormatOption { Text = "Create a new <div>", Format = "DIV" });
            shiftEnterOptions.Add(new FormatOption { Text = "Create a new <p>", Format = "P" });
            return shiftEnterOptions;
        }

    }
}
