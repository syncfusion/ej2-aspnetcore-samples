#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Navigations;
using Syncfusion.EJ2.Diagrams;
using System.ComponentModel;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;

namespace EJ2CoreSampleBrowser.Controllers.Diagram
{
    public partial class DiagramController : Controller
    {
        public IActionResult CRUD()
        {
            DiagramCrudAction nodeCrud = new DiagramCrudAction()
            {
                //Define URL to perform CRUD operations with nodes records in database.
                Read = "https://js.syncfusion.com/demos/ejServices/api/Diagram/GetNodes",
                Create = "https://js.syncfusion.com/demos/ejServices/api/Diagram/AddNodes",
                Update = "https://js.syncfusion.com/demos/ejServices/api/Diagram/UpdateNodes",
                Destroy = "https://js.syncfusion.com/demos/ejServices/api/Diagram/DeleteNodes",
                CustomFields = new object[] { "Id", "Description", "Color" },
            };
            ViewBag.NodeCrud = nodeCrud;
            ConnectionDataSource dataSource = new ConnectionDataSource()

            {
                Id = "Name",
                SourceID = "SourceNode",
                TargetID = "TargetNode",
                CustomFields = new object[] { "Id" },
                CrudAction = new CRUDAction()
                {
                    //Define URL to perform CRUD operations with connector records in database.
                    Read = "https://js.syncfusion.com/demos/ejServices/api/Diagram/GetConnectors",
                    Create = "https://js.syncfusion.com/demos/ejServices/api/Diagram/AddConnectors",
                    Update = "https://js.syncfusion.com/demos/ejServices/api/Diagram/UpdateConnectors",
                    Destroy = "https://js.syncfusion.com/demos/ejServices/api/Diagram/DeleteConnectors",
                    CustomFields = new object[] { "Id" },
                }
            };

            ViewBag.DataSource = dataSource;

            DiagramDataSource DataSourceSettings = new DiagramDataSource();
            DataSourceSettings.Id = "Name";
            DataSourceSettings.CrudAction = nodeCrud;
            DataSourceSettings.ConnectionDataSource = dataSource;
            ViewBag.DataSourceSettings = DataSourceSettings;

            ViewBag.button = new
            {
                content = "Update",
                isPrimary = true
            };
            ViewBag.setNodeTemplate = "setNodeTemplate";
            ViewBag.nodeDefaults = "nodeDefaults";
            ViewBag.connectorDefaults = "connectorDefaults";
            return View();
        }
    }
    public class CRUDAction
    {
        [DefaultValue(null)]
        [HtmlAttributeName("read")]
        [JsonProperty("read")]
        public string Read { get; set; }

        [DefaultValue(null)]
        [HtmlAttributeName("create")]
        [JsonProperty("create")]
        public string Create { get; set; }

        [DefaultValue(null)]
        [HtmlAttributeName("update")]
        [JsonProperty("update")]
        public string Update { get; set; }

        [DefaultValue(null)]
        [HtmlAttributeName("destroy")]
        [JsonProperty("destroy")]
        public string Destroy { get; set; }

        [DefaultValue(null)]
        [HtmlAttributeName("customFields")]
        [JsonProperty("customFields")]
        public object[] CustomFields { get; set; }
    }

    public class ConnectionDataSource : DiagramConnectionDataSource
    {
        [DefaultValue(null)]
        [HtmlAttributeName("id")]
        [JsonProperty("id")]
        public new string Id { get; set; }

        [DefaultValue(null)]
        [HtmlAttributeName("sourceID")]
        [JsonProperty("sourceID")]
        public new string SourceID { get; set; }

        [DefaultValue(null)]
        [HtmlAttributeName("customFields")]
        [JsonProperty("customFields")]
        public object[] CustomFields { get; set; }

        [DefaultValue(null)]
        [HtmlAttributeName("targetID")]
        [JsonProperty("targetID")]
        public new string TargetID { get; set; }

        [DefaultValue(null)]
        [HtmlAttributeName("crudAction")]
        [JsonProperty("crudAction")]
        public new CRUDAction CrudAction { get; set; }
    }
}