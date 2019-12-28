using Microsoft.AspNetCore.Mvc;
using Presupuesto.Controllers;
using Presupuesto.Models;
using Presupuesto.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Presupuesto.UnitTests
{
    public class ProyectoControllerUnitTest
    {
        [Fact]
        public async Task TestGetProyectosAsync()
        {
            var dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(TestGetProyectosAsync));
            var controller = new ProyectoController(dbContext);

            var response = await controller.GetProyecto() as ObjectResult;
            var value = response.Value as IListResponse<Proyecto>;

            dbContext.Dispose();
            

            Assert.False(value.DidError);


        }
        [Fact]
        public async Task TestGetProyectoByIdAsync()
        {
            var dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(TestGetProyectoByIdAsync));
            var controller = new ProyectoController(dbContext);
            int id = 1;

            var response = await controller.GetProyectoById(id) as ObjectResult;
            var value = response.Value as ISingleResponse<Proyecto>;

            dbContext.Dispose();


            Assert.False(value.DidError);
        }

        [Fact]
        public async Task TestPostProyectoAsync()
        {
            var dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(TestPostProyectoAsync));
            var controller = new ProyectoController(dbContext);

            var proyecto = new Proyecto
            {
                Id = 6,
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


            var response = await controller.PostProyecto(proyecto) as ObjectResult;
            var value = response.Value as ISingleResponse<Proyecto>;

            dbContext.Dispose();


            Assert.False(value.DidError);
        }

        [Fact]
        public async Task TestPutProyectoAsync()
        {
            var dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(TestPutProyectoAsync));
            var controller = new ProyectoController(dbContext);

            int id = 3;
            var proyecto = new Proyecto
            {
                Id = 3,
                Nombre_Obra = "Obra6",
                Comentarios = "Comentarios6",
                Contratante = "Contratante6",
                Desperdicio_Materiales = 60,
                Fecha_Modificacion = DateTime.Today.ToShortDateString(),
                Fecha_Presentacion = DateTime.Today.AddDays(200).ToShortDateString(),                
                Porcentaje_Menor = 5,
                Porcentaje_Prestaciones_Sociales = 63,
                Proponente = "Proponente 6"
            };


            var response = await controller.PutProyecto(id, proyecto) as ObjectResult;
            var value = response.Value as IResponse;

            dbContext.Dispose();


            Assert.False(value.DidError);
        }



    }
}
