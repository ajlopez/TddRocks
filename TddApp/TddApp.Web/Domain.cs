using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TddApp.Core.Entities;
using System.IO;
using System.Web.Helpers;

namespace TddApp.Web
{
    public class Domain
    {
        private static Domain current = new Domain();

        private IList<Project> projects = new List<Project>();

        public static Domain Current { get { return current; } }

        public IList<Project> Projects { get { return this.projects; } }

        public void InitializeFromFolder(string path)
        {
            string filename = Path.Combine(path, "Projects.json");
            string text = File.ReadAllText(filename);
            dynamic items = Json.Decode(text);

            foreach (dynamic item in items)
            {
                Project project = new Project();
                project.Id = item.Id;
                project.Name = item.Name;
                this.projects.Add(project);
            }
        }
    }
}

