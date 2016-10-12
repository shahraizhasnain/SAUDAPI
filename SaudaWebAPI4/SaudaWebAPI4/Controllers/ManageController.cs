using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaudaWebAPI4.Controllers
{
    public class ManageController : Controller
    {
        // GET: Manage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StoreView()
        {
            var manage = new[]
            {
                new Models.Category()
                {
                CategoryID = 1,
                CategoryName = "New1",
                CategoryDisplayName = "NewDisplay 1"
                },

                new Models.Category()
                {
                CategoryID = 1,
                CategoryName = "New1",
                CategoryDisplayName = "NewDisplay 1"
                },

                new Models.Category()
                {
                CategoryID = 1,
                CategoryName = "New1",
                CategoryDisplayName = "NewDisplay 1"
                },

                new Models.Category()
                {
                CategoryID = 1,
                CategoryName = "New1",
                CategoryDisplayName = "NewDisplay 1"
                },

                new Models.Category()
                {
                CategoryID = 1,
                CategoryName = "New1",
                CategoryDisplayName = "NewDisplay 1"
                }
        };
            
            return View(manage);
        }
    }
}