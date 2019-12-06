using Presupuesto.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Presupuesto.IntegrationTest
{
    public class ItemIntegrationTest : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public ItemIntegrationTest(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task TestGetItemsAsync()
        {
            var request = "/api/Item";

            var response = await Client.GetAsync(request);

            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task TestGetItemsByIdAsync()
        {
            var request = "/api/Item/2";

            var response = await Client.GetAsync(request);

            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task TestPostItemsAsync()
        {
            var request = "/api/Item";
            var Item = new Item
            {
                Id = 0,
                Codigo = "3421",
                CapituloId = 3,
                Descripcion = "Item 1",
                Cantidad = 55,
                Aporte = 100,
                NumeroCapitulo = 1,
                Unidad = "M2",
                ProyectoId = 1002,
                ValorUnitario = 500000
            };

            var response = await Client.PostAsync(request, ContentHelper.GetStringContent(Item));

            var value = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task TestPutItemsAsync()
        {
            var request = "/api/Item/2004";
            var Item = new Item
            {
                Id = 2004,
                Codigo = "3421",
                CapituloId = 3,
                Descripcion = "Item 1",
                Cantidad = 55,
                Aporte = 100,
                NumeroCapitulo = 1,
                Unidad = "M2",
                ProyectoId = 1002,
                ValorUnitario = 500000
            };

            var response = await Client.PutAsync(request, ContentHelper.GetStringContent(Item));

            var value = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
        }
    }

}
