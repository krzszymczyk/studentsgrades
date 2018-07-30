using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsGrades.Models;
using StudentsGrades.Services;

namespace StudentsGrades.Tests.MsTest
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
        public void Calculate_Should_Return_Correct_Result_2_4167()
        {
            var list = new List<Grade>
            {
                new Grade {Value = 2.75M, Weight = 1},
                new Grade {Value = 1.75M, Weight = 1},
                new Grade {Value = 2.75M, Weight = 1}
            };

            var result = serviceUnderTests.Calculate(list);

            Assert.AreEqual(2.4167M,result);
        }

        [TestMethod]
        public void Calculate_Should_Return_Correct_Result_2_0833()
        {
            var list = new List<Grade>
            {
                new Grade {Value = 2.75M, Weight = 1},
                new Grade {Value = 1.75M, Weight = 1},
                new Grade {Value = 1.75M, Weight = 1}
            };

            var result = serviceUnderTests.Calculate(list);

            Assert.AreEqual(2.0833M, result);
        }

        [TestMethod]
        public void Calculate_Should_Return_Correct_Result_4_4()
        {
            var list = new List<Grade>
            {
                new Grade {Value = 5, Weight = 2},
                new Grade {Value = 4, Weight = 3}
            };

            var result = serviceUnderTests.Calculate(list);

            Assert.AreEqual(4.4M, result);
        }
    }
}
