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
        public async Task<IActionResult> GetCapitulo(int proyectoId)
        {
            var response = new ListResponse<Capitulo>();
            try
            {
                List<Capitulo> Capitulos = await _context.Capitulo
                    .Where(x => x.ProyectoId.Equals(proyectoId))
                    .OrderBy(x => x.Numero).ToListAsync();
                response.Message = "Lista Capitulos";
                response.Model = Capitulos;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }
            return response.ToHttpResponse();
            
        }

        // GET api/Capitulo/5
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetCapituloById(int id)
        {
            var response = new SingleResponse<Capitulo>();
            try
            {
                var Capitulo = await _context.Capitulo.FindAsync(id);

                if (Capitulo == null)
                {
                    return NotFound();
                }
                response.Model = Capitulo;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }
            return response.ToHttpResponse();
        }

        // POST api/Capitulo
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PostCapitulo(Capitulo Capitulo)
        {
            var response = new SingleResponse<Capitulo>();
            try
            {
                _context.Add(Capitulo);
                await _context.SaveChangesAsync();

                response.Message = "Created";
                response.Model = CreatedAtAction(nameof(GetCapituloById), new { id = Capitulo.Id }, Capitulo).Value as Capitulo;
                
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }
            return response.ToHttpResponse();
        }

        // PUT api/Capitulo/5
        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PutCapitulo(int id, Capitulo Capitulo)
        {
            var response = new Response();
            try
            {
                if (id != Capitulo.Id)
                {
                    return BadRequest();
                }
                _context.Entry(Capitulo).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                response.Message = "Updated";
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