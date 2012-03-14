using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WorkingDays.Tests
{
    [TestClass]
    public class WorkingDaysCalendarTests
    {
        [TestMethod]
        public void TypicalMondayIsAWorkingDay()
        {
            WorkingDaysCalendar calendar = new WorkingDaysCalendar();
            
            DateTime monday = new DateTime(2012, 3, 12);

            Assert.IsTrue(calendar.IsWorkingDay(monday));
        }
    }
}
