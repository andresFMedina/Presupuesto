using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presupuesto.Models;
using Presupuesto.Utils;

namespace Presupuesto.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleController : ControllerBase
    {
        private readonly PresupuestoContext _context;

        public DetalleController(PresupuestoContext context)
        {
            _context = context;
        }

        // GET: api/Detalle
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetDetalle(int analisisId=0, int itemId=0)
        {
            var response = new ListResponse<Detalle>();

            try
            {
                var List = await _context.Detalle.ToListAsync();
                if (analisisId != 0)
                {
                    List = await _context.Detalle.Where(d => d.AnalisisUnitarioId.Equals(analisisId)).ToListAsync();
                }
                if (itemId != 0)
                {
                    List = await _context.Detalle.Where(d => d.ItemId.Equals(itemId)).ToListAsync();
                }
                response.Model = List;
                response.Message = "Lista de Detalles";
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }
            return response.ToHttpResponse();            
        }

        // GET: api/Detalle/listado
        [HttpGet("listado")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetListadoGeneralDetallePorProyecto(int proyectoId = 0)
        {
            var response = new ListResponse<Detalle>();

            try
            {
                var List = await _context.Detalle.Where(d => d.Item.ProyectoId.Equals(proyectoId))
                    .ToListAsync();

                var ListAux = new List<Detalle>();

                for(int i = 0; i < List.Count() ; i++)
                {
                    for(int j = 0; j < List.Count(); j++)
                    {
                        
                        var detalleI = List.ElementAt(i);
                        var detalleJ = List.ElementAt(j);
                        if (!detalleI.Equals(detalleJ))
                        {
                            if (detalleI.Codigo.Equals(detalleJ.Codigo))
                            {
                                detalleI.Rendimiento += detalleJ.Rendimiento;
                                List[i] = detalleI;
                                List.RemoveAt(j);
                            }
                        }
                        
                    }
                }               
                
                response.Model = List;
                response.Message = "Lista de Detalles";
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }
            return response.ToHttpResponse();
        }


        // GET api/Detalle/5
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetDetalleById(int id)
        {
            var response = new SingleResponse<Detalle>();

            try
            {
                var Detalle = await _context.Detalle.FindAsync(id);

                if (Detalle == null)
                {
                    return NotFound();
                }

                response.Message = $"Detalle {id}";
                response.Model = Detalle;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }
            return response.ToHttpResponse();
        }

        // POST api/Detalle
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PostDetalle(Detalle Detalle)
        {
            var response = new SingleResponse<Detalle>();
            try
            {
                _context.Add(Detalle);
                await _context.SaveChangesAsync();

                response.Message = "Created";
                response.Model = CreatedAtAction(nameof(GetDetalleById), new { id = Detalle.Id }, Detalle).Value as Detalle;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }
            return response.ToHttpResponse();
        }

        // PUT api/Detalle/5
        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PutDetalle(int id, [FromBody] Detalle value)
        {
            Response response = new Response();
            try
            {
                Detalle updatedDetalle = value;
                var selectedElement = _context.Detalle.Find(id);
                selectedElement.Codigo = value.Codigo;
                selectedElement.Descripcion = value.Descripcion;
                selectedElement.Unidad = value.Unidad;
                selectedElement.Precio = value.Precio;
                selectedElement.Rendimiento = value.Rendimiento;
                selectedElement.Desperdicio = value.Desperdicio;
                selectedElement.Grupo = value.Grupo;
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }

            return response.ToHttpResponse();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid detalle id");
            var detalle = _context.Detalle
                    .Where(d => d.Id == id)
                    .FirstOrDefault();

            _context.Entry(detalle).State = EntityState.Deleted;
            await _context.SaveChangesAsync();


            return Ok();
        }
    }
}