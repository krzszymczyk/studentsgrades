using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StudentsGrades.Services
{
    public class SupervisorApiService:ISupervisorApiService
    {
        private HttpClient _client;

        public SupervisorApiService()
        {
            _client = new HttpClient {BaseAddress = new Uri("http://beststudentsresultapi.localtest.me/api/")};
        }
        public async Task<bool> SendRating(Guid studentId, int rating)
        {
            var model = new {StudentId = studentId, Rating = rating};
            var response = await _client.PostAsync("result", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8,"application/json"));
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var success = JsonConvert.DeserializeObject<bool>(responseContent);

                return success;
            }

            return false;
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
