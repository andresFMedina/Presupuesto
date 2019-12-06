using Presupuesto.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Presupuesto.IntegrationTest
{
    public class RecursoBasicoIntegrationTest : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public RecursoBasicoIntegrationTest(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task TestGetRecursoBasicosAsync()
        {
            var request = "/api/RecursoBasico";

            var response = await Client.GetAsync(request);

            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task TestGetRecursoBasicosByIdAsync()
        {
            var request = "/api/RecursoBasico/2646";

            var response = await Client.GetAsync(request);

            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task TestPostRecursoBasicosAsync()
        {
            var request = "/api/RecursoBasico";
            var RecursoBasico = new RecursoBasico
            {

                Id = 0,
                Codigo = "56589",
                Descripcion = "Recurso 3000",
                Precio = 68930,
                Unidad = "UND"

            };

            var response = await Client.PostAsync(request, ContentHelper.GetStringContent(RecursoBasico));

            var value = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task TestPutRecursoBasicosAsync()
        {
            var request = "/api/RecursoBasico/2646";
            var RecursoBasico = new RecursoBasico
            {
                Id = 2646,
                Codigo = "56589",
                Descripcion = "Recurso 3000",
                Precio = 68930,
                Unidad = "UND"
            };

            var response = await Client.PutAsync(request, ContentHelper.GetStringContent(RecursoBasico));

            var value = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
        }
    }
}
