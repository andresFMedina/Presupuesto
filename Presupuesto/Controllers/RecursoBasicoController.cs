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
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetRecursoBasico(string filter, int page = 1)
        {
            var response = new PagedResponse<RecursoBasico>();

            try
            {
                List<RecursoBasico> _RecursoBasico = await _context.RecursoBasico.ToListAsync();
                if (!string.IsNullOrEmpty(filter))
                {
                    foreach (var item in filter.Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries))

                        _RecursoBasico = _RecursoBasico
                            .Where(x => x.Codigo.StartsWith(item) ||
                                        x.Descripcion.ToLowerInvariant().Contains(item.ToLowerInvariant())).ToList();
                }

                response.CurrentFilter = filter;
                response.CurrentPage = page;
                response.RegisterPerPages = Constants.NPages;
                response.TotalRegister = _RecursoBasico.Count();
                response.TotalPages = (int)Math.Ceiling((double) response.TotalRegister / Constants.NPages);

                _RecursoBasico = _RecursoBasico.Skip((page - 1) * Constants.NPages)
                                            .Take(Constants.NPages)
                                            .OrderBy(x => x.Codigo)
                                            .OrderBy(x => x.Descripcion)
                                            .ToList();
                response.Model = _RecursoBasico;
                response.Message = string.Format("Page {0} of {1}, Total of products: {2}.", response.CurrentPage, response.TotalPages, response.TotalRegister);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";
            }

            return response.ToHttpResponse();
        }

        // GET api/RecursoBasico/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetRecursoBasicoById(int id)
        {
            SingleResponse<RecursoBasico> response = new SingleResponse<RecursoBasico>();
            try
            {
                response.Model = await _context.RecursoBasico.FindAsync(id);
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = string.Format("There was an internal error, please contact to technical support. {0}", ex.Message);
            }
            return response.ToHttpResponse();
        }

        // POST api/RecursoBasico
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PostRecursoBasico(RecursoBasico recursoBasico)
        {
            SingleResponse<RecursoBasico> response = new SingleResponse<RecursoBasico>();
            try
            {
                _context.Add(recursoBasico);
                await _context.SaveChangesAsync();
                response.Model = CreatedAtAction(nameof(GetRecursoBasicoById), new { id = recursoBasico.Id }, recursoBasico).Value as RecursoBasico;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = string.Format("There was an internal error, please contact to technical support. {0}", ex.Message);
            }
            return response.ToHttpResponse();           

            
        }

        // PUT api/RecursoBasico/5
        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PutRecursoBasico(int id, [FromBody] RecursoBasico value)
        {
            Response response = new Response();
            try
            {
                RecursoBasico updatedRecursoBasico = value;
                var selectedElement = _context.RecursoBasico.Find(id);
                selectedElement.Codigo = value.Codigo;
                selectedElement.Descripcion = value.Descripcion;
                selectedElement.Unidad = value.Unidad;
                selectedElement.Precio = value.Precio;                
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
        public void Delete(int id)
        {
        }
    }

}
