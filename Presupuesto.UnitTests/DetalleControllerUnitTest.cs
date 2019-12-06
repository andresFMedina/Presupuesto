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
    public class DetalleControllerUnitTest
    {
        [Fact]
        public async Task Test_GetDetalleByAnalisisIdAsync()
        {
            PresupuestoContext dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(Test_GetDetalleByAnalisisIdAsync));
            DetalleController controller = new DetalleController(dbContext);

            int analisisId = 2;
            ObjectResult response = await controller.GetDetalle(analisisId) as ObjectResult;
            var value = response.Value as IListResponse<Detalle>;

            Assert.False(value.DidError);
        }

        [Fact]
        public async Task Test_GetDetalleByIdAsync()
        {
            PresupuestoContext dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(Test_GetDetalleByIdAsync));
            DetalleController controller = new DetalleController(dbContext);

            int id = 1;
            ObjectResult response = await controller.GetDetalleById(id) as ObjectResult;
            var value = response.Value as ISingleResponse<Detalle>;

            Assert.False(value.DidError);
        }

        [Fact]
        public async Task Test_PostDetalleAsync()
        {
            PresupuestoContext dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(Test_PostDetalleAsync));
            DetalleController controller = new DetalleController(dbContext);

            Detalle Detalle = new Detalle
            {
                Id = 3,
                Codigo = "34643",
                Descripcion = "Descripcion",
                AnalisisUnitarioId = 1,
                DetalleDe = "analisis",
                Precio = 546200,
                Rendimiento = 600,
                Unidad = "UND"
            };

            ObjectResult response = await controller.PostDetalle(Detalle) as ObjectResult;
            var value = response.Value as ISingleResponse<Detalle>;

            Assert.False(value.DidError);
        }

        [Fact]
        public async Task Test_PutDetalleAsync()
        {
            PresupuestoContext dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(Test_PutDetalleAsync));
            DetalleController controller = new DetalleController(dbContext);

            Detalle Detalle = new Detalle
            {
                Id = 2,
                Codigo = "24643",
                Descripcion = "Descripcion",
                AnalisisUnitarioId = 1,
                DetalleDe = "analisis",
                Precio = 56200,
                Rendimiento = 600,
                Unidad = "UND"
            };
            int id = 2;
            ObjectResult response = await controller.PutDetalle(id, Detalle) as ObjectResult;
            var value = response.Value as Response;

            Assert.False(value.DidError);
        }
    }
}
