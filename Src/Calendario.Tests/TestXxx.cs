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

        [TestMethod]
        public void WhenCalendarHasTwoNonWorkingDayOfWeekAndReturnsNonWorkingForThoseDays()
        {
            WorkingDatesCalendar argentineCalendar = new WorkingDatesCalendar();
            argentineCalendar.AddNonWorkingDayOfWeek(DayOfWeek.Saturday);
            argentineCalendar.AddNonWorkingDayOfWeek(DayOfWeek.Sunday);
            Assert.IsTrue(argentineCalendar.IsNonWorkingDate(someSaturday()));
            Assert.IsTrue(argentineCalendar.IsNonWorkingDate(someSunday()));
        }

        [TestMethod]
        public void WhenCalendarHasANonWorkingDayOfMonthThatDayIsNonWorkingDate()
        {
            WorkingDatesCalendar argentineCalendar = new WorkingDatesCalendar();
            argentineCalendar.AddNonWorkingDayOfMonth(someJanuaryFirst());
            Assert.IsTrue(argentineCalendar.IsNonWorkingDate(someJanuaryFirst()));
        }

        [TestMethod]
        public void Test6()
        {
            WorkingDatesCalendar argentineCalendar = new WorkingDatesCalendar();
            argentineCalendar.AddNonWorkingDayOfMonth(someJanuaryFirst());
            Assert.IsFalse(argentineCalendar.IsNonWorkingDate(someNotJanuaryFirst()));
        }

        [TestMethod]
        public void WhenCalendarHasTwoNonWorkingDayOfMonthThoseDaysAreNonWorkingDate()
        {
            WorkingDatesCalendar argentineCalendar = new WorkingDatesCalendar();
            argentineCalendar.AddNonWorkingDayOfMonth(someJanuaryFirst());
            argentineCalendar.AddNonWorkingDayOfMonth(someChrismas());
            Assert.IsFalse(argentineCalendar.IsNonWorkingDate(someNotJanuaryFirst()));
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

        private DateTime someJanuaryFirst()
        {
            return new DateTime(2012, 1, 1);
        }

        private DateTime someNotJanuaryFirst()
        {
            return new DateTime(2012, 1, 2);
        }

        private DateTime someChrismas()
        {
            return new DateTime(2012, 12, 24);
        }
    }
}
