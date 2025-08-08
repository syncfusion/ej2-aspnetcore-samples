#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
        bool isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
        public List<ThemeList> ThemeLists()
        {
            List<ThemeList> theme = new List<ThemeList>();
    #if RELEASE && STAGING
            theme.Add(new ThemeList { Id = "material", Theme = "Material", Index = 0 });
            theme.Add(new ThemeList { Id = "material3", Theme = "Material 3", Index = 1 });
            theme.Add(new ThemeList { Id = "fabric", Theme = "Fabric", Index = 2 });
            theme.Add(new ThemeList { Id = "fluent", Theme = "Fluent", Index = 3 });
            theme.Add(new ThemeList { Id = "fluent2", Theme = "Fluent 2", Index = 4 });
            theme.Add(new ThemeList { Id = "bootstrap", Theme = "Bootstrap", Index = 5 });
            theme.Add(new ThemeList { Id = "bootstrap4", Theme = "Bootstrap v4", Index = 6 });
            theme.Add(new ThemeList { Id = "bootstrap5", Theme = "Bootstrap v5", Index = 7 });
            theme.Add(new ThemeList { Id = "bootstrap5.3", Theme = "Bootstrap 5.3", Index = 8 });
            theme.Add(new ThemeList { Id = "tailwind", Theme = "Tailwind CSS", Index = 9 });
            theme.Add(new ThemeList { Id = "tailwind3", Theme = "Tailwind3 CSS", Index = 10 });
            theme.Add(new ThemeList { Id = "highcontrast", Theme = "High Contrast", Index = 11 });
            theme.Add(new ThemeList { Id = "fluent2-highcontrast", Theme = "Fluent 2 High Contrast", Index = 12 });
#else
            theme.Add(new ThemeList { Id = "material3", Theme = "Material 3", Index = 0 });
            theme.Add(new ThemeList { Id = "fluent", Theme = "Fluent", Index = 1 });
            theme.Add(new ThemeList { Id = "fluent2", Theme = "Fluent 2", Index = 2 });
            theme.Add(new ThemeList { Id = "bootstrap5.3", Theme = "Bootstrap 5", Index = 3 });
            theme.Add(new ThemeList { Id = "tailwind", Theme = "Tailwind CSS", Index = 4 });
            theme.Add(new ThemeList { Id = "highcontrast", Theme = "High Contrast", Index = 5 });
            theme.Add(new ThemeList { Id = "fluent2-highcontrast", Theme = "Fluent 2 High Contrast", Index = 6 });
#endif
            return theme;
        }
    } 
}
