using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsGrades.Services;

namespace StudentsGrades.IntegrationTests.MsTest
{
    [TestClass]
    public class SupervisorApiServiceTests
    {
        [TestMethod]
        public async Task SendRequest_ApiShouldReturnTrue()
        {
            var studentId = Guid.Empty;
            var rating = 5;

            var result = await serviceUnderTest.SendRating(studentId, rating);

            Assert.IsTrue(result);
        }

        #region Configuration
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            serviceUnderTest = new SupervisorApiService();
        }
        [ClassCleanup]
        public static void CleanUp()
        {
            serviceUnderTest.Dispose();
        }
        static ISupervisorApiService serviceUnderTest;




        #endregion
    }
}
