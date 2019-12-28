using Presupuesto.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Presupuesto.IntegrationTest
{
    public class ProyectoIntegrationTest : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public ProyectoIntegrationTest(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task TestGetProyectosAsync()
        {
            var request = "/api/Proyecto";

            var response = await Client.GetAsync(request);

            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task TestGetProyectosByIdAsync()
        {
            var request = "/api/Proyecto/2";

            var response = await Client.GetAsync(request);

            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task TestPostProyectosAsync()
        {
            var request = "/api/Proyecto";
            var proyecto = new Proyecto
            {
                Id = 0,
                Nombre_Obra = "Obra6",
                Comentarios = "Comentarios6",
                Contratante = "Contratante6",
                Desperdicio_Materiales = 60,
                Fecha_Modificacion = DateTime.Today.ToShortDateString(),
                Fecha_Presentacion = DateTime.Today.AddDays(200).ToShortDateString(),                
                Porcentaje_Menor = 6,
                Porcentaje_Prestaciones_Sociales = 63,
                Proponente = "Proponente 6"
            };

            var response = await Client.PostAsync(request, ContentHelper.GetStringContent(proyecto));

            var value = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task TestPutProyectosAsync()
        {
            var request = "/api/Proyecto/1002";
            var proyecto = new Proyecto
            {
                Id = 1002,
                Nombre_Obra = "Obra5",
                Comentarios = "Comentarios6",
                Contratante = "Contratante6",
                Desperdicio_Materiales = 60,
                Fecha_Modificacion = DateTime.Today.ToShortDateString(),
                Fecha_Presentacion = DateTime.Today.AddDays(200).ToShortDateString(),                
                Porcentaje_Menor = 6,
                Porcentaje_Prestaciones_Sociales = 63,
                Proponente = "Proponente 6"
            };

            var response = await Client.PutAsync(request, ContentHelper.GetStringContent(proyecto));

            var value = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
        }
    }
}
