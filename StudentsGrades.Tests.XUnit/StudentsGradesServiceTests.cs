using System;
using System.Collections.Generic;
using StudentsGrades.Models;
using StudentsGrades.Services;
using Xunit;

namespace StudentsGrades.Tests.XUnit
{
    public class StudentsGradesServiceTests
    {
       
        #region Configuration

        StudentGradesService serviceUnderTests;

        public StudentsGradesServiceTests()
        {
            serviceUnderTests = new StudentGradesService();
        }

        #endregion

        [Fact]
        public void Calculate_Should_Return_Correct_Result()
        {
            var list = new List<Grade>
            {
                new Grade {Value = 5, Weight = 2},
                new Grade {Value = 4, Weight = 3}
            };

            var result = serviceUnderTests.Calculate(list);

            Assert.Equal(4.4M, result);
        }
    }
}
