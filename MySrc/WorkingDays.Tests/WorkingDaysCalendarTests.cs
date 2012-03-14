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
            Assert.AreEqual(monday.DayOfWeek, DayOfWeek.Monday);

            Assert.IsTrue(calendar.IsWorkingDay(monday));
        }

        [TestMethod]
        public void TypicalSundayIsANonWorkingDay()
        {
            WorkingDaysCalendar calendar = new WorkingDaysCalendar();

            DateTime sunday = new DateTime(2012, 3, 11);
            Assert.AreEqual(sunday.DayOfWeek, DayOfWeek.Sunday);

            Assert.IsFalse(calendar.IsWorkingDay(sunday));
        }

        [TestMethod]
        public void TypicalSaturdayIsANonWorkingDay()
        {
            WorkingDaysCalendar calendar = new WorkingDaysCalendar();

            DateTime saturday = new DateTime(2012, 3, 10);
            Assert.AreEqual(saturday.DayOfWeek, DayOfWeek.Saturday);

            Assert.IsFalse(calendar.IsWorkingDay(saturday));
        }
    }
}
