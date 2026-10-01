using System;
using System.Collections.Generic;

namespace EJ2CoreSampleBrowser.Helpers
{
    public static class DocumentationUrlHelper
    {
        private const string CoreDocsUrl = "https://ej2.syncfusion.com/aspnetcore/documentation/";
        private const string SdkDocsUrl = "https://help.syncfusion.com/";
        private const string SdkPlatformPath = "asp-net-core";
        private const string DefaultPage = "getting-started";
        private const string AspNetCoreSegment = "aspnetcore";
        private const string GridCorePage = "getting-started-core";
        private const string IntroductionSlug = "introduction";

        private static readonly Uri IntroductionUrl =
            new Uri($"{CoreDocsUrl}{IntroductionSlug}", UriKind.Absolute);

        private static readonly IReadOnlyDictionary<string, (string Sdk, string Path, string Page)> ComponentSdkMap =
            new Dictionary<string, (string Sdk, string Path, string Page)>(StringComparer.OrdinalIgnoreCase)
            {
                // Grid SDK
                ["grid"] = ("grid-sdk", "data-grid", GridCorePage),
                ["treegrid"] = ("grid-sdk", "tree-grid", GridCorePage),
                ["pivottable"] = ("grid-sdk", "pivot-table", DefaultPage),

                // Chart SDK
                ["chart"] = ("chart-sdk", "charts", DefaultPage),
                ["threedimensionschart"] = ("chart-sdk", "3d-charts", DefaultPage),
                ["circularchart3d"] = ("chart-sdk", "3d-circular-charts", DefaultPage),
                ["stockchart"] = ("chart-sdk", "stock-chart", DefaultPage),
                ["circulargauge"] = ("chart-sdk", "circular-gauge", DefaultPage),
                ["lineargauge"] = ("chart-sdk", "linear-gauge", DefaultPage),
                ["heatmapchart"] = ("chart-sdk", "heatmap-chart", DefaultPage),
                ["maps"] = ("chart-sdk", "maps", DefaultPage),
                ["rangenavigator"] = ("chart-sdk", "range-navigator", DefaultPage),
                ["smithchart"] = ("chart-sdk", "smith-chart", DefaultPage),
                ["sparkline"] = ("chart-sdk", "sparkline-charts", DefaultPage),
                ["barcode"] = ("chart-sdk", "barcode-generator", DefaultPage),
                ["sankey"] = ("chart-sdk", "sankey-diagram", DefaultPage),
                ["treemap"] = ("chart-sdk", "treemap", DefaultPage),
                ["bulletchart"] = ("chart-sdk", "bullet-chart", DefaultPage),
                ["dashboardlayout"] = ("chart-sdk", "dashboard-layout", DefaultPage),

                // File Manager SDK
                ["filemanager"] = ("file-manager-sdk", string.Empty, DefaultPage),

                // Gantt SDK
                ["gantt"] = ("gantt-sdk", "gantt-chart", DefaultPage),
                ["kanban"] = ("gantt-sdk", "kanban", DefaultPage),

                // Rich Text Editor SDK
                ["richtexteditor"] = ("rich-text-editor-sdk", "rich-text-editor", DefaultPage),
                ["blockeditor"] = ("rich-text-editor-sdk", "block-editor", DefaultPage),
                ["markdowneditor"] = ("rich-text-editor-sdk", "markdown-editor", DefaultPage),

                // Scheduler SDK
                ["schedule"] = ("scheduler-sdk", "schedule", DefaultPage),
                ["calendar"] = ("scheduler-sdk", "calendar", DefaultPage),
                ["datepicker"] = ("scheduler-sdk", "date-picker", DefaultPage),
                ["daterangepicker"] = ("scheduler-sdk", "daterange-picker", DefaultPage),
                ["datetimepicker"] = ("scheduler-sdk", "datetime-picker", DefaultPage),
                ["timepicker"] = ("scheduler-sdk", "time-picker", DefaultPage),

                // Diagram SDK
                ["diagram"] = ("diagram-sdk", string.Empty, DefaultPage)
            };

        private static readonly IReadOnlyDictionary<string, (string Slug, string Page)> DirectDocumentationMap =
            new Dictionary<string, (string Slug, string Page)>(StringComparer.OrdinalIgnoreCase)
            {
                // Direct ASP.NET Core documentation URLs
                ["badge"] = ("badge", "getting-started-asp-core"),
                ["aiassistview"] = ("ai-assistview",DefaultPage),
                ["chatui"] = ("chat-ui", DefaultPage),
                ["inlineaiassist"] = ("inline-ai-assist", DefaultPage),
                ["speechtotext"] = ("speech-to-text", DefaultPage),
                ["inplaceeditor"] = ("in-place-editor", DefaultPage),
                ["autocomplete"] = ("auto-complete", DefaultPage),
                ["combobox"] = ("combo-box", DefaultPage),
                ["dropdownlist"] = ("drop-down-list", DefaultPage),
                ["multiselect"] = ("multi-select", DefaultPage),
                ["listbox"] = ("list-box", DefaultPage),
                ["dropdowntree"] = ("drop-down-tree", DefaultPage),
                ["multicolumncombobox"] = ("multicolumn-combobox", DefaultPage),
                ["contextmenu"] = ("context-menu", DefaultPage),
                ["progressbar"] = ("progress-bar", DefaultPage),
                ["fab"] = ("floating-action-button", DefaultPage),
                ["floatingactionbutton"] = ("floating-action-button", DefaultPage),
                ["imageeditor"] = ("image-editor", DefaultPage),
                ["textboxes"] = ("textbox", DefaultPage),
                ["colorpicker"] = ("color-picker", DefaultPage),
                ["rangeslider"] = ("range-slider", DefaultPage),
                ["otpinput"] = ("otp-input", DefaultPage),
                ["predefineddialogs"] = ("predefined-dialogs", DefaultPage),
                ["querybuilder"] = ("query-builder", DefaultPage)
            };

        private static readonly HashSet<string> IntroductionRedirectComponents =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                // Redirect these components to common Introduction page
                "arcgauge",
                "smartpastebutton",
                "smarttextarea",
                "formrenderer"
            };

        public static Uri GetGettingStartedUrl(string componentName)
        {
            var normalizedComponentName = NormalizeKey(componentName);

            if (string.IsNullOrWhiteSpace(normalizedComponentName))
            {
                return IntroductionUrl;
            }

            if (IntroductionRedirectComponents.Contains(normalizedComponentName))
            {
                return IntroductionUrl;
            }

            if (DirectDocumentationMap.TryGetValue(normalizedComponentName, out var directDocumentation))
            {
                return new Uri(
                    BuildCoreDocumentationUrl(directDocumentation.Slug, directDocumentation.Page),
                    UriKind.Absolute
                );
            }

            if (ComponentSdkMap.TryGetValue(normalizedComponentName, out var sdkDocumentation))
            {
                return new Uri(
                    BuildSdkDocumentationUrl(sdkDocumentation.Sdk, sdkDocumentation.Path, sdkDocumentation.Page),
                    UriKind.Absolute
                );
            }

            return new Uri(
                BuildCoreDocumentationUrl(NormalizeKey(componentName), DefaultPage),
                UriKind.Absolute
            );
        }

        public static Uri GetGettingStartedUrlFromPath(string requestPath)
        {
            var componentName = GetComponentNameFromPath(requestPath);
            return GetGettingStartedUrl(componentName);
        }

        private static string BuildSdkDocumentationUrl(string sdk, string path, string page)
        {
            var baseUrl = $"{SdkDocsUrl}{sdk}/{SdkPlatformPath}";

            return string.IsNullOrWhiteSpace(path)
                ? $"{baseUrl}/{page}"
                : $"{baseUrl}/{path}/{page}";
        }

        private static string BuildCoreDocumentationUrl(string slug, string page)
        {
            return $"{CoreDocsUrl}{slug}/{page}";
        }

        private static string GetComponentNameFromPath(string requestPath)
        {
            if (string.IsNullOrWhiteSpace(requestPath))
            {
                return string.Empty;
            }

            var pathOnly = requestPath
                .Split('?')[0]
                .Split('#')[0];

            var segments = pathOnly.Split(
                new[] { '/' },
                StringSplitOptions.RemoveEmptyEntries
            );

            if (segments.Length == 0)
            {
                return string.Empty;
            }

            return segments.Length >= 2
                ? segments[segments.Length - 2]
                : segments[0];
        }

        private static string NormalizeKey(string value)
        {
            return (value ?? string.Empty)
                .Trim()
                .Trim('/')
                .Replace("-", string.Empty)
                .Replace("_", string.Empty)
                .Replace(" ", string.Empty)
                .ToLowerInvariant();
        }
    }
}