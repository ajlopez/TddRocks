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
        public void Test1()
        {
            WorkingDatesCalendar argentineCalendar = new WorkingDatesCalendar();
            Assert.IsTrue(argentineCalendar.IsNonWorkingDate(someSunday()));
        }

        [TestMethod]
        public void Test2()
        {
            WorkingDatesCalendar argentineCalendar = new WorkingDatesCalendar();
            Assert.IsFalse(argentineCalendar.IsNonWorkingDate(someMonday()));
        }

        [TestMethod]
        public void Test3()
        {
            WorkingDatesCalendar argentineCalendar = new WorkingDatesCalendar();
            Assert.IsTrue(argentineCalendar.IsNonWorkingDate(someSaturday()));
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
