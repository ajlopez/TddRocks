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
            if (day.DayOfWeek == DayOfWeek.Sunday)
                return true;

            return false;
        }
    }
}
