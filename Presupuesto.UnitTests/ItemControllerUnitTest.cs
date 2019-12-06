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
    public class ItemControllerUnitTest
    {
        [Fact]
        public async Task Test_GetItemByProyectoIdAsync()
        {
            PresupuestoContext dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(Test_GetItemByProyectoIdAsync));
            ItemController controller = new ItemController(dbContext);

            int proyectoId = 2;
            ObjectResult response = await controller.GetItem(proyectoId, "") as ObjectResult;
            var value = response.Value as IPagedResponse<Item>;

            Assert.False(value.DidError);
        }

        [Fact]
        public async Task Test_GetItemByIdAsync()
        {
            PresupuestoContext dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(Test_GetItemByIdAsync));
            ItemController controller = new ItemController(dbContext);

            int id = 1;
            ObjectResult response = await controller.GetItemById(id) as ObjectResult;
            var value = response.Value as ISingleResponse<Item>;

            Assert.False(value.DidError);
        }

        [Fact]
        public async Task Test_PostItemAsync()
        {
            PresupuestoContext dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(Test_PostItemAsync));
            ItemController controller = new ItemController(dbContext);

            Item Item = new Item
            {
                Id = 4,
                Codigo = "4421",
                CapituloId = 1,
                Descripcion = "Item 1",
                Cantidad = 55,
                Aporte = 100,
                NumeroCapitulo = 1,
                Unidad = "M2",
                ProyectoId = 4,
                ValorUnitario = 500000
            };

            ObjectResult response = await controller.PostItem(Item) as ObjectResult;
            var value = response.Value as ISingleResponse<Item>;

            Assert.False(value.DidError);
        }

        [Fact]
        public async Task Test_PutItemAsync()
        {
            PresupuestoContext dbContext = DbContextMocker.GetPresupuestoDbContext(nameof(Test_PutItemAsync));
            ItemController controller = new ItemController(dbContext);

            Item Item = new Item
            {
                Id = 2,
                Codigo = "6421",
                CapituloId = 1,
                Descripcion = "Item 1",
                Cantidad = 55,
                Aporte = 100,
                NumeroCapitulo = 1,
                Unidad = "M2",
                ProyectoId = 4,
                ValorUnitario = 500000
            };
            int id = 2;
            ObjectResult response = await controller.PutItem(id, Item) as ObjectResult;
            var value = response.Value as Response;

            Assert.False(value.DidError);
        }
    }
}
