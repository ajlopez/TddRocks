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

        [TestMethod]
        public void TypicalWeek()
        {
            WorkingDaysCalendar calendar = new WorkingDaysCalendar();

            DateTime monday = new DateTime(2012, 3, 12);
            Assert.AreEqual(monday.DayOfWeek, DayOfWeek.Monday);

            Assert.IsTrue(calendar.IsWorkingDay(monday));
            Assert.IsTrue(calendar.IsWorkingDay(monday.AddDays(1)));
            Assert.IsTrue(calendar.IsWorkingDay(monday.AddDays(2)));
            Assert.IsTrue(calendar.IsWorkingDay(monday.AddDays(3)));
            Assert.IsTrue(calendar.IsWorkingDay(monday.AddDays(4)));
            Assert.IsFalse(calendar.IsWorkingDay(monday.AddDays(5)));
            Assert.IsFalse(calendar.IsWorkingDay(monday.AddDays(6)));
        }

        [TestMethod]
        public void SetSaturdayAsAWorkingDay()
        {
            WorkingDaysCalendar calendar = new WorkingDaysCalendar();

            calendar.AddDayOfWeekAsWorkingDay(DayOfWeek.Saturday);

            DateTime saturday = new DateTime(2012, 3, 10);
            Assert.AreEqual(saturday.DayOfWeek, DayOfWeek.Saturday);        

            Assert.IsTrue(calendar.IsWorkingDay(saturday));
        }

        [TestMethod]
        public void SetMondayAsANonWorkingDay()
        {
            WorkingDaysCalendar calendar = new WorkingDaysCalendar();

            calendar.AddDayOfWeekAsNonWorkingDay(DayOfWeek.Monday);

            DateTime monday = new DateTime(2012, 3, 12);
            Assert.AreEqual(monday.DayOfWeek, DayOfWeek.Monday);

            Assert.IsFalse(calendar.IsWorkingDay(monday));
        }

        [TestMethod]
        public void SetWeekendAsWorkingDaysAndMondayAsANonWorkingDay()
        {
            WorkingDaysCalendar calendar = new WorkingDaysCalendar();

            calendar.AddDayOfWeekAsWorkingDay(DayOfWeek.Saturday);
            calendar.AddDayOfWeekAsWorkingDay(DayOfWeek.Sunday);
            calendar.AddDayOfWeekAsNonWorkingDay(DayOfWeek.Monday);

            DateTime saturday = new DateTime(2012, 3, 10);
            Assert.AreEqual(saturday.DayOfWeek, DayOfWeek.Saturday);

            Assert.IsTrue(calendar.IsWorkingDay(saturday));
            Assert.IsTrue(calendar.IsWorkingDay(saturday.AddDays(1)));
            Assert.IsFalse(calendar.IsWorkingDay(saturday.AddDays(2)));
        }
    }
}
