using System;
using System.Collections.Generic;
using System.Text;
using Presupuesto.Models;

namespace Presupuesto.UnitTests
{
    public static class DbContextExtensions
    {
        public static void Seed(this PresupuestoContext dbContext)
        {
            dbContext.Proyecto.Add(new Proyecto
            {
                Id = 1,
                Comentarios = "Comentarios1",
                Contratante = "Contratante1",
                Desperdicio_Materiales = 80,
                Fecha_Modificacion = DateTime.Today.ToShortDateString(),
                Fecha_Presentacion = DateTime.Today.AddDays(100).ToShortDateString(),                
                Nombre_Obra = "Obra1",
                Porcentaje_Menor = 80,
                Porcentaje_Prestaciones_Sociales = 50,
                Proponente = "Proponente1" 
            }
            );

            dbContext.Proyecto.Add(new Proyecto
            {
                Id = 2,
                Comentarios = "Comentarios2",
                Contratante = "Contratante2",
                Desperdicio_Materiales = 70,
                Fecha_Modificacion = DateTime.Today.ToShortDateString(),
                Fecha_Presentacion = DateTime.Today.AddDays(150).ToShortDateString(),                
                Nombre_Obra = "Obra2",
                Porcentaje_Menor = 30,
                Porcentaje_Prestaciones_Sociales = 10,
                Proponente = "Proponente2"
            }
            );

            dbContext.Proyecto.Add(new Proyecto
            {
                Id = 3,
                Comentarios = "Comentarios3",
                Contratante = "Contratante3",
                Desperdicio_Materiales = 80,
                Fecha_Modificacion = DateTime.Today.ToShortDateString(),
                Fecha_Presentacion = DateTime.Today.AddDays(100).ToShortDateString(),                
                Nombre_Obra = "Obra3",
                Porcentaje_Menor = 40,
                Porcentaje_Prestaciones_Sociales = 50,
                Proponente = "Proponente3"
            }
            );

            dbContext.Proyecto.Add(new Proyecto
            {
                Id = 4,
                Comentarios = "Comentarios4",
                Contratante = "Contratante4",
                Desperdicio_Materiales = 75,
                Fecha_Modificacion = DateTime.Today.ToShortDateString(),
                Fecha_Presentacion = DateTime.Today.AddDays(200).ToShortDateString(),                
                Nombre_Obra = "Obra4",
                Porcentaje_Menor = 60,
                Porcentaje_Prestaciones_Sociales = 15,
                Proponente = "Proponente4"
            }
            );

            dbContext.Proyecto.Add(new Proyecto
            {
                Id = 5,
                Comentarios = "Comentarios5",
                Contratante = "Contratante5",
                Desperdicio_Materiales = 80,
                Fecha_Modificacion = DateTime.Today.ToShortDateString(),
                Fecha_Presentacion = DateTime.Today.AddDays(100).ToShortDateString(),                
                Nombre_Obra = "Obra5",
                Porcentaje_Menor = 80,
                Porcentaje_Prestaciones_Sociales = 50,
                Proponente = "Proponente5"
            }
            );

            dbContext.AnalisisUnitario.Add(new AnalisisUnitario
            {
                Id = 1,
                Codigo = "54643",
                Descripcion = "Descripcion",
                ProyectoId = 4,
                Unidad = "M2",
                ValorUnitario = 645900
            });

            dbContext.AnalisisUnitario.Add(new AnalisisUnitario
            {
                Id = 2,
                Codigo = "54643",
                Descripcion = "Descripcion",
                ProyectoId = 4,
                Unidad = "M2",
                ValorUnitario = 645900
            });

            dbContext.AnalisisUnitario.Add(new AnalisisUnitario
            {
                Id = 3,
                Codigo = "54643",
                Descripcion = "Descripcion",
                ProyectoId = 4,
                Unidad = "M2",
                ValorUnitario = 645900
            });

            dbContext.AnalisisUnitario.Add(new AnalisisUnitario
            {
                Id = 4,
                Codigo = "54643",
                Descripcion = "Descripcion",
                ProyectoId = 4,
                Unidad = "M2",
                ValorUnitario = 645900
            });

            dbContext.Capitulo.Add(new Capitulo
            {
                Id = 1,
                Numero = 1,
                Descripcion = "Descripcion 1",
                ProyectoId = 4,
                Subtotal = 9874100
            });

            dbContext.Capitulo.Add(new Capitulo
            {
                Id = 2,
                Numero = 2,
                Descripcion = "Descripcion 2",
                ProyectoId = 4,
                Subtotal = 452100
            });

            dbContext.Item.Add(new Item
            {
                Id = 1,
                Codigo = "5421",
                CapituloId = 1,
                Descripcion = "Item 1",
                Cantidad = 55,
                Aporte = 100,
                NumeroCapitulo = 1,
                Unidad = "M2",
                ProyectoId = 4,
                ValorUnitario = 500000
            });

            dbContext.Item.Add(new Item
            {
                Id = 2,
                Codigo = "2421",
                CapituloId = 1,
                Descripcion = "Item 1",
                Cantidad = 55,
                Aporte = 100,
                NumeroCapitulo = 1,
                Unidad = "M2",
                ProyectoId = 4,
                ValorUnitario = 500000
            });

            dbContext.Item.Add(new Item
            {
                Id = 3,
                Codigo = "3421",
                CapituloId = 1,
                Descripcion = "Item 1",
                Cantidad = 55,
                Aporte = 100,
                NumeroCapitulo = 1,
                Unidad = "M2",
                ProyectoId = 4,
                ValorUnitario = 500000
            });

            dbContext.Detalle.Add(new Detalle
            {
                Id = 1,
                Codigo = "54643",
                Descripcion = "Descripcion",
                AnalisisUnitarioId = 1,
                DetalleDe = "analisis",
                Precio = 546200,
                Rendimiento = 600,
                Unidad = "UND"
            });

            dbContext.Detalle.Add(new Detalle
            {
                Id = 2,
                Codigo = "44643",
                Descripcion = "Descripcion",
                ItemId = 1,
                DetalleDe = "item",
                Precio = 546200,
                Rendimiento = 600,
                Unidad = "UND"
            });

            dbContext.CostoIndirecto.Add(new CostoIndirecto
            {
                Id = 1,
                ProyectoId = 4,
                Descripcion = "Costo Indirecto 1",
                Porcentaje = (float)0.22,
            });

            dbContext.CostoIndirecto.Add(new CostoIndirecto
            {
                Id = 2,
                ProyectoId = 4,
                Descripcion = "Costo Indirecto 2",
                Porcentaje = (float)0.12,
            });
            dbContext.RecursoBasico.Add(new RecursoBasico
            {
                Id = 1,
                Codigo = "56589",
                Descripcion = "Recurso 3000",
                Precio = 68930,
                Unidad = "UND"
            });

            dbContext.RecursoBasico.Add(new RecursoBasico
            {
                Id = 2,
                Codigo = "56589",
                Descripcion = "Recurso 3000",
                Precio = 9865,
                Unidad = "UND"
            });


            dbContext.SaveChanges();

        }
    }
}
