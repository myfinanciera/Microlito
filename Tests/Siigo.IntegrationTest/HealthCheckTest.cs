using Siigo.Microservice.Api;
using Siigo.IntegrationTest.Fixtures;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Siigo.IntegrationTest
{
    public sealed class HealthCheckTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient client;

        public HealthCheckTest(CustomWebApplicationFactory<Startup> factory) =>
            client = factory.CreateClient();


        public async Task GetStatus_Default_Returns200Ok()
        {
            var response = await this.client.GetAsync("/health");

            response.EnsureSuccessStatusCode(); // Status Code 200-299

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
