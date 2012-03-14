namespace Calendario
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class WorkingDatesCalendar
    {
        private IList<DayOfWeek> nonWorkingDaysOfWeek = new List<DayOfWeek>();
        private IList<DateTime> nonWorkingDaysOfMonth = new List<DateTime>();

        public bool IsNonWorkingDate(DateTime day)
        {
            if (this.nonWorkingDaysOfWeek.Contains(day.DayOfWeek))
                return true;

            if (nonWorkingDaysOfMonth.Any(dt => dt.Month == day.Month && dt.Day == day.Day))
                return true;

            return false;
        }

        public void AddNonWorkingDayOfWeek(DayOfWeek dayOfWeek)
        {
            this.nonWorkingDaysOfWeek.Add(dayOfWeek);
        }

        public void AddNonWorkingDayOfMonth(DateTime day)
        {
            this.nonWorkingDaysOfMonth.Add(day);
        }
    }
}
