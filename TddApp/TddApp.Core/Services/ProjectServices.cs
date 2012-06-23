namespace TddApp.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TddApp.Core.Entities;

    public class ProjectServices
    {
        private IList<Project> projects;

        public ProjectServices()
            : this(new List<Project>())
        {
        }

        public ProjectServices(IList<Project> projects)
        {
            this.projects = projects;
        }

        public IEnumerable<Project> GetProjects()
        {
            return this.projects;
        }

        public void AddProject(Project project)
        {
            int maxid = 0;

            if (this.projects.Count > 0)
                maxid = this.projects.Max(p => p.Id);

            project.Id = maxid + 1;

            this.projects.Add(project);
        }
    }
}
