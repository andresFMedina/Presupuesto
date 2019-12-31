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
    public class ItemController : ControllerBase
    {
        private readonly PresupuestoContext _context;

        public ItemController(PresupuestoContext context)
        {
            _context = context;
        }

        // GET: api/Item
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetItem(int proyectoId, string filter, int page = 1)
        {
            var response = new PagedResponse<Item>();

            try
            {
                List<Item> _Item;

                _Item = await _context.Item
                    .Where(x => x.ProyectoId.Equals(proyectoId)).ToListAsync();

                //Filtering

                if (!string.IsNullOrEmpty(filter))
                {
                    foreach (var item in filter.Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries))

                        _Item = _Item
                            .Where(x => x.Codigo.StartsWith(item) ||
                                        x.Descripcion.ToLowerInvariant().Contains(item.ToLowerInvariant())).ToList();
                }

                //Pagination
                int _TotalRegister = 0;
                int _TotalPages = 0;

                _TotalRegister = _Item.Count();

                _Item = _Item.Skip((page - 1) * Constants.NPages)
                                                .Take(Constants.NPages)
                                                .OrderBy(x => x.Codigo)
                                                .OrderBy(x => x.Descripcion)
                                                .ToList();

                _TotalPages = (int)Math.Ceiling((double)_TotalRegister / Constants.NPages);

                response.RegisterPerPages = Constants.NPages;
                response.TotalPages = _TotalPages;
                response.TotalRegister = _TotalRegister;
                response.CurrentFilter = filter;
                response.CurrentPage = page;
                response.Model = _Item;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }
            return response.ToHttpResponse();
        }


        //GET api/Item/Capitulo
        [HttpGet("Capitulo")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetItemByCapitulo(int capituloId)
        {
            var response = new ListResponse<Item>();

            try
            {
                var List = await _context.Item.ToListAsync();
                List = await _context.Item.Where(i => i.CapituloId.Equals(capituloId)).ToListAsync();
                response.Model = List;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }
            return response.ToHttpResponse();
        }

        // GET api/Item/5
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var response = new SingleResponse<Item>();

            try
            {
                var item = await _context.Item.FindAsync(id);

                if (item == null)
                {
                    return NotFound();
                }
                response.Model = item;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }
            return response.ToHttpResponse();


        }

        [HttpGet("CostoDirecto")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetCostoDirecto(int proyectoId)
        {
            var response = new SingleResponse<float>();

            try
            {
                var Costos = await _context.Item.Where(i => i.ProyectoId == proyectoId).ToListAsync();
                var CostoDirecto = Costos.Sum(i => i.ValorUnitario * i.Cantidad);
                response.Model = CostoDirecto;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }
            return response.ToHttpResponse();
        }

        // POST api/Item
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PostItem(Item item)
        {
            var response = new SingleResponse<Item>();

            try
            {
                _context.Add(item);
                await _context.SaveChangesAsync();

                response.Model = CreatedAtAction(nameof(GetItemById), new { id = item.Id }, item).Value as Item;
                response.Message = "Created";
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }
            return response.ToHttpResponse();
        }

        // PUT api/Item/5
        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> PutItem(int id, [FromBody] Item value)
        {
            Response response = new Response();
            try
            {
                Item updatedItem = value;
                var selectedElement = _context.Item.Find(id);
                selectedElement.Codigo = value.Codigo;
                selectedElement.Descripcion = value.Descripcion;
                selectedElement.Unidad = value.Unidad;
                selectedElement.ValorUnitario = value.ValorUnitario;
                selectedElement.Cantidad = value.Cantidad;
                selectedElement.NumeroCapitulo = value.NumeroCapitulo;
                selectedElement.CapituloId = value.CapituloId;
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
                return BadRequest("Not a valid item id");
            var item = _context.Item
                    .Where(i => i.Id == id)
                    .FirstOrDefault();

            _context.Entry(item).State = EntityState.Deleted;
            await _context.SaveChangesAsync();


            return Ok();
        }
    }
}
