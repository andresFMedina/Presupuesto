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
    public class CapituloController : ControllerBase
    {
        private readonly PresupuestoContext _context;

        public CapituloController(PresupuestoContext context)
        {
            _context = context;
        }

        // GET: api/Capitulo
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<IEnumerable<Capitulo>>> GetCapitulo(int proyectoId)
        {
            List < Capitulo > Capitulos = await _context.Capitulo.Where(x => x.ProyectoId.Equals(proyectoId)).ToListAsync();
            return Capitulos;
        }

        // GET api/Capitulo/5
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Capitulo>> GetCapituloById(int id)
        {
            var Capitulo = await _context.Capitulo.FindAsync(id);

            if (Capitulo == null)
            {
                return NotFound();
            }

            return Capitulo;
        }

        // POST api/Capitulo
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Capitulo>> PostCapitulo(Capitulo Capitulo)
        {
            _context.Add(Capitulo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCapituloById), new { id = Capitulo.Id }, Capitulo);
        }

        // PUT api/Capitulo/5
        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PutCapitulo(int id, Capitulo Capitulo)
        {
            if (id != Capitulo.Id)
            {
                return BadRequest();
            }
            _context.Entry(Capitulo).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid capitulo id");
            var capitulo = _context.Capitulo
                    .Where(c => c.Id == id)
                    .FirstOrDefault();

            _context.Entry(capitulo).State = EntityState.Deleted;
            await _context.SaveChangesAsync();


            return Ok();
        }
    }
}