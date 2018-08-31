using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Moq;
using StudentsGrades.Services;
using Xunit;

namespace StudentsGrades.Tests.XUnit
{
    public class StudentsFinalRatingServiceTests
    {
        #region configuration

        private StudentsFinalRatingService serviceUnderTests;
        private Mock<IStudentGradesAverageService> studentsGradesAverageServiceMock;

        public StudentsFinalRatingServiceTests()
        {
            studentsGradesAverageServiceMock = new Mock<IStudentGradesAverageService>();
            serviceUnderTests = new StudentsFinalRatingService(studentsGradesAverageServiceMock.Object);
        }

        #endregion

        [Theory]
        [InlineData(5.5, 6)]
        [InlineData(4.7, 5)]
        [InlineData(3.7, 4)]
        [InlineData(2.7, 3)]
        [InlineData(1.7, 2)]
        [InlineData(1.5, 1)]
        public void GetFinalRatingShouldReturnCorrectResult(double average, int expectedResult)
        {
            //Arrange
            studentsGradesAverageServiceMock.Setup(s => s.Calculate(null)).Returns((decimal) average);
            //Act
            var result = serviceUnderTests.GetFinalRating(null);
                //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
