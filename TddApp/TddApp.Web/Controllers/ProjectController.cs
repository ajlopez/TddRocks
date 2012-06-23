namespace TddApp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TddApp.Core.Entities;
    using TddApp.Core.Services;

    public class ProjectController : Controller
    {
        private ProjectServices services;

        public ProjectController()
            : this(Domain.Current.Projects)
        {
        }

        public ProjectController(IList<Project> projects)
            : this(new ProjectServices(projects))
        {
        }

        public ProjectController(ProjectServices services)
        {
            this.services = services;
        }

        public ActionResult Index()
        {
            return View(this.services.GetProjects());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Project project)
        {
            this.services.AddProject(project);
            return RedirectToAction("Index");
        }
    }
}
