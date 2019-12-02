using System;
using System.Collections.Generic;
using System.IO;
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
    public class RecursoBasicoController : ControllerBase
    {
        private readonly PresupuestoContext _context;
        

        public RecursoBasicoController(PresupuestoContext context)
        {
            _context = context;
        }


        // GET: api/RecursoBasico
        // Params: filter 
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Paginator<RecursoBasico>>> GetRecursoBasico(string filter,
                                                                                     int page= 1)
        {
            List<RecursoBasico> _RecursoBasico;
            Paginator<RecursoBasico> _PaginadorRecursoBasico;

            _RecursoBasico = _context.RecursoBasico.ToList();

            //Filtering

            if (!string.IsNullOrEmpty(filter))
            {
                foreach (var item in filter.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries))

                    _RecursoBasico = _RecursoBasico
                        .Where(x => x.Codigo.StartsWith(item) ||
                                    x.Descripcion.Contains(item)).ToList();
            }

            //Pagination
            int _TotalRegister = 0;
            int _TotalPages = 0;

            _TotalRegister = _RecursoBasico.Count();

            _RecursoBasico = _RecursoBasico.Skip((page - 1) * Constants.NPages)
                                            .Take(Constants.NPages)
                                            .OrderBy(x => x.Codigo)
                                            .OrderBy(x => x.Descripcion)
                                            .ToList();

            _TotalPages = (int)Math.Ceiling((double)_TotalRegister / Constants.NPages);

            _PaginadorRecursoBasico = new Paginator<RecursoBasico>()
            {
                RegisterPerPages = Constants.NPages,
                TotalRegister = _TotalRegister,
                TotalPages = _TotalPages,
                CurrentPage = page,
                CurrentFilter = filter,
                Result = _RecursoBasico

            };

            return _PaginadorRecursoBasico;
        }

        // GET api/RecursoBasico/5
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<RecursoBasico>> GetRecursoBasicoById(int id)
        {
            var recursoBasico = await _context.RecursoBasico.FindAsync(id);
            if (recursoBasico == null)
            {
                return NotFound();
            }

            return recursoBasico;
        }

        // POST api/RecursoBasico
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<RecursoBasico>> PostRecursoBasico(RecursoBasico recursoBasico)
        {
            _context.Add(recursoBasico);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecursoBasicoById), new { id = recursoBasico.Id }, recursoBasico);
        }

        // PUT api/RecursoBasico/5
        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PutRecursoBasico(int id, RecursoBasico recursoBasico)
        {
            if(id != recursoBasico.Id)
            {
                return BadRequest();
            }
            _context.Entry(recursoBasico).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [EnableCors("AllowOrigin")]
        public void Delete(int id)
        {
        }
    }

}
