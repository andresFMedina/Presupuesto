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
    public class AnalisisUnitarioController : ControllerBase
    {
        private readonly PresupuestoContext _context;

        public AnalisisUnitarioController(PresupuestoContext context)
        {
            _context = context;            
        }
        // GET: api/AnalisisUnitario        
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Paginator<AnalisisUnitario>>> GetAnalisisUnitario(int proyectoId, string filter, int page=1)
        {
            List<AnalisisUnitario> _AnalisisUnitario;
            Paginator<AnalisisUnitario> _PaginadorAnalisisUnitario;

            _AnalisisUnitario = _context.AnalisisUnitario
                .Where(x => x.ProyectoId.Equals(proyectoId)).ToList();

            //Filtering

            if (!string.IsNullOrEmpty(filter))
            {
                foreach (var item in filter.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries))

                    _AnalisisUnitario = _AnalisisUnitario
                        .Where(x => x.Codigo.StartsWith(item) ||
                                    x.Descripcion.Contains(item)).ToList();
            }

            //Pagination
            int _TotalRegister = 0;
            int _TotalPages = 0;

            _TotalRegister = _AnalisisUnitario.Count();

            _AnalisisUnitario = _AnalisisUnitario.Skip((page - 1) * Constants.NPages)
                                            .Take(Constants.NPages)
                                            .OrderBy(x => x.Codigo)
                                            .OrderBy(x => x.Descripcion)
                                            .ToList();

            _TotalPages = (int)Math.Ceiling((double)_TotalRegister / Constants.NPages);

            _PaginadorAnalisisUnitario = new Paginator<AnalisisUnitario>()
            {
                RegisterPerPages = Constants.NPages,
                TotalRegister = _TotalRegister,
                TotalPages = _TotalPages,
                CurrentPage = page,
                CurrentFilter = filter,
                Result = _AnalisisUnitario

            };

            return _PaginadorAnalisisUnitario;
        }

        // GET api/AnalisisUnitario/5        
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<AnalisisUnitario>> GetAnalisisUnitarioById(int id)
        {
            var analisisUnitario = await _context.AnalisisUnitario.FindAsync(id);

            if (analisisUnitario == null)
            {
                return NotFound();
            }
            // analisisUnitario.Detalles = await _context.Detalle.Where(x => x.AnalisisUnitarioId.Equals(id)).ToListAsync();
            return analisisUnitario;
        }

        // POST api/AnalisisUnitario        
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<AnalisisUnitario>> PostAnalisisUnitario(AnalisisUnitario analisisUnitario)
        {
            _context.Add(analisisUnitario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAnalisisUnitarioById), new { id = analisisUnitario.Id }, analisisUnitario);
        }

        // PUT api/AnalisisUnitario/5
        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PutAnalisisUnitario(int id, AnalisisUnitario analisisUnitario)
        {
            if(analisisUnitario.Id != id)
            {
                return BadRequest();
            }

            _context.Entry(analisisUnitario).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid analisis id");
            var analisisUnitario = _context.AnalisisUnitario
                    .Where(a => a.Id == id)
                    .FirstOrDefault();

            _context.Entry(analisisUnitario).State = EntityState.Deleted;
            await _context.SaveChangesAsync();


            return Ok();
        }
    }
}
