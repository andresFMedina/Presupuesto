using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presupuesto.Models;

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
        public async Task<ActionResult<IEnumerable<Detalle>>> GetDetalle(int analisisId=0, int itemId=0)
        {
            var List = await _context.Detalle.ToListAsync();
            if(analisisId != 0)
            {
                List = await _context.Detalle.Where(d => d.AnalisisUnitarioId.Equals(analisisId)).ToListAsync();
            }
            if (itemId != 0)
            {
                List = await _context.Detalle.Where(d => d.ItemId.Equals(itemId)).ToListAsync();
            }
            return List;
        }

        // GET api/Detalle/5
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Detalle>> GetDetalleById(int id)
        {
            var Detalle = await _context.Detalle.FindAsync(id);

            if (Detalle == null)
            {
                return NotFound();
            }

            return Detalle;
        }

        // POST api/Detalle
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Detalle>> PostDetalle(Detalle Detalle)
        {
            _context.Add(Detalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDetalleById), new { id = Detalle.Id }, Detalle);
        }

        // PUT api/Detalle/5
        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PutDetalle(int id, Detalle Detalle)
        {
            if (id != Detalle.Id)
            {
                return BadRequest();
            }
            _context.Entry(Detalle).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
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