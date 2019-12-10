using Microsoft.AspNetCore.Mvc;
using Presupuesto.Controllers;
using Presupuesto.Models;
using Presupuesto.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Presupuesto.UnitTests
{
    public class AnalisisUnitarioUnitTest
    {
        [Fact]
        public async Task Test_GetAnalisisByProyectoIdAsync()
        {
            PresupuestoContext dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(Test_GetAnalisisByProyectoIdAsync));
            AnalisisUnitarioController controller = new AnalisisUnitarioController(dbContext);

            int proyectoId = 2;
            ObjectResult response = await controller.GetAnalisisUnitario(proyectoId, "") as ObjectResult;
            var value = response.Value as IPagedResponse<AnalisisUnitario>;

            Assert.False(value.DidError);
        }

        [Fact]
        public async Task Test_GetAnalisisByIdAsync()
        {
            PresupuestoContext dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(Test_GetAnalisisByIdAsync));
            AnalisisUnitarioController controller = new AnalisisUnitarioController(dbContext);

            int id = 1;
            ObjectResult response = await controller.GetAnalisisUnitarioById(id) as ObjectResult;
            var value = response.Value as ISingleResponse<AnalisisUnitario>;

            Assert.False(value.DidError);
        }

        [Fact]
        public async Task Test_PostAnalisisAsync()
        {
            PresupuestoContext dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(Test_PostAnalisisAsync));
            AnalisisUnitarioController controller = new AnalisisUnitarioController(dbContext);

            AnalisisUnitario analisis = new AnalisisUnitario
            {
                Id = 5,
                Codigo = "54643",
                Descripcion = "Descripcion",                
                ProyectoId = 4,
                Unidad = "M2",
                ValorUnitario = 645900
            };
            
            ObjectResult response = await controller.PostAnalisisUnitario(analisis) as ObjectResult;
            var value = response.Value as ISingleResponse<AnalisisUnitario>;

            Assert.False(value.DidError);
        }

        [Fact]
        public async Task Test_PutAnalisisAsync()
        {
            PresupuestoContext dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(Test_PutAnalisisAsync));
            AnalisisUnitarioController controller = new AnalisisUnitarioController(dbContext);

            AnalisisUnitario analisis = new AnalisisUnitario
            {
                Id = 4,
                Codigo = "54643",
                Descripcion = "Descripcion 1",
                ProyectoId = 4,
                Unidad = "M2",
                ValorUnitario = 645900
            };
            int id = 4;
            ObjectResult response = await controller.PutAnalisisUnitario(id, analisis) as ObjectResult;
            var value = response.Value as Response;

            Assert.False(value.DidError);
        }
    }
}
