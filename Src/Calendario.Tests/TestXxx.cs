using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calendario.Tests
{
    [TestClass]
    public class TestXxx
    {
        [TestMethod]
        public void WhenCalendarHasANonWorkingDayOfWeekReturnsItIsNonWorkingDay()
        {
            WorkingDatesCalendar argentineCalendar = new WorkingDatesCalendar();
            argentineCalendar.AddNonWorkingDayOfWeek(DayOfWeek.Sunday);
            Assert.IsTrue(argentineCalendar.IsNonWorkingDate(someSunday()));
        }

        [TestMethod]
        public void WhenCalendarHasANonWorkingDayOfWeekReturnsItIsNotNonWorkingDayForOtherDay()
        {
            WorkingDatesCalendar argentineCalendar = new WorkingDatesCalendar();
            argentineCalendar.AddNonWorkingDayOfWeek(DayOfWeek.Sunday);
            Assert.IsFalse(argentineCalendar.IsNonWorkingDate(someMonday()));
        }

        [TestMethod]
        public void WhenCalendarHasANonWorkingDayOfWeekReturnsNonWorkingForThatDayOfWeekAndFalseForAnotherOne()
        {
            WorkingDatesCalendar argentineCalendar = new WorkingDatesCalendar();
            argentineCalendar.AddNonWorkingDayOfWeek(DayOfWeek.Sunday);
            Assert.IsFalse(argentineCalendar.IsNonWorkingDate(someSaturday()));
            Assert.IsTrue(argentineCalendar.IsNonWorkingDate(someSunday()));
        }

        private DateTime someSaturday()
        {
            return new DateTime(2012, 3, 10);
        }

        private DateTime someSunday()
        {
            return new DateTime(2012, 3, 11);
        }

        private DateTime someMonday()
        {
            return new DateTime(2012, 3, 12);
        }
    }
}
