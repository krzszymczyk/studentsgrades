using System;
using System.Collections.Generic;
using StudentsGrades.Models;
using StudentsGrades.Services;
using StudentsGrades.Tests.XUnit.ClassData;
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
        [Theory]
        [ClassData(typeof(StudentsGradesServiceTestsClassData))]
        public void Calculate_Should_Return_Correct_Statuses(List<Grade> gradesList,decimal expectedResult)
        {
            var result = serviceUnderTests.Calculate(gradesList);

            Assert.Equal(expectedResult, result);
        }
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
