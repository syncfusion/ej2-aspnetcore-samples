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
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers {
    public partial class DocumentEditorController : Controller
    {
        public ActionResult MailMerge()
        {
            List<object> exportItems = new List<object>();
            exportItems.Add(new { text = "Microsoft Word (.docx)", id = "word" });
            exportItems.Add(new { text = "Syncfusion Document Text (.sfdt)", id = "sfdt" });
            ViewBag.ExportItems = exportItems;

           List<object> listdata = new List<object>();
            listdata.Add(new
            {
                text = "ProductName",
                id = "_productname",
                Category = "Drag or click the field to insert.",
                htmlAttributes = new { draggable = true }
            });
            listdata.Add(new
            {
                text = "ShipName",
                id = "_shipname",
                Category = "Drag or click the field to insert.",
                htmlAttributes = new { draggable = true }
            });
            listdata.Add(new
            {
                text = "CustomerID",
                id = "_customerid",
                Category = "Drag or click the field to insert.",
                htmlAttributes = new { draggable = true }
            });
            listdata.Add(new
            {
                text = "Quantity",
                id = "_quantity",
                Category = "Drag or click the field to insert.",
                htmlAttributes = new { draggable = true }
            });
            listdata.Add(new
            {
                text = "UnitPrice",
                id = "_unitprice",
                Category = "Drag or click the field to insert.",
                htmlAttributes = new { draggable = true }
            });
            listdata.Add(new
            {
                text = "Discount",
                id = "_discount",
                Category = "Drag or click the field to insert.",
                htmlAttributes = new { draggable = true }
            });         
            listdata.Add(new
            {
                text = "ShipAddress",
                id = "_shipaddress",
                Category = "Drag or click the field to insert.",
                htmlAttributes = new { draggable = true }
            });
            listdata.Add(new
            {
                text = "ShipCity",
                id = "_shipcity",
                Category = "Drag or click the field to insert.",
                htmlAttributes = new { draggable = true }
            });
            listdata.Add(new
            {
                text = "ShipCountry",
                id = "_shipcountry",
                Category = "Drag or click the field to insert.",
                htmlAttributes = new { draggable = true }
            });
            listdata.Add(new
            {
                text = "OrderId",
                id = "_orderid",
                Category = "Drag or click the field to insert.",
                htmlAttributes = new { draggable = true }
            });
            listdata.Add(new
            {
                text = "OrderDate",
                id = "_orderdate",
                Category = "Drag or click the field to insert.",
                htmlAttributes = new { draggable = true }
            });
            ViewBag.dataSource = listdata;
            return View();
        }

        }
    }

