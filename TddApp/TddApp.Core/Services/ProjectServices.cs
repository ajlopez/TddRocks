namespace TddApp.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TddApp.Core.Entities;
    using TddApp.Core.Data;

    public class ProjectServices
    {
        private ProjectRepository repository;

        public ProjectServices()
            : this(new List<Project>())
        {
        }

        public ProjectServices(IList<Project> projects)
            : this(new ProjectRepository(projects))
        {
        }

        public ProjectServices(ProjectRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Project> GetProjects()
        {
            return this.repository.GetProjects();
        }

        public void AddProject(Project project)
        {
            this.repository.AddProject(project);
        }
    }
}
