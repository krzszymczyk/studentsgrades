using System;
using System.Threading.Tasks;
using StudentsGrades.IntegrationTests.Xunit.Fixtures;
using Xunit;

namespace StudentsGrades.IntegrationTests.XUnit
{
    public class SupervisorApiServiceTests:IClassFixture<SupervisorApiServiceFixture>
    {
        private SupervisorApiServiceFixture fixture;

        public SupervisorApiServiceTests(SupervisorApiServiceFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task SendRating_ApiShouldReturnTrue()
        {
            var rating = 5;
            var studentId = Guid.Empty;

            var result = await fixture.ServiceUnderTest.SendRating(studentId, rating);

            Assert.True(result);
        }
    }
}
