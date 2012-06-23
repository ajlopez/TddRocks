namespace TddApp.Core.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TddApp.Core.Entities;

    public class ProjectRepository
    {
        private IList<Project> projects;
        private int maxid = 0;

        public ProjectRepository()
            : this(new List<Project>())
        {
        }

        public ProjectRepository(IList<Project> projects)
        {
            this.projects = projects;

            if (projects.Count > 0)
                this.maxid = projects.Max(p => p.Id);
        }

        public IQueryable<Project> GetProjects()
        {
            return this.projects.AsQueryable();
        }

        public void AddProject(Project project)
        {
            maxid++;
            project.Id = maxid;
            this.projects.Add(project);
        }
    }
}
