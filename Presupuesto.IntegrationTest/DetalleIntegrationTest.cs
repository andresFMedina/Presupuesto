using Presupuesto.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Presupuesto.IntegrationTest
{
    public class DetalleIntegrationTest : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public DetalleIntegrationTest(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task TestGetDetallesAsync()
        {
            var request = "/api/Detalle";

            var response = await Client.GetAsync(request);

            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task TestGetDetallesByIdAsync()
        {
            var request = "/api/Detalle/4007";

            var response = await Client.GetAsync(request);

            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task TestPostDetallesAsync()
        {
            var request = "/api/Detalle";
            var Detalle = new Detalle
            {
                Id = 0,
                Codigo = "54643",
                Descripcion = "Descripcion",
                AnalisisUnitarioId = 3006,
                DetalleDe = "analisis",
                Precio = 546200,
                Rendimiento = 600,
                Unidad = "UND"
            };

            var response = await Client.PostAsync(request, ContentHelper.GetStringContent(Detalle));

            var value = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task TestPutDetallesAsync()
        {
            var request = "/api/Detalle/4007";
            var Detalle = new Detalle
            {
                Id = 4007,
                Codigo = "54643",
                Descripcion = "Descripcion",
                AnalisisUnitarioId = 3006,
                DetalleDe = "analisis",
                Precio = 546200,
                Rendimiento = 600,
                Unidad = "UND"
            };

            var response = await Client.PutAsync(request, ContentHelper.GetStringContent(Detalle));

            var value = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
        }
    }

}
