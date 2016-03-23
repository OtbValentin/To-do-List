using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epam.TodoManager.Presentation.WebMvc.Controllers
{
    public class WebappController : Controller
    {
        // GET: Webapp
        public ActionResult Inbox()
        {
            return View();
        }

        public ActionResult Tasks()
        {
            return View();
        }

        public ActionResult Lists()
        {
            return View();
        }
    }
}