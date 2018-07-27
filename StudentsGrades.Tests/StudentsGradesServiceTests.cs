using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsGrades.Models;
using StudentsGrades.Services;

namespace StudentsGrades.Tests
{
    [TestClass]
    public class StudentsGradesServiceTests
    {
        #region Configuration

        StudentGradesService serviceUnderTests;

        public StudentsGradesServiceTests()
        {
            serviceUnderTests = new StudentGradesService();
        }

        #endregion

        [TestMethod]
        public void Calculate_Should_Return_Correct_Result()
        {
            var list = new List<Grade>
            {
                new Grade {Value = 5, Weight = 2},
                new Grade {Value = 4, Weight = 3}
            };

            var result = serviceUnderTests.Calculate(list);

            Assert.AreEqual(4.4M,result);
        }
    }
}
