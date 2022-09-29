#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
namespace CoreDemos
{
    public class ThemeList
    {
        public string Id { get; set; }
        public string Theme { get; set; }
        public int Index { get; set; }

        public List<ThemeList> ThemeLists()
        {
            List<ThemeList> theme = new List<ThemeList>();
            theme.Add(new ThemeList { Id = "fluent", Theme = "Fluent", Index=0 });
            theme.Add(new ThemeList { Id = "fluent-dark", Theme = "Fluent Dark", Index = 1});
            theme.Add(new ThemeList { Id = "bootstrap5", Theme = "Bootstrap v5", Index = 2 });
            theme.Add(new ThemeList { Id = "bootstrap5-dark", Theme = "Bootstrap v5 Dark", Index = 3 });
            theme.Add(new ThemeList { Id = "tailwind", Theme = "Tailwind CSS", Index = 4 });
            theme.Add(new ThemeList { Id = "tailwind-dark", Theme = "Tailwind CSS Dark", Index = 5});
            theme.Add(new ThemeList { Id = "material", Theme = "Material", Index = 6 });
            theme.Add(new ThemeList { Id = "bootstrap4", Theme = "Bootstrap v4", Index = 7});
            theme.Add(new ThemeList { Id = "bootstrap", Theme = "Bootstrap", Index = 8 });
            theme.Add(new ThemeList { Id = "bootstrap-dark", Theme = "Bootstrap Dark", Index = 9 });
            theme.Add(new ThemeList { Id = "highcontrast", Theme = "High Contrast", Index = 10 });
            return theme;
        }
    } 
}
