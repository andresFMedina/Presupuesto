using Presupuesto.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Presupuesto.IntegrationTest
{
    public class CapituloIntegrationTest : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public CapituloIntegrationTest(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task TestGetCapitulosAsync()
        {
            var request = "/api/Capitulo";

            var response = await Client.GetAsync(request);

            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task TestGetCapitulosByIdAsync()
        {
            var request = "/api/Capitulo/3";

            var response = await Client.GetAsync(request);

            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task TestPostCapitulosAsync()
        {
            var request = "/api/Capitulo";
            var Capitulo = new Capitulo
            {
                Id = 0,
                Numero = 1,
                Descripcion = "Descripcion 1",
                ProyectoId = 1002,
                Subtotal = 9874100
            };

            var response = await Client.PostAsync(request, ContentHelper.GetStringContent(Capitulo));

            var value = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task TestPutCapitulosAsync()
        {
            var request = "/api/Capitulo/3";
            var Capitulo = new Capitulo
            {
                Id = 3,
                Numero = 1,
                Descripcion = "Descripcion 2",
                ProyectoId = 1002,
                Subtotal = 9874100
            };

            var response = await Client.PutAsync(request, ContentHelper.GetStringContent(Capitulo));

            var value = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
        }
    }
}
