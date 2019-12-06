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
    public class CapituloControllerUnitTest
    {
        [Fact]
        public async Task Test_GetCapituloByProyectoIdAsync()
        {
            PresupuestoContext dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(Test_GetCapituloByProyectoIdAsync));
            CapituloController controller = new CapituloController(dbContext);

            int proyectoId = 2;
            ObjectResult response = await controller.GetCapitulo(proyectoId) as ObjectResult;
            var value = response.Value as IListResponse<Capitulo>;

            Assert.False(value.DidError);
        }

        [Fact]
        public async Task Test_GetCapituloByIdAsync()
        {
            PresupuestoContext dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(Test_GetCapituloByIdAsync));
            CapituloController controller = new CapituloController(dbContext);

            int id = 1;
            ObjectResult response = await controller.GetCapituloById(id) as ObjectResult;
            var value = response.Value as ISingleResponse<Capitulo>;

            Assert.False(value.DidError);
        }

        [Fact]
        public async Task Test_PostCapituloAsync()
        {
            PresupuestoContext dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(Test_PostCapituloAsync));
            CapituloController controller = new CapituloController(dbContext);

            Capitulo Capitulo = new Capitulo
            {
                Id = 3,
                Numero = 1,
                Descripcion = "Descripcion",
                ProyectoId = 4,
                Subtotal = 952100
            };

            ObjectResult response = await controller.PostCapitulo(Capitulo) as ObjectResult;
            var value = response.Value as ISingleResponse<Capitulo>;

            Assert.False(value.DidError);
        }

        [Fact]
        public async Task Test_PutCapituloAsync()
        {
            PresupuestoContext dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(Test_PutCapituloAsync));
            CapituloController controller = new CapituloController(dbContext);

            Capitulo Capitulo = new Capitulo
            {
                Id = 2,
                Numero = 1,
                Descripcion = "Descripcion",
                ProyectoId = 4,
                Subtotal = 9872100
            };
            int id = 2;
            ObjectResult response = await controller.PutCapitulo(id, Capitulo) as ObjectResult;
            var value = response.Value as Response;

            Assert.False(value.DidError);
        }
    }
}
