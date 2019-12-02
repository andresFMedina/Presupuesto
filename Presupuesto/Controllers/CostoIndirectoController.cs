using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presupuesto.Models;


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
        public async Task<ActionResult<IEnumerable<CostoIndirecto>>> GetCostoIndirecto(int proyecto)
        {
            return await _context.CostoIndirecto
                .Where(x => x.ProyectoId.Equals(proyecto))
                .ToListAsync();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<CostoIndirecto>> GetCostoIndirectoById(int id)
        {
            var costoIndirecto = await _context.CostoIndirecto.FindAsync(id);

            if(costoIndirecto == null)
            {
                NotFound();
            }

            return costoIndirecto;
        }

        [HttpGet("Total")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<float>> GetCostoDirecto(int proyectoId)
        {
            var Costos = await _context.CostoIndirecto.Where(c => c.ProyectoId == proyectoId).ToListAsync();
            var CostoDirecto = Costos.Sum(c => c.Porcentaje);
            return CostoDirecto;
        }

        // POST api/CostoIndirecto
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<CostoIndirecto>> PostCostoIndirecto(CostoIndirecto costoIndirecto)
        {
            _context.Add(costoIndirecto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCostoIndirectoById), new { id = costoIndirecto.Id }, costoIndirecto);
        }

        // PUT api/CostoIndirecto/5
        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PutCostoIndirecto(int id, CostoIndirecto costoIndirecto)
        {
            if(id != costoIndirecto.Id)
            {
                return BadRequest();
            }
            _context.Entry(costoIndirecto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
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
