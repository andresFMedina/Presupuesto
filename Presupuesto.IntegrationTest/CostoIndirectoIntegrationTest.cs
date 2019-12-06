using Presupuesto.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Presupuesto.IntegrationTest
{
    public class CostoIndirectoIntegrationTest : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public CostoIndirectoIntegrationTest(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task TestGetCostoIndirectosAsync()
        {
            var request = "/api/CostoIndirecto";

            var response = await Client.GetAsync(request);

            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task TestGetCostoIndirectosByIdAsync()
        {
            var request = "/api/CostoIndirecto/1005";

            var response = await Client.GetAsync(request);

            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task TestPostCostoIndirectosAsync()
        {
            var request = "/api/CostoIndirecto";
            var CostoIndirecto = new CostoIndirecto
            {
                Id = 0,
                ProyectoId = 1002,
                Descripcion = "Costo Indirecto 1",
                Porcentaje = (float)0.22,
            };

            var response = await Client.PostAsync(request, ContentHelper.GetStringContent(CostoIndirecto));

            var value = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task TestPutCostoIndirectosAsync()
        {
            var request = "/api/CostoIndirecto/1005";
            var CostoIndirecto = new CostoIndirecto
            {
                Id = 1005,
                ProyectoId = 1002,
                Descripcion = "Costo Indirecto 1",
                Porcentaje = (float)0.20,
            };

            var response = await Client.PutAsync(request, ContentHelper.GetStringContent(CostoIndirecto));

            var value = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
        }
    }

}
