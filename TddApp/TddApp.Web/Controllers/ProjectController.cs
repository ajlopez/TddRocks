namespace TddApp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TddApp.Core.Entities;

    public class ProjectController : Controller
    {
        private IList<Project> projects;

        public ProjectController()
            : this(Domain.Current.Projects)
        {
        }

        public ProjectController(IList<Project> projects)
        {
            this.projects = projects;
        }

        public ActionResult Index()
        {
            return View(this.projects);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Project project)
        {
            int maxid = 0;
            
            if (this.projects.Count > 0)
                maxid = this.projects.Max(p => p.Id);

            project.Id = maxid + 1;
            this.projects.Add(project);
            return RedirectToAction("Index");
        }
    }
}
