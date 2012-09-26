// -----------------------------------------------------------------------
// <copyright file="Project.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Projects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Project
    {
        private IList<ProjectAllocatedResource> allocations = new List<ProjectAllocatedResource>();

        public void AllocateResource(Resource resource, DateTime fromDate, DateTime toDate, int dailyload)
        {
            if (resource == null)
                throw new ArgumentNullException("resource");

            for (var day = fromDate; day <= toDate; day = day.AddDays(1))
            {
                if (day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)
                    continue;
                this.allocations.Add(new ProjectAllocatedResource()
                {
                    Resource = resource,
                    Day = day,
                    Load = dailyload
                });
            }
        }

        public int GetDailyLoad(Resource resource, DateTime fromDate)
        {
            var allocation = this.allocations.FirstOrDefault(alloc => alloc.Day == fromDate && alloc.Resource == resource);

            if (allocation == null)
                return 0;

            return allocation.Load;
        }
    }
}
