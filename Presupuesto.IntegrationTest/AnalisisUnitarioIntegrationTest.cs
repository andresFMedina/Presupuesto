using Presupuesto.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Presupuesto.IntegrationTest
{
    public class AnalisisUnitarioIntegrationTest : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public AnalisisUnitarioIntegrationTest(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task TestGetAnalisisUnitariosAsync()
        {
            var request = "/api/AnalisisUnitario";

            var response = await Client.GetAsync(request);

            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task TestGetAnalisisUnitariosByIdAsync()
        {
            var request = "/api/AnalisisUnitario/3006";

            var response = await Client.GetAsync(request);

            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task TestPostAnalisisUnitariosAsync()
        {
            var request = "/api/AnalisisUnitario";
            var AnalisisUnitario = new AnalisisUnitario
            {
                Id = 0,
                Codigo = "54643",
                Descripcion = "Descripcion",
                ProyectoId = 1002,
                Unidad = "M2",
                ValorUnitario = 645900
            };

            var response = await Client.PostAsync(request, ContentHelper.GetStringContent(AnalisisUnitario));

            var value = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task TestPutAnalisisUnitariosAsync()
        {
            var request = "/api/AnalisisUnitario/3006";
            var AnalisisUnitario = new AnalisisUnitario
            {
                Id = 3006,
                Codigo = "54643",
                Descripcion = "Descripcion",
                ProyectoId = 1002,
                Unidad = "M2",
                ValorUnitario = 645900
            };

            var response = await Client.PutAsync(request, ContentHelper.GetStringContent(AnalisisUnitario));

            var value = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
        }
    }
    
    
}
