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
    public class RecursoBasicoControllerUnitTest
    {
        [Fact]
        public async Task TestGetRecursoBasicosAsync()
        {
            var dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(TestGetRecursoBasicosAsync));
            var controller = new RecursoBasicoController(dbContext);

            var response = await controller.GetRecursoBasico("") as ObjectResult;
            var value = response.Value as IListResponse<RecursoBasico>;

            dbContext.Dispose();


            Assert.False(value.DidError);


        }
        [Fact]
        public async Task TestGetRecursoBasicoByIdAsync()
        {
            var dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(TestGetRecursoBasicoByIdAsync));
            var controller = new RecursoBasicoController(dbContext);
            int id = 1;

            var response = await controller.GetRecursoBasicoById(id) as ObjectResult;
            var value = response.Value as ISingleResponse<RecursoBasico>;

            dbContext.Dispose();


            Assert.False(value.DidError);
        }

        [Fact]
        public async Task TestPostRecursoBasicoAsync()
        {
            var dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(TestPostRecursoBasicoAsync));
            var controller = new RecursoBasicoController(dbContext);

            var RecursoBasico = new RecursoBasico
            {
                Id = 3000,
                Codigo = "56589",
                Descripcion = "Recurso 3000",
                Precio = 68930,
                Unidad = "UND"
            };


            var response = await controller.PostRecursoBasico(RecursoBasico) as ObjectResult;
            var value = response.Value as ISingleResponse<RecursoBasico>;

            dbContext.Dispose();


            Assert.False(value.DidError);
        }

        [Fact]
        public async Task TestPutRecursoBasicoAsync()
        {
            var dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(TestPutRecursoBasicoAsync));
            var controller = new RecursoBasicoController(dbContext);

            int id = 3000;
            var RecursoBasico = new RecursoBasico
            {
                Id = 3000,
                Codigo = "56589",
                Descripcion = "Recurso 3000",
                Precio = 68930,
                Unidad = "UND"
            };


            var response = await controller.PutRecursoBasico(id, RecursoBasico) as ObjectResult;
            var value = response.Value as IResponse;

            dbContext.Dispose();


            Assert.Equal("The instance of entity type 'RecursoBasico' cannot be tracked because another instance with the same key value for {'Id'} is already being tracked. When attaching exist", value.ErrorMessage);
        }



    }
}
