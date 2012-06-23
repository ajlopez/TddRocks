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
    }
}
