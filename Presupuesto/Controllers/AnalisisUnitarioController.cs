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
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetAnalisisUnitario(int proyectoId, string filter, int page = 1)
        {
            var response = new PagedResponse<AnalisisUnitario>();

            try
            {
                List<AnalisisUnitario> _AnalisisUnitario;

                _AnalisisUnitario = await _context.AnalisisUnitario.ToListAsync();
                    //.Where(x => x.ProyectoId.Equals(proyectoId)).ToListAsync();

                if (!string.IsNullOrEmpty(filter))
                {
                    foreach (string item in filter.Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries))
                    {
                        _AnalisisUnitario = _AnalisisUnitario
                            .Where(x => x.Codigo.StartsWith(item) ||
                                        x.Descripcion.ToLower().Contains(item.ToLower())).ToList();
                    }
                }

                _AnalisisUnitario = _AnalisisUnitario.Skip((page - 1) * Constants.NPages)
                                                .Take(Constants.NPages)
                                                .OrderBy(x => x.Codigo)
                                                .OrderBy(x => x.Descripcion)
                                                .ToList();

                response.CurrentFilter = filter;
                response.CurrentPage = page;
                response.RegisterPerPages = Constants.NPages;
                response.TotalRegister = _AnalisisUnitario.Count();
                response.TotalPages = (int)Math.Ceiling((double)response.TotalRegister / Constants.NPages);
                response.Model = _AnalisisUnitario;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }

            return response.ToHttpResponse();            
        }

        // GET api/AnalisisUnitario/5        
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetAnalisisUnitarioById(int id)
        {
            SingleResponse<AnalisisUnitario> response = new SingleResponse<AnalisisUnitario>();

            try
            {
                var analisisUnitario = await _context.AnalisisUnitario.FindAsync(id);

                if (analisisUnitario == null)
                {
                    return NotFound();
                }
                response.Model = analisisUnitario;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }

            return response.ToHttpResponse();
        }

        // POST api/AnalisisUnitario        
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PostAnalisisUnitario(AnalisisUnitario analisisUnitario)
        {
            SingleResponse<AnalisisUnitario> response = new SingleResponse<AnalisisUnitario>();

            try
            {
                _context.Add(analisisUnitario);
                await _context.SaveChangesAsync();
                response.Model = CreatedAtAction(nameof(GetAnalisisUnitarioById), new { id = analisisUnitario.Id }, analisisUnitario).Value as AnalisisUnitario;                
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }

            return response.ToHttpResponse();
        }

        // PUT api/AnalisisUnitario/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PutAnalisisUnitario(int id, [FromBody] AnalisisUnitario value)
        {
            Response response = new Response();
            try {
                AnalisisUnitario updatedAnalisisUnitario = value;
                var selectedElement = _context.AnalisisUnitario.Find(id);
                selectedElement.Codigo = value.Codigo;
                selectedElement.Descripcion = value.Descripcion;
                selectedElement.Unidad = value.Unidad;
                selectedElement.ValorUnitario = value.ValorUnitario;
                selectedElement.Grupo = value.Grupo;
                selectedElement.CostoEquipo = value.CostoEquipo;
                selectedElement.CostoManoObra = value.CostoManoObra;
                selectedElement.CostoMateriales = value.CostoMateriales;
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
