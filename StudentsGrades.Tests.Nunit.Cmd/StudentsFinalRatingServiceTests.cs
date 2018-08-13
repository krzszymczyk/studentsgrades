using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
using NUnit.Framework;
using StudentsGrades.Services;

namespace StudentsGrades.Tests.Nunit.Cmd
{
    public class StudentsFinalRatingServiceTests
    {
        #region Configuration

        private StudentsFinalRatingService serviceUnderTests;
        private IStudentGradesAverageService studentGradesAverageServiceMock;
        public StudentsFinalRatingServiceTests()
        {
            studentGradesAverageServiceMock = Substitute.For<IStudentGradesAverageService>();
            serviceUnderTests  = new StudentsFinalRatingService(studentGradesAverageServiceMock);
        }

        #endregion
        [Test]
        [TestCase(5.5, 6)]
        [TestCase(4.7, 5)]
        [TestCase(3.7, 4)]
        [TestCase(2.7, 3)]
        [TestCase(1.7, 2)]
        [TestCase(1.5, 1)]

        public void GetFinalRatingShouldReturnCorrectResult(double average, int expectedResult)
        {
            studentGradesAverageServiceMock.Calculate(null).Returns(((decimal)average));
            //Arrange

            //Act
            var result = serviceUnderTests.GetFinalRating(null);
            //Assert;
            Assert.AreEqual(expectedResult,result);
        }
    }
}
