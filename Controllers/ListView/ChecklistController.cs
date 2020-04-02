using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.ListView
{
    public partial class ListViewController : Controller
    {

        public IActionResult Checklist()
        {
            List<object> listdata = new List<object>();
            listdata.Add(new
            {
                text = "Audi A4",
                id = "9bdb",
                category = "Audi"
            });
            listdata.Add(new
            {
                text = "Audi A4",
                id = "9bdb",
                category = "Audi"
            });
            listdata.Add(new
            {
                text = "Audi A5",
                id = "4589",
                category = "Audi"
            });

            listdata.Add(new
            {
                text = "Audi A6",
                id = "e807",
                category = "Audi"
            });
            listdata.Add(new
            {
                text = "Audi A7",
                id = "a0cc",
                category = "Audi"
            });
            listdata.Add(new
            {
                text = "Audi A8",
                id = "5e26",
                category = "Audi"
            });
            listdata.Add(new
            {
                text = "BMW 501",
                id = "f849",
                category = "BMW"
            });
            listdata.Add(new
            {
                text = "BMW 502",
                id = "7aff",
                category = "BMW"
            });
            listdata.Add(new
            {
                text = "BMW 503",
                id = "b1da",
                category = "BMW"
            });
            listdata.Add(new
            {
                text = "BMW 507",
                id = "de2f",
                category = "BMW"
            });
            listdata.Add(new
            {
                text = "BMW 3200",
                id = "b2b1",
                category = "BMW"
            });
            List<object> data = new List<object>();
            data.Add(new { text = "Hennessey Venom", id = "list-01" });
            data.Add(new { text = "Bugatti Chiron", id = "list-02" });
            data.Add(new { text = "Bugatti Veyron Super Sport", id = "list-03" });
            data.Add(new { text = "SSC Ultimate Aero", id = "list-04" });
            data.Add(new { text = "Koenigsegg CCR", id = "list-05" });
            data.Add(new { text = "McLaren F1", id = "list-06" });
            data.Add(new { text = "Aston Martin One- 77", id = "list-07" });
            data.Add(new { text = "Jaguar XJ220", id = "list-08" });
            data.Add(new { text = "McLaren P1", id = "list-09" });
            data.Add(new { text = "Ferrari LaFerrari", id = "list-10" });
            data.Add(new { text = "Mercedes-Benz Aston Martin", id = "list-11" });
            data.Add(new { text = "Zenvo ST1", id = "list-12" });
            data.Add(new { text = "Lamborghini Veneno", id = "list-13" });

            ViewBag.groupData = listdata;
            ViewBag.dataSource = data;
            return View();
        }
    }
}