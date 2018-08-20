using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moq;
using StudentsGrades.Models;
using StudentsGrades.Services;
using Xunit;

namespace StudentsGrades.Tests.XUnit
{
    public class StudentsFinalRatingSupervisorServiceTests
    {
        [Fact]
        public async Task GetFinalRating_RatingIsLessThan4_RequestToSupervisorShouldnotBeSent()
        {
            //Arrange
            Guid studentId = Guid.Empty;
            var gradesList = new List<Grade>();
            studentsFinalRatingServiceMock.Setup(s => s.GetFinalRating(gradesList)).Returns(3);
            //Act
            int result = await serviceUnderTest.GetFinalRating(studentId, gradesList);

            //Assert
            supervisorApiServiceMock.Verify(s=>s.SendRating(studentId,result), Times.Never);
        }
        [Fact]
        public async Task GetFinalRating_RatingIsLessEqual4_RequestToSupervisorShouldBeSent()
        {
            //Arrange
            Guid studentId = Guid.Empty;
            var gradesList = new List<Grade>();
            studentsFinalRatingServiceMock.Setup(s => s.GetFinalRating(gradesList)).Returns(4);
            //Act
            int result = await serviceUnderTest.GetFinalRating(studentId, gradesList);

            //Assert
            supervisorApiServiceMock.Verify(s => s.SendRating(studentId, result), Times.Once);
        }
        [Fact]
        public async Task GetFinalRating_RatingIsGreatedThanl4_RequestToSupervisorShouldBeSent()
        {
            //Arrange
            Guid studentId = Guid.Empty;
            var gradesList = new List<Grade>();
            studentsFinalRatingServiceMock.Setup(s => s.GetFinalRating(gradesList)).Returns(5);
            //Act
            int result = await serviceUnderTest.GetFinalRating(studentId, gradesList);

            //Assert
            supervisorApiServiceMock.Verify(s => s.SendRating(studentId, result), Times.Once);
        }

        #region Configuration

        private IStudentsFinalRatingSupervisorService serviceUnderTest;

        private Mock<IStudentsFinalRatingService> studentsFinalRatingServiceMock;

        private Mock<ISupervisorApiService> supervisorApiServiceMock;
        public StudentsFinalRatingSupervisorServiceTests()
        {
            studentsFinalRatingServiceMock = new Mock<IStudentsFinalRatingService>();
            supervisorApiServiceMock = new Mock<ISupervisorApiService>();
            serviceUnderTest = new StudentsFinalRatingSupervisorService(studentsFinalRatingServiceMock.Object, supervisorApiServiceMock.Object);
        }


        #endregion
    }
}
