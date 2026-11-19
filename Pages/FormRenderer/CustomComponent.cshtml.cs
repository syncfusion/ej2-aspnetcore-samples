using EJ2CoreSampleBrowser.Pages.FormRenderer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Syncfusion.EJ2.FormRenderer;

namespace EJ2CoreSampleBrowser_NET10.Pages.FormRenderer
{
    public class CustomComponentModel : PageModel
    {
        public Schema ContactSchema { get; set; }

        public void OnGet()
        {
            ContactSchema = new Schema
            {
                Version = "1.0.0",
                Properties = new SchemaProperties
                {
                    FormHeading = new HtmlProperty
                    {
                        Id = "formHeading",
                        Name = "formHeading",
                        Widget = "staticHtml",
                        HideLabel = true,
                        DefaultValue = "<div style='text-align:center;padding:12px 0;'><h2>Contact Us</h2><p>We would love to hear from you. Please fill out the form below and our team will get back to you.</p></div>"
                    },
                    FullName = new TextboxProperty
                    {
                        Id = "fullName",
                        Name = "fullName",
                        Type = "string",
                        Widget = "textbox",
                        Label = "Full Name",
                        Placeholder = "Enter your full name",
                        Required = true,
                        MinLength = 2,
                        MaxLength = 100,
                        LabelPosition = "top",
                        TemplateId = "textboxTemplate"
                    },
                    Email = new TextboxProperty
                    {
                        Id = "email",
                        Name = "email",
                        Type = "string",
                        Widget = "textbox",
                        Label = "Email Address",
                        Placeholder = "Enter your email address",
                        TextboxType = "email",
                        Required = true,
                        LabelPosition = "top",
                        TemplateId = "emailTemplate"
                    },
                    InquiryType = new DropdownProperty
                    {
                        Id = "inquiryType",
                        Name = "inquiryType",
                        Type = "string",
                        Widget = "dropdown",
                        Label = "Inquiry Type",
                        DefaultValue = "",
                        Placeholder = "Select inquiry type",
                        LabelPosition = "top",
                        Options = new List<SelectOption>
                        {
                            new SelectOption { Text = "General Inquiry", Value = "general" },
                            new SelectOption { Text = "Sales", Value = "sales" },
                            new SelectOption { Text = "Support", Value = "support" },
                            new SelectOption { Text = "Partnership", Value = "partnership" },
                            new SelectOption { Text = "Feedback", Value = "feedback" }
                        }
                    },
                    Message = new TextareaProperty
                    {
                        Id = "message",
                        Name = "message",
                        Type = "string",
                        Widget = "textarea",
                        Label = "Message",
                        Placeholder = "Enter your message",
                        Required = true,
                        Rows = 5,
                        MinLength = 10,
                        MaxLength = 1000,
                        LabelPosition = "top"
                    },
                    Consent = new CheckboxProperty
                    {
                        Id = "consent",
                        Name = "consent",
                        Type = "boolean",
                        Widget = "checkbox",
                        Label = "I agree to be contacted regarding my inquiry.",
                        Required = true,
                        Checked = false
                    },
                    Submit = new SubmitButtonProperty
                    {
                        Id = "submit",
                        Name = "submit",
                        Type = "button",
                        Label = "Submit",
                        ButtonType = "submit",
                        Widget = "button",
                        Style = "primary"
                    }
                },
                Layout = new List<LayoutNode>
                {
                    new LayoutNode { Type = "field", PropertyId = "formHeading" },
                    new LayoutNode { Type = "field", PropertyId = "fullName" },
                    new LayoutNode { Type = "field", PropertyId = "email" },
                    new LayoutNode { Type = "field", PropertyId = "inquiryType" },
                    new LayoutNode { Type = "field", PropertyId = "message" },
                    new LayoutNode { Type = "field", PropertyId = "consent" },
                    new LayoutNode { Type = "field", PropertyId = "submit" }
                },
                Settings = new SchemaSettings
                {
                    Name = "Contact Us"
                }
            };
        }

        public List<CustomWidgetSetting> CustomWidgets()
        {
            var customWidgetsList = new List<CustomWidgetSetting>();

            customWidgetsList.Add(new CustomWidgetSetting
            {
                TemplateId = "textboxTemplate",
                Template = "[id]:${fieldData.id};[name]:${fieldData.name};[placeholder]:${fieldData.placeholder};[type]:text;"
            });

            // Add more widgets as needed
            customWidgetsList.Add(new CustomWidgetSetting
            {
                TemplateId = "emailTemplate",
                Template = "[id]:${fieldData.id};[name]:${fieldData.name};[type]:${fieldData.textboxType};"
            });

            customWidgetsList.Add(new CustomWidgetSetting
            {
                Type = "dropdown",
                Template = "[id]:${fieldData.id};[name]:${fieldData.name};"
            });

            return customWidgetsList;
        }

    }

    public class Schema
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("properties")]
        public SchemaProperties Properties { get; set; }

        [JsonProperty("layout")]
        public List<LayoutNode> Layout { get; set; }

        [JsonProperty("settings")]
        public SchemaSettings Settings { get; set; }
    }

    public class SchemaProperties
    {
        [JsonProperty("html")]
        public HtmlProperty Html { get; set; }

        [JsonProperty("lastName")]
        public TextboxProperty LastName { get; set; }

        [JsonProperty("firstName")]
        public TextboxProperty FirstName { get; set; }

        [JsonProperty("phoneNumber")]
        public TextboxProperty PhoneNumber { get; set; }

        [JsonProperty("userName")]
        public TextboxProperty UserName { get; set; }

        [JsonProperty("confirmPassword")]
        public ConfirmPasswordProperty ConfirmPassword { get; set; }

        [JsonProperty("password")]
        public PasswordProperty Password { get; set; }

        [JsonProperty("iAgreeToTheTermsAndConditions")]
        public CheckboxProperty IAgreeToTheTermsAndConditions { get; set; }

        [JsonProperty("submit")]
        public SubmitButtonProperty Submit { get; set; }

        [JsonProperty("formHeading")]
        public HtmlProperty FormHeading { get; set; }

        [JsonProperty("fullName")]
        public TextboxProperty FullName { get; set; }

        [JsonProperty("email")]
        public TextboxProperty Email { get; set; }

        [JsonProperty("inquiryType")]
        public DropdownProperty InquiryType { get; set; }

        [JsonProperty("message")]
        public TextareaProperty Message { get; set; }

        [JsonProperty("consent")]
        public CheckboxProperty Consent { get; set; }
    }

    public class SchemaSettings
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }
    }

    public class HtmlProperty
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("defaultValue")]
        public string DefaultValue { get; set; }

        [JsonProperty("widget")]
        public string Widget { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("hideLabel")]
        public bool HideLabel { get; set; }

        [JsonProperty("placeholder")]
        public string Placeholder { get; set; }
    }

    public class TextboxProperty
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("textboxType")]
        public string TextboxType { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("widget")]
        public string Widget { get; set; }

        [JsonProperty("labelPosition")]
        public string LabelPosition { get; set; }

        [JsonProperty("autocomplete")]
        public bool Autocomplete { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("placeholder")]
        public string Placeholder { get; set; }

        [JsonProperty("minLength")]
        public int? MinLength { get; set; }

        [JsonProperty("maxLength")]
        public int? MaxLength { get; set; }

        [JsonProperty("templateId")]
        public string TemplateId { get; set; }

        [JsonProperty("defaultValue")]
        public string DefaultValue { get; set; }

        [JsonProperty("rows")]
        public int? Rows { get; set; }
    }

    public class DropdownProperty : TextboxProperty
    {
        [JsonProperty("options")]
        public List<SelectOption> Options { get; set; }
    }

    public class TextareaProperty : TextboxProperty
    {
        [JsonProperty("rows")]
        public new int Rows { get; set; }
    }

    public class SelectOption
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class ConfirmPasswordProperty
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("textboxType")]
        public string TextboxType { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("widget")]
        public string Widget { get; set; }

        [JsonProperty("labelPosition")]
        public string LabelPosition { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("customValidation")]
        public List<CustomValidationRule> CustomValidation { get; set; }
    }

    public class PasswordProperty
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("textboxType")]
        public string TextboxType { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("minLength")]
        public int MinLength { get; set; }

        [JsonProperty("widget")]
        public string Widget { get; set; }

        [JsonProperty("labelPosition")]
        public string LabelPosition { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }
    }

    public class CheckboxProperty
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("widget")]
        public string Widget { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("checked")]
        public bool Checked { get; set; }
    }

    public class SubmitButtonProperty
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("buttonType")]
        public string ButtonType { get; set; }

        [JsonProperty("widget")]
        public string Widget { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("style")]
        public string Style { get; set; }
    }

    public class CustomValidationRule
    {
        [JsonProperty("expression")]
        public string Expression { get; set; }
    }

    public class LayoutNode
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("propertyId")]
        public string PropertyId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("hideBorders")]
        public bool HideBorders { get; set; }

        [JsonProperty("rows")]
        public int Rows { get; set; }

        [JsonProperty("cols")]
        public int Cols { get; set; }

        [JsonProperty("cells")]
        public List<List<TableCell>> Cells { get; set; }

        [JsonProperty("children")]
        public List<LayoutNode> Children { get; set; }
    }

    public class TableCell
    {
        [JsonProperty("row")]
        public int Row { get; set; }

        [JsonProperty("col")]
        public int Col { get; set; }

        [JsonProperty("children")]
        public List<LayoutNode> Children { get; set; }
    }

}

