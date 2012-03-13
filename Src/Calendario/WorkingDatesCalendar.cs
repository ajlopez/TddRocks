namespace Calendario
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class WorkingDatesCalendar
    {
        private IList<DayOfWeek> nonWorkingDaysOfWeek = new List<DayOfWeek>();

        public bool IsNonWorkingDate(DateTime day)
        {
            if (this.nonWorkingDaysOfWeek.Contains(day.DayOfWeek))
                return true;

            return false;
        }

        public void AddNonWorkingDayOfWeek(DayOfWeek dayOfWeek)
        {
            this.nonWorkingDaysOfWeek.Add(dayOfWeek);
        }
    }
}
