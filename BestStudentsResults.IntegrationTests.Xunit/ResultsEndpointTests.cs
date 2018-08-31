using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BestStudentsResults.IntegrationTests.Xunit.Collections;
using BestStudentsResults.IntegrationTests.Xunit.Fixtures;
using BestStudentsResults.ViewModels;
using Newtonsoft.Json;
using Xunit;

namespace BestStudentsResults.IntegrationTests.Xunit
{
    [Collection(nameof(IntegrationCollection))]
    public class ResultsEndpointTests
    {
        [Fact]
        public async Task Post_ResultShouldBeSavedInDb()
        {
            var model = new StudentResultViewModel {Rating = 5, StudentId = Guid.NewGuid()};

            var response =
                await integrationFixture.Client.PostAsync(endpoint, new StringContent(JsonConvert.SerializeObject(model),Encoding.UTF8,"application/json"));

            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(1, dbFixture.DbContext.StudentsResults.Where(r=>r.StudentId == model.StudentId).Count());

        }

        [Fact]
        public async Task Post_ResultShouldNotBeSavedInDb()
        {
            var model = new StudentResultViewModel { Rating = 5, StudentId = Guid.Empty };

            var response =
                await integrationFixture.Client.PostAsync(endpoint, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(0, dbFixture.DbContext.StudentsResults.Where(r => r.StudentId == model.StudentId).Count());

        }
        #region configuration

        private IntegrationFixture integrationFixture;
        private DbFixture dbFixture;
        private string endpoint = "api/result/";

        public ResultsEndpointTests(IntegrationFixture integrationFixture, DbFixture dbFixture)
        {
            this.integrationFixture = integrationFixture;
            this.dbFixture = dbFixture;
        }

        #endregion

    }
}
