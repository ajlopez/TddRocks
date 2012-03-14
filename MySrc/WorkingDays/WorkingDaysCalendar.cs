using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkingDays
{
    public class WorkingDaysCalendar
    {
        private DayOfWeek? workingDay;

        public bool IsWorkingDay(DateTime day)
        {
            if (this.workingDay.HasValue && this.workingDay.Value == day.DayOfWeek)
                return true;

            if (day.DayOfWeek == DayOfWeek.Sunday || day.DayOfWeek == DayOfWeek.Saturday)
                return false;

            return true;
        }

        public void AddDayOfWeekAsWorkingDay(DayOfWeek dayOfWeek)
        {
            this.workingDay = dayOfWeek;
        }
    }
}
