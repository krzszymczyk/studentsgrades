using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsGrades.Models;
using StudentsGrades.Services;

namespace StudentsGrades.Tests.MsTest
{
    [TestClass]
    public class StudentsGradesAverageServiceTests
    {
        [DataTestMethod]
        [DataRow(5.5,6)]
        [DataRow(4.7,5)]
        [DataRow(3.7,4)]
        [DataRow(2.7,3)]
        [DataRow(1.7,2)]
        [DataRow(1.5,1)]
        public void GetFinalRating_ShouldReturnCorrectResult(double average, int expectedRating)
        {

            IStudentGradesAverageService studentGradesAverageService = new StudentsGradesAverageServiceMock((decimal)average);
            var serviceUnder = new StudentsFinalRatingService(studentGradesAverageService);

            var result = serviceUnder.GetFinalRating(null);

            Assert.AreEqual(result, expectedRating);
        }
    }

    public class StudentsGradesAverageServiceMock : IStudentGradesAverageService
    {
        private decimal average;

        public StudentsGradesAverageServiceMock(decimal average)
        {
            this.average = average;
        }
        public decimal Calculate(IEnumerable<Grade> grades)
        {
            return average;
        }
    }
}
