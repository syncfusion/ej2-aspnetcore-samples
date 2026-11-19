using EJ2CoreSampleBrowser.Pages.FormRenderer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EJ2CoreSampleBrowser.Pages.FormBuilder
{
    public class DefaultModel : PageModel
    {
        public Schema FormSchema { get; set; }

        public void OnGet()
        {
            FormSchema = new Schema
            {
                Properties = new Dictionary<string, object>(),
                Layout = new List<object>(),
                Settings = new SchemaSettings
                {
                    Name = "Untitled Form",
                    Width = "100%"
                }
            };
        }

        public class Schema
        {
            [JsonProperty("properties")]
            public Dictionary<string, object> Properties { get; set; }

            [JsonProperty("layout")]
            public List<object> Layout { get; set; }

            [JsonProperty("settings")]
            public SchemaSettings Settings { get; set; }
        }

        public class SchemaSettings
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("width")]
            public string Width { get; set; }
        }
    }

}
