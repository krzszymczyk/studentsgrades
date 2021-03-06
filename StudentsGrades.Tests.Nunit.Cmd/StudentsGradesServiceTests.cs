using System.Collections.Generic;
using NUnit.Framework;
using StudentsGrades.Models;
using StudentsGrades.Services;

namespace StudentsGrades.Tests.Nunit.Cmd
{
    
    public class StudentsGradesServiceTests
    {
        [Test]
        public void Calculate_Should_Return_Correct_Result()
        {
            var list = new List<Grade>
            {
                new Grade {Value = 5, Weight = 2},
                new Grade {Value = 4, Weight = 3}
            };

            var result = _averageServiceUnderTests.Calculate(list);

            Assert.AreEqual(4.4M, result);
        }

        #region Configuration

        StudentGradesAverageService _averageServiceUnderTests;

        public StudentsGradesServiceTests()
        {
            _averageServiceUnderTests = new StudentGradesAverageService();
        }

        #endregion
    }
}