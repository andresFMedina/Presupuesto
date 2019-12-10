using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presupuesto.Models;
using Presupuesto.Utils;

namespace Presupuesto.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CostoIndirectoController : Controller
    {
        private readonly PresupuestoContext _context;

        public CostoIndirectoController(PresupuestoContext context)
        {
            _context = context;
        }

        // GET: api/CostoIndirecto 
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetCostoIndirecto(int proyecto)
        {
            var response = new ListResponse<CostoIndirecto>();
            try
            {
                response.Model = await _context.CostoIndirecto
                .Where(x => x.ProyectoId.Equals(proyecto))
                .ToListAsync();
                response.Message = "Costos Indirectos";
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }
            return response.ToHttpResponse();

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetCostoIndirectoById(int id)
        {
            var response = new SingleResponse<CostoIndirecto>();
            try
            {
                var costoIndirecto = await _context.CostoIndirecto.FindAsync(id);

                if (costoIndirecto == null)
                {
                    NotFound();
                }
                response.Model = costoIndirecto;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }
            return response.ToHttpResponse();


        }

        [HttpGet("Total")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetCostoDirecto(int proyectoId)
        {
            var response = new SingleResponse<float>();
            try
            {
                var costos = await _context.CostoIndirecto.Where(c => c.ProyectoId == proyectoId).ToListAsync();
                var costoDirecto = costos.Sum(c => c.Porcentaje);
                response.Model = costoDirecto;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }
            return response.ToHttpResponse();

        }

        // POST api/CostoIndirecto
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PostCostoIndirecto(CostoIndirecto costoIndirecto)
        {
            var response = new SingleResponse<CostoIndirecto>();
            try
            {
                _context.Add(costoIndirecto);
                await _context.SaveChangesAsync();

                response.Model = CreatedAtAction(nameof(GetCostoIndirectoById), new { id = costoIndirecto.Id }, costoIndirecto).Value as CostoIndirecto;
                response.Message = "Created";
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }
            return response.ToHttpResponse();            
        }

        // PUT api/CostoIndirecto/5
        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PutCostoIndirecto(int id, [FromBody] CostoIndirecto value)
        {
            Response response = new Response();
            try
            {
                CostoIndirecto updatedCostoIndirecto = value;
                var selectedElement = _context.CostoIndirecto.Find(id);                
                selectedElement.Descripcion = value.Descripcion;
                selectedElement.Porcentaje = value.Porcentaje;                
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
                return BadRequest("Not a valid costo id");
            var costoIndirecto = _context.CostoIndirecto
                    .Where(c => c.Id == id)
                    .FirstOrDefault();

            _context.Entry(costoIndirecto).State = EntityState.Deleted;
            await _context.SaveChangesAsync();


            return Ok();
        }
    }
}
