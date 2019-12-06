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
    public class CostoIndirectoControllerUnitTest
    {
        [Fact]
        public async Task Test_GetCostoIndirectoByProyectoIdAsync()
        {
            PresupuestoContext dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(Test_GetCostoIndirectoByProyectoIdAsync));
            CostoIndirectoController controller = new CostoIndirectoController(dbContext);

            int proyectoId = 4;
            ObjectResult response = await controller.GetCostoIndirecto(proyectoId) as ObjectResult;
            var value = response.Value as IListResponse<CostoIndirecto>;

            Assert.False(value.DidError);
        }

        [Fact]
        public async Task Test_GetCostoIndirectoByIdAsync()
        {
            PresupuestoContext dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(Test_GetCostoIndirectoByIdAsync));
            CostoIndirectoController controller = new CostoIndirectoController(dbContext);

            int id = 1;
            ObjectResult response = await controller.GetCostoIndirectoById(id) as ObjectResult;
            var value = response.Value as ISingleResponse<CostoIndirecto>;

            Assert.False(value.DidError);
        }

        [Fact]
        public async Task Test_PostCostoIndirectoAsync()
        {
            PresupuestoContext dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(Test_PostCostoIndirectoAsync));
            CostoIndirectoController controller = new CostoIndirectoController(dbContext);

            CostoIndirecto CostoIndirecto = new CostoIndirecto
            {
                Id = 3,
                ProyectoId = 4,
                Descripcion = "Costo Indirecto 3",
                Porcentaje = (float)0.02,
            };

            ObjectResult response = await controller.PostCostoIndirecto(CostoIndirecto) as ObjectResult;
            var value = response.Value as ISingleResponse<CostoIndirecto>;

            Assert.False(value.DidError);
        }

        [Fact]
        public async Task Test_PutCostoIndirectoAsync()
        {
            PresupuestoContext dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(Test_PutCostoIndirectoAsync));
            CostoIndirectoController controller = new CostoIndirectoController(dbContext);

            CostoIndirecto CostoIndirecto = new CostoIndirecto
            {
                Id = 2,
                ProyectoId = 4,
                Descripcion = "Costo Indirecto 2.1",
                Porcentaje = (float)0.22,
            };
            int id = 2;
            ObjectResult response = await controller.PutCostoIndirecto(id, CostoIndirecto) as ObjectResult;
            var value = response.Value as Response;

            Assert.False(value.DidError);
        }
    }
}
