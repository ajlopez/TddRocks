using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TddApp.Web.Models;

namespace TddApp.Web.Controllers
{
    public class ProjectController : Controller
    {
        public ActionResult Index()
        {
            return View(new List<Project>());
        }
    }
}
