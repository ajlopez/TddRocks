using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkingDays
{
    public class WorkingDaysCalendar
    {
        private IList<DayOfWeek> nonWorkingDaysOfWeek = new List<DayOfWeek>() { DayOfWeek.Saturday, DayOfWeek.Sunday };

        public bool IsWorkingDay(DateTime day)
        {
            if (this.nonWorkingDaysOfWeek.Contains(day.DayOfWeek))
                return false;

            return true;
        }

        public void AddDayOfWeekAsWorkingDay(DayOfWeek dayOfWeek)
        {
            if (this.nonWorkingDaysOfWeek.Contains(dayOfWeek))
                this.nonWorkingDaysOfWeek.Remove(dayOfWeek);
        }

        public void AddDayOfWeekAsNonWorkingDay(DayOfWeek dayOfWeek)
        {
            if (!this.nonWorkingDaysOfWeek.Contains(dayOfWeek))
                this.nonWorkingDaysOfWeek.Add(dayOfWeek);
        }
    }
}
