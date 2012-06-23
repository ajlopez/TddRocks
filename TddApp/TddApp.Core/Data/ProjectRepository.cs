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

        public ProjectRepository()
            : this(new List<Project>())
        {
        }

        public ProjectRepository(IList<Project> projects)
        {
            this.projects = projects;
        }

        public IQueryable<Project> GetProjects()
        {
            return this.projects.AsQueryable();
        }
    }
}
