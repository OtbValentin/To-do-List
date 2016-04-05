using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Epam.TodoManager.Presentation.WebMvc.Controllers
{
    public class WebappController : Controller
    {
        // GET: Webapp
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lists()
        {
            return View();
        }

        public ActionResult Tasks()
        {
            return View();
        }

        public ActionResult Task()
        {
            return View();
        }

    }

    public class AjaxOnly : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            return controllerContext.RequestContext.HttpContext.Request.IsAjaxRequest();
        }
    }
}