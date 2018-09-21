using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https=//go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class TreeViewController : Controller
    {
        
        public IActionResult RTL()
        {
            List<object> treedata = new List<object>();
            treedata.Add(new
            {
                id = "1",
                name = "Web Controls",
                expanded = true,
                hasChild = true
            });
            treedata.Add(new
            {
                id = "2",
                pid = "1",
                name = "Calendar",
                hasChild = true
            });
            treedata.Add(new
             {
                 id = "7",
                 pid = "2",
                 name = "Constructor",
             });
            treedata.Add(new
              {
                  id = "8",
                  pid = "2",
                  name = "Properties",
              });
            treedata.Add(new
               {
                   id = "9",
                   pid = "2",
                   name = "Methods",
               });
            treedata.Add(new
                {
                    id = "9",
                    pid = "2",
                    name = "Events",
                });
            treedata.Add(new
                 {
                     id = "3",
                     pid = "1",
                     name = "Data Grid",
                     hasChild = true
                 });
            treedata.Add(new
                  {
                      id = "11",
                      pid = "3",
                      name = "Constructor",
                  });
            treedata.Add(new
                  {
                      id = "12",
                      pid = "3",
                      name = "Fields",
                  });
            treedata.Add(new
                  {
                      id = "13",
                      pid = "3",
                      name = "Properties",
                  });
            treedata.Add(new
                    {
                        id = "14",
                        pid = "3",
                        name = "Methods",
                    });
            treedata.Add(new
                     {
                         id = "15",
                         pid = "3",
                         name = "Events",
                     });
            treedata.Add(new
                      {
                          id = "4",
                          pid = "1",
                          name = "DropDownList",
                          hasChild = true
                      });
            treedata.Add(new
                       {
                           id = "16",
                           pid = "4",
                           name = "Constructor",
                       });
            treedata.Add(new
                       {
                           id = "17",
                           pid = "4",
                           name = "Events",
                       });
            treedata.Add(new
                        {
                            id = "18",
                            pid = "4",
                            name = "Properties",
                        });
            treedata.Add(new
                         {
                             id = "5",
                             pid = "1",
                             name = "Menu",
                             hasChild = true
                         });
                          treedata.Add(new
                          {
                              id = "19",
                              pid = "5",
                              name = "Constructor",
                          });
                           treedata.Add(new
                           {
                               id = "20",
                               pid = "5",
                               name = "Events",
                           });
                           treedata.Add(new
                           {
                               id = "21",
                               pid = "5",
                               name = "Properties",
                           });

                            ViewBag.dataSource = treedata;

            return View();
        }
    }
}









