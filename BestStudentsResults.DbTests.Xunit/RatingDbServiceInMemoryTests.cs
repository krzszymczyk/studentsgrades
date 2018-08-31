using System;
using System.Linq;
using System.Threading.Tasks;
using BestStudentsResults.DbTests.Xunit.Fixtures;
using BestStudentsResults.Services;
using BestStudentsResults.ViewModels;
using Xunit;

namespace BestStudentsResults.DbTests.Xunit
{
    public class RatingDbServiceInMemoryTests:IClassFixture<InMemoryDbFixture>
    {
        [Fact]
        public async Task AddRating_RecordShouldBeAddedToDb()
        {
            var model = new StudentResultViewModel {Rating = 5, StudentId = Guid.NewGuid()};

            var result = await serviceUnderTest.AddRating(model);

            Assert.NotEmpty(dbFixture.DbContext.StudentsResults.ToList());
        }

        #region configuration

        private RatingDbService serviceUnderTest;
        private InMemoryDbFixture dbFixture;

        public RatingDbServiceInMemoryTests(InMemoryDbFixture dbFixture)
        {
            serviceUnderTest = new RatingDbService(dbFixture.DbContext);

            this.dbFixture = dbFixture;
        }
        //sko�czone na 12.02 -> nast�pny 12.03 test na sqlserver
        #endregion

    }
}
