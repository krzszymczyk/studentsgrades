using System;
using System.Threading.Tasks;
using NUnit.Framework;
using StudentsGrades.Services;

namespace StudentsGrades.IntegrationTests.NUnit
{
    [TestFixture]
    public class SupervisorApiServiceTests
    {
        private SupervisorApiService serviceUnderTests;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
             serviceUnderTests = new SupervisorApiService();
        }

        [Test]
        public async Task SendRating_ApiShouldReturnTrue()
        {
            var studentId = Guid.Empty;
            var rating = 5;

            var result = await serviceUnderTests.SendRating(studentId, rating);

            Assert.True(result);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            serviceUnderTests.Dispose();
        }
    }
}