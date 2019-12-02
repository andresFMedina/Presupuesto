using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Presupuesto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

namespace Presupuesto.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        private readonly PresupuestoContext _context;

        public ProyectoController(PresupuestoContext context)
        {
            _context = context;            
        }
        //GET: api/Proyecto
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<IEnumerable<Proyecto>>> GetProyecto()
        {
            return await _context.Proyecto.ToListAsync();
        }

        //GET: api/Proyecto/5
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Proyecto>> GetProyectoById(int id)
        {
            var proyecto = await _context.Proyecto.FindAsync(id);

            if (proyecto == null)
            {
                return NotFound();
            }

            return proyecto;
        }

        //POST: api/Proyecto
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Proyecto>> PostProyecto(Proyecto proyecto)
        {
            _context.Proyecto.Add(proyecto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProyectoById), new { id = proyecto.Id }, proyecto);
        }

        //PUT: api/Proyecto/5
        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PutProyecto(int id, Proyecto proyecto)
        {
            if(id != proyecto.Id)
            {
                return BadRequest();
            }

            _context.Entry(proyecto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }

    
    
}
