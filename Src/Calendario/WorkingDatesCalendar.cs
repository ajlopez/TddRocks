using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calendario
{
    public class WorkingDatesCalendar
    {
        private DayOfWeek nonWorkingDay;

        public bool IsNonWorkingDate(DateTime day)
        {
            if (day.DayOfWeek == nonWorkingDay)
                return true;

            return false;
        }

        public void AddNonWorkingDayOfWeek(DayOfWeek dayOfWeek)
        {
            this.nonWorkingDay = dayOfWeek;
        }
    }
}
