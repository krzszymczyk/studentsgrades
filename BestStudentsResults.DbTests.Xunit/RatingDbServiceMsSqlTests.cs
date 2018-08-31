using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestStudentsResults.DbTests.Xunit.Fixtures;
using BestStudentsResults.Services;
using BestStudentsResults.ViewModels;
using Xunit;

namespace BestStudentsResults.DbTests.Xunit
{
    public class RatingDbServiceMsSqlTests:IClassFixture<MsSqlDbFixture>
    {
        [Fact]
        public async  Task AddRating_Record_should_be_added_to_DB()
        {
            var model = new StudentResultViewModel
            {
                Rating = 5,
                StudentId = Guid.NewGuid()
            };

            var result = await serviceUnderTest.AddRating(model);

            Assert.NotEmpty(dbFixture.DbContext.StudentsResults.ToList());
        }
        #region configuration

        private RatingDbService serviceUnderTest;
        private MsSqlDbFixture dbFixture;

        public RatingDbServiceMsSqlTests(MsSqlDbFixture dbFixture)
        {
            serviceUnderTest = new RatingDbService(dbFixture.DbContext);
            this.dbFixture = dbFixture;
        }

        #endregion
    }
}
