using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calendario
{
    public class WorkingDatesCalendar
    {
        public bool IsNonWorkingDate(DateTime day)
        {
            if (day.DayOfWeek == DayOfWeek.Sunday || day.DayOfWeek == DayOfWeek.Saturday)
                return true;

            return false;
        }
    }
}
