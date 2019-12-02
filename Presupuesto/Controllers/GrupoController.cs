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
    public class GrupoController : ControllerBase
    {
        private readonly PresupuestoContext _context;

        public GrupoController(PresupuestoContext context)
        {
            _context = context;            
        }

        // GET: api/Grupo
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<IEnumerable<Grupo>>> GetGrupo()
        {
            return await _context.Grupo.ToListAsync();
        }

        // GET api/Grupo/5
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Grupo>> GetGrupoById(int id)
        {
            var grupo = await _context.Grupo.FindAsync(id);

            if (grupo == null)
            {
                return NotFound();
            }

            return grupo;
        }

        // POST api/Grupo
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Grupo>> PostGrupo(Grupo grupo)
        {
            _context.Grupo.Add(grupo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGrupoById), new { id = grupo.Id }, grupo);
        }

        // PUT api/Grupo/5
        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PutProyecto(int id, Grupo grupo)
        {
            if(id != grupo.Id)
            {
                return BadRequest();
            }
            _context.Entry(grupo).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
    }
}
