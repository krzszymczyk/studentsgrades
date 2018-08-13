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

        StudentGradesAverageService _averageServiceUnderTests;

        public StudentsGradesServiceTests()
        {
            _averageServiceUnderTests = new StudentGradesAverageService();
        }

        public static IEnumerable<object[]> GetGradesWithExpectedResults()
        {
            yield return new object[]
            {
                new List<Grade>
                {
                    new Grade {Value = 2.75M, Weight = 1},
                    new Grade {Value = 1.75M, Weight = 1},
                    new Grade {Value = 2.75M, Weight = 1},
                },
                2.4167M
            };
            yield return new object[]
            {
                new List<Grade>
                {
                    new Grade {Value = 2.75M, Weight = 1},
                    new Grade {Value = 1.75M, Weight = 1},
                    new Grade {Value = 1.75M, Weight = 1},
                },
                2.0833M
            };
        }

        #endregion

        [Theory]
        [MemberData(nameof(StudentsGradesServiceTests.GetGradesWithExpectedResults), MemberType = typeof(StudentsGradesServiceTests))]
        public void Calculate_Should_Return_Correct_Results_With_MemberData(List<Grade> gradesList, decimal expectedResult)
        {
            var result = _averageServiceUnderTests.Calculate(gradesList);

            Assert.Equal(expectedResult, result);
        }
        [Theory]
        [ClassData(typeof(StudentsGradesServiceTestsClassData))]
        public void Calculate_Should_Return_Correct_Statuses(List<Grade> gradesList,decimal expectedResult)
        {
            var result = _averageServiceUnderTests.Calculate(gradesList);

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

            var result = _averageServiceUnderTests.Calculate(list);

            Assert.Equal(4.4M, result);
        }
    }
}
